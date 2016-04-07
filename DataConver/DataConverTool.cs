using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Threading;
using System.Data.OleDb;

using Microsoft.Office.Interop.Excel;
using SuperMap.Data;
using ESRI.ArcGIS.AnalysisTools;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataManagementTools;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geoprocessor;
using ESRI.ArcGIS.Geoprocessing;
using SuperMapTool;


namespace DataConver
{
    class DataConverTool
    {
        
       // private AxMapControl axMapControl = null;
        private Geoprocessor gp = new Geoprocessor();
        private int vec_count = 0;//矢量数据处理计数
        private int ras_count = 0;//栅格数据处理计数
        private DirectoryInfo di;
        private DateTime datetime;
        private Hashtable Htable;
        static SuperMap.Data.Workspace wks = new SuperMap.Data.Workspace();
        private Recordset recordset;
        private ImportTool importTool = new ImportTool(wks);
        private Setting set = new Setting();
        DevExpress.XtraEditors.MarqueeProgressBarControl progressBar;
        DevComponents.DotNetBar.Controls.RichTextBoxEx MessageShow;
        DevComponents.DotNetBar.LabelX lab_progress;
        DevComponents.DotNetBar.LabelX lb;
        private string failedRecord = "";
        int max=0;
        AxMapControl axMapControl = null;
        private string fhys = null;
        public DataConverTool(DevComponents.DotNetBar.LabelX lab_progress, DevComponents.DotNetBar.LabelX lb, DevExpress.XtraEditors.MarqueeProgressBarControl progressBar, DevComponents.DotNetBar.Controls.RichTextBoxEx MessageShow, AxMapControl axMap)
        {
            this.lb = lb;
            this.axMapControl = axMap;
            this.lab_progress = lab_progress;
            this.progressBar = progressBar;
            this.MessageShow = MessageShow;
        }
        public void controller(string txtPath, string shpFilePath, string shpFileName, string cellSize, string SavaPath)
        {
          //  readtxt += readTXT(txtPath, shpFilePath, shpFileName, cellSize, SavaPath);
        }
        //实时进度信息
        public void pgrs(int p)
        {
            double percent = Convert.ToDouble(p) / Convert.ToDouble(max);
            lb.Text = percent.ToString("0%");
        }
        //实时输出信息
        public void Msg(string msg)
        {
            try
            {
                System.Windows.Forms. Application.DoEvents();
                progressBar.EditValue = msg;
                MessageShow.AppendText(msg + System.Environment.NewLine);
                MessageShow.Focus();
                MessageShow.SelectionStart = MessageShow.Text.Length;///焦点在最后
            }
            catch
            { }
        }
        //时间计算
        public  string ExecDateDiff(DateTime dateBegin, DateTime dateEnd)
        {
            TimeSpan ts1 = new TimeSpan(dateBegin.Ticks);
            TimeSpan ts2 = new TimeSpan(dateEnd.Ticks);
            TimeSpan ts3 = ts1.Subtract(ts2).Duration();
            //你想转的格式
            return String.Format("{0}时{1}分{2}秒。", ts3.Hours, ts3.Minutes, ts3.Seconds);
        }
        /*主处理函数需要执行的操作：
         * 1、传入参数：河段路径
         * 2、方法：数据转换、溃口数据导入、淹没过程数据导入、影响分析数据导入、模板、属性替换、生成处理报告、更改文件名
         * 3、定义参数：输出路径
         * 
         */
        //主处理函数
        public bool DealAll(string dataPath, string password)
        {
            set.passWord = password;
            DateTime dt = DateTime.Now;
            string tiff = null;
            string mod = null;
            string fxtb = null;
            string outPath = null;
            string outPath_Mid = null;
            string outPath_Final = null;
            try
            {
                if (dataPath.Substring(dataPath.Length - 3) == "已处理")
                    return false;//判断该编制单元是否被处理，是则返回，不是则继续执行
                di = new DirectoryInfo(dataPath);
                FileInfo[] information = di.GetFiles("*信息.txt", SearchOption.AllDirectories);
                FileInfo[] yuanData = di.GetFiles("元数据.xml", SearchOption.AllDirectories);
                //成果图的获取
                DirectoryInfo[] picture = di.GetDirectories("*成果图件*", SearchOption.AllDirectories);
               
                //地图数据获取
                FileInfo[] mxd = di.GetFiles("完整地图.mxd", SearchOption.AllDirectories);
                
                //设置淹没过程影像文件路径
                DirectoryInfo[] tiff1 = di.GetDirectories("tiffPath", SearchOption.AllDirectories);
                if(tiff1.Length>0)
                tiff = tiff1[0].FullName;
                else
                {
                    if (MessageBox.Show("未找到淹没过程数据，是否即时生成？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Tiff tif = new Tiff(dataPath) { StartPosition = FormStartPosition.CenterScreen };
                        //tif.TopMost = true;
                        tif.Show();
                        return false;
                    }
                    else
                        MessageBox.Show("无淹没过程数据，继续无法将无法生成淹没过程地图", "提示");
                    
                }
                MessageShow.Clear();
                mod = set.mod;//设置地图模板路径
                //设置编制单元名称，用于信息输出
                fxtb = dataPath.Substring(dataPath.LastIndexOf("\\") + 1);
                datetime = DateTime.Now;//设置开始实时间
                lab_progress.Text = String.Format("正在处理：【{0}】", fxtb);
                Msg("正在处理河段：" + fxtb);
                if (System.IO.Directory.Exists(String.Format("{0}\\{1}_已处理", set.deal_path, fxtb)))
                {
                    if (MessageBox.Show("已处理编制单元中已存在该编制单元，是否覆盖继续转换？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                       return false;
                    }
                   
                }
                //创建输出对应目录
                outPath = importTool.createFolder(String.Format("{0}\\{1}_已处理", set.deal_path, fxtb));
                //创建输出中间数据目录
                outPath_Mid = importTool.createFolder(String.Format("{0}\\中间数据", outPath));
                //创建超图结果数据目录
                outPath_Final = importTool.createFolder(String.Format("{0}\\{1}", outPath, fxtb));
                if(information.Length>0)
                File.Copy(information[0].FullName, String.Format("{0}\\{1}", outPath_Final, information[0].Name), true);
                if(yuanData.Length>0)
                File.Copy(yuanData[0].FullName, String.Format("{0}\\{1}", outPath_Final, yuanData[0].Name), true);
                DirectoryInfo codeDir = new DirectoryInfo(set.setupPath);
                FileInfo[] codeFile = codeDir.GetFiles("地物编码表.txt",SearchOption.AllDirectories);
//=======================================================================================
//----------------------------------------------------------------------------------------
                Msg(lab_progress.Text = "【" + fxtb + "】正在进行数据转换···");
                axMapControl.LoadMxFile(mxd[0].FullName, 0, Type.Missing);
                //提取数据函数调用
                if (codeFile.Length > 0)
                {
                    Htable = getCode(codeFile[0].FullName);
                    getGroupLayer(axMapControl, outPath_Mid);
                }
                else
                    Msg("未找到地物编码表···请检查文件是否存在");
                Msg(String.Format("本次处理数据总数为：{0}条\r\n其中处理矢量数据：{1}条\r\n处理栅格数据：{2}条", vec_count + ras_count, vec_count, ras_count));
                Msg("用时：" + ExecDateDiff(datetime, DateTime.Now));//显示用时
//---------------------------------------------------------------------------------------

                
                Msg(lab_progress.Text = "【" + fxtb + "】正在导入淹没过程影像数据···");
                //淹没过程影像数据导入
                ymgcImport(outPath_Final, tiff);
              
//----------------------------------------------------------------------------------------
                //水利工程数据导入
                Msg(lab_progress.Text = "【" + fxtb + "】正在导入水利工程数据···");
                slgc(outPath_Final, outPath_Mid);
       
//----------------------------------------------------------------------------------------
                //专题地图的导入
                Msg(lab_progress.Text = "【" + fxtb + "】正在导入专题地图数据···");
                ztdt(outPath_Final, outPath_Mid);
//----------------------导入excel数据-------------------------
                Msg(lab_progress.Text = "【" + fxtb + "】正在导入Excel支撑数据···");
                ExcelDataImport("*避洪转移展示支撑数据*.xls*", outPath_Final, "bhzyAttr", "bhzy.udb");
                ExcelDataImport("*查询业务支撑数据*.xls*", outPath_Final, "ywcxAttr", "ywcx.udb");
//----------------------------------------------------------------------------------------
                //避洪转移数据导入
                Msg(lab_progress.Text = "【" + fxtb + "】正在导入避洪转移数据···");
                bhzy(dataPath, outPath_Final);

//----------------------------------------------------------------------------------------
                //复合要素数据导入
                Msg(lab_progress.Text = "【" + fxtb + "】正在导入复合要素数据···");
                fhysImport(outPath_Final, outPath_Mid);

//----------------------------------------------------------------------------------------
                //影响分析数据导入
                Msg(lab_progress.Text = "【" + fxtb + "】正在导入影响分析数据···");
                yxfx(dataPath, outPath_Final);

//----------------------------------------------------------------------------------------
                //更新影响分析数据属性表
                Msg(lab_progress.Text = "【" + fxtb + "】正在更新属性数据···");
                try
                {

                    FileInfo[] xlsPath = di.GetFiles("*影响分析支撑数据*.xls*", SearchOption.AllDirectories);
                    foreach (FileInfo xx in xlsPath)
                    {
                        ConnectAttribute(xx.FullName, String.Format("{0}\\yxfx", outPath_Final));
                    }
                }
                catch
                {
                    Msg("更新属性数据不存在，跳过更新");
                }
                

                 
//-------------------------导入地图模板---------------------------------------------------------------
                
                Msg(lab_progress.Text = "【" + fxtb + "】正在加载地图模板···");

                datetime = DateTime.Now;
                ImportMapModel(String.Format("{0}\\MapResult", outPath_Final), outPath_Final, set.mod);
               
                Msg("用时：" + ExecDateDiff(datetime, DateTime.Now));
 
//----------------------------------------------------------------------------------------
                //复制成果图
                Msg(lab_progress.Text = "【" + fxtb + "】正在复制成果图···");

                importTool.createFolder(outPath_Final + "\\成果图");
                di = new DirectoryInfo(picture[0].FullName);
                max = di.GetFiles().Length;
                foreach (FileInfo jpg in di.GetFiles())
                {
                    int p = 0;
                    File.Copy(jpg.FullName, String.Format("{0}\\成果图\\{1}", outPath_Final, jpg.Name), true);
                    pgrs(p++);
                }
                Msg("复制成果图成功！");
//----------------------------------------------------------------------------------------
                //生成处理报告
                Msg("正在生成处理报告····");
                Msg("本编制单元用时：" + ExecDateDiff(dt, DateTime.Now));
                MessageShow.SaveFile(outPath_Final + "_处理报告.txt", RichTextBoxStreamType.TextTextOleObjs);
                Msg(outPath_Final + "_处理报告.txt  已生成成功!");

                Msg("正在生成错误日志····");
                MessageShow.Text = failedRecord;
                MessageShow.SaveFile(outPath_Final + "_错误日志.txt", RichTextBoxStreamType.TextTextOleObjs);
               // Directory.Move(dataPath, dataPath + "_已处理");
                lab_progress.Text = "【" + fxtb + "】处理完成";
                return true;
            }
            catch (Exception ex)
            {
                Msg(ex.Message);
                return false;
            }
        }

//=============================功能函数========================================
       //---------------------数据提取------------------------------------------
        //读取groupLayer
        public void getGroupLayer(AxMapControl mapControl, string outPath_Mid)
        {
            //IFeatureLayer layer = null;
            max = mapControl.LayerCount;

            for (int i = 0; i < mapControl.LayerCount; i++)
            {
                pgrs(i);
                ILayer layers = mapControl.get_Layer(i);
                if (layers is GroupLayer || layers is ICompositeLayer)   //判断是否是groupLayer
                {
                    //MessageBox.Show(layers.Name);
                    //创建文件夹：slgc，ztdt，bhzy
                    if (layers.Name.Equals("水利工程"))
                    {
                        //创建文件夹：slgc
                        string slgcPath = importTool.createFolder(outPath_Mid + "\\slgc");
                        List<string> StoreFeatureLayerSourse = new List<string>();
                        //将该文件路径传入函数中
                        getSlgcSubLayer(layers, slgcPath, StoreFeatureLayerSourse);  //递归的思想
                    }
                    else if (layers.Name.Substring(0, 2).Equals("方案"))
                    {

                        //创建ztdu文件夹
                        string ztdtPath = importTool.createFolder(outPath_Mid + "\\ztdt");

                        //传入参数  ztdt和方案i

                        getSubLayer(layers, ztdtPath, layers.Name + "_", false);  //递归的思想

                    }
                    else
                    {
                        //创建bhzy文件夹
                        string bhzyPath = importTool.createFolder(outPath_Mid + "\\fhys");
                        ////传入参数
                        getSubLayer(layers, bhzyPath, null, true);  //递归的思想
                    }

                }

            }
            //MessageBox.Show(layer.Name);
            //return layer;
        }
        //读取子图层
        public void getSubLayer(ILayer layers, string ExportPath, string plan, bool Isfhys)
        {

            ICompositeLayer compositeLayer = layers as ICompositeLayer;
            for (int i = 0; i < compositeLayer.Count; i++)
            {
                ILayer layer = compositeLayer.Layer[i];   //递归
                if (layer is GroupLayer || layer is ICompositeLayer)
                {
                    if (Isfhys)
                    {
                        fhys = layer.Name + "_";
                    }
                    //MessageBox.Show(layer.Name);
                    getSubLayer(layer, ExportPath, plan, Isfhys);
                }
                else
                {
                    try
                    {
                        IFeatureLayer l = layer as IFeatureLayer;
                        IRasterLayer r = layer as IRasterLayer;
                        if (plan != null && plan.Substring(0, 2) == "方案")
                        {
                            if (!(layer.Name.Contains("方案")))//陈杜彬315修改
                                layer.Name = plan + layer.Name;
                               // layer.Name = plan + layer.Name.Substring(0, layer.Name.LastIndexOf("_"));
                           // else
                                
                        }

                        if (l != null)
                        {
                            if (Isfhys)
                                layer.Name = fhys + layer.Name;
                            if (plan != null && plan.Contains("方案"))
                            {
                                if (l.Name.Contains("淹没历时"))
                                    MessageBox.Show("淹没历时");
                                if (l.FeatureClass.ShapeType == ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolygon)
                                {
                                    shp2Raster(gp, l.FeatureClass, l.Name, ExportPath + "\\" + layer.Name);
                                    
                                }
                                else
                                    ExtractFeatureClass(layer.Name, gp, ExportPath, FeatureClassSourse(l));

                            }
                            else
                                ExtractFeatureClass(layer.Name, gp, ExportPath, FeatureClassSourse(l));
                        }
                        else if (r != null)
                        {
                            if (Isfhys)
                                r.Name = fhys + r.Name;
                            ExtractRaster(r.Name, gp, ExportPath, RasterDataSourse(r));
                        }
                        //Msg(layer.Name);
                    }
                    catch
                    {


                    }
                    //}
                }
            }

            //return l;
        }
        //抽取feature
        public void getSlgcSubLayer(ILayer layers, string ExportPath, List<string> list)
        {

            ICompositeLayer compositeLayer = layers as ICompositeLayer;
            for (int i = 0; i < compositeLayer.Count; i++)
            {
                ILayer layer = compositeLayer.Layer[i];   //递归
                if (layer is GroupLayer || layer is ICompositeLayer)
                {
                    //MessageBox.Show(layer.Name);
                    getSlgcSubLayer(layer, ExportPath, list);
                }
                else
                {
                    try
                    {
                        IFeatureLayer l = layer as IFeatureLayer;

                        if (l != null)
                        {
                            string sourse = FeatureClassSourse(l);
                            if (list.Count > 0)
                            {
                                bool isdeal = false;
                                foreach (string s in list)
                                {
                                    if (s == sourse)
                                    {
                                        isdeal = true;
                                        break;
                                    }
                                }
                                if (!isdeal)
                                {
                                    if (Htable == null)
                                        return;
                                    ExcuteGetFeature(l.FeatureClass, Htable, ExportPath);
                                    list.Add(sourse);
                                }
                            }
                            else
                            {
                                if (Htable == null)
                                    return;
                                ExcuteGetFeature(l.FeatureClass, Htable, ExportPath);

                                // ExtractFeatureClass(layer.Name, gp, ExportPath, FeatureClassSourse(l));
                                list.Add(sourse);
                            }
                        }

                    }
                    catch (Exception ex)
                    {

                        Msg(ex.Message);
                    }
                    //}
                }
            }

            //return l;
        }
        //读取编码表
        private Hashtable getCode(string CodeTxt)
        {
            Hashtable hb = new Hashtable();
            string[] split;
            string l;
            try
            {
                StreamReader sr = new StreamReader(CodeTxt, Encoding.Default);
                while ((l = sr.ReadLine()) != null)
                {
                    split = l.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    object key = split[0];
                    object value = split[1];
                    if (hb.Contains(key))
                        MessageBox.Show(key.ToString());
                    hb.Add(key, value);
                }
                return hb;
            }
            catch (Exception ex)
            {
                Msg(ex.Message);
                return null;
            }
        }
        //根据code值来抽取各图层存放至slgc中
        private void getFeature(Geoprocessor gp, IFeatureClass featureClass, string codeValue, string SavaFolder, Hashtable hb)
        {
            try
            {
                ESRI.ArcGIS.AnalysisTools.Select selectFeature = new Select();
                selectFeature.in_features = featureClass;
                selectFeature.where_clause = "Code=" + codeValue;
                selectFeature.out_feature_class = string.Format("{0}\\{1}.shp", SavaFolder, hb[codeValue]);
                gp.OverwriteOutput = true;
                gp.Execute(selectFeature, null);
                Msg(hb[codeValue].ToString() + "转换成功···");
            }
            catch (Exception ex)
            {
                Msg(ex.Message);
            }
        }
        private void ExcuteGetFeature(IFeatureClass featureClass, Hashtable Htable, string SavaFolder)
        {
            if (featureClass == null)
                return;
            Geoprocessor gp = new Geoprocessor();
            try
            {
                string[] uniqueValue = GetUniqueValue(featureClass, "Code");
                foreach (string codeValue in uniqueValue)
                {
                    getFeature(gp, featureClass, codeValue, SavaFolder, Htable);
                }
            }
            catch (Exception ex)
            {
                Msg(ex.Message);
            }
        }
        /// <summary>
        /// 获取字段唯一值
        /// </summary>
        public static string[] GetUniqueValue(IFeatureClass pFeatureClass, string strFld)
        {

            //得到IFeatureCursor游标
            IFeatureCursor pCursor = pFeatureClass.Search(null, false);
            //coClass对象实例生成
            IDataStatistics pData = new DataStatisticsClass();
            pData.Field = strFld;
            pData.Cursor = pCursor as ICursor;
            //枚举唯一值
            System.Collections.IEnumerator pEnumVar = pData.UniqueValues;
            //记录总数
            int RecordCount = pData.UniqueValueCount;
            //字符数组
            string[] strValue = new string[RecordCount];
            pEnumVar.Reset();
            int i = 0;
            while (pEnumVar.MoveNext())
            {
                strValue[i++] = pEnumVar.Current.ToString();
            }
            return strValue;
        }
        
        //提取featureclass图层的路径信息
        private string FeatureClassSourse(IFeatureLayer pFeatureLayer)
        {
            string featureClassSourse = null;
            try
            {
                //pFeatureLayer = GetFeatureLayer(LayerName);
                if (pFeatureLayer.DataSourceType == "File Geodatabase Feature Class" || pFeatureLayer.DataSourceType == "文件地理数据库要素类")
                {
                    IFeatureClass fc = pFeatureLayer.FeatureClass;
                    string name1 = fc.AliasName;
                    IFeatureDataset fds = fc.FeatureDataset;
                    string name2 = fds.BrowseName;
                    string name3 = fds.Workspace.PathName;
                    featureClassSourse = String.Format("{0}\\{1}\\{2}", name3, name2, name1);
                    return featureClassSourse;
                }
                else
                    return null;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        //提取RasterDataSourse图层的路径信息
        private string RasterDataSourse(IRasterLayer pRasterLayer)
        {
            try
            {
                //IRasterLayer pRasterLayer = GetRasterLayer(LayerName);
                return pRasterLayer.FilePath;//.Substring(0, pRasterLayer.FilePath.LastIndexOf("\\"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        //提取矢量数据
        private void ExtractFeatureClass(string LayerName, Geoprocessor gp, string aimPath, string sourcePath)
        {
            //Msg("开始处理..." + LayerName);
            try
            {
                ESRI.ArcGIS.DataManagementTools.CopyFeatures copyFeature = new CopyFeatures();
                copyFeature.in_features = sourcePath;
                copyFeature.out_feature_class = String.Format("{0}\\{1}", aimPath, LayerName);
                gp.OverwriteOutput = true;
                gp.Execute(copyFeature, null);
                Msg(LayerName + "-->转换完成！");
                vec_count++;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

        }
        //
        /// <summary>
        /// 提取栅格数据
        /// </summary>
        /// <param name="LayerName">图层名字</param>
        /// <param name="gp">gp工具</param>
        /// <param name="aimPath">目标数据</param>
        /// <param name="sourcePath">存储位置</param>
        private void ExtractRaster(string LayerName, Geoprocessor gp, string aimPath, string sourcePath)
        {
            Msg("开始处理..." + LayerName);
            string RasterName = sourcePath.Substring(sourcePath.LastIndexOf("\\") + 1);
            try
            {
                if (RasterName.Substring(0, 4).Equals("Band"))
                    sourcePath = sourcePath.Substring(0, sourcePath.LastIndexOf("\\"));//陈杜彬 3.8修改
                ESRI.ArcGIS.DataManagementTools.CopyRaster copyRaster = new CopyRaster() { in_raster = sourcePath, out_rasterdataset = String.Format("{0}\\{1}.tif", aimPath, LayerName) };
                gp.OverwriteOutput = true;
                gp.Execute(copyRaster, null);
                Msg(LayerName + "-->转换完成！");
                ras_count++;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
//--------------导入数据-------------------------------------------------------------
        //数据导入函数
        private void DataImport(string type1, string type2, string sourPath, DatasourceConnectionInfo info, bool IsYmgc)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(sourPath);
            List<string> tif = new List<string>();
            try
            {
                if (!System.IO.Directory.Exists(sourPath))
                {
                    Msg("无此数据。");
                    return;
                }
                datetime = DateTime.Now;
                List<string> shp = importTool.getAllFileName(sourPath, type1);
                int p = 0;
                max = shp.Count;
                foreach (string l1 in shp)
                {

                    if (l1 == "水系面状.shp")
                        continue;
                    failedRecord += importTool.ImportShp(sourPath + l1, info);// resultData + "\\" + jcdt.Text);
                    pgrs(++p);
                    Msg(l1 + "导入成功！");
                }
                FileInfo[] tifFile = directoryInfo.GetFiles("*.tif", SearchOption.TopDirectoryOnly);
                if (IsYmgc)
                {
                    tif = FileSort(tifFile);
                }
                else
                    tif = importTool.getAllFileName(sourPath, type2);
                //tif.Sort();
                max = tif.Count;
                int q = 0;
                foreach (string l2 in tif)
                {

                    if (IsYmgc)
                        failedRecord += importTool.ImportTIFF(sourPath + l2 + ".tif", info);
                    else
                        failedRecord += importTool.ImportTIFF(sourPath + l2, info);
                    pgrs(q++);
                    Msg(l2 + "导入成功！");
                }
                Msg("导入任务数据总" + (shp.Count + tif.Count).ToString() + "条");//+ "\r\n" + "本次成功导入数据" + importTool.i.ToString() + "条");
                Msg("用时：" + ExecDateDiff(datetime, DateTime.Now));
            }
            catch (Exception ex)
            {
                Msg(ex.Message);
            }
        }
        //file排序
        private List<string> FileSort(FileInfo[] fileInfo)
        {
            List<int> list = new List<int>();
            List<string> sortList = new List<string>();
            try
            {
                if (fileInfo.Length > 0)
                {
                    foreach (FileInfo file in fileInfo)
                    {
                        int index = file.Name.Substring(4).LastIndexOf(".");
                        list.Add(Convert.ToInt32(file.Name.Substring(4).Substring(0, index)));
                    }
                    list.Sort();
                    foreach (int sorted in list)
                    {
                        sortList.Add("time" + sorted.ToString());
                    }
                    return sortList;
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        
        //水利工程导入函数
        private void slgc(string outPath_Final, string outPath_Mid)
        {

            try
            {
                //创建udb并加密
                //DatasourceConnectionInfo info = CreatUDB(outPath_Final, "slgc", set.passWod);
                DatasourceConnectionInfo info = new DatasourceConnectionInfo() { Password = set.passWord, Server = String.Format("{0}\\slgc.udb", outPath_Final) };
                DataImport("*.shp", "*.tif", outPath_Mid + "\\slgc\\", info,false);
                wks.Datasources.CloseAll();
            }
            catch (Exception ex)
            {
                Msg(ex.Message);
            }
        }
        //专题地图导入函数
        public void ztdt(string outPath_Final, string outPath_Mid)
        {
            try
            {
                //DatasourceConnectionInfo info = CreatUDB(outPath_Final, "ztdt", set.passWod);
                DatasourceConnectionInfo info = new DatasourceConnectionInfo() { Password = set.passWord, Server = String.Format("{0}\\ztdt.udb", outPath_Final) };
                DataImport("*.shp", "*.tif", outPath_Mid + "\\ztdt\\", info,false);
                wks.Datasources.CloseAll();
            }
            catch (Exception ex)
            {
                Msg(ex.Message);
            }
        }
        //复合要素方案导入
        public void fhysImport(string outPath_Final, string outPath_Mid)
        {
            try
            {
                //DatasourceConnectionInfo info = CreatUDB(outPath_Final, "ztdt", set.passWod);
                DatasourceConnectionInfo info = new DatasourceConnectionInfo() { Password = set.passWord, Server = String.Format("{0}\\fhys.udb", outPath_Final) };
                DataImport("*.shp", "*.tif", outPath_Mid + "\\fhys\\", info,false);
                wks.Datasources.CloseAll();
            }
            catch (Exception ex)
            {
                Msg(ex.Message);
            }
        }
        //影响分析导入函数
        public void yxfx(string yxfx_path, string outPath_Final)
        {
            try
            {
                string mc;//设置过滤水系面状的数据
                datetime = DateTime.Now;
                //创建数据源
                di = new DirectoryInfo(yxfx_path);
                DirectoryInfo[] yxfxPath = di.GetDirectories("6.3影响分析支撑数据", SearchOption.AllDirectories);
                DatasourceConnectionInfo info = new DatasourceConnectionInfo() { Password = set.passWord, Server = String.Format("{0}\\yxfx.udb", outPath_Final) };
                foreach (DirectoryInfo dd in yxfxPath)
                {
                    ////遍历文件夹
                    FileInfo[] info_file = dd.GetFiles("*.shp", SearchOption.AllDirectories);
                    max = info_file.Length; int p = 0;
                    foreach (FileInfo NextFolder in info_file)//"*.shp",
                    {

                        mc = NextFolder.Name;
                        if (mc == "水系面状.shp")
                            continue;
                        failedRecord += importTool.ImportShp(String.Format("{0}\\{1}", NextFolder.Directory, mc), info);
                        pgrs(++p);
                        Msg(mc + "导入成功！");
                    }
                    Msg(String.Format("本次成功导入数据{0}条", importTool.i));
                    Msg("用时：" + ExecDateDiff(datetime, DateTime.Now));
                }
                wks.Datasources.CloseAll();
            }
            catch (Exception ex)
            {
                Msg(ex.Message);
            }
        }
        //避洪转移数据导入
        public void bhzy(string bhzy_path, string outPath_Final)
        {
            try
            {
                datetime = DateTime.Now;
                //创建数据源
                di = new DirectoryInfo(bhzy_path);
                DirectoryInfo[] bhzyPath = di.GetDirectories("6.4避洪转移展示支撑数据", SearchOption.AllDirectories);
                DatasourceConnectionInfo info = new DatasourceConnectionInfo() { Password = set.passWord, Server = String.Format("{0}\\bhzy.udb", outPath_Final) };
                FileInfo[] info_file = bhzyPath[0].GetFiles("*.shp", SearchOption.AllDirectories);
                max = info_file.Length;
                if (max == 0)
                    return;
                int p = 0;
                foreach (FileInfo NextFolder in info_file)//"*.shp",
                {
                    failedRecord += importTool.ImportShp(String.Format("{0}\\{1}", NextFolder.Directory, NextFolder.Name), info);
                    pgrs(++p);
                    Msg(NextFolder.Name + "导入成功！");
                }
                Msg(String.Format("本次成功导入数据{0}条", importTool.i));
                Msg("用时：" + ExecDateDiff(datetime, DateTime.Now));
                //}
                wks.Datasources.CloseAll();
            }
            catch (Exception ex)
            {
                Msg(ex.Message);
            }
        }

        //淹没过程数据的导入
        public void ymgcImport(string outPath_Final, string ymgc_path)
        {
            try
            {   //生成淹没过程数据存放在txt名字命名的文件夹下即tiffPath---ymgcX
                if (ymgc_path == null)
                {
                    Msg("淹没过程数据不存在，系统自动跳过该操作··");
                    return;
                }
                DirectoryInfo tifDi = new DirectoryInfo(ymgc_path);
                DirectoryInfo[] ymgcDir = tifDi.GetDirectories();
                if (ymgcDir.Length > 0)
                {
                    foreach (DirectoryInfo ymgcX in tifDi.GetDirectories())
                    {
                        //DatasourceConnectionInfo info = CreatUDB(outPath_Final, "ztdt", set.passWod);
                        //string udbName = ymgc_path.Substring(ymgc_path.LastIndexOf("\\") + 1);
                        DatasourceConnectionInfo info = new DatasourceConnectionInfo();
                        info.Password = set.passWord;
                        info.Server = outPath_Final + "\\" + ymgcX.Name + ".udb";
                        DataImport(" ", "*.tif", ymgcX.FullName + "\\", info, true);
                    }
                    wks.Datasources.CloseAll();
                }
            }
            catch (Exception ex)
            {
                Msg(ex.Message);
            }
        }//excel表导入函数
        //属性表数据导入
        public void ExcelDataImport(string xlName, string outPath_Final, string csvName,string udbName)
        {
            try
            {
                //将避洪转移支撑数据导入需要参数：excel路径，"*避洪转移展示支撑数据 .xls"
                FileInfo[] info_file = di.GetFiles(xlName, SearchOption.AllDirectories);
                if (info_file != null && info_file.Length > 0)
                {
                    bool toCSVStatus = false;
                    //string bhzyXlName = "bhzyAtrr.csv";
                    foreach (FileInfo xlPath in info_file)
                    {
                        toCSVStatus = toCSV(String.Format("{0}\\{1}", xlPath.DirectoryName, xlPath.Name), String.Format("{0}\\{1}", xlPath.DirectoryName, csvName));
                    }
                    if (toCSVStatus)
                    {
                        FileInfo[] CSVfile = di.GetFiles("*.csv", SearchOption.AllDirectories);
                        foreach (FileInfo subName in CSVfile)
                        {
                            CSVImport(subName.Name, outPath_Final, udbName);
                            File.Delete(subName.FullName);
                        }
                    }
                }
                else
                    Msg("数据不存在。");
            }
            catch (Exception ex)
            {
                Msg(ex.Message);
            }
        }
        public void CSVImport(string CSVTargetName, string outPath_Final,string udbName)
        {
            try
            {

                DatasourceConnectionInfo info = new DatasourceConnectionInfo() { Password = set.passWord, Server = String.Format("{0}\\{1}", outPath_Final, udbName) };
                FileInfo[] info_file = di.GetFiles(CSVTargetName, SearchOption.AllDirectories);

                foreach (FileInfo NextFolder in info_file)//"*.shp",
                {
                    failedRecord += importTool.ImportCSV(CSVTargetName, NextFolder.FullName, info);

                    Msg(NextFolder.Name + "导入成功！");
                }


                wks.Datasources.CloseAll();
            }
            catch (Exception ex)
            {
                Msg(ex.Message);
            }
        }
//------------更新属性表-----------------------------------------------------------------
        
        public void ConnectAttribute(string xlsPath, string udbPath)
        {
            datetime = DateTime.Now;
            string[] m_newFieldName = { "生产总值", "耕地面积", "人口总数" };
            //定义工作空间
            SuperMap.Data.Workspace wps = new SuperMap.Data.Workspace();
            //工作空间打开数据源
            wps.Datasources.Open(new DatasourceConnectionInfo(udbPath, "yxfx", set.passWord));
            //临时数据集
            Dataset srcDataset = wps.Datasources[0].Datasets["xzjLayer"];
            DatasetVector dv = (DatasetVector)srcDataset;
            FieldInfos m_fieldInfos = dv.FieldInfos;
            for (int i = 0; i < m_newFieldName.Length; i++)
            {
                try
                {
                    if (m_fieldInfos.IndexOf(m_newFieldName[i]) != -1)
                    {
                        Msg("数据集中已经有指定字段！" + m_newFieldName[i]);

                        continue;
                    }

                    SuperMap.Data.FieldInfo delField = new SuperMap.Data.FieldInfo(m_newFieldName[i], SuperMap.Data.FieldType.Double) { IsRequired = false, DefaultValue = "0.0", Caption = m_newFieldName[i] };
                    m_fieldInfos.Add(delField);
                    Msg("成功添加字段：" + m_newFieldName[i]);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            recordset = dv.GetRecordset(false, CursorType.Dynamic);
            UpdateFieldValueTest(recordset, xlsPath);
            wps.Dispose();
            Msg("用时：" + ExecDateDiff(datetime, DateTime.Now));
        }
        private void UpdateFieldValueTest(Recordset recordset, string xlsPath)
        {
            try
            {
                string[] sheetNameList = GetSheetNameList(xlsPath);
                System.Data.DataTable dt = importTool.ExcelToDataTable(xlsPath, sheetNameList[0]);

                int length = recordset.RecordCount;
                if (length != 0)
                {

                    /*需求：根据乡镇名字确定更新数据
                     1、选择成行改变：1)循环判断工作表中name列的所有记录，是否等于属性表中name列的第一行的内容   
                                     2)记录工作表中的对应的行数h
                                     3）对数据集中特定字段逐行赋值*/
                    try
                    {
                        for (int m = 1; m <= length; m++)//行循环更新
                        {
                            recordset.SeekID(m);
                            recordset.Edit();
                            object name = recordset.GetObject("T_NAME");
                            seekExcel(name.ToString(), dt, recordset, m);

                        }

                        recordset.Update();

                        Msg("修改属性字段完成");
                    }
                    catch (Exception ex)
                    {
                        Msg(ex.Message);
                    }
                }
                else
                {
                    Msg("记录集中没有记录");
                }
            }
            catch (Exception ex)
            {
                Msg(ex.Message);
            }


        }
        private void seekExcel(string Name,System.Data.DataTable dt, Recordset recordset, int m)
        {
            bool next = false;
            try
            {
                for (int seekXZ = 0; seekXZ < dt.Rows.Count; seekXZ++)
                {
                    for (int seekColumn = 0; seekColumn < dt.Columns.Count; seekColumn++)
                    {
                        string s = dt.Rows[seekXZ][seekColumn].ToString();
                        if (s == Name)
                        {

                            double valueGDP = Convert.ToDouble(dt.Rows[seekXZ][seekColumn + 1]);
                            double valueAC = Convert.ToDouble(dt.Rows[seekXZ][seekColumn + 2]);
                            double valuePE = Convert.ToDouble(dt.Rows[seekXZ][seekColumn + 3]);
                            recordset.SeekID(m);
                            recordset.Edit();
                            recordset.SetDouble("生产总值", valueGDP);
                            recordset.Update();
                            recordset.SeekID(m);
                            recordset.Edit();
                            recordset.SetDouble("耕地面积", valueAC);
                            recordset.Update();
                            recordset.SeekID(m);
                            recordset.Edit();
                            recordset.SetDouble("人口总数", valuePE);
                            recordset.Update();
                            recordset.Refresh();
                            //MessageBox.Show(valueGDP.ToString() + "GDP：" + recordset.GetObject("GDP").ToString() + "\r" + valueAC.ToString() + recordset.GetObject("耕地面积").ToString() + "\r" + valuePE.ToString() + recordset.GetObject("总人口").ToString());
                            next = true;
                            break;
                        }
                        if (next)
                            break;
                    }
                    if (next)
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //------------导入地图模板和投影转换---------------------------------------------------------------------
        #region  导入地图模板和投影转换

        public void ImportMapModel( string wsp, string sources, string symbol)
        {

            CreateWorkspace(wsp, sources, symbol);
            try
            {
                SuperMap.Data.Workspace sWorkspace1 = new SuperMap.Data.Workspace();
                WorkspaceConnectionInfo info = new WorkspaceConnectionInfo(wsp + ".smwu");//@"G:\数据转换\测试数据\Test1\test.smwu");
                info.Password = set.passWord;
                sWorkspace1.Open(info);
                SuperMap.Data.Maps maps = sWorkspace1.Maps;
                SuperMap.Mapping.Map map = new SuperMap.Mapping.Map(sWorkspace1);
                DirectoryInfo di = new DirectoryInfo(set.setupPath);
                DirectoryInfo[] model = di.GetDirectories("MapModel", SearchOption.AllDirectories);
                DirectoryInfo directory = new DirectoryInfo(set.setupPath);
                FileInfo[] xml = model[0].GetFiles("*.xml");
                FileInfo[] finfoYmss = directory.GetFiles("*淹没水深*.xml", SearchOption.AllDirectories);
                FileInfo[] finfoYmls = directory.GetFiles("*淹没历时*.xml", SearchOption.AllDirectories);
                FileInfo[] finfoDdsj = directory.GetFiles("*到达时间*.xml", SearchOption.AllDirectories);
                FileInfo[] finfoYmt = directory.GetFiles("*淹没图*.xml", SearchOption.AllDirectories);
                max = xml.Length; int p = 0;
                foreach (FileInfo nn in xml)
                {

                    string Mapxml = readXML(nn.FullName);
                    string Mapname = nn.Name.Substring(0, nn.Name.LastIndexOf("."));
                    if (maps.IndexOf(Mapname) != -1)
                        maps.Remove(maps.IndexOf(Mapname));
                    maps.Add(Mapname, Mapxml);
                    //ModelApplication(Mapxml, wsp + ".smwu", nn.Name.Substring(0, nn.Name.Length - 4));
                    pgrs(p++);
                    Msg(nn.Name + "模板导入成功");
                    if (nn.Name.Contains("jcdt"))
                    {
                        //更新地图
                        if (sWorkspace1.Datasources["ztdt"] != null)
                        {
                            Datasource ds = sWorkspace1.Datasources["ztdt"];

                            string ref_YMSS = finfoYmss[0].FullName;
                            string ref_YMLS = finfoYmls[0].FullName;
                            string ref_DDSJ = finfoDdsj[0].FullName;
                            string ref_YMT = finfoYmt[0].FullName;
                            map = importTool.refresModels(ds, map, Mapname, ref_YMSS, ref_YMLS, ref_DDSJ, ref_YMT);
                            sWorkspace1.Maps.SetMapXML(Mapname, map.ToXML());
                            sWorkspace1.Save();
                        }
                        Msg(String.Format("地图{0}更新成功！", Mapname));
                        for (int i = 0; i < sWorkspace1.Datasources.Count; i++)
                        {
                            string datasourceName = sWorkspace1.Datasources[i].Alias;
                            if (datasourceName.Contains("ymgc"))
                            {
                                Datasource ds = sWorkspace1.Datasources[i];
                                string ref_YMSS = finfoYmss[0].FullName;
                                map = importTool.YMGCrefresModels(ds, map, Mapname, ref_YMSS);
                                sWorkspace1.Maps.Add(datasourceName, map.ToXML());
                                Msg(String.Format("地图{0}更新成功！", datasourceName));
                                sWorkspace1.Save();
                            }
                        }

                    }


                   

                }
                if (sWorkspace1.Save())
                    Msg("地图导入完成！");
                sWorkspace1.Dispose();
            }
            catch (Exception ex)
            {
               Msg("地图导入未完成！"+ex.Message);
            }
        }
        //读取xml中 的内容
        public String readXML(string pathOfXML)
        {
            string ss = File.ReadAllText(pathOfXML, Encoding.UTF8);
            return ss;
        }
        public void ModelApplication(String xml, string wksPath, string name)
        {
            //初始化工作空间
            try
            {
                SuperMap.Data.Workspace sWorkspace1 = new SuperMap.Data.Workspace();
                WorkspaceConnectionInfo info = new WorkspaceConnectionInfo(wksPath) { Password = set.passWord };//@"G:\数据转换\测试数据\Test1\test.smwu");
                sWorkspace1.Open(info);
                SuperMap.Data.Maps maps = sWorkspace1.Maps;

                maps.Add(name, xml);
                sWorkspace1.Save();
                sWorkspace1.Dispose();
            }
            catch (Exception ex)
            {
                Msg(ex.Message);
            }

        }
        public void CreateWorkspace(string wpsPath, string sources, string symbol)
        {
            // 创建工作空间，弹出 “关于”对话框
            Msg("正在创建工作空间···");
            SuperMap.Data.Workspace workspace = new SuperMap.Data.Workspace();
            WorkspaceConnectionInfo workspaceConnectionInfo = new WorkspaceConnectionInfo() { Type = WorkspaceType.SMWU, Name = "MapResult", Password = set.passWord };
            String file = wpsPath;
            workspaceConnectionInfo.Server = file;

            if (workspace.Create(workspaceConnectionInfo))
            {
                //MessageBox.Show("创建工作空间成功");
                workspace.Caption = "MapResult";
                workspace.Save();
                Msg("工作空间创建成功：" + workspace.Caption);
               // System.Threading.Thread.Sleep(500);
                Msg("正在导入符号库···");
                DirectoryInfo di = new DirectoryInfo(symbol);
                foreach (FileInfo fill in di.GetFiles("*.bru"))
                {
                    File.Copy(fill.FullName, String.Format("{0}//{1}", sources, fill.Name), true);
                    SymbolFillLibrary sf = workspace.Resources.FillLibrary;
                    sf.FromFile(String.Format("{0}//{1}", sources, fill.Name));
                    workspace.Save();
                }
                foreach (FileInfo point in di.GetFiles("*.sym"))
                {
                    File.Copy(point.FullName, String.Format("{0}//{1}", sources, point.Name), true);

                    SymbolMarkerLibrary sf = workspace.Resources.MarkerLibrary;
                    sf.FromFile(String.Format("{0}//{1}", sources, point.Name));
                    workspace.Save();
                } foreach (FileInfo Line in di.GetFiles("*.lsl"))
                {
                    File.Copy(Line.FullName, String.Format("{0}//{1}", sources, Line.Name), true);

                    SymbolLineLibrary sf = workspace.Resources.LineLibrary;
                    sf.FromFile(String.Format("{0}//{1}", sources, Line.Name));
                    workspace.Save();
                }
                Msg("符号库导入成功");

                System.Threading.Thread.Sleep(500);

                di = new DirectoryInfo(sources);
                FileInfo[] fl = di.GetFiles("*.udb");
                for (int s = 0; s < fl.Length; s++)
                {

                    DatasourceConnectionInfo ds = new DatasourceConnectionInfo();
                    ds.Alias = fl[s].Name.Substring(0, fl[s].Name.Length - 4);
                    Msg("添加数据源：" + ds.Alias);

                    ds.Server = String.Format("{0}\\{1}", sources, fl[s]);
                    ds.Password = set.passWord;
                    //ds.Password = "aaaazzzz";
                    Datasource datasource = workspace.Datasources.Open(ds);

                    if (datasource == null)
                    {
                        MessageBox.Show("打开数据源失败");
                    }

                    workspace.Save();

                }
                workspace.Close();
                workspace.Dispose();
                workspaceConnectionInfo.Dispose();
            }

        }

        #endregion
        //-------------淹没过程tif生成函数------------------------------------------------
  
        //根据txt文件内容提取tif
        //读取txt信息函数  返回一个数组/根据对应的前面数据返回哈希表
        public void readTXT(string txtPath, string shpFilePath, string shpFileName,string cellSize, string SavaPath)
        {
            importTool.createFolder(SavaPath);
            IFeatureClass pfeatureClass = shpToFeatureClass(shpFileName, shpFilePath);
            Hashtable hs = null;
            List<string> line = new List<string>();
            string l;
            try
            {
                StreamReader sr = new StreamReader(txtPath);
                while ((l = sr.ReadLine()) != null)
                {
                    string[] split = l.Split(new char[] { ' ' ,'\t'}, StringSplitOptions.RemoveEmptyEntries);

                    if (split.Length < 2)//陈杜彬3.7修改 
                    {
                        line.Add(split[0]);
                        if (hs != null)
                        {
                            progressBar.EditValue = lab_progress.Text = "正在生成time" + line[line.Count - 2] + ".tif·····";
                            Feature2Raster(gp, selectFeatureClass(gp, setValue(pfeatureClass, hs),  importTool.createFolder(SavaPath + "\\shp文件"), "time" + line[line.Count - 2] + ".shp"), cellSize, SavaPath + "\\time" + line[line.Count - 2] + ".tif");
                          
                        }
                        hs = new Hashtable();
                        continue;
                    }
                    object key = split[0];
                    object value = split[1];
                    hs.Add(key, value);//将读取的txt数值存入
                }
                progressBar.EditValue = lab_progress.Text = "正在生成time" + line[line.Count - 1] + ".tif·····";
                Feature2Raster(gp, selectFeatureClass(gp, setValue(pfeatureClass, hs), importTool.createFolder(SavaPath + "\\shp文件"), "time" + line[line.Count - 1] + ".shp"), cellSize, SavaPath + "\\time" + line[line.Count - 1] + ".tif");
                progressBar.EditValue = lab_progress.Text = "淹没过程影像数据生成完成！";
            }
            catch (Exception ex)
            {
                Msg(ex.Message+"淹没过程数据提取发生错误");
                return;
            }
           
        }
        //select提取淹没范围
        public IFeatureClass selectFeatureClass(Geoprocessor gp, IFeatureClass sourceFeatureClass, string out_FeatureClassPath, string out_FeatureClassName)
        {
            try
            {
                if (sourceFeatureClass == null)
                    return null;
                ESRI.ArcGIS.AnalysisTools.Select select = new Select() { in_features = sourceFeatureClass, out_feature_class = String.Format("{0}\\{1}", out_FeatureClassPath, out_FeatureClassName), where_clause = "VALUE > 0" };
                gp.OverwriteOutput = true;
                gp.Execute(select, null);
                //Msg(out_FeatureClassName + "生成成功！");
                return shpToFeatureClass(out_FeatureClassName, out_FeatureClassPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        //处理shp文件
        public IFeatureClass shpToFeatureClass(string shpFileName, string shpFilePath)
        {
            try
            {
                IWorkspaceFactory pWorkspaceFactory = new ShapefileWorkspaceFactoryClass();
                IFeatureWorkspace pFeatureWorkspace = (IFeatureWorkspace)pWorkspaceFactory.OpenFromFile(shpFilePath, 0);
                IFeatureLayer pFeatureLayer = new FeatureLayerClass() { FeatureClass = pFeatureWorkspace.OpenFeatureClass(shpFileName) };
                IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;
                return pFeatureClass;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        //对shpfile的赋值函数
        public IFeatureClass setValue(IFeatureClass pFeatureClass, Hashtable hsTable)
        {
            try
            {
                if (pFeatureClass != null)
                {
                    int nIndex = pFeatureClass.FindField("GRIDCODE");
                    int ValueIndex = pFeatureClass.FindField("VALUE");
                    if (ValueIndex == -1)
                    {
                        IField newField = new FieldClass();
                        IFieldEdit fieldEdit = (IFieldEdit)newField;
                        fieldEdit.Name_2 = "VALUE";
                        fieldEdit.Type_2 = esriFieldType.esriFieldTypeDouble;
                        pFeatureClass.AddField(newField);
                        ValueIndex = pFeatureClass.FindField("VALUE");
                    }
                    if (nIndex != -1&&ValueIndex!=-1)
                    {
                        
                        IField pField = pFeatureClass.Fields.get_Field(nIndex);
                        IFeatureCursor pCursor = pFeatureClass.Update(null, false);
                        IFeature pFeature = pCursor.NextFeature();
                        while (pFeature != null)
                        {
                            double v =0;
                           // string s=hsTable.Contains("3311").ToString();
                            string c = pFeature.get_Value(nIndex).ToString();
                            if(hsTable.Contains(c))
                             v = Convert.ToDouble(hsTable[pFeature.get_Value(nIndex).ToString() as object].ToString());

                            pFeature.set_Value(ValueIndex, v);//赋值语句
                            pCursor.UpdateFeature(pFeature);
                            pFeature = pCursor.NextFeature();

                        }

                    }

                    return pFeatureClass;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                if (pFeatureClass != null)
                    pFeatureClass = null;
                GC.Collect();
            }
            
        }
        //Feature2Raster转换函数
        public void Feature2Raster(Geoprocessor gp, IFeatureClass pFeatrueClass,string cellSize, string SavaPath)
        {
            try
            {
                if (pFeatrueClass == null)
                    return;
                ESRI.ArcGIS.ConversionTools.FeatureToRaster feature2Raster = new ESRI.ArcGIS.ConversionTools.FeatureToRaster() { in_features = pFeatrueClass, field = "VALUE", out_raster = SavaPath };
                if (cellSize != null && cellSize != "普分")
                {
                    if (cellSize == "高分")
                        cellSize = "10";
                    else
                        cellSize = "100";
                    feature2Raster.cell_size = Convert.ToDouble(cellSize) / 100000;
                }
                    gp.OverwriteOutput = true;
                gp.Execute(feature2Raster, null);
            }
            catch (Exception ex)
            {
                Msg(ex.Message+"矢量转栅格失败");
            }
        }
        public void shp2Raster(Geoprocessor gp, IFeatureClass pFeatrueClass, string field, string SavaPath)
        {
            string name = field;
            try
            {
                if (field != null)
                {
                    if (field.Contains("淹没水深"))
                    {
                        field = "YMSS";
                    }
                    if (field.Contains("淹没历时"))
                        field = "YMLS";
                    if (field.Contains("淹没图"))
                    {
                        field = "YMSS";
                        if (pFeatrueClass.FindField(field) == -1)
                        {
                            field = "HSLS";
                            if (pFeatrueClass.FindField(field) == -1)
                                field = "DDSJ";
                        }
                        
                    }
                    if (field.Contains("到达时间"))
                        field = "DDSJ";
                    if (!getField(field, pFeatrueClass))
                    {
                        Msg(name+"-->无法转换！");
                        return;
                    }
                }
                ESRI.ArcGIS.ConversionTools.FeatureToRaster feature2Raster = new ESRI.ArcGIS.ConversionTools.FeatureToRaster();
                feature2Raster.in_features = pFeatrueClass;
                feature2Raster.field = field;
               // feature2Raster.cell_size = "";
                feature2Raster.out_raster = SavaPath + ".tif";
                gp.OverwriteOutput = true;
                gp.Execute(feature2Raster, null);
                Msg(name + "-->转换完成！");
            }
            catch (Exception ex)
            {
                Msg(ex.Message);
            }
        }
        private bool getField(string field,IFeatureClass pFeatrueClass)
        {
            int findFile = pFeatrueClass.FindField(field);
            if (findFile == -1)
            {
                Msg("未找到字段" + field);
                return false;
            }
            else
                return true;
        }
        //------------------淹没过程影响数据统计-------------------------------------
        //统计主函数
        public System.Data.DataTable ymStatistics(string StaShpPath, string czShpLayer)
        {
            Hashtable areaStaHs = new Hashtable();
            Hashtable czStaHs = new Hashtable();
            List<string> TimeX = new List<string>();//3.8修改添加  记录时刻
            DirectoryInfo Di = new DirectoryInfo(StaShpPath);

            try
            {
                System.Data.DataTable dtable = new System.Data.DataTable();
                dtable.Columns.Add("Time", System.Type.GetType("System.String"));
                dtable.Columns.Add("ymczCount（个）", System.Type.GetType("System.String"));
                dtable.Columns.Add("ymczArea（平方公里）", System.Type.GetType("System.String"));
                DateTime dt = DateTime.Now;
                FileInfo[] shpFile = Di.GetFiles("*.shp", SearchOption.TopDirectoryOnly);
                TimeX = FileSort(shpFile);
                foreach (string file in TimeX)
                {
                    object keyName = file;//.Name.Substring(0, file.Name.Length - 4);
                    //TimeX.Add(keyName.ToString());
                    progressBar.EditValue = lab_progress.Text = "正在统计" + file + "·····";
                    //面积统计
                    //areaSta.Add(Caculate(file.Name, file.DirectoryName, "GRIDAREA"));
                    object AreaValue = Caculate(file, StaShpPath, "GRIDAREA") / 1000000;//单位平方公里
                    areaStaHs.Add(keyName, AreaValue);
                    //村庄统计
                    importTool.createFolder(StaShpPath + "\\czStastic");
                    IntersectFeature(gp, StaShpPath, file + ".shp", czShpLayer, StaShpPath + "\\czStastic\\ymcz" + file + ".shp");
                    //czSta.Add(caculateCountry(file.DirectoryName + "\\czStastic", "ymcz" + file.Name));
                    object czValue = caculateCountry(StaShpPath + "\\czStastic", "ymcz" + file + ".shp");
                    czStaHs.Add(keyName, czValue);
                    progressBar.EditValue = lab_progress.Text = "完成统计保存结果";
                    progressBar.Properties.Stopped = true;
                }
                //listSort(TimeX);
                for (int i = 0; i < czStaHs.Count; i++)
                {
                    DataRow dr1 = dtable.NewRow();
                    dtable.Rows.Add(dr1);
                    dtable.Rows[i]["Time"] = TimeX[i];
                    dtable.Rows[i]["ymczCount（个）"] = czStaHs[TimeX[i]].ToString();
                    dtable.Rows[i]["ymczArea（平方公里）"] = areaStaHs[TimeX[i]].ToString();
                }
                dataTableToCsv(dtable, StaShpPath + "\\淹没统计.xls");
               // System.Diagnostics.Process.Start(StaShpPath + "\\淹没统计.xls"); //打开excel文件
                return dtable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        //将DataTable输出为Excel表格
        private void dataTableToCsv(System.Data. DataTable table, string file)
        {

            string title = "";

            System.IO.FileStream fs = new System.IO.FileStream(file, FileMode.OpenOrCreate);

            //FileStream fs1 = File.Open(file, FileMode.Open, FileAccess.Read);

            StreamWriter sw = new StreamWriter(new BufferedStream(fs), System.Text.Encoding.Default);

            for (int i = 0; i < table.Columns.Count; i++)
            {

                title += table.Columns[i].ColumnName + "\t"; //栏位：自动跳到下一单元格

            }

            title = title.Substring(0, title.Length - 1) + "\n";

            sw.Write(title);

            foreach (DataRow row in table.Rows)
            {

                string line = "";

                for (int i = 0; i < table.Columns.Count; i++)
                {

                    line += row[i].ToString().Trim() + "\t"; //内容：自动跳到下一单元格

                }

                line = line.Substring(0, line.Length - 1) + "\n";

                sw.Write(line);

            }

            sw.Close();

            fs.Close();




        }
        //计算属性中某字段（面积）和
        public Double Caculate(string shpFileName, string shpFilePath, string fileName)
        {
            try
            {
                IFeatureClass pFeatureClass = shpToFeatureClass(shpFileName, shpFilePath);
                ITable pTable = (ITable)pFeatureClass;
                double count = 0;
                ICursor pcursor = pTable.Update(null, false);
                IRow pRow = pcursor.NextRow();
                int nIndex = pFeatureClass.FindField(fileName);
                if (nIndex != -1)
                {
                    IField pField = pFeatureClass.Fields.get_Field(nIndex);
                    for (int i = 0; i < pTable.RowCount(null); i++)
                    {
                        string c = pRow.get_Value(nIndex).ToString();
                        double v = Convert.ToDouble(c);
                        count += v;
                        pRow = pcursor.NextRow();
                    }

                    return count/1000000;//单位是平方公里

                }
                else
                    return 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
        //叠加村庄和淹没时刻数据
        public void IntersectFeature(Geoprocessor gp, string sourseFeature1, string n1, string sourseFeature2Name, string SavaFeature)
        {
            try
            {
                ESRI.ArcGIS.AnalysisTools.Intersect intersectFeatures = new Intersect() { in_features = String.Format("{0}\\{1};{2}", sourseFeature1, n1, sourseFeature2Name), out_feature_class = SavaFeature, output_type = "POINT" };
                gp.OverwriteOutput = true;
                gp.Execute(intersectFeatures, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //村庄点计算
        public int caculateCountry(string shpFilePath, string shpFileName)
        {
            try
            {
                IFeatureClass pFeatureClass = shpToFeatureClass(shpFileName, shpFilePath);
                ITable pTable = (ITable)pFeatureClass;
                int count = pTable.RowCount(null);
                return count;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
    //-----------------导入Excel数据--------------------------------------------
        //读取excel文件excel转DataTable
        public System.Data.DataTable ExcelToDataTable(string strExcelFileName, string strSheetName)
        {
            string strConn;
            FileInfo file = new FileInfo(strExcelFileName);
            if (!file.Exists)
            {
                throw new Exception("文件不存在");
            }
            string extension = file.Extension;
            //源的定义
            switch (extension)
            {
                case ".xls":
                    strConn = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'", strExcelFileName);
                    break;
                case ".xlsx":
                    strConn = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'", strExcelFileName);
                    break;
                default:
                    strConn = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'", strExcelFileName);
                    break;
            }
            //Sql语句
            //string strExcel = string.Format("select * from [{0}$]", strSheetName); 这是一种方法
            string strExcel = String.Format("select * from   [{0}$]", strSheetName);
            // string strExcel = string.Format("select * from [{0}$]" , strSheetName);

            //定义存放的数据表
            DataSet ds = new DataSet();

            //连接数据源
            OleDbConnection conn = new OleDbConnection(strConn);

            conn.Open();

            //适配到数据源
            OleDbDataAdapter adapter = new OleDbDataAdapter(strExcel, conn);// strConn);
            adapter.Fill(ds, strSheetName);
            conn.Close();
            return ds.Tables[strSheetName];
        }
        //获取excel工作表名字
        public string[] GetSheetNameList(string ExcelFilePath)
        {
            try
            {
                string strConn;
                FileInfo file = new FileInfo(ExcelFilePath);
                if (!file.Exists)
                {
                    throw new Exception("文件不存在");
                }
                string extension = file.Extension;
                //源的定义
                switch (extension)
                {
                    case ".xls":
                        strConn = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'", ExcelFilePath);
                        break;
                    case ".xlsx":
                        strConn = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'", ExcelFilePath);
                        break;
                    default:
                        strConn = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'", ExcelFilePath);
                        break;
                }
                System.Data.OleDb.OleDbConnection oleDbConnection = new OleDbConnection(strConn);
                oleDbConnection.Open();
                System.Data.DataTable dt = oleDbConnection.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                string[] sheetNameList = new string[dt.Rows.Count];
                for (int index = 0; index < dt.Rows.Count; index++)
                {
                    string name = dt.Rows[index][2].ToString();
                    string nameChange = name.Replace("#", ".").Replace("$", "").Replace("'", "");//.Remove(name.LastIndexOf('$'),1);
                    sheetNameList[index] = nameChange;//dt.Rows[index][2].ToString().Replace('#', '.').Remove('$');
                }
                oleDbConnection.Close();
                return sheetNameList;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        //excel转csv
        public bool ExcelToCsv(string SourceExcelPathAndName, string targetCSVPathAndName, string excelSheetName, string columnDelimeter, int headerRowsToSkip)
        {
            Microsoft.Office.Interop.Excel.Application OXL = null;
            Microsoft.Office.Interop.Excel.Workbooks workbooks = null;
            Workbook mWorkbook = null;
            Sheets mWorkSheets = null;
            Worksheet mWSheet = null;
            try
            {
                OXL = new Microsoft.Office.Interop.Excel.Application();
                OXL.Visible = false;
                OXL.DisplayAlerts = false;
                workbooks = OXL.Workbooks;
                mWorkbook = workbooks.Open(SourceExcelPathAndName, 0, false, 5, "", "", false, XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                mWorkSheets = mWorkbook.Worksheets;
                mWSheet = (Worksheet)mWorkSheets.get_Item(excelSheetName);
                Microsoft.Office.Interop.Excel.Range range = mWSheet.UsedRange;
                Microsoft.Office.Interop.Excel.Range rngCurrentRow;
                for (int i = 0; i < headerRowsToSkip; i++)
                {
                    rngCurrentRow = range.get_Range("A1", Type.Missing).EntireRow;
                    rngCurrentRow.Delete(XlDeleteShiftDirection.xlShiftUp);
                }
                range.Replace("\n", "", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                range.Replace(",", columnDelimeter, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                mWorkbook.SaveAs(targetCSVPathAndName, Microsoft.Office.Interop.Excel.XlFileFormat.xlCSV, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, false);
                return true;

            }
            catch (Exception ex)
            {
                Msg("属性表导入错误！···");
                return false;
            }
            finally
            {
                if (mWSheet != null)
                    mWSheet = null;
                if (mWorkbook != null)
                {
                    mWorkbook.Close(Type.Missing, Type.Missing, Type.Missing);
                    mWorkbook = null;
                }
                if (OXL != null)
                    OXL.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(OXL);
                if (OXL != null)
                    OXL = null;
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
        }
       
        //测试转csv主函数
        public bool toCSV(string excelPath, string csvPath)
        {
            try
            {

                string[] sheetNameList = GetSheetNameList(excelPath);
                if (sheetNameList != null && sheetNameList.Length > 0)
                {
                    foreach (string sheetName in sheetNameList)
                    {
                        string csvNamePath = String.Format("{0}{1}.csv", csvPath, sheetName);
                        if (sheetNameList.Length == 1)
                            csvNamePath = csvPath + ".csv";
                        ExcelToCsv(excelPath, csvNamePath, sheetName, "|#|", 1);

                    }
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Msg(ex.Message);
                return false;
            }
        }




    }
}
