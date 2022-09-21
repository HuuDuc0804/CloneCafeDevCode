using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic.Commands.Handler
{
    public class CreateVideoHandler : IRequestHandler<CreateVideo, BaseCommandResultWithData<Video>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public CreateVideoHandler(AppDatabase database,
            IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResultWithData<Video>> Handle(CreateVideo request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<Video>();
            try
            {
                var video = mapper.Map<Video>(request);
                video.SetCreateInfo(request.UserName ?? string.Empty, AppGlobal.SysDateTime);
                database.Videos.Add(video);
                database.SaveChanges();
                result.Success = true;
                result.Data = video;
            }
            catch (Exception ex)
            {
                result.Messages = ex.Message;
            }
            return Task.FromResult(result);
        }
    }
}
