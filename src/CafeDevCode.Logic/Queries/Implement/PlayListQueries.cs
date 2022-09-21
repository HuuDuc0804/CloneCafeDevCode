using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic.Queries.Implement
{
    public class PlayListQueries : IPlayListQueries
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public PlayListQueries(AppDatabase database,
            IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }

        public List<PlayListSummaryModel> GetAll()
        {
            return database.PlayLists
                .Where(x => x.IsDeleted != true)
                .Select(x => mapper.Map<PlayListSummaryModel>(x))
                .ToList();
        }

        public Task<List<PlayListSummaryModel>> GetAllAsync()
        {
            return Task.Run(() => database.Categories
                .Where(x => x.IsDeleted != true)
                .Select(x => mapper.Map<PlayListSummaryModel>(x))
                .ToListAsync());
        }

        public PlayListDetailModel? GetDetail(int id)
        {
            var playList = database.PlayLists.FirstOrDefault(x => x.Id == id);

            if (playList != null)
            {
                var result = mapper.Map<PlayListDetailModel>(playList);

                var palyListVideoIds = database.PostCategories.Where(x => x.CategoryId == id)
                    .Select(x => x.PostId);

                var videos = database.Videos.Where(x => palyListVideoIds.Contains(x.Id));

                result.Videos = videos.ToList();
                return result;
            }

            return null;
        }

        public Task<PlayListDetailModel?> GetDetailAsync(int id)
        {
            PlayListDetailModel? result = null;
            var playList = database.PlayLists.FirstOrDefault(x => x.Id == id);

            if (playList != null)
            {
                result = mapper.Map<PlayListDetailModel>(playList);

                var palyListVideoIds = database.PostCategories.Where(x => x.CategoryId == id)
                    .Select(x => x.PostId);

                var videos = database.Videos.Where(x => palyListVideoIds.Contains(x.Id));

                result.Videos = videos.ToList();
            }

            return Task.FromResult(result);
        }

        public BasePagingData<PlayListSummaryModel> GetPaging(BaseQuery query)
        {
            var playLists = database.PlayLists
                .Where(x => x.Title!.Contains(query.Keywords ?? string.Empty) ||
                            x.Keywords!.Contains(query.Keywords ?? string.Empty) ||
                            x.Description!.Contains(query.Keywords ?? string.Empty) ||
                            x.IsDeleted != true)
                .Skip(((query.PageIndex - 1) * query.PageSize) ?? 0).Take((query.PageSize * query.PageIndex) ?? 20)
                .Select(x => mapper.Map<PlayListSummaryModel>(x))
                .ToList();

            var playListCount = database.Authors.Count();

            return new BasePagingData<PlayListSummaryModel>()
            {
                Items = playLists,
                PageSize = query.PageSize ?? 1,
                PageIndex = query.PageIndex ?? 20,
                TotalItem = playListCount,
                TotalPage = (int)Math.Ceiling((double)playListCount / (query.PageSize ?? 20))
            };
        }

        public Task<BasePagingData<PlayListSummaryModel>> GetPagingAsync(BaseQuery query)
        {
            var playLists = database.PlayLists
                .Where(x => x.Title!.Contains(query.Keywords ?? string.Empty) ||
                            x.Keywords!.Contains(query.Keywords ?? string.Empty) ||
                            x.Description!.Contains(query.Keywords ?? string.Empty) ||
                            x.IsDeleted != true)
                .Skip(((query.PageIndex - 1) * query.PageSize) ?? 0).Take((query.PageSize * query.PageIndex) ?? 20)
                .Select(x => mapper.Map<PlayListSummaryModel>(x))
                .ToList();

            var playListCount = database.Authors.Count();

            return Task.FromResult(new BasePagingData<PlayListSummaryModel>()
            {
                Items = playLists,
                PageSize = query.PageSize ?? 1,
                PageIndex = query.PageIndex ?? 20,
                TotalItem = playListCount,
                TotalPage = (int)Math.Ceiling((double)playListCount / (query.PageSize ?? 20))
            });
        }
    }
}
