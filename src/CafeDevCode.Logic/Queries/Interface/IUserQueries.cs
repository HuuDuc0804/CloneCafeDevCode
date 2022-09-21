using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic.Queries.Interface
{
    public interface IUserQueries
    {
        BasePagingData<UserSummaryModel> GetPaging(BaseQuery query);
        List<UserSummaryModel> GetAll();
        UserDetailModel? GetDetail(string userName);
        Task<UserDetailModel?> GetDetailAsync(string userName);
        Task<BasePagingData<UserSummaryModel>> GetPagingAsync(BaseQuery query);
        Task<List<UserSummaryModel>> GetAllAsync();
        bool IsExistUserName(string userName);
    }
}
