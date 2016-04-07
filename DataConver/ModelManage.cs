using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DataConver
{
    public partial class ModelManage : Form
    {
        private Setting set;
        public ModelManage()
        {
            InitializeComponent();
            listviewSet(this.listView1);
            set = new Setting();
        }

        private void listviewSet(System.Windows.Forms.ListView Deal_Data)
        {
            Deal_Data.SmallImageList = imageList1;
            Deal_Data.MultiSelect = false;
            Deal_Data.GridLines = true;
            Deal_Data.FullRowSelect = true;
            Deal_Data.CheckBoxes = false;
            Deal_Data.View = View.Details;
        }

        private void ModelManage_Load(object sender, EventArgs e)
        {

            listView1.Columns.Add("地图模板名称", 300);
            refreshListView(this.listView1);
        }
//---------------------------触发函数-------------------------------------
        private void 更换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Change(true);
        }
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteMod(this.listView1);
        }
        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Change(false);
        }
        //----------------------------功能函数----------------------------------

        /// <summary>
        /// 刷新listview
        /// </summary>
        /// <param name="listView1"></param>
        private void refreshListView(ListView listView1)
        {
            DirectoryInfo di = new DirectoryInfo(set.mod);

            foreach (FileInfo ff in di.GetFiles("*.xml"))
            {
                ListViewItem lv = new ListViewItem();
                lv.ImageIndex = 0;
                lv.Text = ff.Name;
                listView1.Items.Add(lv);
            }
        }
        /// <summary>
        /// 更新函数
        /// </summary>
        /// <param name="change">判断是否为更换还是新增</param>
        /// <returns></returns>
        private bool Change(bool change)
        {
            string Chg = "是否更换地图模板:";
            string add = "是否新增地图模板：";
            string mesg = null;
            try
            {
                if (listView1.SelectedItems.Count == 0 && change)
                {
                    MessageBox.Show("请选中要编辑的模板");

                    return false;
                }
                else
                {
                    if (change)
                        mesg = Chg;
                    else
                        mesg = add;
                    OpenFileDialog sfd = new OpenFileDialog();
                    sfd.Title = "打开";
                    sfd.Filter = "地图模板|*.xml";
                    //sfd.Multiselect = true;
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        if (MessageBox.Show(mesg + sfd.SafeFileName, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            File.Copy(sfd.FileName, set.mod + "\\" + sfd.SafeFileName, true);
                            if (change)
                            {
                                if (sfd.SafeFileName != listView1.FocusedItem.Text)
                                    File.Delete(set.mod + "\\" + listView1.FocusedItem.Text);
                            }
                            MessageBox.Show("操作成功！");
                            listView1.Items.Clear();
                            refreshListView(this.listView1);
                        }

                        return true;
                    }
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }
        /// <summary>
        /// 删除函数
        /// </summary>
        private void deleteMod(ListView listView1)
        {
            try
            {
                if (listView1.SelectedItems.Count == 0)
                {
                    MessageBox.Show("请选中要编辑的模板");

                    return;
                }
                else
                {
                    if (MessageBox.Show("确定要删除文件：" + listView1.FocusedItem.Text, "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                       
                        deleteFiles(set.mod + "\\" + listView1.FocusedItem.Text);
                        listView1.FocusedItem.Remove();
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

        /// <summary>
        /// 右键菜单显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(this.listView1, e.Location);
            }
        }
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="strDir"></param>
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

       
    }
}
