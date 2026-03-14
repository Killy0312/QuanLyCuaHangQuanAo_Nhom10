using QuanLyShopQuanAo.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LoaiSanPhamDAL
    {
        public DataTable GetLoaiSanPham()
        {
            string query = "SELECT MaLoai, TenLoai FROM LoaiSanPham";

            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
