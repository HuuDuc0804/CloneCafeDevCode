using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic.Queries.Implement
{
    public class TagQueries : ITagQueries
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public TagQueries(AppDatabase database,
            IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public List<TagSummaryModel> GetAll()
        {
            return database.Tags
              .Select(x => mapper.Map<TagSummaryModel>(x))
              .ToList();
        }

        public Task<List<TagSummaryModel>> GetAllAsync()
        {
            return database.Tags
              .Select(x => mapper.Map<TagSummaryModel>(x))
              .ToListAsync();
        }

        public List<TagSummaryModel> GetByPostId(int postId)
        {
            var postTags = database.PostTags.Where(x => x.PostId == postId);
            return database.Tags
             .Where(t => postTags.Select(x => x.TagId).Contains(t.Id))
             .Select(x => mapper.Map<TagSummaryModel>(x))
             .ToList();
        }

        public TagDetailModel? GetDetail(int id)
        {
            var tag = database.Tags.FirstOrDefault(x => x.Id == id);

            if (tag != null)
            {
                var result = mapper.Map<TagDetailModel>(tag);

                var tagPostIds = database.PostTags.Where(x => x.TagId == id)
                    .Select(x => x.PostId);
                var tagVideoIds = database.VideoTags.Where(x => x.TagId == id).ToList()
                    .Select(x => x.VideoId);

                var posts = database.Posts.Where(x => tagPostIds.Contains(x.Id));
                var videos = database.Videos.Where(x => tagVideoIds.Contains(x.Id));

                result.Posts = posts.ToList();
                result.Videos = videos.ToList();

                return result;
            }

            return null;
        }

        public Task<TagDetailModel?> GetDetailAsync(int id)
        {
            TagDetailModel? result = null;
            var tag = database.Tags.FirstOrDefault(x => x.Id == id);

            if (tag != null)
            {
                result = mapper.Map<TagDetailModel>(tag);

                var tagPostIds = database.PostTags.Where(x => x.TagId == id)
                    .Select(x => x.PostId);
                var tagVideoIds = database.VideoTags.Where(x => x.TagId == id)
                    .Select(x => x.VideoId);

                var posts = database.Posts.Where(x => tagPostIds.Contains(x.Id));
                var videos = database.Videos.Where(x => tagVideoIds.Contains(x.Id));

                result.Posts = posts.ToList();
                result.Videos = videos.ToList();
            }

            return Task.FromResult(result);
        }

        public BasePagingData<TagSummaryModel> GetPaging(BaseQuery query)
        {
            var tags = database.Tags
                .Where(x => x.Title!.Contains(query.Keywords ?? string.Empty) ||
                            x.Description!.Contains(query.Keywords ?? string.Empty) ||
                            x.IsDeleted != true)
                .Skip(((query.PageIndex - 1) * query.PageSize) ?? 0).Take((query.PageSize * query.PageIndex) ?? 20)
                .Select(x => mapper.Map<TagSummaryModel>(x))
                .ToList();

            var tagCount = database.Authors.Count();

            return new BasePagingData<TagSummaryModel>()
            {
                Items = tags,
                PageSize = query.PageSize ?? 1,
                PageIndex = query.PageIndex ?? 20,
                TotalItem = tagCount,
                TotalPage = (int)Math.Ceiling((double)tagCount / (query.PageSize ?? 20))
            };
        }

        public Task<BasePagingData<TagSummaryModel>> GetPagingAsync(BaseQuery query)
        {
            var tags = database.Tags
                .Where(x => x.Title!.Contains(query.Keywords ?? string.Empty) ||
                            x.Description!.Contains(query.Keywords ?? string.Empty) ||
                            x.IsDeleted != true)
                .Skip(((query.PageIndex - 1) * query.PageSize) ?? 0).Take((query.PageSize * query.PageIndex) ?? 20)
                .Select(x => mapper.Map<TagSummaryModel>(x))
                .ToList();

            var tagCount = database.Authors.Count();

            return Task.FromResult(new BasePagingData<TagSummaryModel>()
            {
                Items = tags,
                PageSize = query.PageSize ?? 1,
                PageIndex = query.PageIndex ?? 20,
                TotalItem = tagCount,
                TotalPage = (int)Math.Ceiling((double)tagCount / (query.PageSize ?? 20))
            });
        }
    }
}
