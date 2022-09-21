using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic.Queries.Interface
{
    public interface IPostQueries
    {
        BasePagingData<PostSummaryModel> GetPaging(BaseQuery query);
        List<PostSummaryModel> GetAll();
        PostDetailModel? GetDetail(int id);
        Task<PostDetailModel?> GetDetailAsync(int id);
        Task<BasePagingData<PostSummaryModel>> GetPagingAsync(BaseQuery query);
        Task<List<PostSummaryModel>> GetAllAsync();
    }
}
