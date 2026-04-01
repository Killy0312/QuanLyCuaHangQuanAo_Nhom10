using DTO;
using QuanLyShopQuanAo.DAL;
using QuanLyShopQuanAo.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class SanPhamDAL
    {
        // 🔹 Lấy danh sách sản phẩm (JOIN loại)
        public DataTable GetAll()
        {
            string query = @"SELECT sp.MaSP, sp.TenSP, sp.MaLoai, l.TenLoai,
                            sp.KichCo, sp.MauSac, sp.GiaBan,
                            sp.SoLuong, sp.TrangThai
                     FROM SanPham sp
                     JOIN LoaiSanPham l ON sp.MaLoai = l.MaLoai";

            return DataProvider.Instance.ExecuteQuery(query);
        }

        // 🔹 Thêm sản phẩm
        public int Insert(string ten, int maLoai, string size,
                          string mau, decimal gia, int soLuong)
        {
            string query = @"INSERT INTO SanPham
                            (TenSP, MaLoai, KichCo, MauSac, GiaBan, SoLuong)
                            VALUES (@TenSP, @MaLoai, @KichCo, @MauSac, @GiaBan, @SoLuong)";

            SqlParameter[] param = {
                new SqlParameter("@TenSP", ten),
                new SqlParameter("@MaLoai", maLoai),
                new SqlParameter("@KichCo", size),
                new SqlParameter("@MauSac", mau),
                new SqlParameter("@GiaBan", gia),
                new SqlParameter("@SoLuong", soLuong)
            };

            return DataProvider.Instance.ExecuteNonQuery(query, param);
        }

        // 🔹 Sửa
        public int Update(int ma, string ten, int maLoai, string size,
                          string mau, decimal gia, int soLuong, bool trangThai)
        {
            string query = @"UPDATE SanPham
                            SET TenSP=@TenSP, MaLoai=@MaLoai, KichCo=@KichCo,
                                MauSac=@MauSac, GiaBan=@GiaBan, SoLuong=@SoLuong,
                                TrangThai=@TrangThai
                            WHERE MaSP=@MaSP";

            SqlParameter[] param = {
                new SqlParameter("@MaSP", ma),
                new SqlParameter("@TenSP", ten),
                new SqlParameter("@MaLoai", maLoai),
                new SqlParameter("@KichCo", size),
                new SqlParameter("@MauSac", mau),
                new SqlParameter("@GiaBan", gia),
                new SqlParameter("@SoLuong", soLuong),
                new SqlParameter("@TrangThai", trangThai)
            };

            return DataProvider.Instance.ExecuteNonQuery(query, param);
        }

        // 🔹 Xóa mềm
        public int Delete(int ma)
        {
            string query = "UPDATE SanPham SET TrangThai = 0 WHERE MaSP=@MaSP";

            SqlParameter[] param = {
                new SqlParameter("@MaSP", ma)
            };

            return DataProvider.Instance.ExecuteNonQuery(query, param);
        }

        // 🔹 Tìm kiếm
        public DataTable Search(string keyword)
        {
            string query = @"SELECT sp.MaSP, sp.TenSP, sp.MaLoai, l.TenLoai,
                            sp.KichCo, sp.MauSac, sp.GiaBan,
                            sp.SoLuong, sp.TrangThai
                     FROM SanPham sp
                     JOIN LoaiSanPham l ON sp.MaLoai = l.MaLoai
                     WHERE sp.TenSP LIKE @kw";

            SqlParameter[] param = {
        new SqlParameter("@kw", "%" + keyword + "%")
    };

            return DataProvider.Instance.ExecuteQuery(query, param);
        }
    }
}
