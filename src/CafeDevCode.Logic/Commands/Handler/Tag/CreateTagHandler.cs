using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic.Commands.Handler
{
    public class CreateTagHandler : IRequestHandler<CreateTag, BaseCommandResultWithData<Tag>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public CreateTagHandler(AppDatabase database,
            IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResultWithData<Tag>> Handle(CreateTag request,
            CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<Tag>();
            try
            {
                var tag = mapper.Map<Tag>(request);
                tag.SetCreateInfo(request.UserName ?? string.Empty, AppGlobal.SysDateTime);
                database.Tags.Add(tag);
                database.SaveChanges();
                result.Success = true;
                result.Data = tag;
            }
            catch (Exception ex)
            {
                result.Messages = ex.Message;
            }
            return Task.FromResult(result);
        }
    }
}
