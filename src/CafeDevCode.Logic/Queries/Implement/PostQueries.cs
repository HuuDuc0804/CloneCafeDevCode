using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic.Queries.Implement
{
    public class PostQueries : IPostQueries
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public PostQueries(AppDatabase database,
            IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public List<PostSummaryModel> GetAll()
        {
            return database.Posts
                .Where(x => x.IsDeleted != true)
                .Select(x => mapper.Map<PostSummaryModel>(x))
                .ToList();
        }

        public Task<List<PostSummaryModel>> GetAllAsync()
        {
            return database.Posts
                .Where(x => x.IsDeleted != true)
                .Select(x => mapper.Map<PostSummaryModel>(x))
                .ToListAsync();
        }

        public PostDetailModel? GetDetail(int id)
        {
            PostDetailModel? result = null;
            var post = database.Posts.FirstOrDefault(x => x.Id == id);

            if (post != null)
            {
                result = mapper.Map<PostDetailModel>(post);

                var author = database.Authors.FirstOrDefault(x => x.Id == post.AuthorId);
                result.Author = author;

                var postTagIds = database.PostTags.Where(x => x.PostId == id)
                    .Select(x => x.TagId);
                var tags = database.Tags.Where(x => postTagIds.Contains(x.Id));
                result.Tags = tags.ToList();

                var postCategoryIds = database.PostCategories.Where(x => x.PostId == id)
                    .Select(x => x.CategoryId);
                var categories = database.Categories.Where(x => postCategoryIds.Contains(x.Id));
                result.Categories = categories.ToList();

                var postRelatedIds = database.PostRelateds.Where(x => x.PostId == id)
                    .Select(x => x.RelatedId);
                var relateds = database.Posts.Where(x => postRelatedIds.Contains(x.Id));
                result.Relates = relateds.ToList();
            }

            return result;
        }

        public Task<PostDetailModel?> GetDetailAsync(int id)
        {
            PostDetailModel? result = null;
            var post = database.Posts.FirstOrDefault(x => x.Id == id);

            if (post != null)
            {
                result = mapper.Map<PostDetailModel>(post);

                var author = database.Authors.FirstOrDefault(x => x.Id == post.AuthorId);
                result.Author = author;

                var postTagIds = database.PostTags.Where(x => x.PostId == id)
                    .Select(x => x.TagId);
                var tags = database.Tags.Where(x => postTagIds.Contains(x.Id));
                result.Tags = tags.ToList();

                var postCategoryIds = database.PostCategories.Where(x => x.PostId == id)
                    .Select(x => x.CategoryId);
                var categories = database.Categories.Where(x => postCategoryIds.Contains(x.Id));
                result.Categories = categories.ToList();

                var postRelatedIds = database.PostRelateds.Where(x => x.PostId == id)
                    .Select(x => x.RelatedId);
                var relateds = database.Posts.Where(x => postRelatedIds.Contains(x.Id));
                result.Relates = relateds.ToList();
            }

            return Task.FromResult(result);
        }

        public BasePagingData<PostSummaryModel> GetPaging(BaseQuery query)
        {
            var posts = database.Posts
                .Where(x => (x.Title!.Contains(query.Keywords ?? string.Empty) ||
                            x.Description!.Contains(query.Keywords ?? string.Empty)) &&
                            x.IsDeleted != true)
                .Skip(((query.PageIndex - 1) * query.PageSize) ?? 0).Take((query.PageSize * query.PageIndex) ?? 20)
                .Select(x => mapper.Map<PostSummaryModel>(x))
                .ToList();

            var postCount = database.Authors.Count();

            return new BasePagingData<PostSummaryModel>()
            {
                Items = posts,
                PageSize = query.PageSize ?? 1,
                PageIndex = query.PageIndex ?? 20,
                TotalItem = postCount,
                TotalPage = (int)Math.Ceiling((double)postCount / (query.PageSize ?? 20))
            };
        }

        public Task<BasePagingData<PostSummaryModel>> GetPagingAsync(BaseQuery query)
        {
            var posts = database.Posts
                .Where(x => (x.Title!.Contains(query.Keywords ?? string.Empty) ||
                            x.Description!.Contains(query.Keywords ?? string.Empty)) &&
                            x.IsDeleted != true)
                .Skip(((query.PageIndex - 1) * query.PageSize) ?? 0).Take((query.PageSize * query.PageIndex) ?? 20)
                .Select(x => mapper.Map<PostSummaryModel>(x))
                .ToList();

            var postCount = database.Authors.Count();

            return Task.FromResult(new BasePagingData<PostSummaryModel>()
            {
                Items = posts,
                PageSize = query.PageSize ?? 1,
                PageIndex = query.PageIndex ?? 20,
                TotalItem = postCount,
                TotalPage = (int)Math.Ceiling((double)postCount / (query.PageSize ?? 20))
            });
        }
    }
}
