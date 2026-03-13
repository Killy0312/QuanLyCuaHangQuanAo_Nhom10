using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShopQuanAo.DTO
{
    public class ChiTietHoaDon
    {
        public int MaHD { get; set; }
        public int MaSP { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        
        public double ThanhTien
        {
            get { return SoLuong * DonGia; }
        }
    }
}
