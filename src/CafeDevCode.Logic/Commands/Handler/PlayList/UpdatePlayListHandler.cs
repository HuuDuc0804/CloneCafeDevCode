using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic.Commands.Handler
{
    public class UpdatePlayListHandler : IRequestHandler<UpdatePlayList, BaseCommandResultWithData<PlayList>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public UpdatePlayListHandler(AppDatabase database,
            IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResultWithData<PlayList>> Handle(UpdatePlayList request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<PlayList>();
            try
            {
                var playList = database.PlayLists.FirstOrDefault(x => x.Id == request.Id);
                if (playList != null)
                {
                    mapper.Map(request, playList);
                    playList.SetUpdateInfo(request.UserName ?? string.Empty, AppGlobal.SysDateTime);
                    database.PlayLists.Update(playList);
                    database.SaveChanges();
                    result.Success = true;
                    result.Data = playList;
                }
                else
                {
                    result.Messages = $"Can't find playlist with id is {request.Id}";
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
