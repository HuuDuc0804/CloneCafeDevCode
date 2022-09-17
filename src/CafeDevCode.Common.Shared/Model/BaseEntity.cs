using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Common.Shared.Model
{
    public class BaseEntity
    {
        public string? CreateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        public string? LastUpdateBy { get; set; }
        public DateTime? LastUpdateAt { get; set; }
        public bool IsDeleted { get; set; }
        public BaseEntity SetCreateInfo(string user, DateTime date)
        {
            this.CreateBy = user;
            this.CreateAt = date;
            return this;
        }
        public BaseEntity SetUpdateInfo(string user, DateTime date)
        {
            this.LastUpdateBy = user;
            this.LastUpdateAt = date;
            return this;
        }
    }
}
