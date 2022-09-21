using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic.Queries.Interface
{
    public interface IRoleQueries
    {
        BasePagingData<RoleSummaryModel> GetPaging(BaseQuery query);
        List<RoleSummaryModel> GetAll();
        RoleDetailModel? GetDetail(string id);
        Task<RoleDetailModel?> GetDetailAsync(string id);
        Task<BasePagingData<RoleSummaryModel>> GetPagingAsync(BaseQuery query);
        Task<List<RoleSummaryModel>> GetAllAsync();
    }
}
