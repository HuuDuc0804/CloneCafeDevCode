using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic.MappingProfile
{
    public class PlayListMappingProfile : Profile
    {
        public PlayListMappingProfile()
        {
            CreateMap<CreatePlayList, PlayList>();
            CreateMap<UpdatePlayList, PlayList>();
            CreateMap<PlayList, PlayListSummaryModel>()
                .ReverseMap();
            CreateMap<PlayList, PlayListDetailModel>()
                .ReverseMap();
        }
    }
}
