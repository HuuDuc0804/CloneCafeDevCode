using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic.Queries.Interface
{
    public interface IVideoQueries
    {
        BasePagingData<VideoSummaryModel> GetPaging(BaseQuery query);
        List<VideoSummaryModel> GetAll();
        VideoDetailModel? GetDetail(int id);
        Task<VideoDetailModel?> GetDetailAsync(int id);
        Task<BasePagingData<VideoSummaryModel>> GetPagingAsync(BaseQuery query);
        Task<List<VideoSummaryModel>> GetAllAsync();
    }
}
