using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SuperMap;
using System.IO;

namespace DataConver
{
    public partial class Tiff : Form
    {
        private SuperMapTool importTool;//定义工具类
        private DataConver.DataConverTool dct;
        private string savaPathInitialize;
        
        //private ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
        public Tiff(string outPut_Path)
        {
            InitializeComponent();
            this.savaPathInitialize = outPut_Path;
            SuperMap.Data.Workspace m_workspace = new SuperMap.Data.Workspace();
            importTool = new SuperMapTool(m_workspace);
            dct = new DataConverTool(this.ExtractMesg, null, this.progressView, null, null);
            this.progressView.Properties.Stopped = true;
            SavaFolder.Text = savaPathInitialize;
            
        }

        private void but_tif_Click(object sender, EventArgs e)
        {
            if (checkPath(SavaFolder.Text))
            {
                bool IsAnalysis = false;
                DateTime dt = DateTime.Now;
                but_tif.Text = "正在处理中";
                but_tif.Enabled= false;
                int i = 1;
                this.progressView.Properties.Stopped = false;
                DirectoryInfo dir = new DirectoryInfo(savaPathInitialize);
                DirectoryInfo[] ymssDir = dir.GetDirectories("*淹没过程动态展示支撑数据", SearchOption.AllDirectories);
                if (ymssDir.Length <= 0)
                {
                    MessageBox.Show("没有找到对应数据文件夹，请检查文件命名");
                    return;
                }
                FileInfo[] Refershp = ymssDir[0].GetFiles("ym*.shp", SearchOption.TopDirectoryOnly);
                FileInfo[] ReferCzLayer = ymssDir[0].GetFiles("xzLayer.shp", SearchOption.AllDirectories);
                if(Refershp.Length<=0||ReferCzLayer.Length<=0)
                {
                    MessageBox.Show("请检查是否存在数据xzLayer.shp、ymss数据");
                    return;
                }
                foreach (FileInfo shp in Refershp)
                {
                    IsAnalysis = false;
                    jindu.Text = String.Format("处理进度：{0}/{1}", i++, Refershp.Length);
                    string shpfilePath = shp.DirectoryName;//shp.FullName.Substring(0, shp.FullName.LastIndexOf("\\"));
                    string shpFileName = shp.Name;//ReferShp.Text.Substring(ReferShp.Text.LastIndexOf("\\") + 1);
                    string shpTrueName = shpFileName.Substring(0, shpFileName.Length - 4);
                    string txtFile = String.Format("{0}.txt", shpTrueName);
                    if (checkFile(String.Format("{0}\\{1}", shpfilePath, txtFile)))
                    {
                        if (!System.IO.Directory.Exists(String.Format("{0}\\tiffPath\\{1}", SavaFolder.Text, shpTrueName)))
                        {
                            dct.readTXT(String.Format("{0}\\{1}", shpfilePath, txtFile), shpfilePath, shpFileName, CellSize.Text, String.Format("{0}\\tiffPath\\{1}", SavaFolder.Text, shpTrueName));
                        }
                        if (!System.IO.Directory.Exists(String.Format("{0}\\tiffPath\\{1}\\shpFiles\\czStastic", SavaFolder.Text, shpTrueName)))
                        {
                           // CzLayer.Text = ReferCzLayer[0].FullName;
                            //dct.ymStatistics(String.Format("{0}\\tiffPath\\{1}\\shpFiles", SavaFolder.Text, shpTrueName), ReferCzLayer[0].FullName, shpTrueName);
                        }
                        else
                        {
                            IsAnalysis = true;
                            continue;
                        }
                    }
                
                }
                this.progressView.Properties.Stopped = true;
                but_tif.Text = "处理淹没过程";
                but_tif.Enabled =  true;
                if (IsAnalysis)
                    MessageBox.Show("已存淹没过程！");
                else
                    MessageBox.Show("生成淹没过程完成！用时：" + dct.ExecDateDiff(dt, DateTime.Now));
                ExtractMesg.Text = "结束。";

               
            }
            else
                return;

        }
        private bool checkFile(string FilePath)
        {
            if (!System.IO.File.Exists(FilePath) || FilePath == null)//|| !System.IO.Directory.Exists(ymgc_tifPath.Text)
            {
                MessageBox.Show("请检查文件是否存在···", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                return true;
        }
        private bool checkPath(string Path)
        {
            if (!System.IO.Directory.Exists(Path) || Path == null)//|| !System.IO.Directory.Exists(ymgc_tifPath.Text)
            {
                MessageBox.Show("请输入正确文件路径···", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                return true;
        }

        private void Tiff_Load(object sender, EventArgs e)
        {

            string NowCell = savaPathInitialize.Substring(savaPathInitialize.LastIndexOf("\\") + 1);
            if (NowCell == null||NowCell=="")
                SavaFolder.Text=DealCell.Text = "请选择需处理的编制单元";
            else
            DealCell.Text = NowCell;
        }

        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxX1.Checked)
                CellSize.Enabled = true;
            else
                CellSize.Enabled = false;
            
        }

        private void Stop_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show(String.Format("系统{0}是否要终止操作？\r\n并且将会退出整个系统！", DealCell.Text), "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                System.Diagnostics.Process.GetCurrentProcess().Kill();
                //this.Close();
            }
            else
                return;
        }

        
    }
}
