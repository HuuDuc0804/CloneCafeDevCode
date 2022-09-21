using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic.MappingProfile
{
    public class AuthorMappingProfile : Profile
    {
        public AuthorMappingProfile()
        {
            CreateMap<CreateAuthor, Author>();
            CreateMap<UpdateAuthor, Author>();
            CreateMap<Author, AuthorSummaryModel>()
                .ReverseMap();
            CreateMap<Author, AuthorDetailModel>()
                .ReverseMap();
        }
    }
}
