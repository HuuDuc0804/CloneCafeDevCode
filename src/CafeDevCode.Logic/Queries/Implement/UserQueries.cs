using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic.Queries.Implement
{
    public class UserQueries : IUserQueries
    {
        private readonly AppDatabase database;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public UserQueries(AppDatabase database,
            UserManager<User> userManager,
            IMapper mapper)
        {
            this.database = database;
            this.userManager = userManager;
            this.mapper = mapper;
        }
        public List<UserSummaryModel> GetAll()
        {
            var users = userManager.Users
                .Select(x => mapper.Map<UserSummaryModel>(x)).ToList();
            return users;
        }

        public Task<List<UserSummaryModel>> GetAllAsync()
        {
            return Task.Run(() => userManager.Users
                .Select(x => mapper.Map<UserSummaryModel>(x))
                .ToListAsync());
        }

        public UserDetailModel? GetDetail(string userName)
        {
            var user = userManager.FindByNameAsync(userName).Result;
            return mapper.Map<UserDetailModel>(user);
        }

        public Task<UserDetailModel?> GetDetailAsync(string userName)
        {
            var user = userManager.FindByNameAsync(userName);
            UserDetailModel? result = null;
            if (user.Result != null)
            {
                result = mapper.Map<UserDetailModel>(user.Result);
            }
            return Task.FromResult(result);
        }

        public BasePagingData<UserSummaryModel> GetPaging(BaseQuery query)
        {
            var users = userManager.Users
                .Where(x => x.UserName!.Contains(query.Keywords ?? string.Empty) ||
                            x.PhoneNumber!.Contains(query.Keywords ?? string.Empty) ||
                            x.Email!.Contains(query.Keywords ?? string.Empty))
                .Skip(((query.PageIndex - 1) * query.PageSize) ?? 0).Take((query.PageSize * query.PageIndex) ?? 20)
                .Select(x => mapper.Map<UserSummaryModel>(x))
                .ToList();

            var userCount = userManager.Users.Count();

            return new BasePagingData<UserSummaryModel>()
            {
                Items = users,
                PageSize = query.PageSize ?? 1,
                PageIndex = query.PageIndex ?? 20,
                TotalItem = userCount,
                TotalPage = (int)Math.Ceiling((double)userCount / (query.PageSize ?? 20))
            };
        }

        public Task<BasePagingData<UserSummaryModel>> GetPagingAsync(BaseQuery query)
        {
            var users = userManager.Users
                .Where(x => x.UserName!.Contains(query.Keywords ?? string.Empty) ||
                            x.PhoneNumber!.Contains(query.Keywords ?? string.Empty) ||
                            x.Email!.Contains(query.Keywords ?? string.Empty))
                .Skip(((query.PageIndex - 1) * query.PageSize) ?? 0).Take((query.PageSize * query.PageIndex) ?? 20)
                .Select(x => mapper.Map<UserSummaryModel>(x))
                .ToList();

            var userCount = userManager.Users.Count();

            return Task.FromResult(new BasePagingData<UserSummaryModel>()
            {
                Items = users,
                PageSize = query.PageSize ?? 1,
                PageIndex = query.PageIndex ?? 20,
                TotalItem = userCount,
                TotalPage = (int)Math.Ceiling((double)userCount / (query.PageSize ?? 20))
            });
        }

        public bool IsExistUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                return false;

            var user = userManager.FindByNameAsync(userName).Result;
            return user != null ? true : false;
        }
    }
}
