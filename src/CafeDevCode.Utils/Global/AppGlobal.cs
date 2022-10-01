using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Utils.Global
{
    public class AppGlobal
    {
        public static DateTime SysDateTime => DateTime.Now;
        public static string InvalidUserName => "Tên đăng nhập không hợp lệ";
        public static string InvalidPassword => "Mật khẩu không hợp lệ";
        public static string DefaultSuccessMessage => "Thao tác thành công!";
    }
}
