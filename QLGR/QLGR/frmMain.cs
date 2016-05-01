using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using DAL;
using BUS;

namespace QLGR
{
    
    public partial  class frmMain : Form
    {
        //Khoi tao chuong trinh bang ky thuat Singleton
        #region Singleton

        frmMain()
        {
            InitializeComponent();
            Tat();
        }

        public static frmMain Instance
        {
            get
            {
                return Nested.instance;
            }

        }

        class Nested
        {

            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {}
            internal static readonly frmMain instance = new frmMain();

        }

        //Khoi tao thuoc tinh tabContol luc mo chuong trinh
        private void Tat()
        {
            this.tabControl1.TabPages.Remove(tabPage2);
            this.tabControl1.TabPages.Remove(tabPage3);
            this.tabControl1.TabPages.Remove(tabPage4);
            this.tabControl1.TabPages.Remove(tabPage5);
            this.tabControl1.TabPages.Remove(tabPage6);
            this.tabControl1.TabPages.Remove(tabPage7);
            this.tabControl1.TabPages.Remove(tabPage8);
            this.tabControl1.TabPages.Remove(tabPage9);

        }

        #endregion

        #region Fields

        //Fields
        Bus_HieuXe hx = new Bus_HieuXe();
        Bus_DichVu tc = new Bus_DichVu();
        Bus_VatTu vt = new Bus_VatTu();
        Bus_Users us = new Bus_Users();
        Bus_PTN tnx = new Bus_PTN();

        #endregion

        //Form Load
        private void frmMain_Load(object sender, EventArgs e)
        {
            hienThi();
        }
        private void hienThi()
        {
            //datagridview HieuXe
            gwHX.DataSource = hx.GetData();
            btnHX5_Click(null, null);

            //datagridview DichVu
            gwDV.DataSource = tc.GetData();
            btnTC5_Click(null, null);

            //datagridview VatTu
            gwVT.DataSource = vt.GetData();
            btnVT5_Click(null, null);

            //datagridview NhanVien
            gwNV.DataSource = us.GetData();

            //datagridview TiepNhanXe
            gwTNX.DataSource = tnx.GetData();
        }

        //Exit Button
        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Sign out button
        private void dangXuat_Click(object sender, EventArgs e)
        {
            frmDN.Instance.Show();
            this.Hide();

        }

