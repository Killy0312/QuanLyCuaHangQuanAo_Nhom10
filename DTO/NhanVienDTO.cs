using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO // Đảm bảo namespace trùng với tên Project DTO của bạn
{
    public class NhanVienDTO
    {
        // Khai báo các thuộc tính (Properties) y hệt các cột trong DB
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }

        // Hàm khởi tạo không tham số (Bắt buộc phải có)
        public NhanVienDTO() { }

        // Hàm khởi tạo có tham số (Giúp gán dữ liệu nhanh hơn)
        public NhanVienDTO(string ma, string ten, string sdt, string diachi)
        {
            this.MaNV = ma;
            this.TenNV = ten;
            this.SDT = sdt;
            this.DiaChi = diachi;
        }
    }
}