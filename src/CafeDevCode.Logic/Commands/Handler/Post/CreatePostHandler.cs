using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic.Commands.Handler
{
    public class CreatePostHandler : IRequestHandler<CreatePost, BaseCommandResultWithData<Post>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public CreatePostHandler(AppDatabase database,
            IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResultWithData<Post>> Handle(CreatePost request,
            CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<Post>();

            try
            {
                var post = mapper.Map<Post>(request);
                post.SetCreateInfo(request.UserName ?? string.Empty, AppGlobal.SysDateTime);
                database.Posts.Add(post);
                database.SaveChanges();
                result.Success = true;
                result.Data = post;
            }
            catch (Exception ex)
            {
                result.Messages = ex.Message;
            }
            return Task.FromResult(result);
        }
    }
}
