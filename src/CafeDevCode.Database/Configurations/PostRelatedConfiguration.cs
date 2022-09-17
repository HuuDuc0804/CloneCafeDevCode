using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Database.Configurations
{
    public class PostRelatedConfiguration : IEntityTypeConfiguration<PostRelated>
    {
        public void Configure(EntityTypeBuilder<PostRelated> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}
