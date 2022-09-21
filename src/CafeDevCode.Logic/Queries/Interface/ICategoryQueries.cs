using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic.Queries.Interface
{
    public interface ICategoryQueries
    {
        BasePagingData<CategorySummaryModel> GetPaging(BaseQuery query);
        List<CategorySummaryModel> GetAll();
        CategoryDetailModel? GetDetail(int id);
        Task<CategoryDetailModel?> GetDetailAsync(int id);
        Task<BasePagingData<CategorySummaryModel>> GetPagingAsync(BaseQuery query);
        Task<List<CategorySummaryModel>> GetAllAsync();
    }
}
