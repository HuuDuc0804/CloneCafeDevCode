using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic.Commands.Handler
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategory, BaseCommandResult>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public DeleteCategoryHandler(AppDatabase database,
            IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResult> Handle(DeleteCategory request,
            CancellationToken cancellationToken)
        {
            var result = new BaseCommandResult();
            try
            {
                var category = database.Categories.FirstOrDefault(x => x.Id == request.Id);
                if (category != null)
                {
                    category.MaskDelete(request.UserName ?? string.Empty, AppGlobal.SysDateTime);
                    database.Categories.Update(category);
                    database.SaveChanges();
                    result.Success = true;
                }
                else
                {
                    result.Messages = $"Can't find category with ID is {request.Id}";
                }
            }
            catch (Exception ex)
            {
                result.Messages = ex.Message;
            }
            return Task.FromResult(result);
        }
    }
}
