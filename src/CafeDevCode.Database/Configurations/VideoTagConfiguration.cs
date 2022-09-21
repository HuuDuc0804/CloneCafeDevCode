using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Database.Configurations
{
    public class VideoTagConfiguration : IEntityTypeConfiguration<VideoTag>
    {
        public void Configure(EntityTypeBuilder<VideoTag> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}
