using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic.Queries.Interface
{
    public interface ITagQueries
    {
        BasePagingData<TagSummaryModel> GetPaging(BaseQuery query);
        List<TagSummaryModel> GetAll();
        List<TagSummaryModel> GetByPostId(int postId);
        TagDetailModel? GetDetail(int id);
        Task<TagDetailModel?> GetDetailAsync(int id);
        Task<BasePagingData<TagSummaryModel>> GetPagingAsync(BaseQuery query);
        Task<List<TagSummaryModel>> GetAllAsync();
    }
}
