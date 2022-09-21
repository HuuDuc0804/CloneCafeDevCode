using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic.Queries.Implement
{
    public class RoleQueries : IRoleQueries
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public RoleQueries(AppDatabase database,
            IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }

        public List<RoleSummaryModel> GetAll()
        {
            return database.Roles
                .Select(x => mapper.Map<RoleSummaryModel>(x))
                .ToList();
        }

        public Task<List<RoleSummaryModel>> GetAllAsync()
        {
            return Task.Run(() => database.Roles
                .Select(x => mapper.Map<RoleSummaryModel>(x))
                .ToListAsync());
        }

        public RoleDetailModel? GetDetail(string id)
        {
            var role = database.Roles.FirstOrDefault(x => x.Id == id);
            if (role != null)
            {
                return mapper.Map<RoleDetailModel>(role);
            }
            return null;
        }

        public Task<RoleDetailModel?> GetDetailAsync(string id)
        {
            RoleDetailModel? result = null;

            var role = database.Roles.FirstOrDefault(x => x.Id == id);
            if (role != null)
            {
                result = mapper.Map<RoleDetailModel>(role);
            }

            return Task.FromResult(result);
        }

        public BasePagingData<RoleSummaryModel> GetPaging(BaseQuery query)
        {
            var posts = database.Roles
                .Where(x => x.Name!.Contains(query.Keywords ?? string.Empty))
                .Skip(((query.PageIndex - 1) * query.PageSize) ?? 0).Take((query.PageSize * query.PageIndex) ?? 20)
                .Select(x => mapper.Map<RoleSummaryModel>(x))
                .ToList();

            var postCount = database.Authors.Count();

            return new BasePagingData<RoleSummaryModel>()
            {
                Items = posts,
                PageSize = query.PageSize ?? 1,
                PageIndex = query.PageIndex ?? 20,
                TotalItem = postCount,
                TotalPage = (int)Math.Ceiling((double)postCount / (query.PageSize ?? 20))
            };
        }

        public Task<BasePagingData<RoleSummaryModel>> GetPagingAsync(BaseQuery query)
        {
            var posts = database.Roles
                .Where(x => x.Name!.Contains(query.Keywords ?? string.Empty))
                .Skip(((query.PageIndex - 1) * query.PageSize) ?? 0).Take((query.PageSize * query.PageIndex) ?? 20)
                .Select(x => mapper.Map<RoleSummaryModel>(x))
                .ToList();

            var postCount = database.Authors.Count();

            return Task.FromResult(new BasePagingData<RoleSummaryModel>()
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
