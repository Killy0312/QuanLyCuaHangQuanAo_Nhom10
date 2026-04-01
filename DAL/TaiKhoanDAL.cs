using System.Data;
using System.Data.SqlClient;
using DTO;

namespace QuanLyShopQuanAo.DAL
{
    public class TaiKhoanDAL
    {
        public string KiemTraDangNhap(string user, string pass)
        {
            // Bước 2: Gọi class DataProvider thông qua Instance
            string query = "SELECT Quyen FROM TaiKhoan WHERE TenDangNhap = @user AND MatKhau = @pass";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@user", user),
                new SqlParameter("@pass", pass)
            };

            DataTable dt = DataProvider.Instance.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["Quyen"].ToString(); // Trả về Admin hoặc NhanVien
            }
            return null;
        }
    }
}