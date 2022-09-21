using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic.Commands.Handler
{
    public class DeletePlayListHandler : IRequestHandler<DeletePlayList, BaseCommandResult>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public DeletePlayListHandler(AppDatabase database,
            IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResult> Handle(DeletePlayList request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResult();
            try
            {
                var playList = database.PlayLists.FirstOrDefault(x => x.Id == request.Id);
                if (playList != null)
                {
                    playList.MaskDelete(request.UserName ?? string.Empty, AppGlobal.SysDateTime);
                    database.PlayLists.Update(playList);
                    database.SaveChanges();
                    result.Success = true;
                }
                else
                {
                    result.Messages = $"Can't find play list with ID is {request.Id}";
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
