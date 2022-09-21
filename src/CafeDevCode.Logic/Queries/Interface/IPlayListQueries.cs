using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic.Queries.Interface
{
    public interface IPlayListQueries
    {
        BasePagingData<PlayListSummaryModel> GetPaging(BaseQuery query);
        List<PlayListSummaryModel> GetAll();
        PlayListDetailModel? GetDetail(int id);
        Task<PlayListDetailModel?> GetDetailAsync(int id);
        Task<BasePagingData<PlayListSummaryModel>> GetPagingAsync(BaseQuery query);
        Task<List<PlayListSummaryModel>> GetAllAsync();
    }
}
