using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic.Commands.Handler
{
    public class DeletePostHandler : IRequestHandler<DeletePost, BaseCommandResult>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public DeletePostHandler(AppDatabase database,
            IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }

        public Task<BaseCommandResult> Handle(DeletePost request,
            CancellationToken cancellationToken)
        {
            var result = new BaseCommandResult();
            try
            {
                var post = database.Posts.FirstOrDefault(x => x.Id == request.Id);
                if (post != null)
                {
                    post.MaskDelete(request.UserName ?? string.Empty, AppGlobal.SysDateTime);
                    database.Posts.Update(post);

                    var postTags = database.PostTags.Where(x => x.PostId == post.Id).ToList();
                    postTags.ForEach(x =>
                    {
                        x.MaskDelete(request.UserName ?? string.Empty, AppGlobal.SysDateTime);
                    });
                    database.PostTags.UpdateRange(postTags);

                    var postCategories = database.PostCategories.Where(x => x.PostId == post.Id).ToList();
                    postCategories.ForEach(x =>
                    {
                        x.MaskDelete(request.UserName ?? string.Empty, AppGlobal.SysDateTime);
                    });
                    database.PostCategories.UpdateRange(postCategories);

                    var postRelates = database.PostRelateds.Where(x => x.PostId == post.Id).ToList();
                    postRelates.ForEach(x =>
                    {
                        x.MaskDelete(request.UserName ?? string.Empty, AppGlobal.SysDateTime);
                    });
                    database.PostRelateds.UpdateRange(postRelates);

                    database.SaveChanges();
                    result.Success = true;
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
