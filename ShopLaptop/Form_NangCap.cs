﻿using ShopLaptop.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopLaptop
{
    public partial class Form_NangCap : Form
    {
        MyConnect myconn = new MyConnect();
        BUS_GoiNangCap bUS_GoiNangCap = new BUS_GoiNangCap();
        BUS_HoatDongNangCap bUS_HoatDongNangCap = new BUS_HoatDongNangCap();
        public Form_NangCap()
        {
            InitializeComponent();
        }

        private void LoadDataGoiNangCap()
        {
            dgv_GoiNangCap.DataSource = bUS_GoiNangCap.LoadGoiNangCaps();
            dgv_GoiNangCap.Refresh();
        }
        private void LoadDataHDNC()
        {
            dgv_HoatDongNangCap.DataSource = bUS_HoatDongNangCap.LoadHoatDongNangCaps();
        }
        private void btn_Show_GoiNangCap_Click(object sender, EventArgs e)
        {
            LoadDataGoiNangCap();
        }
        private void btn_Show_HoatDongNangCap_Click(object sender, EventArgs e)
        {
            LoadDataHDNC();
        }
        private void ResetGoiNangCap()
        {
            txt_MaGoiNangCap.ResetText();
            txt_TenGoiNC.ResetText();
            txt_PhiNC.ResetText();
        }
        private void ResetHDNC()
        {
            txt_MaNV_HDNC.ResetText();
            txt_MaKH_HDNC.ResetText();
            txt_MaGoi_HDNC.ResetText();
        }
        private void dgv_GoiNangCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_MaGoiNangCap.Text = dgv_GoiNangCap.CurrentRow.Cells[0].Value.ToString();
            txt_TenGoiNC.Text = dgv_GoiNangCap.CurrentRow.Cells[1].Value.ToString();
            txt_PhiNC.Text = dgv_GoiNangCap.CurrentRow.Cells[2].Value.ToString();
        }
        private void dgv_HoatDongNangCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_MaNV_HDNC.Text = dgv_HoatDongNangCap.CurrentRow.Cells[0].Value.ToString();
            txt_MaKH_HDNC.Text = dgv_HoatDongNangCap.CurrentRow.Cells[1].Value.ToString();
            txt_MaGoi_HDNC.Text = dgv_HoatDongNangCap.CurrentRow.Cells[2].Value.ToString();
        }
        private void btn_Them_GoiNangCap_Click(object sender, EventArgs e)
        {
            try
            {
                bool is_success = bUS_GoiNangCap.InsertGoiNangCap(txt_MaGoiNangCap.Text,txt_TenGoiNC.Text,txt_PhiNC.Text);
                LoadDataGoiNangCap();
                ResetGoiNangCap();
                if (is_success)
                {
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
        private void btn_Sua_GoiNangCap_Click(object sender, EventArgs e)
        {
            try
            {
                bool is_success = bUS_GoiNangCap.UpdateGoiNangCap(txt_MaGoiNangCap.Text, txt_TenGoiNC.Text, txt_PhiNC.Text);
                LoadDataGoiNangCap();
                ResetGoiNangCap();
                if (is_success)
                {
                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

        }
        private void btn_Xoa_GoiNangCap_Click(object sender, EventArgs e)
        {
            try
            {
                bool is_success = bUS_GoiNangCap.DeleteGoiNangCap(txt_MaGoiNangCap.Text, txt_TenGoiNC.Text, txt_PhiNC.Text);
                LoadDataGoiNangCap();
                ResetGoiNangCap();
                if (is_success)
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
        private void btn_Them_HDNC_Click(object sender, EventArgs e)
        {
            try
            {
                bool is_success = bUS_HoatDongNangCap.InsertHoatDongNangCap(txt_MaNV_HDNC.Text,txt_MaKH_HDNC.Text,txt_MaGoi_HDNC.Text);
                LoadDataGoiNangCap();
                ResetGoiNangCap();
                if (is_success)
                {
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

        }

        private void btn_Sua_HDNC_Click(object sender, EventArgs e)
        {
            try
            {
                bool is_success = bUS_HoatDongNangCap.UpdateHoatDongNangCap(txt_MaNV_HDNC.Text, txt_MaKH_HDNC.Text, txt_MaGoi_HDNC.Text);
                LoadDataGoiNangCap();
                ResetGoiNangCap();
                if (is_success)
                {
                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

        }

        private void btn_Xoa_HDNC_Click(object sender, EventArgs e)
        {
            try
            {
                bool is_success = bUS_HoatDongNangCap.DeleteHoatDongNangCap(txt_MaNV_HDNC.Text, txt_MaKH_HDNC.Text, txt_MaGoi_HDNC.Text);
                LoadDataGoiNangCap();
                ResetGoiNangCap();
                if (is_success)
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void tbp_Infor_GoiNangCap_Click(object sender, EventArgs e)
        {

        }

        private void btn_TimKiem_GoiNangCap_Click(object sender, EventArgs e)
        {
            myconn.openConnectionAdmin();
            SqlCommand cmd = new SqlCommand("Select * From func_SearchNangCapByID(@MaGoiNC)", myconn.getConnectionAdmin);
            cmd.Parameters.AddWithValue("@MaGoiNC", txt_TimKiem_GoiNangCap.Text);
            DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            dgv_GoiNangCap.DataSource = dt;
            myconn.closeConnectionAdmin();
        }


        private void btn_TimKiem_HoatDongNangCap_Click_1(object sender, EventArgs e)
        {
            myconn.openConnectionAdmin();
            SqlCommand cmd = new SqlCommand("Select * From func_SearHoatDongNangCap(@MaNV, @MaKH, @MaGoiBH)", myconn.getConnectionAdmin);
            cmd.Parameters.AddWithValue("@MaNV", txt_TimKiem_MaNhanVien.Text);
            cmd.Parameters.AddWithValue("@MaKH", txt_TimKiem_MaKhachHang.Text);
            cmd.Parameters.AddWithValue("@MaGoiBH", txt_TimKiem_MaGoiNC.Text);
            DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            dgv_HoatDongNangCap.DataSource = dt;
            myconn.closeConnectionAdmin();
        }
    }
}
