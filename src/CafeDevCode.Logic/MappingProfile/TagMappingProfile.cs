using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic.MappingProfile
{
    public class TagMappingProfile : Profile
    {
        public TagMappingProfile()
        {
            CreateMap<CreateTag, Tag>();
            CreateMap<UpdateTag, Tag>();
            CreateMap<Tag, TagSummaryModel>()
                .ReverseMap();
            CreateMap<Tag, TagDetailModel>()
                .ReverseMap();
        }
    }
}
