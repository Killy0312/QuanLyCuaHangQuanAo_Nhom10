using System.Data;
using System.Data.SqlClient;
using DTO;

namespace QuanLyShopQuanAo.DAL
{
    public class NhanVienDAL
    {
        public DataTable LayDanhSachNV()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT * FROM NhanVien");
        }

        public bool ThemNV(NhanVienDTO nv)
        {
            string query = "INSERT INTO NhanVien (MaNV, TenNV, SDT) VALUES (@ma, @ten, @sdt)";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@ma", nv.MaNV),
                new SqlParameter("@ten", nv.TenNV),
                new SqlParameter("@sdt", nv.SDT)
            };
            return DataProvider.Instance.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool SuaNV(NhanVienDTO nv)
        {
            string query = "UPDATE NhanVien SET TenNV = @ten, SDT = @sdt WHERE MaNV = @ma";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@ma", nv.MaNV),
                new SqlParameter("@ten", nv.TenNV),
                new SqlParameter("@sdt", nv.SDT)
            };
            return DataProvider.Instance.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool XoaNV(string maNV)
        {
            string query = "DELETE FROM NhanVien WHERE MaNV = @ma";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@ma", maNV)
            };
            return DataProvider.Instance.ExecuteNonQuery(query, parameters) > 0;
        }
    }
}