        //Dieu khien TabControl
        #region Some Property of control Tab and others

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            //This code will render a "x" mark at the end of the Tab caption. 
            e.Graphics.DrawString("x", e.Font, Brushes.Black, e.Bounds.Right - 19, e.Bounds.Top + 4);
            e.Graphics.DrawString(this.tabControl1.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 12, e.Bounds.Top + 4);
            e.DrawFocusRectangle();
        }

        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 1; i < this.tabControl1.TabPages.Count; i++)
            {
                Rectangle rPage = tabControl1.GetTabRect(i);
                Rectangle closeButton = new Rectangle(rPage.Right - 18, rPage.Top + 5, 15 , 15);
                if (closeButton.Contains(e.Location))
                    this.tabControl1.TabPages.RemoveAt(i);
            }
        }

        private void dichVu_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Add(tabPage3);
            tabControl1.SelectedTab = tabPage3;
            
        }

        private void hieuXe_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Add(tabPage2);
            tabControl1.SelectedTab = tabPage2;
        }

        private void phuTung_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage4);
            tabControl1.TabPages.Add(tabPage4);
            tabControl1.SelectedTab = tabPage4;
        }

        private void nhanVien_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage5);
            tabControl1.TabPages.Add(tabPage5);
            tabControl1.SelectedTab = tabPage5;
        }

        private void TNXe_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage6);
            tabControl1.TabPages.Add(tabPage6);
            tabControl1.SelectedTab = tabPage6;
            //Load MaHx len combobox
            txtHX.DataSource = gwHX.DataSource;
            txtHX.DisplayMember = "TenHX";
            txtHX.ValueMember = "MaHX";
        }

        private void nhapPT_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage7);
            tabControl1.TabPages.Add(tabPage7);
            tabControl1.SelectedTab = tabPage7;
        }

        private void QLSC_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage8);
            tabControl1.TabPages.Add(tabPage8);
            tabControl1.SelectedTab = tabPage8;
        }

        private void QD_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage9);
            tabControl1.TabPages.Add(tabPage9);
            tabControl1.SelectedTab = tabPage9;
        }

        //Solve checkbox in User table
        private void nam_CheckedChanged(object sender, EventArgs e)
        {
            if (nam.Checked == true)
                nu.Checked = false;
        }

        private void nu_CheckedChanged(object sender, EventArgs e)
        {
            if (nu.Checked == true)
                nam.Checked = false;
        }

        #endregion
       
        //////////////////////////////
        ///Tao hieu ung mouse hover
        //////////////////////////////
        #region Mouse Effect
        private void hieuXe_MouseHover(object sender, EventArgs e)
        {
            pnlHieuXe.BackColor = Color.MintCream;

        }

        private void hieuXe_MouseLeave(object sender, EventArgs e)
        {
            pnlHieuXe.BackColor = Color.Transparent;
        }

        private void dichVu_MouseHover(object sender, EventArgs e)
        {
            pnlDichVu.BackColor = Color.MintCream;
        }

        private void dichVu_MouseLeave(object sender, EventArgs e)
        {
            pnlDichVu.BackColor = Color.Transparent;
        }

        private void phuTung_MouseHover(object sender, EventArgs e)
        {
            pnlVatTu.BackColor = Color.MintCream;
        }

        private void phuTung_MouseLeave(object sender, EventArgs e)
        {
            pnlVatTu.BackColor = Color.Transparent;
        }

        private void nhanVien_MouseHover(object sender, EventArgs e)
        {
            pnlNV.BackColor = Color.MintCream;
        }

        private void nhanVien_MouseLeave(object sender, EventArgs e)
        {
            pnlNV.BackColor = Color.Transparent;
        }

        private void TNXe_MouseHover(object sender, EventArgs e)
        {
            pnlTNX.BackColor = Color.MintCream;
        }

        private void TNXe_MouseLeave(object sender, EventArgs e)
        {
            pnlTNX.BackColor = Color.Transparent;
        }

        private void nhapPT_MouseHover(object sender, EventArgs e)
        {
            pnlNVT.BackColor = Color.MintCream;
        }

        private void nhapPT_MouseLeave(object sender, EventArgs e)
        {
            pnlNVT.BackColor = Color.Transparent;
        }

        private void QLSC_MouseHover(object sender, EventArgs e)
        {
            pnlQLSC.BackColor = Color.MintCream;
        }

        private void QLSC_MouseLeave(object sender, EventArgs e)
        {
            pnlQLSC.BackColor = Color.Transparent;
        }

        private void QD_MouseHover(object sender, EventArgs e)
        {
            pnlTDQD.BackColor = Color.MintCream;
        }

        private void QD_MouseLeave(object sender, EventArgs e)
        {
            pnlTDQD.BackColor = Color.Transparent;
        }

        private void DSPSX_MouseHover(object sender, EventArgs e)
        {
            pnlDSPX.BackColor = Color.MintCream;
        }

        private void DSPSX_MouseLeave(object sender, EventArgs e)
        {
            pnlDSPX.BackColor = Color.Transparent;
        }

        private void DSX_MouseHover(object sender, EventArgs e)
        {
            pnlDSX.BackColor = Color.MintCream;
        }

        private void DSX_MouseLeave(object sender, EventArgs e)
        {
            pnlDSX.BackColor = Color.Transparent;
        }

        private void BC_TK_MouseHover(object sender, EventArgs e)
        {
            pnlBC.BackColor = Color.MintCream;
        }

        private void BC_TK_MouseLeave(object sender, EventArgs e)
        {
            pnlBC.BackColor = Color.Transparent;
        }

        private void doanhSo_MouseHover(object sender, EventArgs e)
        {
            pnlDS.BackColor = Color.MintCream;
        }

        private void doanhSo_MouseLeave(object sender, EventArgs e)
        {
            pnlDS.BackColor = Color.Transparent;
        }

        private void TKX_MouseHover(object sender, EventArgs e)
        {
            pnlTKX.BackColor = Color.MintCream;
        }

        private void TKX_MouseLeave(object sender, EventArgs e)
        {
            pnlTKX.BackColor = Color.Transparent;
        }

        private void TKPSC_MouseHover(object sender, EventArgs e)
        {
            pnlTKPSC.BackColor = Color.MintCream;
        }

        private void TKPSC_MouseLeave(object sender, EventArgs e)
        {
            pnlTKPSC.BackColor = Color.Transparent;
        }

        private void TTBT_MouseHover(object sender, EventArgs e)
        {
            pnlTTBT.BackColor = Color.MintCream;
        }

        private void TTBT_MouseLeave(object sender, EventArgs e)
        {
            pnlTTBT.BackColor = Color.Transparent;
        }

        private void dangXuat_MouseHover(object sender, EventArgs e)
        {
            pnlDX.BackColor = Color.MintCream;
        }

        private void dangXuat_MouseLeave(object sender, EventArgs e)
        {
            pnlDX.BackColor = Color.Transparent;
        }

        private void gioiThieu_MouseHover(object sender, EventArgs e)
        {
            pnlGT.BackColor = Color.MintCream;
        }

        private void gioiThieu_MouseLeave(object sender, EventArgs e)
        {
            pnlGT.BackColor = Color.Transparent;
        }

        private void help_MouseHover(object sender, EventArgs e)
        {
            pnlGD.BackColor = Color.MintCream;
        }

        private void help_MouseLeave(object sender, EventArgs e)
        {
            pnlGD.BackColor = Color.Transparent;
        }

        private void exit_MouseHover(object sender, EventArgs e)
        {
            pnlExit.BackColor = Color.MintCream;
        }

        private void exit_MouseLeave(object sender, EventArgs e)
        {
            pnlExit.BackColor = Color.Transparent;
        }
        private void pic1_MouseHover(object sender, EventArgs e)
        {
            panel1.BackColor = Color.MintCream;
        }

        private void pic1_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Transparent;
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            panel2.BackColor = Color.MintCream;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            panel2.BackColor = Color.Transparent;
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            panel3.BackColor = Color.MintCream;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            panel3.BackColor = Color.Transparent;
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            panel4.BackColor = Color.MintCream;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            panel4.BackColor = Color.Transparent;
        }
        #endregion

        /////////////////////////////
        /// <Tag Hieu Xe>
        /////////////////////////////
        #region Hieu Xe

        //Load data of selecting Row to textBox
        private void gwHX_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in gwHX.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                txtMHX.Text = row.Cells["MaHX"].Value.ToString();
                txtTHX.Text = row.Cells["TenHX"].Value.ToString();
            }
        }

        //Add button
        private void btnHX1_Click(object sender, EventArgs e)
        {
            this.txtTHX.Text = "";
            this.btnHX1.Enabled = false;
            this.btnHX2.Enabled = false;
            this.btnHX3.Enabled = false;
            this.btnHX4.Enabled = true;
            this.btnHX5.Enabled = true;
        }

        //Delete button
        private void btnHX2_Click(object sender, EventArgs e)
        {
            SQL_HieuXe _hx = new SQL_HieuXe();
            _hx.SMaHX = txtMHX.Text;
            if (MessageBox.Show("Bạn có chắc muốn xóa?", "Cảnh báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (hx.DelHX(_hx) == true)
                {
                    MessageBox.Show("Xóa Thành Công! ^^! ", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gwHX.DataSource = hx.GetData();
                }
                else
                    MessageBox.Show("Không thể xóa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Edit button
        private void btnHX3_Click(object sender, EventArgs e)
        {
            SQL_HieuXe _hx = new SQL_HieuXe();
            if (this.txtMHX.Text == "" || this.txtTHX.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _hx.SMaHX = txtMHX.Text;
            _hx.STenHX = txtTHX.Text;
            if (hx.UpdateHX(_hx) == true)
            {
                MessageBox.Show("Sửa thành công Nhân viên " + _hx.STenHX , "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gwHX.DataSource = hx.GetData();
            }
            else
                MessageBox.Show("Không thể sửa!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Insert button
        private void btnHX4_Click(object sender, EventArgs e)
        {
            SQL_HieuXe _hx = new SQL_HieuXe();
            if (this.txtMHX.Text == "" || this.txtTHX.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _hx.SMaHX = txtMHX.Text;
            _hx.STenHX = txtTHX.Text;
            if (hx.InsertHX(_hx) == true)
            {
                MessageBox.Show("Thêm thành công Hiệu xe " + _hx.STenHX, "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gwHX.DataSource = hx.GetData();
            }
            else
                MessageBox.Show("Không thể thêm!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Cancel button
        private void btnHX5_Click(object sender, EventArgs e)
        {
            this.btnHX1.Enabled = true;
            this.btnHX2.Enabled = true;
            this.btnHX3.Enabled = true;
            this.btnHX4.Enabled = false;
            this.btnHX5.Enabled = false;
        }

        #endregion

        /////////////////////////////
        /// <Tag Dich Vu>
        /////////////////////////////
        #region DichVu

        //Load data of selecting Row to textBox
        private void gwDV_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in gwDV.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                
                DataGridViewRow row = cell.OwningRow;
                txtMTC.Text = row.Cells["MaTC"].Value.ToString();
                txtTTC.Text = row.Cells["TenTC"].Value.ToString();
                txtGT.Text = String.Format("{0:0,0}", row.Cells["GiaTien"].Value);
            }
        }

        //Add button
        private void btnTC1_Click(object sender, EventArgs e)
        {
            this.txtTTC.Text = "";
            this.txtGT.Text = "";
            this.btnTC1.Enabled = false;
            this.btnTC2.Enabled = false;
            this.btnTC3.Enabled = false;
            this.btnTC4.Enabled = true;
            this.btnTC5.Enabled = true;
        }

        //Del button
        private void btnTC2_Click(object sender, EventArgs e)
        {
            SQL_DichVu dv = new SQL_DichVu();
            dv.SMaTC = this.txtMTC.Text;
            if (MessageBox.Show("Bạn có chắc muốn xóa?", "Cảnh báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (tc.DelDV(dv) == true)
                {
                    MessageBox.Show("Xóa thành công!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gwDV.DataSource = tc.GetData();
                }
                else
                    MessageBox.Show("Không thể xóa!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Edit button
        private void btnTC3_Click(object sender, EventArgs e)
        {
            SQL_DichVu dv = new SQL_DichVu();
            if (this.txtMTC.Text == "" || this.txtTTC.Text == "" || this.txtGT.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dv.SMaTC = this.txtMTC.Text;
            dv.STenTC = this.txtTTC.Text;
            dv.SGiaTien = Int32.Parse(this.txtGT.Text.Replace(",", ""));
            if (tc.UpdateDV(dv) == true)
            {
                MessageBox.Show("Sửa thành công dịch vụ " + dv.STenTC, "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gwDV.DataSource = tc.GetData();
            }
            else
                MessageBox.Show("Không thể sửa!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Save button
        private void btnTC4_Click(object sender, EventArgs e)
        {
            SQL_DichVu dv = new SQL_DichVu();
            if(this.txtMTC.Text == "" || this.txtTTC.Text == "" || this.txtGT.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dv.SMaTC = this.txtMTC.Text;
            dv.STenTC = this.txtTTC.Text;
            dv.SGiaTien = Int32.Parse(this.txtGT.Text.Replace(",",""));
            if (tc.InsertDV(dv) == true)
            {
                MessageBox.Show("Thêm thành công dịch vụ " + dv.STenTC, "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gwDV.DataSource = tc.GetData();
            }
            else
                MessageBox.Show("Không thể thêm!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Cancel button
        private void btnTC5_Click(object sender, EventArgs e)
        {
            this.btnTC1.Enabled = true;
            this.btnTC2.Enabled = true;
            this.btnTC3.Enabled = true;
            this.btnTC4.Enabled = false;
            this.btnTC5.Enabled = false;
        }

        #endregion

        /////////////////////////////
        /// <Tag Vat Tu>
        /////////////////////////////
        #region Vat Tu

        //Load data of selecting Row to textBox
        private void gwVT_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in gwVT.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {

                DataGridViewRow row = cell.OwningRow;
                txtMVT.Text = row.Cells["MaVT"].Value.ToString();
                txtTVT.Text = row.Cells["TenVT"].Value.ToString();
                txtSLVT.Text = row.Cells["SL"].Value.ToString();
                txtDGVT.Text = String.Format("{0:0,0}", row.Cells["DonGia"].Value);
            }
        }

        //Add button
        private void btnVT1_Click(object sender, EventArgs e)
        {
            this.txtTVT.Text = "";
            this.txtDGVT.Text = "";
            this.txtSLVT.Text = "";
            this.btnVT1.Enabled = false;
            this.btnVT2.Enabled = false;
            this.btnVT3.Enabled = false;
            this.btnVT4.Enabled = true;
            this.btnVT5.Enabled = true;

        }

        //Del button
        private void btnVT2_Click(object sender, EventArgs e)
        {
            SQL_VatTu _vt = new SQL_VatTu();
            _vt.SMaVT = this.txtMVT.Text;
            if (MessageBox.Show("Bạn có chắc muốn xóa?", "Cảnh báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (vt.DelVT(_vt) == true)
                {
                    MessageBox.Show("Xóa Thành Công! ^^! ", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gwVT.DataSource = vt.GetData();
                }
                else
                    MessageBox.Show("Không thể xóa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Edit button
        private void btnVT3_Click(object sender, EventArgs e)
        {
            SQL_VatTu _vt = new SQL_VatTu();
            if(this.txtMVT.Text == "" || this.txtTVT.Text == "" || this.txtSLVT.Text == "" || this.txtDGVT.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _vt.SMaVT = this.txtMVT.Text;
            _vt.STenVT = this.txtTVT.Text;
            _vt.SSL = Int32.Parse(this.txtSLVT.Text);
            _vt.SDonGia = Int32.Parse(this.txtDGVT.Text.Replace(",", ""));
            if (vt.UpdateVT(_vt) == true)
            {
                MessageBox.Show("Sửa thành công vật tư " + _vt.STenVT , "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gwVT.DataSource = vt.GetData();
            }
            else
                MessageBox.Show("Không thể sửa!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Save button
        private void btnVT4_Click(object sender, EventArgs e)
        {
            SQL_VatTu _vt = new SQL_VatTu();
            if (this.txtMVT.Text == "" || this.txtTVT.Text == "" || this.txtSLVT.Text == "" || this.txtDGVT.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _vt.SMaVT = this.txtMVT.Text;
            _vt.STenVT = this.txtTVT.Text;
            _vt.SSL = Int32.Parse(this.txtSLVT.Text);
            _vt.SDonGia = Int32.Parse(this.txtDGVT.Text.Replace(",", ""));
            if (vt.InsertVT(_vt) == true)
            {
                MessageBox.Show("Thêm thành công vật tư " + _vt.STenVT, "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gwVT.DataSource = vt.GetData();
            }
            else
                MessageBox.Show("Vật tư vừa thêm đã có trong danh sách!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Cancel button
        private void btnVT5_Click(object sender, EventArgs e)
        {
            this.btnVT1.Enabled = true;
            this.btnVT2.Enabled = true;
            this.btnVT3.Enabled = true;
            this.btnVT4.Enabled = false;
            this.btnVT5.Enabled = false;


        }

        #endregion

        private void btnTNX1_Click(object sender, EventArgs e)
        {

        }

        private void lblDichVu_Click(object sender, EventArgs e)
        {

        }

        
    }
}
