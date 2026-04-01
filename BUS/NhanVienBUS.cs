using DTO;
using QuanLyShopQuanAo.DAL;
using QuanLyShopQuanAo.DTO;
using System.Data;

namespace QuanLyShopQuanAo.BUS
{
    public class NhanVienBUS
    {
        private NhanVienDAL dalNV = new NhanVienDAL();

        public DataTable LayDanhSachNV()
        {
            return dalNV.LayDanhSachNV();
        }

        public string ThemNV(NhanVienDTO nv)
        {
            // 1. Kiểm tra bỏ trống
            if (string.IsNullOrWhiteSpace(nv.MaNV)) return "Mã nhân viên không được để trống!";
            if (string.IsNullOrWhiteSpace(nv.TenNV)) return "Tên nhân viên không được để trống!";

            // 2. Kiểm tra logic SĐT (đúng 10 số)
            if (nv.SDT.Length != 10) return "Số điện thoại phải có đúng 10 chữ số!";

            // Kiểm tra SĐT có phải là số không (tránh nhập chữ)
            long sdt;
            if (!long.TryParse(nv.SDT, out sdt)) return "Số điện thoại phải là định dạng số!";

            // 3. Nếu mọi thứ hợp lệ mới gọi DAL
            if (dalNV.ThemNV(nv))
                return "Thêm nhân viên thành công!";
            else
                return "Thêm thất bại (Lỗi hệ thống hoặc trùng mã)!";
        }

        public string SuaNV(NhanVienDTO nv)
        {
            // Tương tự như thêm, nhưng thường không cho sửa Mã NV
            if (string.IsNullOrWhiteSpace(nv.TenNV)) return "Tên không được để trống!";
            if (nv.SDT.Length != 10) return "SĐT phải đủ 10 số!";

            if (dalNV.SuaNV(nv))
                return "Cập nhật thành công!";
            else
                return "Cập nhật thất bại!";
        }

        public string XoaNV(string maNV)
        {
            if (string.IsNullOrEmpty(maNV)) return "Phải chọn nhân viên cần xóa!";

            if (dalNV.XoaNV(maNV))
                return "Xóa thành công!";
            else
                return "Xóa thất bại!";
        }
    }
}