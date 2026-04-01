using QuanLyShopQuanAo.DAL;

namespace QuanLyShopQuanAo.BUS
{
    public class TaiKhoanBUS
    {
        private TaiKhoanDAL dalTK = new TaiKhoanDAL();

        public string KiemTraDangNhap(string user, string pass)
        {
            // Kiểm tra rỗng ngay tại BUS
            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
            {
                return "EMPTY"; // Trả về mã lỗi tự quy định
            }

            // Gọi DAL để lấy "Quyền" từ Database
            return dalTK.KiemTraDangNhap(user, pass);
        }
    }
}