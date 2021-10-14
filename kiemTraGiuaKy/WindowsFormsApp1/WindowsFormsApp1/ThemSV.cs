﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Model;
using WindowsFormsApp1.IO;

namespace WindowsFormsApp1
{
    public partial class frmThemSV:Form
    {
        private readonly NewSinhVienDataSourch _NewSinhVienDataSourch;
        private bool _capNhat;
        public SinhVien sv;




        public frmThemSV(NewSinhVienDataSourch importExport, bool capNhat = false)
        {
            _NewSinhVienDataSourch = importExport;
            _capNhat = capNhat;
            InitializeComponent();

        }
        public void comboboxLop(string tenLop)
        {
            cboLop.Text = tenLop;
        }
        public void comboboxKhoa(string tenKhoa)
        {
            cboKhoa.Text = tenKhoa;
        }
        private SinhVien GetSinhVien()
        {
            SinhVien sv = new SinhVien();
            sv.MSSV = mtxtMaSo.Text;
            sv.HoVaTenLot = txtHoTen.Text;
            sv.Ten = txtTen.Text;
            sv.NgaySinh = dtpNgaySinh.Value;
            sv.SoDienThoai = mkbSDT.Text;
            sv.DiaChi = txtDiaChi.Text;
            sv.GioiTinh = "Nam";
            if (rdNu.Checked)
            {
                sv.GioiTinh = "Nữ";
            }
            sv.Lop = cboLop.Text;
            sv.Khoa = cboKhoa.Text;
            return sv;
        }
       
        private void btnLưu_Click_1(object sender, EventArgs e)
        {
            SinhVien sv = GetSinhVien();
            if (string.IsNullOrWhiteSpace(sv.MSSV) || string.IsNullOrWhiteSpace(sv.HoVaTenLot) || string.IsNullOrWhiteSpace(sv.Ten))
            {
                MessageBox.Show("Cần nhập đầy đủ thông tin Sinh vien!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            var list = _NewSinhVienDataSourch.GetKhoa();
            var khoa = list.Find(p => p.Ten == sv.Khoa);
            Lop lops = khoa.Lops.FirstOrDefault(p => p.Ten == sv.Lop);
            if (lops != null)
            {
                SinhVien s = lops.sinhViens.FirstOrDefault(p => p.MSSV == sv.MSSV);
                if (s == null)
                {
                    lops.ThemSinhVien(sv);        
                }
                else
                {
                    s.CapNhatSV(sv.MSSV, sv.HoVaTenLot, sv.Ten, sv.GioiTinh, sv.NgaySinh, sv.SoDienThoai, sv.Lop, sv.Khoa, sv.DiaChi);
                }
           
                Close();
            }
        }
        private void CapNhatSV()
        {
            mtxtMaSo.Text = sv.MSSV;
            mtxtMaSo.Enabled = false;
            txtHoTen.Text = sv.HoVaTenLot;
            txtTen.Text = sv.Ten;
            if (sv.GioiTinh == "Nam")
            {
                rdNam.Checked = true;
            }
            else
            {
                rdNu.Checked = true;
            }

            if (sv.NgaySinh == new DateTime(0001, 1, 1))
            {
                dtpNgaySinh.Value = DateTime.Now;
            }
            else
            {
                dtpNgaySinh.Value = sv.NgaySinh;
            }
            mkbSDT.Text = sv.SoDienThoai;
            txtDiaChi.Text = sv.DiaChi;
            cboLop.Text = sv.Lop;
            cboKhoa.Text = sv.Khoa; 
        }

        private void frmThemSV_Load(object sender, EventArgs e)
        {
            var khoa = _NewSinhVienDataSourch.GetKhoa();
            rdNam.Checked = true;

            if (_capNhat)
            {
                CapNhatSV();
            }


            foreach (var k in khoa)
            {
                cboKhoa.Items.Add(k.Ten);

                foreach (var l in k.Lops)
                {
                    cboLop.Items.Add(l.Ten);
                }
            }

        }
    }
}
