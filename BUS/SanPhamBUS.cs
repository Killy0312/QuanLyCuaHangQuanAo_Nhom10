using DAL;
using DTO;
using QuanLyShopQuanAo.DAL;
using QuanLyShopQuanAo.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class SanPhamBUS
    {
        SanPhamDAL dal = new SanPhamDAL();

        public DataTable GetAll()
        {
            return dal.GetAll();
        }

        public bool Insert(string ten, int maLoai, string size,
                           string mau, decimal gia, int soLuong)
        {
            if (string.IsNullOrEmpty(ten))
                throw new Exception("Tên sản phẩm không được rỗng");

            if (gia <= 0)
                throw new Exception("Giá phải > 0");

            if (soLuong < 0)
                throw new Exception("Số lượng không hợp lệ");

            return dal.Insert(ten, maLoai, size, mau, gia, soLuong) > 0;
        }

        public bool Update(int ma, string ten, int maLoai, string size,
                           string mau, decimal gia, int soLuong, bool trangThai)
        {
            return dal.Update(ma, ten, maLoai, size, mau, gia, soLuong, trangThai) > 0;
        }

        public bool Delete(int ma)
        {
            return dal.Delete(ma) > 0;
        }

        public DataTable Search(string keyword)
        {
            return dal.Search(keyword);
        }
    }
}
