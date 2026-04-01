using QuanLyShopQuanAo.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace DAL
{
    public class LoaiSanPhamDAL
    {
        // 🔹 Lấy tất cả
        public DataTable GetAll()
        {
            string query = "SELECT * FROM LoaiSanPham";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        // 🔹 Thêm
        public int Insert(string tenLoai, string moTa)
        {
            string query = @"INSERT INTO LoaiSanPham (TenLoai, MoTa)
                             VALUES (@TenLoai, @MoTa)";

            SqlParameter[] param = {
                new SqlParameter("@TenLoai", tenLoai),
                new SqlParameter("@MoTa", moTa)
            };

            return DataProvider.Instance.ExecuteNonQuery(query, param);
        }

        // 🔹 Sửa
        public int Update(int maLoai, string tenLoai, string moTa)
        {
            string query = @"UPDATE LoaiSanPham
                             SET TenLoai=@TenLoai, MoTa=@MoTa
                             WHERE MaLoai=@MaLoai";

            SqlParameter[] param = {
                new SqlParameter("@MaLoai", maLoai),
                new SqlParameter("@TenLoai", tenLoai),
                new SqlParameter("@MoTa", moTa)
            };

            return DataProvider.Instance.ExecuteNonQuery(query, param);
        }

        // 🔹 Xóa
        public int Delete(int maLoai)
        {
            string query = "DELETE FROM LoaiSanPham WHERE MaLoai=@MaLoai";

            SqlParameter[] param = {
                new SqlParameter("@MaLoai", maLoai)
            };

            return DataProvider.Instance.ExecuteNonQuery(query, param);
        }

        // 🔹 Tìm kiếm
        public DataTable Search(string keyword)
        {
            string query = @"SELECT * FROM LoaiSanPham
                             WHERE TenLoai LIKE @kw";

            SqlParameter[] param = {
                new SqlParameter("@kw", "%" + keyword + "%")
            };

            return DataProvider.Instance.ExecuteQuery(query, param);
        }
    }
}
