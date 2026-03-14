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

        public DataTable GetSanPham()
        {
            return dal.GetAll();
        }

        public bool Them(SanPhamDTO sp)
        {
            return dal.Insert(sp) > 0;
        }

        public bool Sua(SanPhamDTO sp)
        {
            return dal.Update(sp) > 0;
        }

        public bool Xoa(int ma)
        {
            return dal.Delete(ma) > 0;
        }

        public DataTable TimKiem(string ten)
        {
            return dal.Search(ten);
        }
    }
}
