using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TaiKhoanDTO
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string Quyen { get; set; }
        public string MaNV { get; set; }

        public TaiKhoanDTO() { }

        public TaiKhoanDTO(string user, string pass, string quyen, string manv)
        {
            this.TenDangNhap = user;
            this.MatKhau = pass;
            this.Quyen = quyen;
            this.MaNV = manv;
        }
    }
}