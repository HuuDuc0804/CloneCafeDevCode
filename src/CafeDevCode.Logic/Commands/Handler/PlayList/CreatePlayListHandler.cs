using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic.Commands.Handler
{
    public class CreatePlayListHandler : IRequestHandler<CreatePlayList, BaseCommandResultWithData<PlayList>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public CreatePlayListHandler(AppDatabase database,
            IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResultWithData<PlayList>> Handle(CreatePlayList request,
            CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<PlayList>();
            try
            {
                var playList = mapper.Map<PlayList>(request);
                playList.SetCreateInfo(request.UserName ?? string.Empty, AppGlobal.SysDateTime);
                database.PlayLists.Add(playList);
                database.SaveChanges();
                result.Success = true;
                result.Data = playList;
            }
            catch (Exception ex)
            {
                result.Messages = ex.Message;
            }
            return Task.FromResult(result);
        }
    }
}
