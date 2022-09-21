using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic.Queries.Implement
{
    public class VideoQueries : IVideoQueries
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public VideoQueries(AppDatabase database,
            IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }

        public List<VideoSummaryModel> GetAll()
        {
            return database.Videos
              .Select(x => mapper.Map<VideoSummaryModel>(x))
              .ToList();
        }

        public Task<List<VideoSummaryModel>> GetAllAsync()
        {
            return database.Videos
              .Select(x => mapper.Map<VideoSummaryModel>(x))
              .ToListAsync();
        }

        public VideoDetailModel? GetDetail(int id)
        {
            var video = database.Tags.FirstOrDefault(x => x.Id == id);

            if (video != null)
            {
                var result = mapper.Map<VideoDetailModel>(video);

                var videoPlayListIds = database.PlayListVideos.Where(x => x.VideoId == id)
                    .Select(x => x.PlayListId);
                var videoTagIds = database.VideoTags.Where(x => x.VideoId == id)
                    .Select(x => x.VideoId);

                var playLists = database.PlayLists.Where(x => videoPlayListIds.Contains(x.Id));
                var tags = database.Tags.Where(x => videoTagIds.Contains(x.Id));

                result.PlayLists = playLists.ToList();
                result.Tags = tags.ToList();

                return result;
            }

            return null;
        }

        public Task<VideoDetailModel?> GetDetailAsync(int id)
        {
            VideoDetailModel? result = null;
            var video = database.Tags.FirstOrDefault(x => x.Id == id);

            if (video != null)
            {
                result = mapper.Map<VideoDetailModel>(video);

                var videoPlayListIds = database.PlayListVideos.Where(x => x.VideoId == id)
                    .Select(x => x.PlayListId);
                var videoTagIds = database.VideoTags.Where(x => x.VideoId == id)
                    .Select(x => x.VideoId);

                var playLists = database.PlayLists.Where(x => videoPlayListIds.Contains(x.Id));
                var tags = database.Tags.Where(x => videoTagIds.Contains(x.Id));

                result.PlayLists = playLists.ToList();
                result.Tags = tags.ToList();
            }

            return Task.FromResult(result);
        }

        public BasePagingData<VideoSummaryModel> GetPaging(BaseQuery query)
        {
            var videos = database.Videos
                .Where(x => x.Title!.Contains(query.Keywords ?? string.Empty) ||
                            x.Description!.Contains(query.Keywords ?? string.Empty) ||
                            x.IsDeleted != true)
                .Skip(((query.PageIndex - 1) * query.PageSize) ?? 0).Take((query.PageSize * query.PageIndex) ?? 20)
                .Select(x => mapper.Map<VideoSummaryModel>(x))
                .ToList();

            var videoCount = database.Authors.Count();

            return new BasePagingData<VideoSummaryModel>()
            {
                Items = videos,
                PageSize = query.PageSize ?? 1,
                PageIndex = query.PageIndex ?? 20,
                TotalItem = videoCount,
                TotalPage = (int)Math.Ceiling((double)videoCount / (query.PageSize ?? 20))
            };
        }

        public Task<BasePagingData<VideoSummaryModel>> GetPagingAsync(BaseQuery query)
        {
            var videos = database.Videos
                .Where(x => x.Title!.Contains(query.Keywords ?? string.Empty) ||
                            x.Description!.Contains(query.Keywords ?? string.Empty) ||
                            x.IsDeleted != true)
                .Skip(((query.PageIndex - 1) * query.PageSize) ?? 0).Take((query.PageSize * query.PageIndex) ?? 20)
                .Select(x => mapper.Map<VideoSummaryModel>(x))
                .ToList();

            var videoCount = database.Authors.Count();

            return Task.FromResult(new BasePagingData<VideoSummaryModel>()
            {
                Items = videos,
                PageSize = query.PageSize ?? 1,
                PageIndex = query.PageIndex ?? 20,
                TotalItem = videoCount,
                TotalPage = (int)Math.Ceiling((double)videoCount / (query.PageSize ?? 20))
            });
        }
    }
}
