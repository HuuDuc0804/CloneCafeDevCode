using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic.Queries.Implement
{
    public class CategoryQueries : ICategoryQueries
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public CategoryQueries(AppDatabase database,
            IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }

        public List<CategorySummaryModel> GetAll()
        {
            return database.Categories
               .Select(x => mapper.Map<CategorySummaryModel>(x))
               .ToList();
        }

        public Task<List<CategorySummaryModel>> GetAllAsync()
        {
            return Task.Run(() => database.Categories
                .Select(x => mapper.Map<CategorySummaryModel>(x))
                .ToListAsync());
        }

        public CategoryDetailModel? GetDetail(int id)
        {
            var category = database.Categories.FirstOrDefault(x => x.Id == id);

            if (category != null)
            {
                var result = mapper.Map<CategoryDetailModel>(category);

                var categoryPostIds = database.PostCategories.Where(x => x.CategoryId == id)
                    .Select(x => x.PostId);

                var posts = database.Posts.Where(x => categoryPostIds.Contains(x.Id));

                result.Posts = posts.ToList();
                return result;
            }

            return null;
        }

        public Task<CategoryDetailModel?> GetDetailAsync(int id)
        {
            CategoryDetailModel? result = null;
            var category = database.Categories.FirstOrDefault(x => x.Id == id);

            if (category != null)
            {
                result = mapper.Map<CategoryDetailModel>(category);

                var categoryPostIds = database.PostCategories.Where(x => x.CategoryId == id)
                    .Select(x => x.PostId);

                var posts = database.Posts.Where(x => categoryPostIds.Contains(x.Id));

                result.Posts = posts.ToList();
            }

            return Task.FromResult(result);
        }

        public BasePagingData<CategorySummaryModel> GetPaging(BaseQuery query)
        {
            var categories = database.Categories
                .Where(x => x.Title!.Contains(query.Keywords ?? string.Empty) ||
                            x.Keywords!.Contains(query.Keywords ?? string.Empty) ||
                            x.Description!.Contains(query.Keywords ?? string.Empty) ||
                            x.IsDeleted != true)
                .Skip(((query.PageIndex - 1) * query.PageSize) ?? 0).Take((query.PageSize * query.PageIndex) ?? 20)
                .Select(x => mapper.Map<CategorySummaryModel>(x))
                .ToList();

            var categoryCount = database.Authors.Count();

            return new BasePagingData<CategorySummaryModel>()
            {
                Items = categories,
                PageSize = query.PageSize ?? 1,
                PageIndex = query.PageIndex ?? 20,
                TotalItem = categoryCount,
                TotalPage = (int)Math.Ceiling((double)categoryCount / (query.PageSize ?? 20))
            };
        }

        public Task<BasePagingData<CategorySummaryModel>> GetPagingAsync(BaseQuery query)
        {
            var categories = database.Categories
                .Where(x => x.Title!.Contains(query.Keywords ?? string.Empty) ||
                            x.Keywords!.Contains(query.Keywords ?? string.Empty) ||
                            x.Description!.Contains(query.Keywords ?? string.Empty) ||
                            x.IsDeleted != true)
                .Skip(((query.PageIndex - 1) * query.PageSize) ?? 0).Take((query.PageSize * query.PageIndex) ?? 20)
                .Select(x => mapper.Map<CategorySummaryModel>(x))
                .ToList();

            var categoryCount = database.Authors.Count();

            return Task.FromResult(new BasePagingData<CategorySummaryModel>()
            {
                Items = categories,
                PageSize = query.PageSize ?? 1,
                PageIndex = query.PageIndex ?? 20,
                TotalItem = categoryCount,
                TotalPage = (int)Math.Ceiling((double)categoryCount / (query.PageSize ?? 20))
            });
        }
    }
}
