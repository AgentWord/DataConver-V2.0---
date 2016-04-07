namespace DataConver
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
                if (m_workspace != null)
                {
                    m_workspace.Dispose();
                    m_workspace = null;
                }
                if (set != null)
                {
                    set.Dispose();
                    set = null;
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btn_Pan = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonGroup2 = new DevExpress.XtraBars.BarButtonGroup();
            this.btn_ScaleIn = new DevExpress.XtraBars.BarButtonItem();
            this.btn_ScaleOut = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Select = new DevExpress.XtraBars.BarButtonItem();
            this.btn_NextView = new DevExpress.XtraBars.BarButtonItem();
            this.buttongroup = new DevExpress.XtraBars.BarButtonGroup();
            this.btn_ZoomIn = new DevExpress.XtraBars.BarButtonItem();
            this.btn_ZoomOut = new DevExpress.XtraBars.BarButtonItem();
            this.btn_FullExtent = new DevExpress.XtraBars.BarButtonItem();
            this.btn_FrontView = new DevExpress.XtraBars.BarButtonItem();
            this.btn_HelpDocument = new DevExpress.XtraBars.BarButtonItem();
            this.btn_About = new DevExpress.XtraBars.BarButtonItem();
            this.btn_OpenMapFile = new DevExpress.XtraBars.BarButtonItem();
            this.btn_AddMapLayer = new DevExpress.XtraBars.BarButtonItem();
            this.btn_ExportMapPic = new DevExpress.XtraBars.BarButtonItem();
            this.btn_MapMeasureLength = new DevExpress.XtraBars.BarButtonItem();
            this.btn_MapMeasureArea = new DevExpress.XtraBars.BarButtonItem();
            this.btn_MapIdentifyInfo = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Data_StatisticTables = new DevExpress.XtraBars.BarButtonItem();
            this.btn_PublishDisasterDoc = new DevExpress.XtraBars.BarButtonItem();
            this.btn_AnalysisFuture = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.btn_ManageOfMap = new DevExpress.XtraBars.BarButtonItem();
            this.btn_ManageOfData = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Save = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Refresh = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.User_On = new DevExpress.XtraBars.BarButtonItem();
            this.User_reg = new DevExpress.XtraBars.BarButtonItem();
            this.User_down = new DevExpress.XtraBars.BarButtonItem();
            this.Data_Cov = new DevExpress.XtraBars.BarButtonItem();
            this.Data_Open = new DevExpress.XtraBars.BarButtonItem();
            this.Data_vec = new DevExpress.XtraBars.BarButtonItem();
            this.User_set = new DevExpress.XtraBars.BarButtonItem();
            this.User_Save = new DevExpress.XtraBars.BarButtonItem();
            this.User_help = new DevExpress.XtraBars.BarButtonItem();
            this.User_Now = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonGalleryBarItem1 = new DevExpress.XtraBars.RibbonGalleryBarItem();
            this.barHeaderItem1 = new DevExpress.XtraBars.BarHeaderItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.User_Manage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.River_manage = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.System_set = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.xtraTabControl_Left = new DevExpress.XtraTab.XtraTabControl();
            this.Pag_UndealData = new DevExpress.XtraTab.XtraTabPage();
            this.but_back = new System.Windows.Forms.Button();
            this.but_openDir = new System.Windows.Forms.Button();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.Lis_UndealData = new System.Windows.Forms.ListView();
            this.Pag_ProcessedData = new DevExpress.XtraTab.XtraTabPage();
            this.but_deal_back = new System.Windows.Forms.Button();
            this.but_deal_openDir = new System.Windows.Forms.Button();
            this.Lis_DealData = new System.Windows.Forms.ListView();
            this.xtraTabControl_Center = new DevExpress.XtraTab.XtraTabControl();
            this.Pag_ProcessMsg = new DevExpress.XtraTab.XtraTabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.undeal_pathway = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.but_undeal = new System.Windows.Forms.Button();
            this.but_Start = new System.Windows.Forms.Button();
            this.but_Cancel = new System.Windows.Forms.Button();
            this.but_password = new System.Windows.Forms.Button();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.lab_progress = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.progressBar = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MessageShow = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.expandablePanel1 = new DevComponents.DotNetBar.ExpandablePanel();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.Pag_Map = new DevExpress.XtraTab.XtraTabPage();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.ScaleLable = new DevExpress.XtraEditors.LabelControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Undeal_Menu_Tool = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.返回ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.视图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.大图标ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Deal_Menu_Tool = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.打开ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.返回ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.视图ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.大图标ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.列表ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl_Left)).BeginInit();
            this.xtraTabControl_Left.SuspendLayout();
            this.Pag_UndealData.SuspendLayout();
            this.Pag_ProcessedData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl_Center)).BeginInit();
            this.xtraTabControl_Center.SuspendLayout();
            this.Pag_ProcessMsg.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBar.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.Pag_Map.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            this.Undeal_Menu_Tool.SuspendLayout();
            this.Deal_Menu_Tool.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btn_Pan,
            this.barButtonGroup2,
            this.btn_ScaleIn,
            this.btn_ScaleOut,
            this.buttongroup,
            this.btn_ZoomIn,
            this.btn_ZoomOut,
            this.btn_HelpDocument,
            this.btn_About,
            this.btn_OpenMapFile,
            this.btn_AddMapLayer,
            this.btn_ExportMapPic,
            this.btn_MapMeasureLength,
            this.btn_MapMeasureArea,
            this.btn_MapIdentifyInfo,
            this.btn_Data_StatisticTables,
            this.btn_PublishDisasterDoc,
            this.btn_AnalysisFuture,
            this.barButtonItem2,
            this.btn_ManageOfMap,
            this.btn_ManageOfData,
            this.btn_FullExtent,
            this.btn_Select,
            this.btn_FrontView,
            this.btn_NextView,
            this.btn_Save,
            this.btn_Refresh,
            this.barButtonItem1,
            this.barButtonItem3,
            this.barButtonItem4,
            this.User_On,
            this.User_reg,
            this.User_down,
            this.Data_Cov,
            this.Data_Open,
            this.Data_vec,
            this.User_set,
            this.User_Save,
            this.User_help,
            this.User_Now,
            this.barButtonItem5,
            this.ribbonGalleryBarItem1,
            this.barHeaderItem1,
            this.barButtonItem6,
            this.barButtonItem7});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ribbonControl1.MaxItemId = 78;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.User_Manage});
            this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(827, 147);
            this.ribbonControl1.Tag = "";
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Above;
            // 
            // btn_Pan
            // 
            this.btn_Pan.Caption = "平移";
            this.btn_Pan.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_Pan.Glyph")));
            this.btn_Pan.Id = 1;
            this.btn_Pan.Name = "btn_Pan";
            this.btn_Pan.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonGroup2
            // 
            this.barButtonGroup2.Caption = "逐级缩放";
            this.barButtonGroup2.Id = 8;
            this.barButtonGroup2.ItemLinks.Add(this.btn_ScaleIn);
            this.barButtonGroup2.ItemLinks.Add(this.btn_ScaleOut);
            this.barButtonGroup2.ItemLinks.Add(this.btn_Select);
            this.barButtonGroup2.ItemLinks.Add(this.btn_NextView);
            this.barButtonGroup2.Name = "barButtonGroup2";
            // 
            // btn_ScaleIn
            // 
            this.btn_ScaleIn.Caption = "渐大";
            this.btn_ScaleIn.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_ScaleIn.Glyph")));
            this.btn_ScaleIn.Id = 9;
            this.btn_ScaleIn.Name = "btn_ScaleIn";
            this.btn_ScaleIn.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // btn_ScaleOut
            // 
            this.btn_ScaleOut.Caption = "渐小";
            this.btn_ScaleOut.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_ScaleOut.Glyph")));
            this.btn_ScaleOut.Id = 10;
            this.btn_ScaleOut.Name = "btn_ScaleOut";
            this.btn_ScaleOut.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // btn_Select
            // 
            this.btn_Select.Caption = "选择\r\n";
            this.btn_Select.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_Select.Glyph")));
            this.btn_Select.Id = 48;
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // btn_NextView
            // 
            this.btn_NextView.Caption = "后一视图";
            this.btn_NextView.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_NextView.Glyph")));
            this.btn_NextView.Id = 50;
            this.btn_NextView.Name = "btn_NextView";
            this.btn_NextView.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // buttongroup
            // 
            this.buttongroup.Caption = "缩放";
            this.buttongroup.Id = 13;
            this.buttongroup.ItemLinks.Add(this.btn_ZoomIn);
            this.buttongroup.ItemLinks.Add(this.btn_ZoomOut);
            this.buttongroup.ItemLinks.Add(this.btn_FullExtent);
            this.buttongroup.ItemLinks.Add(this.btn_FrontView);
            this.buttongroup.Name = "buttongroup";
            // 
            // btn_ZoomIn
            // 
            this.btn_ZoomIn.Caption = "放大";
            this.btn_ZoomIn.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_ZoomIn.Glyph")));
            this.btn_ZoomIn.Id = 14;
            this.btn_ZoomIn.Name = "btn_ZoomIn";
            this.btn_ZoomIn.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // btn_ZoomOut
            // 
            this.btn_ZoomOut.Caption = "缩小";
            this.btn_ZoomOut.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_ZoomOut.Glyph")));
            this.btn_ZoomOut.Id = 15;
            this.btn_ZoomOut.Name = "btn_ZoomOut";
            this.btn_ZoomOut.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // btn_FullExtent
            // 
            this.btn_FullExtent.Caption = "全局\r\n";
            this.btn_FullExtent.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_FullExtent.Glyph")));
            this.btn_FullExtent.Id = 45;
            this.btn_FullExtent.Name = "btn_FullExtent";
            this.btn_FullExtent.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // btn_FrontView
            // 
            this.btn_FrontView.Caption = "前一视图";
            this.btn_FrontView.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_FrontView.Glyph")));
            this.btn_FrontView.Id = 49;
            this.btn_FrontView.Name = "btn_FrontView";
            this.btn_FrontView.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // btn_HelpDocument
            // 
            this.btn_HelpDocument.Caption = "帮助文档";
            this.btn_HelpDocument.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_HelpDocument.Glyph")));
            this.btn_HelpDocument.Id = 17;
            this.btn_HelpDocument.Name = "btn_HelpDocument";
            this.btn_HelpDocument.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btn_About
            // 
            this.btn_About.Caption = "关于";
            this.btn_About.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_About.Glyph")));
            this.btn_About.Id = 18;
            this.btn_About.Name = "btn_About";
            this.btn_About.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btn_OpenMapFile
            // 
            this.btn_OpenMapFile.Caption = "打开地图";
            this.btn_OpenMapFile.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_OpenMapFile.Glyph")));
            this.btn_OpenMapFile.Id = 21;
            this.btn_OpenMapFile.Name = "btn_OpenMapFile";
            this.btn_OpenMapFile.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btn_AddMapLayer
            // 
            this.btn_AddMapLayer.Caption = "添加图层";
            this.btn_AddMapLayer.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_AddMapLayer.Glyph")));
            this.btn_AddMapLayer.Id = 22;
            this.btn_AddMapLayer.Name = "btn_AddMapLayer";
            this.btn_AddMapLayer.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btn_ExportMapPic
            // 
            this.btn_ExportMapPic.Caption = "输出地图";
            this.btn_ExportMapPic.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_ExportMapPic.Glyph")));
            this.btn_ExportMapPic.Id = 23;
            this.btn_ExportMapPic.Name = "btn_ExportMapPic";
            this.btn_ExportMapPic.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btn_MapMeasureLength
            // 
            this.btn_MapMeasureLength.Caption = "长度测量";
            this.btn_MapMeasureLength.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_MapMeasureLength.Glyph")));
            this.btn_MapMeasureLength.Id = 25;
            this.btn_MapMeasureLength.Name = "btn_MapMeasureLength";
            this.btn_MapMeasureLength.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btn_MapMeasureArea
            // 
            this.btn_MapMeasureArea.Caption = "面积测量";
            this.btn_MapMeasureArea.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_MapMeasureArea.Glyph")));
            this.btn_MapMeasureArea.Id = 26;
            this.btn_MapMeasureArea.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btn_MapMeasureArea.LargeGlyph")));
            this.btn_MapMeasureArea.Name = "btn_MapMeasureArea";
            this.btn_MapMeasureArea.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btn_MapIdentifyInfo
            // 
            this.btn_MapIdentifyInfo.Caption = "属性查看";
            this.btn_MapIdentifyInfo.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_MapIdentifyInfo.Glyph")));
            this.btn_MapIdentifyInfo.Id = 27;
            this.btn_MapIdentifyInfo.Name = "btn_MapIdentifyInfo";
            this.btn_MapIdentifyInfo.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btn_Data_StatisticTables
            // 
            this.btn_Data_StatisticTables.Caption = "导入坐标";
            this.btn_Data_StatisticTables.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_Data_StatisticTables.Glyph")));
            this.btn_Data_StatisticTables.Id = 28;
            this.btn_Data_StatisticTables.Name = "btn_Data_StatisticTables";
            this.btn_Data_StatisticTables.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btn_PublishDisasterDoc
            // 
            this.btn_PublishDisasterDoc.Caption = "范围分析";
            this.btn_PublishDisasterDoc.Id = 29;
            this.btn_PublishDisasterDoc.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btn_PublishDisasterDoc.LargeGlyph")));
            this.btn_PublishDisasterDoc.Name = "btn_PublishDisasterDoc";
            this.btn_PublishDisasterDoc.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btn_AnalysisFuture
            // 
            this.btn_AnalysisFuture.Caption = "趋势分析";
            this.btn_AnalysisFuture.Id = 30;
            this.btn_AnalysisFuture.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btn_AnalysisFuture.LargeGlyph")));
            this.btn_AnalysisFuture.Name = "btn_AnalysisFuture";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "输出数据管理";
            this.barButtonItem2.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.Glyph")));
            this.barButtonItem2.Id = 41;
            this.barButtonItem2.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.LargeGlyph")));
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // btn_ManageOfMap
            // 
            this.btn_ManageOfMap.Caption = "地图数据管理";
            this.btn_ManageOfMap.Id = 42;
            this.btn_ManageOfMap.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btn_ManageOfMap.LargeGlyph")));
            this.btn_ManageOfMap.Name = "btn_ManageOfMap";
            // 
            // btn_ManageOfData
            // 
            this.btn_ManageOfData.Caption = "数据集管理";
            this.btn_ManageOfData.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_ManageOfData.Glyph")));
            this.btn_ManageOfData.Id = 43;
            this.btn_ManageOfData.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btn_ManageOfData.LargeGlyph")));
            this.btn_ManageOfData.Name = "btn_ManageOfData";
            // 
            // btn_Save
            // 
            this.btn_Save.Caption = "保存";
            this.btn_Save.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_Save.Glyph")));
            this.btn_Save.Id = 51;
            this.btn_Save.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btn_Save.LargeGlyph")));
            this.btn_Save.Name = "btn_Save";
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Caption = "刷新";
            this.btn_Refresh.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_Refresh.Glyph")));
            this.btn_Refresh.Id = 52;
            this.btn_Refresh.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btn_Refresh.LargeGlyph")));
            this.btn_Refresh.Name = "btn_Refresh";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "系统设置";
            this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
            this.barButtonItem1.Id = 53;
            this.barButtonItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.LargeGlyph")));
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "专题图输出";
            this.barButtonItem3.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.Glyph")));
            this.barButtonItem3.Id = 54;
            this.barButtonItem3.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.LargeGlyph")));
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "测试";
            this.barButtonItem4.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.Glyph")));
            this.barButtonItem4.Id = 56;
            this.barButtonItem4.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.LargeGlyph")));
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // User_On
            // 
            this.User_On.Caption = "用户登录";
            this.User_On.Id = 57;
            this.User_On.LargeGlyph = global::DataConver.Properties.Resources.aboutUs_64;
            this.User_On.Name = "User_On";
            // 
            // User_reg
            // 
            this.User_reg.Caption = "用户注册";
            this.User_reg.Glyph = ((System.Drawing.Image)(resources.GetObject("User_reg.Glyph")));
            this.User_reg.Id = 58;
            this.User_reg.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("User_reg.LargeGlyph")));
            this.User_reg.Name = "User_reg";
            // 
            // User_down
            // 
            this.User_down.Caption = "退出";
            this.User_down.Glyph = ((System.Drawing.Image)(resources.GetObject("User_down.Glyph")));
            this.User_down.Id = 59;
            this.User_down.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("User_down.LargeGlyph")));
            this.User_down.Name = "User_down";
            this.User_down.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem7_ItemClick);
            // 
            // Data_Cov
            // 
            this.Data_Cov.Caption = "数据处理工具";
            this.Data_Cov.Glyph = ((System.Drawing.Image)(resources.GetObject("Data_Cov.Glyph")));
            this.Data_Cov.Id = 60;
            this.Data_Cov.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("Data_Cov.LargeGlyph")));
            this.Data_Cov.Name = "Data_Cov";
            // 
            // Data_Open
            // 
            this.Data_Open.Caption = "参考地图模板";
            this.Data_Open.Glyph = ((System.Drawing.Image)(resources.GetObject("Data_Open.Glyph")));
            this.Data_Open.Id = 61;
            this.Data_Open.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("Data_Open.LargeGlyph")));
            this.Data_Open.Name = "Data_Open";
            this.Data_Open.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Model_Manage_ItemClick);
            // 
            // Data_vec
            // 
            this.Data_vec.Caption = "编制单元管理";
            this.Data_vec.Glyph = ((System.Drawing.Image)(resources.GetObject("Data_vec.Glyph")));
            this.Data_vec.Id = 62;
            this.Data_vec.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("Data_vec.LargeGlyph")));
            this.Data_vec.Name = "Data_vec";
            this.Data_vec.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Data_vec_ItemClick);
            // 
            // User_set
            // 
            this.User_set.Caption = "设置";
            this.User_set.Glyph = ((System.Drawing.Image)(resources.GetObject("User_set.Glyph")));
            this.User_set.Id = 64;
            this.User_set.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("User_set.LargeGlyph")));
            this.User_set.Name = "User_set";
            this.User_set.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.User_set_ItemClick);
            // 
            // User_Save
            // 
            this.User_Save.Caption = "保存";
            this.User_Save.Glyph = ((System.Drawing.Image)(resources.GetObject("User_Save.Glyph")));
            this.User_Save.Id = 65;
            this.User_Save.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("User_Save.LargeGlyph")));
            this.User_Save.Name = "User_Save";
            // 
            // User_help
            // 
            this.User_help.Caption = "帮助";
            this.User_help.Id = 66;
            this.User_help.LargeGlyph = global::DataConver.Properties.Resources.Help_64;
            this.User_help.Name = "User_help";
            this.User_help.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.User_help_ItemClick);
            // 
            // User_Now
            // 
            this.User_Now.Caption = "当前登录用户为：";
            this.User_Now.Edit = this.repositoryItemTextEdit1;
            this.User_Now.EditValue = "";
            this.User_Now.Id = 68;
            this.User_Now.Name = "User_Now";
            this.User_Now.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.User_Now.Width = 0;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "地图配图";
            this.barButtonItem5.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.Glyph")));
            this.barButtonItem5.Id = 69;
            this.barButtonItem5.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.LargeGlyph")));
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // ribbonGalleryBarItem1
            // 
            this.ribbonGalleryBarItem1.Caption = "ribbonGalleryBarItem1";
            this.ribbonGalleryBarItem1.Enabled = false;
            this.ribbonGalleryBarItem1.Id = 70;
            this.ribbonGalleryBarItem1.Name = "ribbonGalleryBarItem1";
            this.ribbonGalleryBarItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barHeaderItem1
            // 
            this.barHeaderItem1.Id = 72;
            this.barHeaderItem1.Name = "barHeaderItem1";
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "关于";
            this.barButtonItem6.Id = 75;
            this.barButtonItem6.LargeGlyph = global::DataConver.Properties.Resources.aboutUs_64;
            this.barButtonItem6.Name = "barButtonItem6";
            this.barButtonItem6.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem6_ItemClick);
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Caption = "生成淹没过程数据";
            this.barButtonItem7.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem7.Glyph")));
            this.barButtonItem7.Id = 77;
            this.barButtonItem7.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem7.LargeGlyph")));
            this.barButtonItem7.Name = "barButtonItem7";
            this.barButtonItem7.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem7_ItemClick_1);
            // 
            // User_Manage
            // 
            this.User_Manage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.River_manage,
            this.System_set,
            this.ribbonPageGroup1});
            this.User_Manage.Name = "User_Manage";
            this.User_Manage.Text = "编制单元处理功能区";
            // 
            // River_manage
            // 
            this.River_manage.ItemLinks.Add(this.Data_vec);
            this.River_manage.ItemLinks.Add(this.Data_Open);
            this.River_manage.Name = "River_manage";
            this.River_manage.Text = "编制单元数据";
            // 
            // System_set
            // 
            this.System_set.ItemLinks.Add(this.User_set);
            this.System_set.ItemLinks.Add(this.User_help);
            this.System_set.ItemLinks.Add(this.barButtonItem6);
            this.System_set.ItemLinks.Add(this.User_down);
            this.System_set.Name = "System_set";
            this.System_set.Text = "系统设置";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem7);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "提取栅格数据";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 147);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.xtraTabControl_Left);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.xtraTabControl_Center);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(827, 430);
            this.splitContainerControl1.SplitterPosition = 291;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // xtraTabControl_Left
            // 
            this.xtraTabControl_Left.AllowDrop = true;
            this.xtraTabControl_Left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl_Left.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl_Left.Name = "xtraTabControl_Left";
            this.xtraTabControl_Left.SelectedTabPage = this.Pag_UndealData;
            this.xtraTabControl_Left.Size = new System.Drawing.Size(291, 430);
            this.xtraTabControl_Left.TabIndex = 0;
            this.xtraTabControl_Left.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.Pag_UndealData,
            this.Pag_ProcessedData});
            // 
            // Pag_UndealData
            // 
            this.Pag_UndealData.Appearance.PageClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Pag_UndealData.Appearance.PageClient.Options.UseBackColor = true;
            this.Pag_UndealData.Controls.Add(this.but_back);
            this.Pag_UndealData.Controls.Add(this.but_openDir);
            this.Pag_UndealData.Controls.Add(this.buttonX1);
            this.Pag_UndealData.Controls.Add(this.Lis_UndealData);
            this.Pag_UndealData.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Pag_UndealData.Image = ((System.Drawing.Image)(resources.GetObject("Pag_UndealData.Image")));
            this.Pag_UndealData.Name = "Pag_UndealData";
            this.Pag_UndealData.Size = new System.Drawing.Size(287, 387);
            this.Pag_UndealData.Text = "未处理编制单元";
            // 
            // but_back
            // 
            this.but_back.Font = new System.Drawing.Font("黑体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_back.Location = new System.Drawing.Point(20, 5);
            this.but_back.Name = "but_back";
            this.but_back.Size = new System.Drawing.Size(98, 23);
            this.but_back.TabIndex = 6;
            this.but_back.Text = "返回上一级";
            this.but_back.UseVisualStyleBackColor = true;
            this.but_back.Click += new System.EventHandler(this.Undeal_back_Click);
            // 
            // but_openDir
            // 
            this.but_openDir.Font = new System.Drawing.Font("黑体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_openDir.Location = new System.Drawing.Point(163, 5);
            this.but_openDir.Name = "but_openDir";
            this.but_openDir.Size = new System.Drawing.Size(90, 23);
            this.but_openDir.TabIndex = 5;
            this.but_openDir.Text = "打开目录";
            this.but_openDir.UseVisualStyleBackColor = true;
            this.but_openDir.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonX1.Location = new System.Drawing.Point(352, 3);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(42, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.Symbol = "";
            this.buttonX1.TabIndex = 2;
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // Lis_UndealData
            // 
            this.Lis_UndealData.BackColor = System.Drawing.Color.Gainsboro;
            this.Lis_UndealData.CheckBoxes = true;
            this.Lis_UndealData.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Lis_UndealData.FullRowSelect = true;
            this.Lis_UndealData.Location = new System.Drawing.Point(0, 32);
            this.Lis_UndealData.Name = "Lis_UndealData";
            this.Lis_UndealData.Size = new System.Drawing.Size(287, 355);
            this.Lis_UndealData.TabIndex = 0;
            this.Lis_UndealData.UseCompatibleStateImageBehavior = false;
            this.Lis_UndealData.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.Lis_UndealData_ItemChecked);
            this.Lis_UndealData.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UnDeal_Data_MouseDown);
            // 
            // Pag_ProcessedData
            // 
            this.Pag_ProcessedData.Controls.Add(this.but_deal_back);
            this.Pag_ProcessedData.Controls.Add(this.but_deal_openDir);
            this.Pag_ProcessedData.Controls.Add(this.Lis_DealData);
            this.Pag_ProcessedData.Image = ((System.Drawing.Image)(resources.GetObject("Pag_ProcessedData.Image")));
            this.Pag_ProcessedData.Name = "Pag_ProcessedData";
            this.Pag_ProcessedData.Size = new System.Drawing.Size(222, 426);
            this.Pag_ProcessedData.Text = "已处理编制单元";
            // 
            // but_deal_back
            // 
            this.but_deal_back.Font = new System.Drawing.Font("黑体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_deal_back.Location = new System.Drawing.Point(20, 5);
            this.but_deal_back.Name = "but_deal_back";
            this.but_deal_back.Size = new System.Drawing.Size(98, 23);
            this.but_deal_back.TabIndex = 8;
            this.but_deal_back.Text = "返回上一级";
            this.but_deal_back.UseVisualStyleBackColor = true;
            this.but_deal_back.Click += new System.EventHandler(this.Deal_back_Click);
            // 
            // but_deal_openDir
            // 
            this.but_deal_openDir.Font = new System.Drawing.Font("黑体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_deal_openDir.Location = new System.Drawing.Point(163, 5);
            this.but_deal_openDir.Name = "but_deal_openDir";
            this.but_deal_openDir.Size = new System.Drawing.Size(90, 23);
            this.but_deal_openDir.TabIndex = 7;
            this.but_deal_openDir.Text = "打开目录";
            this.but_deal_openDir.UseVisualStyleBackColor = true;
            this.but_deal_openDir.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // Lis_DealData
            // 
            this.Lis_DealData.BackColor = System.Drawing.Color.Gainsboro;
            this.Lis_DealData.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Lis_DealData.Location = new System.Drawing.Point(0, 71);
            this.Lis_DealData.Name = "Lis_DealData";
            this.Lis_DealData.Size = new System.Drawing.Size(222, 355);
            this.Lis_DealData.TabIndex = 2;
            this.Lis_DealData.UseCompatibleStateImageBehavior = false;
            this.Lis_DealData.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Deal_Data_MouseDoubleClick);
            this.Lis_DealData.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Deal_Data_MouseDown);
            // 
            // xtraTabControl_Center
            // 
            this.xtraTabControl_Center.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.xtraTabControl_Center.Appearance.Options.UseBackColor = true;
            this.xtraTabControl_Center.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl_Center.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl_Center.Name = "xtraTabControl_Center";
            this.xtraTabControl_Center.SelectedTabPage = this.Pag_ProcessMsg;
            this.xtraTabControl_Center.Size = new System.Drawing.Size(532, 430);
            this.xtraTabControl_Center.TabIndex = 2;
            this.xtraTabControl_Center.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.Pag_ProcessMsg,
            this.Pag_Map});
            // 
            // Pag_ProcessMsg
            // 
            this.Pag_ProcessMsg.Appearance.PageClient.BackColor = System.Drawing.Color.Turquoise;
            this.Pag_ProcessMsg.Appearance.PageClient.Options.UseBackColor = true;
            this.Pag_ProcessMsg.Controls.Add(this.panel1);
            this.Pag_ProcessMsg.Controls.Add(this.groupBox1);
            this.Pag_ProcessMsg.Controls.Add(this.expandablePanel1);
            this.Pag_ProcessMsg.Controls.Add(this.axLicenseControl1);
            this.Pag_ProcessMsg.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pag_ProcessMsg.Image = ((System.Drawing.Image)(resources.GetObject("Pag_ProcessMsg.Image")));
            this.Pag_ProcessMsg.Name = "Pag_ProcessMsg";
            this.Pag_ProcessMsg.Size = new System.Drawing.Size(528, 387);
            this.Pag_ProcessMsg.Text = "处理信息进度输出";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.undeal_pathway);
            this.panel1.Controls.Add(this.but_undeal);
            this.panel1.Controls.Add(this.but_Start);
            this.panel1.Controls.Add(this.but_Cancel);
            this.panel1.Controls.Add(this.but_password);
            this.panel1.Controls.Add(this.labelX3);
            this.panel1.Controls.Add(this.lab_progress);
            this.panel1.Controls.Add(this.labelX2);
            this.panel1.Controls.Add(this.progressBar);
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 196);
            this.panel1.TabIndex = 21;
            // 
            // undeal_pathway
            // 
            // 
            // 
            // 
            this.undeal_pathway.Border.Class = "TextBoxBorder";
            this.undeal_pathway.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.undeal_pathway.ButtonCustom.Tooltip = "";
            this.undeal_pathway.ButtonCustom2.Tooltip = "";
            this.undeal_pathway.Location = new System.Drawing.Point(125, 95);
            this.undeal_pathway.Name = "undeal_pathway";
            this.undeal_pathway.PreventEnterBeep = true;
            this.undeal_pathway.Size = new System.Drawing.Size(322, 29);
            this.undeal_pathway.TabIndex = 37;
            // 
            // but_undeal
            // 
            this.but_undeal.Location = new System.Drawing.Point(460, 93);
            this.but_undeal.Name = "but_undeal";
            this.but_undeal.Size = new System.Drawing.Size(43, 28);
            this.but_undeal.TabIndex = 35;
            this.but_undeal.Text = "···";
            this.but_undeal.UseVisualStyleBackColor = true;
            this.but_undeal.Click += new System.EventHandler(this.but_undeal_Click);
            // 
            // but_Start
            // 
            this.but_Start.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_Start.Location = new System.Drawing.Point(361, 149);
            this.but_Start.Name = "but_Start";
            this.but_Start.Size = new System.Drawing.Size(82, 30);
            this.but_Start.TabIndex = 34;
            this.but_Start.Text = "开始处理";
            this.but_Start.UseVisualStyleBackColor = true;
            this.but_Start.Click += new System.EventHandler(this.but_Start_Click);
            // 
            // but_Cancel
            // 
            this.but_Cancel.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_Cancel.Location = new System.Drawing.Point(263, 149);
            this.but_Cancel.Name = "but_Cancel";
            this.but_Cancel.Size = new System.Drawing.Size(82, 30);
            this.but_Cancel.TabIndex = 33;
            this.but_Cancel.Text = "取消";
            this.but_Cancel.UseVisualStyleBackColor = true;
            this.but_Cancel.Click += new System.EventHandler(this.but_Cancel_Click);
            // 
            // but_password
            // 
            this.but_password.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_password.Location = new System.Drawing.Point(165, 149);
            this.but_password.Name = "but_password";
            this.but_password.Size = new System.Drawing.Size(82, 30);
            this.but_password.TabIndex = 32;
            this.but_password.Text = "设置密码";
            this.but_password.UseVisualStyleBackColor = true;
            this.but_password.Click += new System.EventHandler(this.but_password_Click_1);
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(453, 55);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(67, 23);
            this.labelX3.TabIndex = 31;
            // 
            // lab_progress
            // 
            // 
            // 
            // 
            this.lab_progress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lab_progress.Location = new System.Drawing.Point(109, 19);
            this.lab_progress.Name = "lab_progress";
            this.lab_progress.Size = new System.Drawing.Size(404, 23);
            this.lab_progress.TabIndex = 27;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(3, 19);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(91, 23);
            this.labelX2.TabIndex = 29;
            this.labelX2.Text = "进度信息：";
            // 
            // progressBar
            // 
            this.progressBar.EditValue = 0;
            this.progressBar.Location = new System.Drawing.Point(5, 55);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(442, 21);
            this.progressBar.TabIndex = 28;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(5, 98);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(126, 23);
            this.labelX1.TabIndex = 26;
            this.labelX1.Text = "选择编制单元：";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox1.Controls.Add(this.MessageShow);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 196);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(528, 191);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "详细处理信息";
            // 
            // MessageShow
            // 
            this.MessageShow.BackColorRichTextBox = System.Drawing.Color.Gainsboro;
            // 
            // 
            // 
            this.MessageShow.BackgroundStyle.Class = "RichTextBoxBorder";
            this.MessageShow.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.MessageShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessageShow.Location = new System.Drawing.Point(3, 25);
            this.MessageShow.Name = "MessageShow";
            this.MessageShow.Rtf = "{\\rtf1\\ansi\\ansicpg936\\deff0\\deflang1033\\deflangfe2052{\\fonttbl{\\f0\\fnil\\fcharset" +
    "134 \\\'ce\\\'a2\\\'c8\\\'ed\\\'d1\\\'c5\\\'ba\\\'da;}}\r\n\\viewkind4\\uc1\\pard\\lang2052\\f0\\fs24\\pa" +
    "r\r\n}\r\n";
            this.MessageShow.Size = new System.Drawing.Size(522, 163);
            this.MessageShow.TabIndex = 12;
            // 
            // expandablePanel1
            // 
            this.expandablePanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandablePanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.expandablePanel1.HideControlsWhenCollapsed = true;
            this.expandablePanel1.Location = new System.Drawing.Point(45, 294);
            this.expandablePanel1.Name = "expandablePanel1";
            this.expandablePanel1.Size = new System.Drawing.Size(425, 203);
            this.expandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel1.Style.GradientAngle = 90;
            this.expandablePanel1.TabIndex = 14;
            this.expandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel1.TitleStyle.GradientAngle = 90;
            this.expandablePanel1.TitleText = "显示详细信息";
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(728, 40);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 1;
            // 
            // Pag_Map
            // 
            this.Pag_Map.Controls.Add(this.axMapControl1);
            this.Pag_Map.Name = "Pag_Map";
            this.Pag_Map.Size = new System.Drawing.Size(593, 426);
            this.Pag_Map.Text = "地图图层数据";
            // 
            // axMapControl1
            // 
            this.axMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl1.Location = new System.Drawing.Point(0, 0);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(593, 426);
            this.axMapControl1.TabIndex = 0;
            this.axMapControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl1_OnMouseDown);
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btn_HelpDocument);
            this.ribbonPageGroup3.ItemLinks.Add(this.btn_About);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "帮助中心";
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 5);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(635, 22);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(150, 25);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightToolStripPanel.Location = new System.Drawing.Point(150, 25);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 150);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 25);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 150);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(635, 5);
            // 
            // ScaleLable
            // 
            this.ScaleLable.Location = new System.Drawing.Point(0, 0);
            this.ScaleLable.Name = "ScaleLable";
            this.ScaleLable.Size = new System.Drawing.Size(75, 14);
            this.ScaleLable.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "文本文件");
            this.imageList1.Images.SetKeyName(1, "图层");
            this.imageList1.Images.SetKeyName(2, "栅格");
            this.imageList1.Images.SetKeyName(3, "日期");
            this.imageList1.Images.SetKeyName(4, "数据源");
            this.imageList1.Images.SetKeyName(5, "file.ico");
            // 
            // Undeal_Menu_Tool
            // 
            this.Undeal_Menu_Tool.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Undeal_Menu_Tool.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.Undeal_Menu_Tool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.返回ToolStripMenuItem2,
            this.删除ToolStripMenuItem,
            this.视图ToolStripMenuItem});
            this.Undeal_Menu_Tool.Name = "contextMenuStrip1";
            this.Undeal_Menu_Tool.Size = new System.Drawing.Size(121, 124);
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Image = global::DataConver.Properties.Resources.openMap_64;
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(120, 30);
            this.打开ToolStripMenuItem.Text = "打开";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开Undeal_Menu_Tool_Click);
            // 
            // 返回ToolStripMenuItem2
            // 
            this.返回ToolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("返回ToolStripMenuItem2.Image")));
            this.返回ToolStripMenuItem2.Name = "返回ToolStripMenuItem2";
            this.返回ToolStripMenuItem2.Size = new System.Drawing.Size(120, 30);
            this.返回ToolStripMenuItem2.Text = "返回";
            this.返回ToolStripMenuItem2.Click += new System.EventHandler(this.返回Undeal_Menu_Tool_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("删除ToolStripMenuItem.Image")));
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(120, 30);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除Undeal_Menu_Tool_Click);
            // 
            // 视图ToolStripMenuItem
            // 
            this.视图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.大图标ToolStripMenuItem,
            this.列表ToolStripMenuItem});
            this.视图ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("视图ToolStripMenuItem.Image")));
            this.视图ToolStripMenuItem.Name = "视图ToolStripMenuItem";
            this.视图ToolStripMenuItem.Size = new System.Drawing.Size(120, 30);
            this.视图ToolStripMenuItem.Text = "视图";
            // 
            // 大图标ToolStripMenuItem
            // 
            this.大图标ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("大图标ToolStripMenuItem.Image")));
            this.大图标ToolStripMenuItem.Name = "大图标ToolStripMenuItem";
            this.大图标ToolStripMenuItem.Size = new System.Drawing.Size(136, 30);
            this.大图标ToolStripMenuItem.Text = "大图标";
            this.大图标ToolStripMenuItem.Click += new System.EventHandler(this.大图标Undeal_Menu_Tool_Click);
            // 
            // 列表ToolStripMenuItem
            // 
            this.列表ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("列表ToolStripMenuItem.Image")));
            this.列表ToolStripMenuItem.Name = "列表ToolStripMenuItem";
            this.列表ToolStripMenuItem.Size = new System.Drawing.Size(136, 30);
            this.列表ToolStripMenuItem.Text = "列表";
            this.列表ToolStripMenuItem.Click += new System.EventHandler(this.列表Undeal_Menu_Tool_Click);
            // 
            // Deal_Menu_Tool
            // 
            this.Deal_Menu_Tool.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Deal_Menu_Tool.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.Deal_Menu_Tool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem1,
            this.返回ToolStripMenuItem1,
            this.删除ToolStripMenuItem1,
            this.视图ToolStripMenuItem1});
            this.Deal_Menu_Tool.Name = "contextMenuStrip2";
            this.Deal_Menu_Tool.Size = new System.Drawing.Size(121, 124);
            // 
            // 打开ToolStripMenuItem1
            // 
            this.打开ToolStripMenuItem1.Image = global::DataConver.Properties.Resources.openMap_64;
            this.打开ToolStripMenuItem1.Name = "打开ToolStripMenuItem1";
            this.打开ToolStripMenuItem1.Size = new System.Drawing.Size(120, 30);
            this.打开ToolStripMenuItem1.Text = "打开";
            this.打开ToolStripMenuItem1.Click += new System.EventHandler(this.打开Deal_Menu_Tool_Click);
            // 
            // 返回ToolStripMenuItem1
            // 
            this.返回ToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("返回ToolStripMenuItem1.Image")));
            this.返回ToolStripMenuItem1.Name = "返回ToolStripMenuItem1";
            this.返回ToolStripMenuItem1.Size = new System.Drawing.Size(120, 30);
            this.返回ToolStripMenuItem1.Text = "返回";
            this.返回ToolStripMenuItem1.Click += new System.EventHandler(this.返回Deal_Menu_Tool_Click);
            // 
            // 删除ToolStripMenuItem1
            // 
            this.删除ToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("删除ToolStripMenuItem1.Image")));
            this.删除ToolStripMenuItem1.Name = "删除ToolStripMenuItem1";
            this.删除ToolStripMenuItem1.Size = new System.Drawing.Size(120, 30);
            this.删除ToolStripMenuItem1.Text = "删除";
            this.删除ToolStripMenuItem1.Click += new System.EventHandler(this.删除Deal_Menu_Tool_Click);
            // 
            // 视图ToolStripMenuItem1
            // 
            this.视图ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.大图标ToolStripMenuItem1,
            this.列表ToolStripMenuItem1});
            this.视图ToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("视图ToolStripMenuItem1.Image")));
            this.视图ToolStripMenuItem1.Name = "视图ToolStripMenuItem1";
            this.视图ToolStripMenuItem1.Size = new System.Drawing.Size(120, 30);
            this.视图ToolStripMenuItem1.Text = "视图";
            // 
            // 大图标ToolStripMenuItem1
            // 
            this.大图标ToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("大图标ToolStripMenuItem1.Image")));
            this.大图标ToolStripMenuItem1.Name = "大图标ToolStripMenuItem1";
            this.大图标ToolStripMenuItem1.Size = new System.Drawing.Size(136, 30);
            this.大图标ToolStripMenuItem1.Text = "大图标";
            this.大图标ToolStripMenuItem1.Click += new System.EventHandler(this.大图标Deal_Menu_Tool_Click);
            // 
            // 列表ToolStripMenuItem1
            // 
            this.列表ToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("列表ToolStripMenuItem1.Image")));
            this.列表ToolStripMenuItem1.Name = "列表ToolStripMenuItem1";
            this.列表ToolStripMenuItem1.Size = new System.Drawing.Size(136, 30);
            this.列表ToolStripMenuItem1.Text = "列表";
            this.列表ToolStripMenuItem1.Click += new System.EventHandler(this.列表Deal_Menu_Tool_Click);
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            // 
            // MainForm
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 577);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "洪水风险图移动端数据预处理工具";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl_Left)).EndInit();
            this.xtraTabControl_Left.ResumeLayout(false);
            this.Pag_UndealData.ResumeLayout(false);
            this.Pag_ProcessedData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl_Center)).EndInit();
            this.xtraTabControl_Center.ResumeLayout(false);
            this.Pag_ProcessMsg.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.progressBar.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.Pag_Map.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            this.Undeal_Menu_Tool.ResumeLayout(false);
            this.Deal_Menu_Tool.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraBars.BarButtonItem btn_Pan;
        private DevExpress.XtraBars.BarButtonGroup barButtonGroup2;
        private DevExpress.XtraBars.BarButtonItem btn_ScaleIn;
        private DevExpress.XtraBars.BarButtonItem btn_ScaleOut;
        private DevExpress.XtraBars.BarButtonGroup buttongroup;
        private DevExpress.XtraBars.BarButtonItem btn_ZoomIn;
        private DevExpress.XtraBars.BarButtonItem btn_ZoomOut;
        private DevExpress.XtraBars.BarButtonItem btn_HelpDocument;
        private DevExpress.XtraBars.BarButtonItem btn_About;
        private DevExpress.XtraBars.BarButtonItem btn_OpenMapFile;
        private DevExpress.XtraBars.BarButtonItem btn_AddMapLayer;
        private DevExpress.XtraBars.BarButtonItem btn_ExportMapPic;
        private DevExpress.XtraBars.BarButtonItem btn_MapMeasureLength;
        private DevExpress.XtraBars.BarButtonItem btn_MapMeasureArea;
        private DevExpress.XtraBars.BarButtonItem btn_MapIdentifyInfo;
        private DevExpress.XtraBars.BarButtonItem btn_Data_StatisticTables;
        private DevExpress.XtraBars.BarButtonItem btn_PublishDisasterDoc;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl_Left;
        private DevExpress.XtraTab.XtraTabPage Pag_UndealData;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl_Center;
        private DevExpress.XtraTab.XtraTabPage Pag_ProcessMsg;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private DevExpress.XtraBars.BarButtonItem btn_AnalysisFuture;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem btn_ManageOfMap;
        private DevExpress.XtraBars.BarButtonItem btn_ManageOfData;
        private DevExpress.XtraBars.BarButtonItem btn_FullExtent;
        private DevExpress.XtraBars.BarButtonItem btn_Select;
        private DevExpress.XtraBars.BarButtonItem btn_NextView;
        private DevExpress.XtraBars.BarButtonItem btn_FrontView;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private DevExpress.XtraEditors.LabelControl ScaleLable;
        private DevExpress.XtraBars.BarButtonItem btn_Save;
        private DevExpress.XtraBars.BarButtonItem btn_Refresh;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem User_On;
        private DevExpress.XtraBars.BarButtonItem User_reg;
        private DevExpress.XtraBars.BarButtonItem User_down;
        private DevExpress.XtraBars.BarButtonItem Data_Cov;
        private DevExpress.XtraBars.BarButtonItem Data_Open;
        private DevExpress.XtraBars.BarButtonItem Data_vec;
        private DevExpress.XtraBars.BarButtonItem User_set;
        private DevExpress.XtraBars.BarButtonItem User_Save;
        private DevExpress.XtraBars.BarButtonItem User_help;
        private DevExpress.XtraBars.Ribbon.RibbonPage User_Manage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup System_set;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup River_manage;
        private DevExpress.XtraBars.BarEditItem User_Now;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.RibbonGalleryBarItem ribbonGalleryBarItem1;
        private System.Windows.Forms.ListView Lis_UndealData;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip Undeal_Menu_Tool;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip Deal_Menu_Tool;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 返回ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 返回ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 视图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 大图标ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 列表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 视图ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 大图标ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 列表ToolStripMenuItem1;
        private System.Windows.Forms.ListView Lis_DealData;
        private DevExpress.XtraBars.BarHeaderItem barHeaderItem1;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevExpress.XtraTab.XtraTabPage Pag_ProcessedData;
        private System.Windows.Forms.Button but_back;
        private System.Windows.Forms.Button but_openDir;
        private System.Windows.Forms.Button but_deal_back;
        private System.Windows.Forms.Button but_deal_openDir;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.Controls.RichTextBoxEx MessageShow;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button but_undeal;
        private System.Windows.Forms.Button but_Start;
        private System.Windows.Forms.Button but_Cancel;
        private System.Windows.Forms.Button but_password;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX lab_progress;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevExpress.XtraEditors.MarqueeProgressBarControl progressBar;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX undeal_pathway;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraTab.XtraTabPage Pag_Map;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
    }
}

