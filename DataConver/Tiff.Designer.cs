namespace DataConver
{
    partial class Tiff
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
            if (disposing && (components != null))
            {
                components.Dispose();
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
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.CellSize = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.checkBoxX1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.DealCell = new DevComponents.DotNetBar.LabelX();
            this.CzLayer = new DevComponents.DotNetBar.LabelX();
            this.SavaFolder = new DevComponents.DotNetBar.LabelX();
            this.progressView = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.ExtractMesg = new DevComponents.DotNetBar.LabelX();
            this.Stop = new DevComponents.DotNetBar.ButtonX();
            this.but_tif = new DevComponents.DotNetBar.ButtonX();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressView.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.CellSize);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.checkBoxX1);
            this.panelEx1.Controls.Add(this.DealCell);
            this.panelEx1.Controls.Add(this.CzLayer);
            this.panelEx1.Controls.Add(this.SavaFolder);
            this.panelEx1.Controls.Add(this.progressView);
            this.panelEx1.Controls.Add(this.ExtractMesg);
            this.panelEx1.Controls.Add(this.Stop);
            this.panelEx1.Controls.Add(this.but_tif);
            this.panelEx1.Controls.Add(this.label2);
            this.panelEx1.Controls.Add(this.label4);
            this.panelEx1.Controls.Add(this.label1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(495, 277);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 9;
            // 
            // CellSize
            // 
            this.CellSize.DisplayMember = "Text";
            this.CellSize.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CellSize.FormattingEnabled = true;
            this.CellSize.ItemHeight = 15;
            this.CellSize.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2,
            this.comboItem3});
            this.CellSize.Location = new System.Drawing.Point(112, 165);
            this.CellSize.Name = "CellSize";
            this.CellSize.Size = new System.Drawing.Size(98, 21);
            this.CellSize.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CellSize.TabIndex = 52;
            this.CellSize.Text = "普分";
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "高分";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "普分";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "低分";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(216, 166);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(26, 23);
            this.labelX1.TabIndex = 47;
            this.labelX1.Text = "米";
            // 
            // checkBoxX1
            // 
            // 
            // 
            // 
            this.checkBoxX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX1.Location = new System.Drawing.Point(19, 165);
            this.checkBoxX1.Name = "checkBoxX1";
            this.checkBoxX1.Size = new System.Drawing.Size(100, 23);
            this.checkBoxX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX1.TabIndex = 45;
            this.checkBoxX1.Text = "设置分辨率：";
            this.checkBoxX1.CheckedChanged += new System.EventHandler(this.checkBoxX1_CheckedChanged);
            // 
            // DealCell
            // 
            // 
            // 
            // 
            this.DealCell.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.DealCell.Location = new System.Drawing.Point(112, 25);
            this.DealCell.Name = "DealCell";
            this.DealCell.Size = new System.Drawing.Size(310, 23);
            this.DealCell.TabIndex = 44;
            this.DealCell.Text = "请选择需处理的编制单元";
            // 
            // CzLayer
            // 
            // 
            // 
            // 
            this.CzLayer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.CzLayer.Location = new System.Drawing.Point(137, 113);
            this.CzLayer.Name = "CzLayer";
            this.CzLayer.Size = new System.Drawing.Size(319, 23);
            this.CzLayer.TabIndex = 43;
            this.CzLayer.Text = "无需设置，系统自动添加";
            // 
            // SavaFolder
            // 
            // 
            // 
            // 
            this.SavaFolder.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.SavaFolder.Location = new System.Drawing.Point(112, 69);
            this.SavaFolder.Name = "SavaFolder";
            this.SavaFolder.Size = new System.Drawing.Size(310, 23);
            this.SavaFolder.TabIndex = 43;
            this.SavaFolder.Text = "请选择需处理的编制单元";
            // 
            // progressView
            // 
            this.progressView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressView.EditValue = 0;
            this.progressView.Location = new System.Drawing.Point(0, 259);
            this.progressView.Name = "progressView";
            this.progressView.Size = new System.Drawing.Size(495, 18);
            this.progressView.TabIndex = 42;
            // 
            // ExtractMesg
            // 
            // 
            // 
            // 
            this.ExtractMesg.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ExtractMesg.Location = new System.Drawing.Point(3, 209);
            this.ExtractMesg.Name = "ExtractMesg";
            this.ExtractMesg.Size = new System.Drawing.Size(489, 33);
            this.ExtractMesg.TabIndex = 37;
            this.ExtractMesg.Text = "提取信息输出";
            // 
            // Stop
            // 
            this.Stop.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Stop.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Stop.Location = new System.Drawing.Point(375, 165);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(108, 38);
            this.Stop.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Stop.TabIndex = 28;
            this.Stop.Text = "终止处理";
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // but_tif
            // 
            this.but_tif.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.but_tif.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.but_tif.Location = new System.Drawing.Point(249, 165);
            this.but_tif.Name = "but_tif";
            this.but_tif.Size = new System.Drawing.Size(108, 38);
            this.but_tif.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.but_tif.TabIndex = 28;
            this.but_tif.Text = "处理淹没过程";
            this.but_tif.Click += new System.EventHandler(this.but_tif_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 29;
            this.label2.Text = "当前处理单元：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 29;
            this.label4.Text = "自动保存路径：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 30;
            this.label1.Text = "设置叠加村庄数据：";
            // 
            // textBoxX1
            // 
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX1.ButtonCustom.Tooltip = "";
            this.textBoxX1.ButtonCustom2.Tooltip = "";
            this.textBoxX1.Enabled = false;
            this.textBoxX1.Location = new System.Drawing.Point(112, 167);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.PreventEnterBeep = true;
            this.textBoxX1.Size = new System.Drawing.Size(98, 21);
            this.textBoxX1.TabIndex = 46;
            this.textBoxX1.Text = "默认值";
            // 
            // Tiff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 277);
            this.Controls.Add(this.panelEx1);
            this.Name = "Tiff";
            this.Text = "生成淹没过程数据";
            this.Load += new System.EventHandler(this.Tiff_Load);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressView.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevExpress.XtraEditors.MarqueeProgressBarControl progressView;
        private DevComponents.DotNetBar.LabelX ExtractMesg;
        private DevComponents.DotNetBar.ButtonX but_tif;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.LabelX DealCell;
        private DevComponents.DotNetBar.LabelX SavaFolder;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX1;
        private DevComponents.DotNetBar.ButtonX Stop;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx CellSize;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.DotNetBar.LabelX CzLayer;
    }
}