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
    
        
       public List<SinhVien> ListSV;
 
        QuanLySinhVien qlsv;
        ListView listView;

        public frmThemSV(QuanLySinhVien qlsv, ListView listView)
        {
            InitializeComponent();
            this.qlsv = qlsv;
            this.listView = listView;           
        }
      

        private SinhVien GetSinhVien()
        {
            SinhVien sv = new SinhVien();
            bool gt = true;
            List<string> cn = new List<string>();
            sv.MSSV = this.mtxtMaSo.Text;
            sv.HoVaTenLot = this.txtHoTen.Text;
            sv.Ten = this.txtTen.Text;
            sv.NgaySinh = this.dtpNgaySinh.Value;
            sv.Lop = this.cboLop.Text;
            sv.SoDienThoai = this.mkbSDT.Text;
            sv.Khoa = this.cboKhoa.Text;
            sv.DiaChi = this.txtDiaChi.Text;
            return sv;
        }
       
        private void btnLưu_Click_1(object sender, EventArgs e)
        {
            
            SinhVien sv = GetSinhVien();
            SinhVien kq = qlsv.Tim(sv.MSSV, delegate (object obj1, object obj2)
            {
                return (obj2 as SinhVien).MSSV.CompareTo(obj1.ToString());
            });
            if (kq != null)
            {
                Form1 frm = new Form1(qlsv);
                MessageBox.Show("Mã sinh viên đã tồn tại! đã cập nhật thông tin", "Lỗi thêm dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bool kqsua;
                kqsua = qlsv.Sua(sv, sv.MSSV, frm.SoSanhTheoMa);
                if (kqsua)
                {
                    frm.LoadListView();
                }
                    
            }            
            else
            {
                
                ListViewItem lvitem = new ListViewItem(sv.MSSV);
                string gt = "Nữ";
                if (rdNam.Checked)
                {
                    gt= "Nam";
                }       
                lvitem.SubItems.Add(sv.HoVaTenLot);
                lvitem.SubItems.Add(sv.Ten);
                lvitem.SubItems.Add(gt);
                lvitem.SubItems.Add(sv.NgaySinh.ToShortDateString());
                lvitem.SubItems.Add(sv.SoDienThoai);
                lvitem.SubItems.Add(sv.Lop);
                lvitem.SubItems.Add(sv.Khoa);                
                lvitem.SubItems.Add(sv.DiaChi);
                this.listView.Items.Add(lvitem);
                            
                MessageBox.Show("Thêm sinh viên thành công!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                

            }
        }
       
    }
}
