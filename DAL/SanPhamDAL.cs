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
        public DataTable GetAll()
        {
            string query = @"SELECT sp.MaSP, sp.TenSP, sp.MaLoai,
                            l.TenLoai, sp.KichCo, sp.MauSac,
                            sp.GiaBan, sp.SoLuong
                            FROM SanPham sp
                            JOIN LoaiSanPham l ON sp.MaLoai = l.MaLoai";

            return DataProvider.Instance.ExecuteQuery(query);
        }

        public int Insert(SanPhamDTO sp)
        {
            string query = @"INSERT INTO SanPham
                            (TenSP,MaLoai,KichCo,MauSac,GiaBan,SoLuong,TrangThai)
                            VALUES
                            (@TenSP,@MaLoai,@KichCo,@MauSac,@GiaBan,@SoLuong,1)";

            SqlParameter[] param =
            {
                new SqlParameter("@TenSP",sp.TenSP),
                new SqlParameter("@MaLoai",sp.MaLoai),
                new SqlParameter("@KichCo",sp.KichCo),
                new SqlParameter("@MauSac",sp.MauSac),
                new SqlParameter("@GiaBan",sp.GiaBan),
                new SqlParameter("@SoLuong",sp.SoLuong)
            };

            return DataProvider.Instance.ExecuteNonQuery(query, param);
        }

        public int Update(SanPhamDTO sp)
        {
            string query = @"UPDATE SanPham
                            SET TenSP=@TenSP,
                                MaLoai=@MaLoai,
                                KichCo=@KichCo,
                                MauSac=@MauSac,
                                GiaBan=@GiaBan,
                                SoLuong=@SoLuong
                            WHERE MaSP=@MaSP";

            SqlParameter[] param =
            {
                new SqlParameter("@TenSP",sp.TenSP),
                new SqlParameter("@MaLoai",sp.MaLoai),
                new SqlParameter("@KichCo",sp.KichCo),
                new SqlParameter("@MauSac",sp.MauSac),
                new SqlParameter("@GiaBan",sp.GiaBan),
                new SqlParameter("@SoLuong",sp.SoLuong),
                new SqlParameter("@MaSP",sp.MaSP)
            };

            return DataProvider.Instance.ExecuteNonQuery(query, param);
        }

        public int Delete(int maSP)
        {
            string query = "DELETE FROM SanPham WHERE MaSP=@MaSP";

            SqlParameter[] param =
            {
                new SqlParameter("@MaSP",maSP)
            };

            return DataProvider.Instance.ExecuteNonQuery(query, param);
        }

        public DataTable Search(string ten)
        {
            string query = @"SELECT sp.MaSP, sp.TenSP, l.TenLoai,
                            sp.KichCo, sp.MauSac,
                            sp.GiaBan, sp.SoLuong
                            FROM SanPham sp
                            JOIN LoaiSanPham l ON sp.MaLoai=l.MaLoai
                            WHERE TenSP LIKE @Ten";

            SqlParameter[] param =
            {
                new SqlParameter("@Ten","%"+ten+"%")
            };

            return DataProvider.Instance.ExecuteQuery(query, param);
        }
    }
}
