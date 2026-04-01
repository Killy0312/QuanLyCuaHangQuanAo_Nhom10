using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPhamDTO
    {
        public int MaSP { get; set; }

        public string TenSP { get; set; }

        public int MaLoai { get; set; }

        public string TenLoai { get; set; }
        public string KichCo { get; set; }

        public string MauSac { get; set; }

        public decimal GiaBan { get; set; }

        public int SoLuong { get; set; }

        public string HinhAnh { get; set; }

        public bool TrangThai { get; set; }
    }
}
