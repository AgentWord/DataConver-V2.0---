using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SuperMap;
using System.Configuration;
using System.Reflection;

namespace DataConver
{
    public partial class Setting : Form
    {
       
        public string undeal_Path;//= @"G:\未处理数据"
        public string mod;// =@"G:\数据转换\项目数据管理\地图模板"
        public string deal_path;
        string strAssemblyFilePath; 
        string strAssemblyDirPath;
        public string setupPath;
        public string report;
        public string CoorRef;
        public string passWord="admin";
        public string ztdt_ref;
        private SuperMapTool importTool;//定义工具类
        private ExeConfigurationFileMap file;
        private Configuration config1;
        private ConfigSectionData data1;
        int leng = 0;
        public Setting()
        {
            file = new ExeConfigurationFileMap();
            InitializeComponent();
            SuperMap.Data.Workspace m_workspace = new SuperMap.Data.Workspace();
            importTool = new SuperMapTool(m_workspace);
            file.ExeConfigFilename = "setting.config";
           
            strAssemblyFilePath = Assembly.GetExecutingAssembly().Location;
            strAssemblyDirPath= System.IO.Path.GetDirectoryName(strAssemblyFilePath);
            leng = strAssemblyDirPath.LastIndexOf("\\");
            setupPath = strAssemblyDirPath.Substring(0, leng);
            set_Value();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                
                undeal_Path = data1.Udeal_path = Udeal_path.Text;

                deal_path = data1.Deal_path = Deal_path.Text;
                mod = data1.mod = Model_path.Text;

                report = data1.report = "OK";
               // CoorRef = data1.Coor_ref = Coor_ref.Text;
                config1.Save(ConfigurationSaveMode.Minimal);
                MessageBox.Show("应用设置已保存！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                set_Value();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            }
        public void set_Value()
        {  
            config1 = ConfigurationManager.OpenMappedExeConfiguration(file, ConfigurationUserLevel.None);
            data1 = config1.Sections["add"] as ConfigSectionData;
            report = data1.report;
            //如果未设置则进行默认设置
            if (data1.report != "OK")
            {
                undeal_Path = Udeal_path.Text = data1.Udeal_path = setupPath + "\\未处理编制单元";

                deal_path = Deal_path.Text = data1.Deal_path = setupPath + "\\已处理编制单元";
                mod = Model_path.Text = data1.mod = setupPath + "\\Reference\\MapModel";

                //CoorRef = Coor_ref.Text = data1.Coor_ref = setupPath + "\\Reference\\CGCS_2000.xml";
                ztdt_ref = setupPath + "\\Reference";
                // config1.Save(ConfigurationSaveMode.Minimal);

            }
            else
            {
                undeal_Path = Udeal_path.Text = data1.Udeal_path ;

                deal_path = Deal_path.Text = data1.Deal_path;
                mod = Model_path.Text = data1.mod ;

               // CoorRef = Coor_ref.Text = data1.Coor_ref;
            }
          
        }

        private void but_Udeal_Click(object sender, EventArgs e)
        {
            importTool.openFolder(Udeal_path);

        }

        private void but_deal_Click(object sender, EventArgs e)
        {
            importTool.openFolder(Deal_path);

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_model_Click(object sender, EventArgs e)
        {
            importTool.openFolder(Model_path);
        }
        /*1、写好配置文件
         * 2、初始化窗口时读取配置文件信息
         * 3、点击确定后更新配置文件信息
         * 4、下次打开程序是自动读取先前保存的配置文件信息；
         * 5、完成
         */
    }
    class ConfigSectionData : ConfigurationSection
    {

        [ConfigurationProperty("Udeal_path")]

        public string Udeal_path
        {

            get { return (string)this["Udeal_path"]; }

            set { this["Udeal_path"] = value; }

        }



        [ConfigurationProperty("Deal_path")]

        public string Deal_path
        {

            get { return (string)this["Deal_path"]; }

            set { this["Deal_path"] = value; }

        }
        
        [ConfigurationProperty("mod")]

        public string mod
        {

            get { return (string)this["mod"]; }

            set { this["mod"] = value; }

        }
       
       
        [ConfigurationProperty("report")]

        public string report
        {

            get { return (string)this["report"]; }

            set { this["report"] = value; }

        }
        [ConfigurationProperty("Coor_ref")]

        public string Coor_ref
        {

            get { return (string)this["Coor_ref"]; }

            set { this["Coor_ref"] = value; }

        }
    }
}
