using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Database.Configurations
{
    public class PlayListVideoConfiguration : IEntityTypeConfiguration<PlayListVideo>
    {
        public void Configure(EntityTypeBuilder<PlayListVideo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}
