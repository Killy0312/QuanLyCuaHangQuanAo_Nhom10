using DAL;
using QuanLyShopQuanAo.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class LoaiSanPhamBUS
    {
        LoaiSanPhamDAL dal = new LoaiSanPhamDAL();

        public DataTable GetAll()
        {
            return dal.GetAll();
        }

        public bool Insert(string tenLoai, string moTa)
        {
            if (string.IsNullOrEmpty(tenLoai))
                throw new Exception("Tên loại không được rỗng");

            return dal.Insert(tenLoai, moTa) > 0;
        }

        public bool Update(int maLoai, string tenLoai, string moTa)
        {
            if (string.IsNullOrEmpty(tenLoai))
                throw new Exception("Tên loại không được rỗng");

            return dal.Update(maLoai, tenLoai, moTa) > 0;
        }

        public bool Delete(int maLoai)
        {
            return dal.Delete(maLoai) > 0;
        }

        public DataTable Search(string keyword)
        {
            return dal.Search(keyword);
        }
    }
}
