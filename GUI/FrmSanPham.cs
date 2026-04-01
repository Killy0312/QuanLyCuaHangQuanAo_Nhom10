using BUS;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyShopQuanAo
{
    public partial class FrmSanPham : Form
    {
        SanPhamBUS spBUS = new SanPhamBUS();
        LoaiSanPhamDAL loaiDAL = new LoaiSanPhamDAL();
        public FrmSanPham()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            dgvSanPham.DataSource = spBUS.GetAll();
        }
        void LoadLoai()
        {
            cboLoai.DataSource = loaiDAL.GetAll();
            cboLoai.DisplayMember = "TenLoai";
            cboLoai.ValueMember = "MaLoai";
        }
        void ResetForm()
        {
            txtMa.Clear();
            txtTen.Clear();
            txtSize.Clear();
            txtMau.Clear();
            txtGia.Clear();
            txtSoLuong.Clear();
            txtTim.Clear();

            chkTrangThai.Checked = true; // mặc định đang bán

            if (cboLoai.Items.Count > 0)
                cboLoai.SelectedIndex = 0;
        }
        private void FrmSanPham_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadLoai();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                spBUS.Insert(
                    txtTen.Text,
                    (int)cboLoai.SelectedValue, 
                    txtSize.Text,
                    txtMau.Text,
                    decimal.Parse(txtGia.Text),
                    int.Parse(txtSoLuong.Text)
                );

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            spBUS.Delete(int.Parse(txtMa.Text));
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            spBUS.Update(
        int.Parse(txtMa.Text),
        txtTen.Text,
        (int)cboLoai.SelectedValue, 
        txtSize.Text,
        txtMau.Text,
        decimal.Parse(txtGia.Text),
        int.Parse(txtSoLuong.Text),
        true
    );

            LoadData();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetForm();
            LoadData();
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            dgvSanPham.DataSource = spBUS.Search(txtTim.Text);
        }
        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMa.Text = dgvSanPham.CurrentRow.Cells["MaSP"].Value.ToString();
                txtTen.Text = dgvSanPham.CurrentRow.Cells["TenSP"].Value.ToString();

                cboLoai.SelectedValue = dgvSanPham.CurrentRow.Cells["MaLoai"].Value;

                txtSize.Text = dgvSanPham.CurrentRow.Cells["KichCo"].Value.ToString();
                txtMau.Text = dgvSanPham.CurrentRow.Cells["MauSac"].Value.ToString();
                txtGia.Text = dgvSanPham.CurrentRow.Cells["GiaBan"].Value.ToString();
                txtSoLuong.Text = dgvSanPham.CurrentRow.Cells["SoLuong"].Value.ToString();
            }
        }
        private void FormSanPham_Activated(object sender, EventArgs e)
        {
            LoadLoai(); 
        }
    }
}
