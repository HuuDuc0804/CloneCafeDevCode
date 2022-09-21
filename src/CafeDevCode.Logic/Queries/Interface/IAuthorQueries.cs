global using CafeDevCode.Common.Shared.Model;
global using CafeDevCode.Logic.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic.Queries.Interface
{
    public interface IAuthorQueries
    {
        BasePagingData<AuthorSummaryModel> GetPaging(BaseQuery query);
        List<AuthorSummaryModel> GetAll();
        AuthorDetailModel? GetDetail(int id);
        Task<AuthorDetailModel?> GetDetailAsync(int id);
        Task<BasePagingData<AuthorSummaryModel>> GetPagingAsync(BaseQuery query);
        Task<List<AuthorSummaryModel>> GetAllAsync();
    }
}
