using DAL;
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

        public DataTable GetLoai()
        {
            return dal.GetLoaiSanPham();
        }
    }
}
