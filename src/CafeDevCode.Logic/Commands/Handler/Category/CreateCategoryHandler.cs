using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic.Commands.Handler
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategory, BaseCommandResultWithData<Category>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public CreateCategoryHandler(AppDatabase database,
            IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResultWithData<Category>> Handle(CreateCategory request,
            CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<Category>();
            try
            {
                var category = mapper.Map<Category>(request);
                category.SetCreateInfo(request.UserName ?? string.Empty, AppGlobal.SysDateTime);
                database.Categories.Add(category);
                database.SaveChanges();
                result.Success = true;
                result.Data = category;
            }
            catch (Exception ex)
            {
                result.Messages = ex.Message;
            }
            return Task.FromResult(result);
        }
    }
}
