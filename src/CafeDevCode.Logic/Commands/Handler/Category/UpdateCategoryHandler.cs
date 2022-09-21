using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic.Commands.Handler
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategory, BaseCommandResultWithData<Category>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public UpdateCategoryHandler(AppDatabase database,
            IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResultWithData<Category>> Handle(UpdateCategory request,
            CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<Category>();
            try
            {
                var category = database.Categories.FirstOrDefault(x => x.Id == request.Id);
                if (category != null)
                {
                    mapper.Map(request, category);
                    category.SetUpdateInfo(request.UserName ?? string.Empty, AppGlobal.SysDateTime);
                    database.Categories.Update(category);
                    database.SaveChanges();
                    result.Success = true;
                    result.Data = category;
                }
                else
                {
                    result.Messages = $"Can't find category with id is {request.Id}";
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
