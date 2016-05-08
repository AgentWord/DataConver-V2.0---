using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using SuperMap;

using System.Threading;


namespace DataConver
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
       
        public string userName;
        private SuperMap.Data.Workspace m_workspace;
        private SuperMapTool importTool;
        public string Undeal_heduanX;
        private string Undeal_heduan;
        private string Deal_heduanX;
        private string Deal_heduan;
        
        private Setting set = new Setting();
      
        private const string TIFFPath = "";
        private List<string> list = new List<string>();
        private string undeal_Path = "";
        private DataConverTool DCT;
        private DirectoryInfo di;
        public string passWord = "admin";
        private string heduan ;
        private string deal_data;
        //构造函数
        public MainForm()
        {
            InitializeComponent();
         
          
            importTool = new SuperMapTool(m_workspace);
            listviewSet(Lis_UndealData);
            listviewSet(Lis_DealData);
            DataManager();
            UISetting();

        }
        private void DataManager()
        {
           // back.Enabled = back2.Enabled = true;

            if (set.report == "OK")
            {
                heduan = set.undeal_Path;
                deal_data = set.deal_path;
                importTool.createFolder(heduan);
                importTool.createFolder(deal_data);
                openFolder(Lis_UndealData, set.undeal_Path);
                openFolder1(Lis_DealData, set.deal_path);
            }

        }
        private void UISetting()
        {
           
            MessageShow.Text = "说明：此转换工具仅适用于洪水风险图——移动风险监测平板标准编制单元预处理工作,请单击开始处理执行操作···";

            //设置进度条
            progressBar.Properties.ShowTitle = true;
            progressBar.EditValue = "待命···";
            progressBar.Properties.Stopped = true;
            //设置路径
            //undeal_path.Text = System.IO.Path.Combine(undeal_Path + "\\" + list[0]);
            //passWord = textEdit1.Text;
            DCT = new DataConverTool(this.lab_progress, this.labelX3, this.progressBar, this.MessageShow,this.axMapControl1);
            undeal_Path = Undeal_heduan;
        }
        //用户退出
        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult result = MessageBox.Show("您是否退出并保存所有操作？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                this.Close();
            }
            else
                return;
           
        }
        //窗口载入
        private void MainForm_Load(object sender, EventArgs e)
        {
           // MessageBox.Show(set.setupPath);
            int l = this.Width;
            //splitContainerControl1.SplitterPosition = l / 3;
            if (set.report != "OK")
            {
                set.StartPosition = FormStartPosition.CenterScreen;
                set.Show();
                set.TopMost = true;
            }
          
        }

        
        //数据管理
        private void Data_vec_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            set.set_Value();
            DataManager();
        }
        
        private void listviewSet(System.Windows.Forms.ListView Deal_Data)
        {
            Deal_Data.SmallImageList = imageList1;
            Deal_Data.MultiSelect = true;
            Deal_Data.GridLines = true;
            Deal_Data.FullRowSelect = true;
            //Deal_Data.CheckBoxes = false;
            Deal_Data.View = View.List;
        }

       
        //帮助
        private void User_help_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //MessageBox.Show("有关技术帮助请咨询" + "\r\n" + "北京超图软件股份有限公司", "帮助", MessageBoxButtons.OK, MessageBoxIcon.Information);
            OpenFolderAndSelectFile(set.setupPath);
        }
        private void OpenFolderAndSelectFile(String fileFullName)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe") { Arguments = "/e,/select/," + fileFullName };
            System.Diagnostics.Process.Start(psi);
        }
        //读取XML
        public String readXML(string pathOfXML)
        {
           string ss = File.ReadAllText(pathOfXML, Encoding.Default);
            return ss;
        }
       
        private void User_set_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Setting set = new Setting() { StartPosition = FormStartPosition.CenterScreen };
            set.ShowDialog();
            set.TopMost=true;
        }

        private void Model_Manage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ModelManage model = new ModelManage() { StartPosition = FormStartPosition.CenterScreen };
            model.Show();
            model.TopMost = true;
        }
        //处理函数
        private void openFolder(System.Windows.Forms.ListView lisview, string hd)
        {
            try
            {
                lisview.Items.Clear();
                DirectoryInfo di = new DirectoryInfo(hd);
                foreach (DirectoryInfo dd in di.GetDirectories())
                {
                    ListViewItem li = new ListViewItem();
                    Undeal_heduanX = dd.Parent.FullName;
                    //Undeal_heduan = dd.Parent.Parent.FullName;
                    li.Text = dd.Name;
                    li.ImageIndex = 5;
                    lisview.Items.Add(li);
                }



            }
            catch 
            {
                //MessageBox.Show("已是主目录");
                //Pag_UndealData.Text = set.undeal_Path;
                openFolder(Lis_UndealData, set.undeal_Path);
                
            }
        }
        private void openFolder1(System.Windows.Forms.ListView lisview, string hd)
        {
            try
            {
                lisview.Items.Clear();
                DirectoryInfo di = new DirectoryInfo(hd);
                foreach (DirectoryInfo dd in di.GetDirectories())
                {
                    ListViewItem li = new ListViewItem();
                    Deal_heduanX = dd.Parent.FullName;
                    Deal_heduan = dd.Parent.Parent.FullName;
                    li.Text = dd.Name;
                    li.ImageIndex = 5;
                    lisview.Items.Add(li);
                }
                foreach (FileInfo mm in di.GetFiles("*.shp"))
                {
                    ListViewItem lii = new ListViewItem() { Text = mm.Name, ImageIndex = 1 };
                    lisview.Items.Add(lii);
                }
                foreach (FileInfo mm in di.GetFiles("*.tif"))
                {
                    ListViewItem lii = new ListViewItem() { Text = mm.Name, ImageIndex = 2 };
                    lisview.Items.Add(lii);
                }
                foreach (FileInfo mm in di.GetFiles("*.udb"))
                {
                    ListViewItem lii = new ListViewItem() { Text = mm.Name, ImageIndex = 4 };
                    lisview.Items.Add(lii);
                }
              

            }
            catch
            {
                MessageBox.Show("已是主目录");
                //Pag_ProcessMsg.Text = set.deal_path;
                openFolder1(Lis_DealData,  set.deal_path);
              
            }
        }
        //未处理数据的实现功能
        private void UnDeal_Data_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Undeal_Menu_Tool.Show(this.Lis_UndealData, e.Location);
            }
        }
        private void 打开Undeal_Menu_Tool_Click(object sender, EventArgs e)
        {
            try
            {
                if (Lis_UndealData.FocusedItem == null)
                {
                    return;
                }
                else
                {
                    Undeal_heduanX = String.Format("{0}\\{1}", Undeal_heduanX, Lis_UndealData.FocusedItem.Text);
                    //Pag_UndealData.Text = Undeal_heduanX;
                    openFolder(Lis_UndealData, Undeal_heduanX);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void 返回Undeal_Menu_Tool_Click(object sender, EventArgs e)
        {
            try
            { 
                //Pag_UndealData.Text = Undeal_heduan;
                openFolder(Lis_UndealData, Undeal_heduan);
            }
            catch
            {
                MessageBox.Show("已是主目录");
                openFolder(Lis_UndealData, set.undeal_Path);
            }
        }
        private void 删除Undeal_Menu_Tool_Click(object sender, EventArgs e)
        {
            try
            {
                if (Lis_UndealData.FocusedItem == null)
                    return;
                else
                {
                    if (MessageBox.Show("确定要删除文件：" + Lis_UndealData.FocusedItem.Text, "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        deleteFiles(String.Format("{0}\\{1}", Undeal_heduanX, Lis_UndealData.FocusedItem.Text));
                        Lis_UndealData.FocusedItem.Remove();
                    }
                    else
                        return;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void 大图标Undeal_Menu_Tool_Click(object sender, EventArgs e)
        {
            Lis_UndealData.LargeImageList = imageList1;
            Lis_UndealData.View = View.LargeIcon;
        }
        private void 列表Undeal_Menu_Tool_Click(object sender, EventArgs e)
        {
            Lis_UndealData.LargeImageList = imageList1;
            Lis_UndealData.View = View.List;
        }
        private void Undeal_back_Click(object sender, EventArgs e)
        {
            try
            { 
                //Pag_UndealData.Text = Undeal_heduan;
                openFolder(Lis_UndealData, Undeal_heduan);
            }
            catch
            {
                MessageBox.Show("已是主目录");
                openFolder(Lis_UndealData, set.undeal_Path);
            }
        }
        //已处理数据管理
        private void Deal_Data_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Deal_Menu_Tool.Show(this.Lis_DealData, e.Location);
            }

        }
        private void 打开Deal_Menu_Tool_Click(object sender, EventArgs e)
        {
            try
            {
                if (Lis_DealData.FocusedItem == null)
                {
                    return;
                }
                else
                {
                    Deal_heduanX = String.Format("{0}\\{1}", Deal_heduanX, Lis_DealData.FocusedItem.Text);
                    //Pag_ProcessMsg.Text = Deal_heduanX;
                    openFolder1(Lis_DealData, Deal_heduanX);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Deal_Data_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Lis_DealData.SelectedItems == null)
            {
                return;
            }
            else
            {
                Deal_heduanX = String.Format("{0}\\{1}", Deal_heduanX, Lis_DealData.FocusedItem.Text);
                //Pag_ProcessMsg.Text = Deal_heduanX;
                openFolder1(Lis_DealData, Deal_heduanX);
            }
        }
        private void 返回Deal_Menu_Tool_Click(object sender, EventArgs e)
        {
            try
            {
                //Pag_ProcessMsg.Text = Deal_heduan;
                openFolder1(Lis_DealData, Deal_heduan);
            }
            catch
            {
                MessageBox.Show("已是主目录");
                openFolder1(Lis_DealData, set.deal_path);
            }
        }
        private void 删除Deal_Menu_Tool_Click(object sender, EventArgs e)
        {
            try
            {
                if (Lis_DealData.FocusedItem == null)
                    return;
                else
                {
                    if (MessageBox.Show("确定要删除文件：" + Lis_DealData.FocusedItem.Text, "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        deleteFiles(String.Format("{0}\\{1}", Deal_heduanX, Lis_DealData.FocusedItem.Text));
                        Lis_DealData.FocusedItem.Remove();
                    }
                    else
                        return;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void 大图标Deal_Menu_Tool_Click(object sender, EventArgs e)
        {
            Lis_DealData.LargeImageList = imageList1;
            Lis_DealData.View = View.LargeIcon;
        }
        private void 列表Deal_Menu_Tool_Click(object sender, EventArgs e)
        {
            Lis_DealData.LargeImageList = imageList1;
            Lis_DealData.View = View.List;
        }
        public static void deleteFiles(string strDir)
        {
            if (Directory.Exists(strDir))
            {
                Directory.Delete(strDir, true);
                MessageBox.Show("删除成功！");
            }
            else if (File.Exists(strDir))
            {
                File.Delete(strDir);
                MessageBox.Show("删除成功！");
            }
            else
            {
                MessageBox.Show("此目录不存在！");
            }
        }
        private void Deal_back_Click(object sender, EventArgs e)
        {
            try
            {
                //Pag_ProcessMsg.Text = Deal_heduan;
                openFolder1(Lis_DealData, Deal_heduan);
            }
            catch
            {
                MessageBox.Show("已是主目录");
                openFolder1(Lis_DealData, set.deal_path);
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            OpenFolderAndSelectFile(set.undeal_Path);
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            OpenFolderAndSelectFile(set.deal_path);
        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show(String.Format("系统{0}是否要终止操作？\r\n并且将会退出整个系统！", lab_progress.Text), "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
               {

                  System.Diagnostics.Process.GetCurrentProcess().Kill();
                   //this.Close();
             }
                else
                  return;

            //}
          
        }

        private void but_Start_Click(object sender, EventArgs e)
        {
            bool IsSuccessful = false;
            
            this.but_Start.Enabled = false;
            this.but_Start.Text = "正在处理";
            MessageShow.Clear();
            if (!System.IO.Directory.Exists(undeal_pathway.Text))//|| !System.IO.Directory.Exists(ymgc_tifPath.Text)
            {
                MessageBox.Show("请输入正确编制单元路径···", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageShow.Text = "请输入正确编制单元路径···";
                this.but_Start.Enabled = true;
                this.but_Start.Text = "开始处理"; return;
            }
            //this.Cursor = Cursors.WaitCursor;
            progressBar.Properties.Stopped = false;
            DateTime dtAll = DateTime.Now;
            foreach (string manyDeal in list)
            {
                undeal_pathway.Text = String.Format("{0}\\{1}", this.Undeal_heduanX, manyDeal);
                di = new DirectoryInfo(undeal_pathway.Text);
                //数据检查工具|| di.GetDirectories("tiffPath").Length == 0
                if (di.GetDirectories("*地图数据库与图件成果",SearchOption.AllDirectories).Length == 0 || di.GetDirectories("*风险图应用业务相关数据",SearchOption.AllDirectories).Length == 0)//更新查找数据方式
                {
                    MessageBox.Show(String.Format("请检查{0}文件下数据完整性！", manyDeal), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }
                try
                {

                    IsSuccessful = DCT.DealAll(undeal_pathway.Text, passWord);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            progressBar.Properties.Stopped = true;

            //this.Cursor = Cursors.Default;
            string dtall = "总用时：" + DCT.ExecDateDiff(dtAll, DateTime.Now);
            //MessageBox.Show("处理完成!" + "\r\n" + dtall, "提示");
            progressBar.EditValue = lab_progress.Text;
            if (IsSuccessful)
                MessageBox.Show(String.Format("{0}\r\n{1}", lab_progress.Text, dtall), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.but_Start.Enabled = true;
            this.but_Start.Text = "开始处理";
        }

        private void but_undeal_Click(object sender, EventArgs e)
        {
            importTool.openFolder(undeal_pathway);
        }

        private void Lis_UndealData_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            test();
        }
        private void test()
        {
            list = new List<string>();
            for (int i = 0; i < Lis_UndealData.Items.Count; i++)
            {
                if (Lis_UndealData.Items[i].Checked)
                {
                    list.Add(Lis_UndealData.Items[i].Text);
                }

            }
            if (list.Count == 0)
            {
               
                undeal_pathway.Text = null; return;
            }
            else
            {


                undeal_pathway.Text = System.IO.Path.Combine(String.Format("{0}\\{1}", Undeal_heduanX, list[0]));

            }
        }

        private void but_password_Click_1(object sender, EventArgs e)
        {
            //password(true);
           passWord = Microsoft.VisualBasic.Interaction.InputBox("请输入保护数据安全的密码：", "设置密码", passWord);

            
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("【洪水风险图移动端数据预处理工具V2.0】", "关于", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void barButtonItem7_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Tiff tif = new Tiff(undeal_pathway.Text) { StartPosition = FormStartPosition.CenterScreen };
            //tif.TopMost = true;
            tif.Show();
        }

        private void axMapControl1_OnMouseDown(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseDownEvent e)
        {
            if (e.button == 2)
            {
                axMapControl1.Pan();
            }
        }
    }
}
