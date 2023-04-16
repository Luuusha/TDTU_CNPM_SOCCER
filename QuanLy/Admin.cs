﻿using QuanLy.Class;
using Quanlysanbong;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLy
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }
        SanVD svd = new SanVD();
        CauLacBo clb = new CauLacBo();
        CauThu ct = new CauThu();
        MuaGiai mg = new MuaGiai();
        LichThiDau ltd = new LichThiDau();
        public void hienthisvd()
        {
            DataTable h = svd.DanhSach();
            tablesvd.DataSource = h;
            for (int i = 0; i < tablesvd.Columns.Count; i++)
            {
                this.tablesvd.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        public void hienthiclb()
        {
            DataTable h = clb.DanhSach();
            tableclb.DataSource = h;
            for (int i = 0; i < tableclb.Columns.Count; i++)
            {
                this.tableclb.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            ketnoi k = new ketnoi();
            SqlConnection con = k.GetConnection();
            string sql = "select * from SanVD ";
            DataTable tb = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(sql, con);
            ad.Fill(tb);
            cbxsvd.DataSource = tb;
            cbxsvd.DisplayMember = "TenSVD";
            cbxsvd.ValueMember = "Id";
        }
        public void hienthiltd()
        {
            DataTable h = ltd.DanhSach();
            tableltd.DataSource = h;
            for (int i = 0; i < tableltd.Columns.Count; i++)
            {
                this.tableltd.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            ketnoi k = new ketnoi();
            SqlConnection con = k.GetConnection();
            string sql = "select * from SanVD ";
            DataTable tb = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(sql, con);
            ad.Fill(tb);
            cbxsv.DataSource = tb;
            cbxsv.DisplayMember = "TenSVD";
            cbxsv.ValueMember = "Id";
            string sql1 = "select * from CauLacBo ";
            DataTable tb1 = new DataTable();
            SqlDataAdapter ad1 = new SqlDataAdapter(sql1, con);
            ad1.Fill(tb1);
            cbx1.DataSource = tb1;
            cbx1.DisplayMember = "TenCLB";
            cbx1.ValueMember = "Id";

            string sql3 = "select * from CauLacBo ";
            DataTable tb3 = new DataTable();
            SqlDataAdapter ad3 = new SqlDataAdapter(sql3, con);
            ad3.Fill(tb3);
            cbx1.DataSource = tb1;
            cbx2.DataSource = tb3;
            cbx2.DisplayMember = "TenCLB";
            cbx2.ValueMember = "Id";

            string sql2 = "select * from MuaGiai ";
            DataTable tb2 = new DataTable();
            SqlDataAdapter ad2 = new SqlDataAdapter(sql2, con);
            ad2.Fill(tb2);
            cbxmg.DataSource = tb2;
            cbxmg.DisplayMember = "TenMuaGiai";
            cbxmg.ValueMember = "Id";
        }
        public void hienthitd()
        {
            ketnoi k = new ketnoi();
            SqlConnection con = k.GetConnection();
            string sql2 = "select * from MuaGiai ";
            DataTable tb2 = new DataTable();
            SqlDataAdapter ad2 = new SqlDataAdapter(sql2, con);
            ad2.Fill(tb2);
            cbxcmg.DataSource = tb2;
            cbxcmg.DisplayMember = "TenMuaGiai";
            cbxcmg.ValueMember = "Id";
        }
        public void hienthict()
        {
            DataTable h = ct.DanhSach();
            tablect.DataSource = h;
            for (int i = 0; i < tablect.Columns.Count; i++)
            {
                this.tablect.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            ketnoi k = new ketnoi();
            SqlConnection con = k.GetConnection();
            string sql = "select * from CauLacBo ";
            DataTable tb = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(sql, con);
            ad.Fill(tb);
            cbxclb.DataSource = tb;
            cbxclb.DisplayMember = "TenCLB";
            cbxclb.ValueMember = "Id";
        }
        public void hienthimg()
        {
            DataTable h = mg.DanhSach();
            tablemg.DataSource = h;
            for (int i = 0; i < tablemg.Columns.Count; i++)
            {
                this.tablemg.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            hienthisvd();
            hienthiclb();
            hienthict();
            hienthiltd();
            hienthimg();
            hienthitd();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tensvd.Text == "" || sc.Text == "" || tp.Text == "")
            {
                MessageBox.Show("Yêu cầu nhập dữ liệu khi thêm mới.");

            }
            else
            {
                svd.ThemSVD(tensvd.Text, sc.Text, tp.Text);
                MessageBox.Show("Thêm mới thành công");
                tensvd.Text = ""; sc.Text = ""; tp.Text = ""; masvd.Text = "";
                hienthisvd();
            }
        }

        private void tablesvd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;

            if (row >= 0)
            {
                masvd.Text = tablesvd.Rows[row].Cells[0].Value.ToString();
                tensvd.Text = tablesvd.Rows[row].Cells[1].Value.ToString();
                sc.Text = tablesvd.Rows[row].Cells[2].Value.ToString();
                tp.Text = tablesvd.Rows[row].Cells[3].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (masvd.Text == "")
            {
                MessageBox.Show("Yêu cầu chọn bản ghi để chỉnh sửa.");

            }
            else
            {
                svd.SuaSVD(int.Parse(masvd.Text), tensvd.Text, sc.Text, tp.Text);
                MessageBox.Show("Sửa thành công");
                tensvd.Text = ""; sc.Text = ""; tp.Text = ""; masvd.Text = "";
                hienthisvd();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (masvd.Text == "")
            {
                MessageBox.Show("Yêu cầu chọn bản ghi để xóa.");

            }
            else
            {
                if (MessageBox.Show("Bạn có muốn xóa sân vận động " + tensvd.Text + " không ?", "Thông báo xóa bản ghi", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    svd.XoaSVD(int.Parse(masvd.Text));
                    MessageBox.Show("Xóa thành công");
                    tensvd.Text = ""; sc.Text = ""; tp.Text = ""; masvd.Text = "";
                    hienthisvd();
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ExportToExcel obj = new ExportToExcel();
            DataTable dt = svd.DanhSach();
            tablesvd.DataSource = dt;
            SaveFileDialog s = new SaveFileDialog();
            if (s.ShowDialog() == DialogResult.OK && tablesvd.RowCount > 0)
            {
                bool export = obj.ToExcel(dt, s.FileName, "Danh sách sân vận động", dt.Columns.Count);
                MessageBox.Show("Xuất file thành công");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataTable h = svd.DanhSach(key.Text);
            tablesvd.DataSource = h;
            for (int i = 0; i < tablesvd.Columns.Count; i++)
            {
                this.tablesvd.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (tenclb.Text == "" || hlv.Text == "")
            {
                MessageBox.Show("Yêu cầu nhập dữ liệu.");
            }
            else
            {
                clb.ThemCLB(tenclb.Text, int.Parse(cbxsvd.SelectedValue.ToString()), hlv.Text);
                tenclb.Text = ""; hlv.Text = ""; maclb.Text = "";
                hienthiclb();
                MessageBox.Show("Thêm mới thành công.");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (maclb.Text == "")
            {
                MessageBox.Show("Yêu cầu chọn dữ liệu cần chỉnh sửa.");
            }
            else
            {
                clb.SuaCLB(int.Parse(maclb.Text), tenclb.Text, int.Parse(cbxsvd.SelectedValue.ToString()), hlv.Text);
                tenclb.Text = ""; hlv.Text = ""; maclb.Text = "";
                hienthiclb();
                MessageBox.Show("Sửa thành công.");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (maclb.Text == "")
            {
                MessageBox.Show("Yêu cầu chọn bản ghi để xóa.");

            }
            else
            {
                if (MessageBox.Show("Bạn có muốn xóa câu lạc bộ " + tenclb.Text + " không ?", "Thông báo xóa bản ghi", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    clb.XoaCLB(int.Parse(maclb.Text));
                    MessageBox.Show("Xóa thành công");
                    tenclb.Text = ""; hlv.Text = ""; maclb.Text = "";
                    hienthiclb();
                }

            }
        }

        private void tableclb_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;

            if (row >= 0)
            {
                maclb.Text = tableclb.Rows[row].Cells[0].Value.ToString();
                tenclb.Text = tableclb.Rows[row].Cells[1].Value.ToString();
                cbxsvd.Text = tableclb.Rows[row].Cells[2].Value.ToString();
                hlv.Text = tableclb.Rows[row].Cells[3].Value.ToString();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DataTable h = clb.DanhSach(keyclb.Text);
            tableclb.DataSource = h;
            for (int i = 0; i < tableclb.Columns.Count; i++)
            {
                this.tableclb.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ExportToExcel obj = new ExportToExcel();
            DataTable dt = clb.DanhSach();
            tableclb.DataSource = dt;
            SaveFileDialog s = new SaveFileDialog();
            if (s.ShowDialog() == DialogResult.OK && tableclb.RowCount > 0)
            {
                bool export = obj.ToExcel(dt, s.FileName, "Danh sách câu lạc bộ", dt.Columns.Count);
                MessageBox.Show("Xuất file thành công");
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (htct.Text == "" || nsct.Text == "" || aoct.Text == "" || qqct.Text == "")
            {
                MessageBox.Show("Yêu cầu nhập dữ liệu.");
            }
            else
            {
                ct.ThemCT(htct.Text, qqct.Text, int.Parse(nsct.Text), int.Parse(aoct.Text), int.Parse(cbxclb.SelectedValue.ToString()));
                htct.Text = ""; nsct.Text = ""; aoct.Text = ""; qqct.Text = "";
                hienthict();
                MessageBox.Show("Thêm mới thành công.");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (mact.Text == "")
            {
                MessageBox.Show("Yêu cầu chọn dữ liệu cần chỉnh sửa.");
            }
            else
            {
                ct.SuaCT(int.Parse(mact.Text), htct.Text, qqct.Text, int.Parse(nsct.Text), int.Parse(aoct.Text), int.Parse(cbxclb.SelectedValue.ToString()));
                htct.Text = ""; nsct.Text = ""; aoct.Text = ""; qqct.Text = ""; mact.Text = "";
                hienthict();
                MessageBox.Show("Sửa thành công.");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (mact.Text == "")
            {
                MessageBox.Show("Yêu cầu chọn bản ghi để xóa.");

            }
            else
            {
                if (MessageBox.Show("Bạn có muốn xóa cầu thủ " + htct.Text + " không ?", "Thông báo xóa bản ghi", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ct.XoaCT(int.Parse(mact.Text));
                    MessageBox.Show("Xóa thành công");
                    htct.Text = ""; nsct.Text = ""; aoct.Text = ""; qqct.Text = ""; mact.Text = "";
                    hienthict();
                }

            }
        }

        private void tablect_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;

            if (row >= 0)
            {
                mact.Text = tablect.Rows[row].Cells[0].Value.ToString();
                htct.Text = tablect.Rows[row].Cells[1].Value.ToString();
                qqct.Text = tablect.Rows[row].Cells[2].Value.ToString();
                nsct.Text = tablect.Rows[row].Cells[3].Value.ToString();
                aoct.Text = tablect.Rows[row].Cells[4].Value.ToString();
                cbxclb.Text = tablect.Rows[row].Cells[5].Value.ToString();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DataTable h = ct.DanhSach(keyct.Text);
            tablect.DataSource = h;
            for (int i = 0; i < tablect.Columns.Count; i++)
            {
                this.tablect.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ExportToExcel obj = new ExportToExcel();
            DataTable dt = ct.DanhSach();
            tablect.DataSource = dt;
            SaveFileDialog s = new SaveFileDialog();
            if (s.ShowDialog() == DialogResult.OK && tablect.RowCount > 0)
            {
                bool export = obj.ToExcel(dt, s.FileName, "Danh sách cầu thủ", dt.Columns.Count);
                MessageBox.Show("Xuất file thành công");
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (tenmg.Text == "")
            {
                MessageBox.Show("Yêu cầu nhập dữ liệu.");
            }
            else
            {
                mg.ThemMG(tenmg.Text);
                tenmg.Text = "";
                hienthimg();
                MessageBox.Show("Thêm mới thành công.");
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (mamg.Text == "")
            {
                MessageBox.Show("Yêu cầu chọn dữ liệu cần chỉnh sửa.");
            }
            else
            {
                mg.SuaMG(int.Parse(mamg.Text), tenmg.Text);
                mamg.Text = ""; tenmg.Text = "";
                hienthimg();
                MessageBox.Show("Sửa thành công.");
            }
            button20.Enabled = true;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (mamg.Text == "")
            {
                MessageBox.Show("Yêu cầu chọn bản ghi để xóa.");

            }
            else
            {
                if (MessageBox.Show("Bạn có muốn xóa mùa giải " + tenmg.Text + " không ?", "Thông báo xóa bản ghi", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    mg.XoaMG(int.Parse(mamg.Text));
                    MessageBox.Show("Xóa thành công");
                    mamg.Text = ""; tenmg.Text = "";
                    hienthimg();
                }

            }
            button20.Enabled = true;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            DataTable h = mg.DanhSach(keymg.Text);
            tablemg.DataSource = h;
            for (int i = 0; i < tablemg.Columns.Count; i++)
            {
                this.tablect.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void tablemg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;

            if (row >= 0)
            {
                mamg.Text = tablemg.Rows[row].Cells[0].Value.ToString();
                tenmg.Text = tablemg.Rows[row].Cells[1].Value.ToString();
            }
            button20.Enabled = false;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            ExportToExcel obj = new ExportToExcel();
            DataTable dt = ct.DanhSach();
            tablemg.DataSource = dt;
            SaveFileDialog s = new SaveFileDialog();
            if (s.ShowDialog() == DialogResult.OK && tablemg.RowCount > 0)
            {
                bool export = obj.ToExcel(dt, s.FileName, "Danh sách mùa giải", dt.Columns.Count);
                MessageBox.Show("Xuất file thành công");
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (cbx1.SelectedValue.ToString() == cbx2.SelectedValue.ToString())
            {
                MessageBox.Show("Yêu cầu chọn 2 đội khác nhau");
            }
            else
            {
                ltd.ThemLTD(int.Parse(cbx1.SelectedValue.ToString()), int.Parse(cbx2.SelectedValue.ToString()), date.Text, int.Parse(cbxsv.SelectedValue.ToString()), int.Parse(cbxmg.SelectedValue.ToString()));
                hienthiltd();
                MessageBox.Show("Thêm mới thành công.");
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (maltd.Text == "")
            {
                MessageBox.Show("Yêu cầu chọn dữ liệu cần chỉnh sửa.");
            }
            else
            {
                ltd.SuaLTD(int.Parse(maltd.Text), int.Parse(cbx1.SelectedValue.ToString()), int.Parse(cbx2.SelectedValue.ToString()), date.Text, int.Parse(cbxsvd.SelectedValue.ToString()), int.Parse(cbxmg.SelectedValue.ToString()));
                hienthiltd();
                MessageBox.Show("Sửa thành công.");
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (maltd.Text == "")
            {
                MessageBox.Show("Yêu cầu chọn bản ghi để xóa.");

            }
            else
            {
                if (MessageBox.Show("Bạn có muốn xóa trận đấu giữa " + cbx1.Text + " và " + cbx2.Text + " không ?", "Thông báo xóa bản ghi", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ltd.XoaLTD(int.Parse(maltd.Text));
                    MessageBox.Show("Xóa thành công");
                    hienthiltd();
                }
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            ExportToExcel obj = new ExportToExcel();
            DataTable dt = ltd.DanhSach();
            tableltd.DataSource = dt;
            SaveFileDialog s = new SaveFileDialog();
            if (s.ShowDialog() == DialogResult.OK && tableltd.RowCount > 0)
            {
                bool export = obj.ToExcel(dt, s.FileName, "Danh sách cầu thủ", dt.Columns.Count);
                MessageBox.Show("Xuất file thành công");
            }
        }

        private void tableltd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;

            if (row >= 0)
            {
                maltd.Text = tableltd.Rows[row].Cells[0].Value.ToString();
                cbx1.Text = tableltd.Rows[row].Cells[1].Value.ToString();
                cbx2.Text = tableltd.Rows[row].Cells[2].Value.ToString();
                cbxsv.Text = tableltd.Rows[row].Cells[3].Value.ToString();
                cbxmg.Text = tableltd.Rows[row].Cells[4].Value.ToString();
                date.Text = tableltd.Rows[row].Cells[5].Value.ToString();
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            DataTable h = ltd.DanhSach(int.Parse(cbxcmg.SelectedValue.ToString()));
            tablekq.DataSource = h;
            for (int i = 0; i < tablekq.Columns.Count; i++)
            {
                this.tablekq.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void tablekq_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;

            if (row >= 0)
            {
                matd.Text = tableltd.Rows[row].Cells[0].Value.ToString();
                clb1.Text = tableltd.Rows[row].Cells[1].Value.ToString();
                clb2.Text = tableltd.Rows[row].Cells[2].Value.ToString();
                cbxsv.Text = tableltd.Rows[row].Cells[3].Value.ToString();
                cbxmg.Text = tableltd.Rows[row].Cells[4].Value.ToString();
                date.Text = tableltd.Rows[row].Cells[5].Value.ToString();
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (matd.Text == "")
            {
                MessageBox.Show("Yêu cầu chọn trận đấu để ghi kết quả");
            }
            else
            {
                var madoi1 = 0;
                var madoi2 = 0;
                var idsvd = 0;
                ketnoi kn = new ketnoi();
                SqlConnection con = kn.GetConnection();
                SqlConnection con1 = kn.GetConnection();
                SqlConnection con2 = kn.GetConnection();
                con.Open();
                string sql1 = "select IdCLB1,IdCLB2,IdSVD from LichThiDau where Id='" +int.Parse(matd.Text) + "' ";
                SqlCommand cmd1 = new SqlCommand(sql1, con);
                SqlDataReader rd1 = cmd1.ExecuteReader();
                if (rd1.Read() == true)
                {
                    madoi1= int.Parse(rd1[0].ToString());
                    madoi2= int.Parse(rd1[1].ToString());
                    idsvd= int.Parse(rd1[2].ToString());
                }
                con1.Open();
                var krta1 = 0;
                string sql3 = "select * from CauLacBo where Id='" + madoi1 + "' and IdSVD='"+idsvd+"' ";
                SqlCommand cmd3 = new SqlCommand(sql3, con1);
                SqlDataReader rd3 = cmd3.ExecuteReader();
                if (rd3.Read() == true)
                {
                    krta1 = 1;
                }
                con2.Open();
                var krta2 = 0;
                string sql4 = "select * from CauLacBo where Id='" + madoi2 + "' and IdSVD='" + idsvd + "' ";
                SqlCommand cmd4 = new SqlCommand(sql4, con2);
                SqlDataReader rd4 = cmd4.ExecuteReader();
                if (rd4.Read() == true)
                {
                    krta2 = 1;
                }
                var diem1 = 0;
                var diem2 = 0;
                var bt11 = int.Parse(bt1.Text);
                var bt22=int.Parse(bt2.Text);   
                if(krta1 ==1 && bt11 > bt22)
                {
                    diem1 = 1;
                    diem2 = 0;
                }
                if (krta1 == 0 && krta2 == 0 && bt11 > bt22)
                {
                    diem1 = 1;
                    diem2 = 0;
                }
                if (krta1 == 0 && krta2 == 0 && bt11 < bt22)
                {
                    diem1 = 0;
                    diem2 = 1;
                }
                if (krta1 == 1 && bt11 > bt22)
                {
                    diem1 = 1;
                    diem2 = 0;
                }
                if (krta2 == 1&&bt22>bt11)
                {
                    diem1 = 0;
                    diem2 = 1;
                }
                if (krta2 == 1 && bt22 < bt11)
                {
                    diem1 = 1;
                    diem2 = 0;
                }
                if((krta1 == 1 || krta2 == 1)&&bt22==bt11)
                {
                    diem2 = 1;
                    diem1 = 1;
                }
                if (krta1 == 0 && krta2 == 0 && bt11 == bt22)
                {
                    diem1 = 1;
                    diem2 = 1;
                }
                KetQua kq = new KetQua();
                kq.ThemKQ(int.Parse(matd.Text), int.Parse(bt1.Text), int.Parse(bt2.Text));
                XepHang xh = new XepHang();
                var m1 = xh.kiemtra(int.Parse(cbxcmg.SelectedValue.ToString()), madoi1);
                if (m1 == 1)
                {
                    xh.SuaXH(int.Parse(cbxcmg.SelectedValue.ToString()), madoi1, diem1);
                }
                else
                {
                    xh.ThemXH(int.Parse(cbxcmg.SelectedValue.ToString()), madoi1, diem1);
                }
                var m2 = xh.kiemtra(int.Parse(cbxcmg.SelectedValue.ToString()), madoi2);
                if (m2 == 1)
                {
                    xh.SuaXH(int.Parse(cbxcmg.SelectedValue.ToString()), madoi2, diem2);
                }
                else
                {
                    xh.ThemXH(int.Parse(cbxcmg.SelectedValue.ToString()), madoi2, diem2);
                }
                matd.Text = "";
                clb1.Text = "";
                clb2.Text = "";
                bt1.Text = "";
                bt2.Text = "";
                MessageBox.Show("Cập nhật kết quả trận đấu thành công.");
                button29_Click(sender, e);
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void clb1_TextChanged(object sender, EventArgs e)
        {

        }

        private void matd_TextChanged(object sender, EventArgs e)
        {

        }

        private void tablekq_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}