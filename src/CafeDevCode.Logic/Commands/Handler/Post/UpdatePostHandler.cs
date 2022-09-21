using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic.Commands.Handler
{
    public class UpdatePostHandler : IRequestHandler<UpdatePost, BaseCommandResultWithData<Post>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public UpdatePostHandler(AppDatabase database,
            IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResultWithData<Post>> Handle(UpdatePost request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<Post>();
            try
            {
                var post = database.Posts.FirstOrDefault(x => x.Id == request.Id);
                if (post != null)
                {
                    mapper.Map(request, post);
                    post.SetUpdateInfo(request.UserName ?? string.Empty, AppGlobal.SysDateTime);
                    database.Posts.Update(post);
                    database.SaveChanges();
                    result.Success = true;
                    result.Data = post;
                }
                else
                {
                    result.Messages = $"Can't find post with ID is {request.Id}";
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
