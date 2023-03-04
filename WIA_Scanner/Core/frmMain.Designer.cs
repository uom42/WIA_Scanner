#nullable enable

using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace WS
{


	partial class frmMain : Form
	{

		/// <summary>Required designer variable.</summary>
		private System.ComponentModel.IContainer components;

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
			this.components = new System.ComponentModel.Container();

			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.sbMain = new System.Windows.Forms.StatusStrip();
			this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblMousePos = new System.Windows.Forms.ToolStripStatusLabel();
			this.pnlLeftMain = new System.Windows.Forms.Panel();
			this.grpScanButtons = new System.Windows.Forms.GroupBox();
			this.tlpProfile = new System.Windows.Forms.TableLayoutPanel();
			this.Panel2 = new System.Windows.Forms.Panel();
			this.cmdScan_FullQuality = new System.Windows.Forms.Button();
			this.chkScan_НесколькоСтраницВручную = new System.Windows.Forms.CheckBox();
			this.llScanUsingSysUI = new System.Windows.Forms.LinkLabel();
			this.grpSettings = new System.Windows.Forms.GroupBox();
			this.tlpQuality = new System.Windows.Forms.TableLayoutPanel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.cmdScan_PreView = new System.Windows.Forms.Button();
			this.lblPageSize = new System.Windows.Forms.Label();
			this.lblDPI = new System.Windows.Forms.Label();
			this.ГоризонтальныйРазделитель_2 = new System.Windows.Forms.Panel();
			this.cboScannerSelect = new System.Windows.Forms.ComboBox();
			this.lblColorMode = new System.Windows.Forms.Label();
			this.cboColorMode = new System.Windows.Forms.ComboBox();
			this.cboDPI = new System.Windows.Forms.ComboBox();
			this.chkUseAutoFeeder = new System.Windows.Forms.CheckBox();
			this.chkUseAutoFeederDuplex = new System.Windows.Forms.CheckBox();
			this.lblFileFormat = new System.Windows.Forms.Label();
			this.lblScanner = new System.Windows.Forms.Label();
			this.cboFileFormat = new System.Windows.Forms.ComboBox();
			this.lblFile_Quality = new System.Windows.Forms.Label();
			this.sldFile_Quality = new System.Windows.Forms.TrackBar();
			this.llScanFolder = new System.Windows.Forms.LinkLabel();
			this.xFileFolder = new common.Controls.PathSelector.DirectorySelector();
			this.chkCropZone_Set = new System.Windows.Forms.CheckBox();
			this.tlpPageCrop = new System.Windows.Forms.TableLayoutPanel();
			this.xudCrop_Width = new System.Windows.Forms.NumericUpDown();
			this.xudCrop_Left = new System.Windows.Forms.NumericUpDown();
			this.xudCrop_Height = new System.Windows.Forms.NumericUpDown();
			this.xudCrop_Top = new System.Windows.Forms.NumericUpDown();
			this.lblCropZone_X = new System.Windows.Forms.Label();
			this.lblCropZone_Y = new System.Windows.Forms.Label();
			this.lblCropZone_W = new System.Windows.Forms.Label();
			this.lblCropZone_H = new System.Windows.Forms.Label();
			this.Splitter1 = new System.Windows.Forms.Splitter();
			this.pnlMainView = new System.Windows.Forms.Panel();
			this.xPageControl = new WS.xPageview();
			this.sbMain.SuspendLayout();
			this.pnlLeftMain.SuspendLayout();
			this.grpScanButtons.SuspendLayout();
			this.tlpProfile.SuspendLayout();
			this.grpSettings.SuspendLayout();
			this.tlpQuality.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.sldFile_Quality)).BeginInit();
			this.tlpPageCrop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.xudCrop_Width)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.xudCrop_Left)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.xudCrop_Height)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.xudCrop_Top)).BeginInit();
			this.pnlMainView.SuspendLayout();
			this.SuspendLayout();
			// 
			// sbMain
			// 
			this.sbMain.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.sbMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.lblStatus,
			this.lblMousePos});
			this.sbMain.Location = new System.Drawing.Point(0, 1303);
			this.sbMain.Name = "sbMain";
			this.sbMain.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
			this.sbMain.Size = new System.Drawing.Size(1865, 32);
			this.sbMain.TabIndex = 3;
			this.sbMain.Text = "StatusStrip1";
			// 
			// lblStatus
			// 
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(1813, 25);
			this.lblStatus.Spring = true;
			this.lblStatus.Text = "*";
			this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblMousePos
			// 
			this.lblMousePos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.lblMousePos.Name = "lblMousePos";
			this.lblMousePos.Size = new System.Drawing.Size(29, 25);
			this.lblMousePos.Text = "xy";
			// 
			// pnlLeftMain
			// 
			this.pnlLeftMain.Controls.Add(this.grpScanButtons);
			this.pnlLeftMain.Controls.Add(this.grpSettings);
			this.pnlLeftMain.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlLeftMain.Location = new System.Drawing.Point(0, 0);
			this.pnlLeftMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.pnlLeftMain.Name = "pnlLeftMain";
			this.pnlLeftMain.Padding = new System.Windows.Forms.Padding(12);
			this.pnlLeftMain.Size = new System.Drawing.Size(583, 1303);
			this.pnlLeftMain.TabIndex = 4;
			// 
			// grpScanButtons
			// 
			this.grpScanButtons.AutoSize = true;
			this.grpScanButtons.Controls.Add(this.tlpProfile);
			this.grpScanButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.grpScanButtons.Location = new System.Drawing.Point(12, 1078);
			this.grpScanButtons.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.grpScanButtons.Name = "grpScanButtons";
			this.grpScanButtons.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.grpScanButtons.Size = new System.Drawing.Size(559, 213);
			this.grpScanButtons.TabIndex = 28;
			this.grpScanButtons.TabStop = false;
			this.grpScanButtons.Text = "Начать сканирование:";
			// 
			// tlpProfile
			// 
			this.tlpProfile.AutoSize = true;
			this.tlpProfile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tlpProfile.ColumnCount = 3;
			this.tlpProfile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpProfile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpProfile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
			this.tlpProfile.Controls.Add(this.Panel2, 0, 1);
			this.tlpProfile.Controls.Add(this.cmdScan_FullQuality, 0, 4);
			this.tlpProfile.Controls.Add(this.chkScan_НесколькоСтраницВручную, 0, 3);
			this.tlpProfile.Controls.Add(this.llScanUsingSysUI, 0, 0);
			this.tlpProfile.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.tlpProfile.Location = new System.Drawing.Point(4, 24);
			this.tlpProfile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tlpProfile.Name = "tlpProfile";
			this.tlpProfile.RowCount = 5;
			this.tlpProfile.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpProfile.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
			this.tlpProfile.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpProfile.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpProfile.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 98F));
			this.tlpProfile.Size = new System.Drawing.Size(551, 184);
			this.tlpProfile.TabIndex = 0;
			// 
			// Panel2
			// 
			this.Panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.tlpProfile.SetColumnSpan(this.Panel2, 3);
			this.Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Panel2.Location = new System.Drawing.Point(4, 25);
			this.Panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Panel2.Name = "Panel2";
			this.Panel2.Size = new System.Drawing.Size(543, 2);
			this.Panel2.TabIndex = 30;
			// 
			// cmdScan_FullQuality
			// 
			this.tlpProfile.SetColumnSpan(this.cmdScan_FullQuality, 3);
			this.cmdScan_FullQuality.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cmdScan_FullQuality.Location = new System.Drawing.Point(4, 91);
			this.cmdScan_FullQuality.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cmdScan_FullQuality.Name = "cmdScan_FullQuality";
			this.cmdScan_FullQuality.Size = new System.Drawing.Size(543, 88);
			this.cmdScan_FullQuality.TabIndex = 3;
			this.cmdScan_FullQuality.Text = "Сканировать и сохранить в файл";
			this.cmdScan_FullQuality.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.cmdScan_FullQuality.UseVisualStyleBackColor = true;
			// 
			// chkScan_НесколькоСтраницВручную
			// 
			this.chkScan_НесколькоСтраницВручную.AutoSize = true;
			this.tlpProfile.SetColumnSpan(this.chkScan_НесколькоСтраницВручную, 2);
			this.chkScan_НесколькоСтраницВручную.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chkScan_НесколькоСтраницВручную.Location = new System.Drawing.Point(4, 57);
			this.chkScan_НесколькоСтраницВручную.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.chkScan_НесколькоСтраницВручную.Name = "chkScan_НесколькоСтраницВручную";
			this.chkScan_НесколькоСтраницВручную.Size = new System.Drawing.Size(495, 24);
			this.chkScan_НесколькоСтраницВручную.TabIndex = 9;
			this.chkScan_НесколькоСтраницВручную.Text = "Несколько страниц вручную";
			this.chkScan_НесколькоСтраницВручную.UseVisualStyleBackColor = true;
			// 
			// llScanUsingSysUI
			// 
			this.llScanUsingSysUI.AutoSize = true;
			this.tlpProfile.SetColumnSpan(this.llScanUsingSysUI, 3);
			this.llScanUsingSysUI.Dock = System.Windows.Forms.DockStyle.Top;
			this.llScanUsingSysUI.Location = new System.Drawing.Point(4, 0);
			this.llScanUsingSysUI.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.llScanUsingSysUI.Name = "llScanUsingSysUI";
			this.llScanUsingSysUI.Size = new System.Drawing.Size(543, 20);
			this.llScanUsingSysUI.TabIndex = 29;
			this.llScanUsingSysUI.TabStop = true;
			this.llScanUsingSysUI.Text = "Сканировать через системный интерфейс ОС.";
			// 
			// grpSettings
			// 
			this.grpSettings.AutoSize = true;
			this.grpSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.grpSettings.Controls.Add(this.tlpQuality);
			this.grpSettings.Dock = System.Windows.Forms.DockStyle.Top;
			this.grpSettings.Location = new System.Drawing.Point(12, 12);
			this.grpSettings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.grpSettings.Name = "grpSettings";
			this.grpSettings.Padding = new System.Windows.Forms.Padding(12);
			this.grpSettings.Size = new System.Drawing.Size(559, 530);
			this.grpSettings.TabIndex = 27;
			this.grpSettings.TabStop = false;
			this.grpSettings.Text = "Параметры:";
			// 
			// tlpQuality
			// 
			this.tlpQuality.AutoSize = true;
			this.tlpQuality.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tlpQuality.ColumnCount = 4;
			this.tlpQuality.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpQuality.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
			this.tlpQuality.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpQuality.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.tlpQuality.Controls.Add(this.panel3, 0, 5);
			this.tlpQuality.Controls.Add(this.cmdScan_PreView, 0, 4);
			this.tlpQuality.Controls.Add(this.lblPageSize, 1, 2);
			this.tlpQuality.Controls.Add(this.lblDPI, 2, 3);
			this.tlpQuality.Controls.Add(this.ГоризонтальныйРазделитель_2, 0, 8);
			this.tlpQuality.Controls.Add(this.cboScannerSelect, 1, 0);
			this.tlpQuality.Controls.Add(this.lblColorMode, 0, 3);
			this.tlpQuality.Controls.Add(this.cboColorMode, 1, 3);
			this.tlpQuality.Controls.Add(this.cboDPI, 3, 3);
			this.tlpQuality.Controls.Add(this.chkUseAutoFeeder, 1, 1);
			this.tlpQuality.Controls.Add(this.chkUseAutoFeederDuplex, 2, 1);
			this.tlpQuality.Controls.Add(this.lblFileFormat, 0, 9);
			this.tlpQuality.Controls.Add(this.lblScanner, 0, 0);
			this.tlpQuality.Controls.Add(this.cboFileFormat, 1, 9);
			this.tlpQuality.Controls.Add(this.lblFile_Quality, 0, 10);
			this.tlpQuality.Controls.Add(this.sldFile_Quality, 1, 10);
			this.tlpQuality.Controls.Add(this.llScanFolder, 0, 12);
			this.tlpQuality.Controls.Add(this.xFileFolder, 1, 12);
			this.tlpQuality.Controls.Add(this.chkCropZone_Set, 1, 6);
			this.tlpQuality.Controls.Add(this.tlpPageCrop, 0, 7);
			this.tlpQuality.Dock = System.Windows.Forms.DockStyle.Top;
			this.tlpQuality.Location = new System.Drawing.Point(12, 31);
			this.tlpQuality.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tlpQuality.Name = "tlpQuality";
			this.tlpQuality.RowCount = 13;
			this.tlpQuality.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpQuality.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpQuality.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpQuality.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpQuality.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
			this.tlpQuality.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
			this.tlpQuality.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpQuality.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpQuality.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
			this.tlpQuality.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpQuality.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpQuality.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpQuality.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpQuality.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpQuality.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpQuality.Size = new System.Drawing.Size(535, 487);
			this.tlpQuality.TabIndex = 0;
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.tlpQuality.SetColumnSpan(this.panel3, 4);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(4, 199);
			this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(527, 2);
			this.panel3.TabIndex = 38;
			// 
			// cmdScan_PreView
			// 
			this.tlpQuality.SetColumnSpan(this.cmdScan_PreView, 4);
			this.cmdScan_PreView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cmdScan_PreView.Location = new System.Drawing.Point(4, 135);
			this.cmdScan_PreView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cmdScan_PreView.Name = "cmdScan_PreView";
			this.cmdScan_PreView.Size = new System.Drawing.Size(527, 54);
			this.cmdScan_PreView.TabIndex = 5;
			this.cmdScan_PreView.Text = "Предварительный просмотр";
			this.cmdScan_PreView.UseVisualStyleBackColor = true;
			// 
			// lblPageSize
			// 
			this.lblPageSize.AutoSize = true;
			this.tlpQuality.SetColumnSpan(this.lblPageSize, 3);
			this.lblPageSize.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblPageSize.Location = new System.Drawing.Point(125, 72);
			this.lblPageSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblPageSize.Name = "lblPageSize";
			this.lblPageSize.Size = new System.Drawing.Size(406, 20);
			this.lblPageSize.TabIndex = 34;
			this.lblPageSize.Text = "Page Size:";
			this.lblPageSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblDPI2
			// 
			this.lblDPI.AutoSize = true;
			this.lblDPI.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblDPI.Location = new System.Drawing.Point(335, 92);
			this.lblDPI.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblDPI.Name = "lblDPI2";
			this.lblDPI.Size = new System.Drawing.Size(106, 38);
			this.lblDPI.TabIndex = 31;
			this.lblDPI.Text = "разрешение:";
			this.lblDPI.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ГоризонтальныйРазделитель_2
			// 
			this.ГоризонтальныйРазделитель_2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.tlpQuality.SetColumnSpan(this.ГоризонтальныйРазделитель_2, 4);
			this.ГоризонтальныйРазделитель_2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ГоризонтальныйРазделитель_2.Location = new System.Drawing.Point(4, 327);
			this.ГоризонтальныйРазделитель_2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.ГоризонтальныйРазделитель_2.Name = "ГоризонтальныйРазделитель_2";
			this.ГоризонтальныйРазделитель_2.Size = new System.Drawing.Size(527, 2);
			this.ГоризонтальныйРазделитель_2.TabIndex = 29;
			// 
			// cboScannerSelect
			// 
			this.tlpQuality.SetColumnSpan(this.cboScannerSelect, 3);
			this.cboScannerSelect.Dock = System.Windows.Forms.DockStyle.Top;
			this.cboScannerSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboScannerSelect.Location = new System.Drawing.Point(125, 5);
			this.cboScannerSelect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cboScannerSelect.Name = "cboScannerSelect";
			this.cboScannerSelect.Size = new System.Drawing.Size(406, 28);
			this.cboScannerSelect.TabIndex = 1;
			// 
			// lblColorMode
			// 
			this.lblColorMode.AutoSize = true;
			this.lblColorMode.Dock = System.Windows.Forms.DockStyle.Right;
			this.lblColorMode.Location = new System.Drawing.Point(54, 92);
			this.lblColorMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblColorMode.Name = "lblColorMode";
			this.lblColorMode.Size = new System.Drawing.Size(63, 38);
			this.lblColorMode.TabIndex = 10;
			this.lblColorMode.Text = "Режим:";
			this.lblColorMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cboColorMode
			// 
			this.cboColorMode.Dock = System.Windows.Forms.DockStyle.Top;
			this.cboColorMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboColorMode.FormattingEnabled = true;
			this.cboColorMode.Location = new System.Drawing.Point(125, 97);
			this.cboColorMode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cboColorMode.Name = "cboColorMode";
			this.cboColorMode.Size = new System.Drawing.Size(202, 28);
			this.cboColorMode.TabIndex = 11;
			// 
			// cboDPI
			// 
			this.cboDPI.Dock = System.Windows.Forms.DockStyle.Top;
			this.cboDPI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboDPI.FormattingEnabled = true;
			this.cboDPI.Location = new System.Drawing.Point(449, 97);
			this.cboDPI.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cboDPI.Name = "cboDPI";
			this.cboDPI.Size = new System.Drawing.Size(82, 28);
			this.cboDPI.TabIndex = 18;
			// 
			// chkUseAutoFeeder
			// 
			this.chkUseAutoFeeder.AutoSize = true;
			this.chkUseAutoFeeder.Dock = System.Windows.Forms.DockStyle.Top;
			this.chkUseAutoFeeder.Location = new System.Drawing.Point(125, 43);
			this.chkUseAutoFeeder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.chkUseAutoFeeder.Name = "chkUseAutoFeeder";
			this.chkUseAutoFeeder.Size = new System.Drawing.Size(202, 24);
			this.chkUseAutoFeeder.TabIndex = 19;
			this.chkUseAutoFeeder.Text = "Через автоподатчик";
			this.chkUseAutoFeeder.UseVisualStyleBackColor = true;
			// 
			// chkUseAutoFeederDuplex
			// 
			this.chkUseAutoFeederDuplex.AutoSize = true;
			this.tlpQuality.SetColumnSpan(this.chkUseAutoFeederDuplex, 2);
			this.chkUseAutoFeederDuplex.Dock = System.Windows.Forms.DockStyle.Top;
			this.chkUseAutoFeederDuplex.Location = new System.Drawing.Point(335, 43);
			this.chkUseAutoFeederDuplex.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.chkUseAutoFeederDuplex.Name = "chkUseAutoFeederDuplex";
			this.chkUseAutoFeederDuplex.Size = new System.Drawing.Size(196, 24);
			this.chkUseAutoFeederDuplex.TabIndex = 20;
			this.chkUseAutoFeederDuplex.Text = "С обеих строн листа";
			this.chkUseAutoFeederDuplex.UseVisualStyleBackColor = true;
			// 
			// lblFileFormat
			// 
			this.lblFileFormat.AutoSize = true;
			this.lblFileFormat.Dock = System.Windows.Forms.DockStyle.Right;
			this.lblFileFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblFileFormat.Location = new System.Drawing.Point(28, 334);
			this.lblFileFormat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblFileFormat.Name = "lblFileFormat";
			this.lblFileFormat.Size = new System.Drawing.Size(89, 38);
			this.lblFileFormat.TabIndex = 21;
			this.lblFileFormat.Text = "Формат:";
			this.lblFileFormat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblScanner
			// 
			this.lblScanner.AutoSize = true;
			this.lblScanner.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblScanner.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblScanner.Location = new System.Drawing.Point(4, 0);
			this.lblScanner.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblScanner.Name = "lblScanner";
			this.lblScanner.Size = new System.Drawing.Size(113, 38);
			this.lblScanner.TabIndex = 22;
			this.lblScanner.Text = "Сканер:";
			this.lblScanner.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cboFileFormat
			// 
			this.tlpQuality.SetColumnSpan(this.cboFileFormat, 3);
			this.cboFileFormat.Dock = System.Windows.Forms.DockStyle.Top;
			this.cboFileFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboFileFormat.FormattingEnabled = true;
			this.cboFileFormat.Location = new System.Drawing.Point(125, 339);
			this.cboFileFormat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cboFileFormat.Name = "cboFileFormat";
			this.cboFileFormat.Size = new System.Drawing.Size(406, 28);
			this.cboFileFormat.TabIndex = 21;
			// 
			// lblFile_Quality
			// 
			this.lblFile_Quality.AutoSize = true;
			this.lblFile_Quality.Dock = System.Windows.Forms.DockStyle.Right;
			this.lblFile_Quality.Location = new System.Drawing.Point(4, 372);
			this.lblFile_Quality.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblFile_Quality.Name = "lblFile_Quality";
			this.lblFile_Quality.Size = new System.Drawing.Size(113, 79);
			this.lblFile_Quality.TabIndex = 22;
			this.lblFile_Quality.Text = "Качество (%):";
			this.lblFile_Quality.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// sldFile_Quality
			// 
			this.tlpQuality.SetColumnSpan(this.sldFile_Quality, 3);
			this.sldFile_Quality.Dock = System.Windows.Forms.DockStyle.Top;
			this.sldFile_Quality.Location = new System.Drawing.Point(125, 377);
			this.sldFile_Quality.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.sldFile_Quality.Maximum = 100;
			this.sldFile_Quality.Name = "sldFile_Quality";
			this.sldFile_Quality.Size = new System.Drawing.Size(406, 69);
			this.sldFile_Quality.TabIndex = 23;
			this.sldFile_Quality.Value = 75;
			// 
			// llScanFolder
			// 
			this.llScanFolder.AutoSize = true;
			this.llScanFolder.Dock = System.Windows.Forms.DockStyle.Right;
			this.llScanFolder.Location = new System.Drawing.Point(10, 451);
			this.llScanFolder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.llScanFolder.Name = "llScanFolder";
			this.llScanFolder.Size = new System.Drawing.Size(107, 36);
			this.llScanFolder.TabIndex = 24;
			this.llScanFolder.TabStop = true;
			this.llScanFolder.Text = "Сохранять в:";
			this.llScanFolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// xFileFolder
			// 
			this.tlpQuality.SetColumnSpan(this.xFileFolder, 3);
			this.xFileFolder.Description = "";
			this.xFileFolder.Dock = System.Windows.Forms.DockStyle.Top;
			this.xFileFolder.EmptyText = "";
			this.xFileFolder.FullPath = "";
			this.xFileFolder.Location = new System.Drawing.Point(125, 456);
			this.xFileFolder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.xFileFolder.Name = "xFileFolder";
			this.xFileFolder.ReadOnly = true;
			this.xFileFolder.RootFolder = System.Environment.SpecialFolder.Desktop;
			this.xFileFolder.SeparatorWidth = 8;
			this.xFileFolder.Size = new System.Drawing.Size(406, 26);
			this.xFileFolder.TabIndex = 25;
			this.xFileFolder.TextBackColor = System.Drawing.SystemColors.Control;
			// 
			// chkScan_Crop
			// 
			this.chkCropZone_Set.AutoSize = true;
			this.tlpQuality.SetColumnSpan(this.chkCropZone_Set, 3);
			this.chkCropZone_Set.Dock = System.Windows.Forms.DockStyle.Top;
			this.chkCropZone_Set.Location = new System.Drawing.Point(125, 211);
			this.chkCropZone_Set.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.chkCropZone_Set.Name = "chkScan_Crop";
			this.chkCropZone_Set.Size = new System.Drawing.Size(406, 24);
			this.chkCropZone_Set.TabIndex = 35;
			this.chkCropZone_Set.Text = "Обрезать";
			this.chkCropZone_Set.UseVisualStyleBackColor = true;
			// 
			// tlpPageCrop
			// 
			this.tlpPageCrop.AutoSize = true;
			this.tlpPageCrop.ColumnCount = 4;
			this.tlpQuality.SetColumnSpan(this.tlpPageCrop, 4);
			this.tlpPageCrop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpPageCrop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpPageCrop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpPageCrop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpPageCrop.Controls.Add(this.xudCrop_Width, 3, 0);
			this.tlpPageCrop.Controls.Add(this.xudCrop_Left, 1, 0);
			this.tlpPageCrop.Controls.Add(this.xudCrop_Height, 3, 1);
			this.tlpPageCrop.Controls.Add(this.xudCrop_Top, 1, 1);
			this.tlpPageCrop.Controls.Add(this.lblCropZone_X, 0, 0);
			this.tlpPageCrop.Controls.Add(this.lblCropZone_Y, 0, 1);
			this.tlpPageCrop.Controls.Add(this.lblCropZone_W, 2, 0);
			this.tlpPageCrop.Controls.Add(this.lblCropZone_H, 2, 1);
			this.tlpPageCrop.Dock = System.Windows.Forms.DockStyle.Top;
			this.tlpPageCrop.Location = new System.Drawing.Point(4, 245);
			this.tlpPageCrop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tlpPageCrop.Name = "tlpPageCrop";
			this.tlpPageCrop.RowCount = 2;
			this.tlpPageCrop.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpPageCrop.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpPageCrop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpPageCrop.Size = new System.Drawing.Size(527, 72);
			this.tlpPageCrop.TabIndex = 37;
			// 
			// xudCrop_Width
			// 
			this.xudCrop_Width.DecimalPlaces = 2;
			this.xudCrop_Width.Dock = System.Windows.Forms.DockStyle.Top;
			this.xudCrop_Width.Location = new System.Drawing.Point(343, 5);
			this.xudCrop_Width.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.xudCrop_Width.Name = "xudCrop_Width";
			this.xudCrop_Width.Size = new System.Drawing.Size(180, 26);
			this.xudCrop_Width.TabIndex = 1;
			// 
			// xudCrop_Left
			// 
			this.xudCrop_Left.DecimalPlaces = 2;
			this.xudCrop_Left.Dock = System.Windows.Forms.DockStyle.Top;
			this.xudCrop_Left.Location = new System.Drawing.Point(77, 5);
			this.xudCrop_Left.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.xudCrop_Left.Name = "xudCrop_Left";
			this.xudCrop_Left.Size = new System.Drawing.Size(179, 26);
			this.xudCrop_Left.TabIndex = 0;
			// 
			// xudCrop_Height
			// 
			this.xudCrop_Height.DecimalPlaces = 2;
			this.xudCrop_Height.Dock = System.Windows.Forms.DockStyle.Top;
			this.xudCrop_Height.Location = new System.Drawing.Point(343, 41);
			this.xudCrop_Height.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.xudCrop_Height.Name = "xudCrop_Height";
			this.xudCrop_Height.Size = new System.Drawing.Size(180, 26);
			this.xudCrop_Height.TabIndex = 3;
			// 
			// xudCrop_Top
			// 
			this.xudCrop_Top.DecimalPlaces = 2;
			this.xudCrop_Top.Dock = System.Windows.Forms.DockStyle.Top;
			this.xudCrop_Top.Location = new System.Drawing.Point(77, 41);
			this.xudCrop_Top.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.xudCrop_Top.Name = "xudCrop_Top";
			this.xudCrop_Top.Size = new System.Drawing.Size(179, 26);
			this.xudCrop_Top.TabIndex = 2;
			// 
			// Label1
			// 
			this.lblCropZone_X.AutoSize = true;
			this.lblCropZone_X.Dock = System.Windows.Forms.DockStyle.Right;
			this.lblCropZone_X.Location = new System.Drawing.Point(8, 0);
			this.lblCropZone_X.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblCropZone_X.Name = "Label1";
			this.lblCropZone_X.Size = new System.Drawing.Size(61, 36);
			this.lblCropZone_X.TabIndex = 4;
			this.lblCropZone_X.Text = "Слева:";
			this.lblCropZone_X.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// Label2
			// 
			this.lblCropZone_Y.AutoSize = true;
			this.lblCropZone_Y.Dock = System.Windows.Forms.DockStyle.Right;
			this.lblCropZone_Y.Location = new System.Drawing.Point(4, 36);
			this.lblCropZone_Y.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblCropZone_Y.Name = "Label2";
			this.lblCropZone_Y.Size = new System.Drawing.Size(65, 36);
			this.lblCropZone_Y.TabIndex = 5;
			this.lblCropZone_Y.Text = "Сверху:";
			this.lblCropZone_Y.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// Label3
			// 
			this.lblCropZone_W.AutoSize = true;
			this.lblCropZone_W.Dock = System.Windows.Forms.DockStyle.Right;
			this.lblCropZone_W.Location = new System.Drawing.Point(264, 0);
			this.lblCropZone_W.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblCropZone_W.Name = "Label3";
			this.lblCropZone_W.Size = new System.Drawing.Size(71, 36);
			this.lblCropZone_W.TabIndex = 6;
			this.lblCropZone_W.Text = "Ширина:";
			this.lblCropZone_W.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// Label4
			// 
			this.lblCropZone_H.AutoSize = true;
			this.lblCropZone_H.Dock = System.Windows.Forms.DockStyle.Right;
			this.lblCropZone_H.Location = new System.Drawing.Point(265, 36);
			this.lblCropZone_H.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblCropZone_H.Name = "Label4";
			this.lblCropZone_H.Size = new System.Drawing.Size(70, 36);
			this.lblCropZone_H.TabIndex = 7;
			this.lblCropZone_H.Text = "Высота:";
			this.lblCropZone_H.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// Splitter1
			// 
			this.Splitter1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.Splitter1.Location = new System.Drawing.Point(583, 0);
			this.Splitter1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Splitter1.MinExtra = 100;
			this.Splitter1.MinSize = 150;
			this.Splitter1.Name = "Splitter1";
			this.Splitter1.Size = new System.Drawing.Size(10, 1303);
			this.Splitter1.TabIndex = 5;
			this.Splitter1.TabStop = false;
			// 
			// pnlMainView
			// 
			this.pnlMainView.Controls.Add(this.xPageControl);
			this.pnlMainView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMainView.Location = new System.Drawing.Point(593, 0);
			this.pnlMainView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.pnlMainView.Name = "pnlMainView";
			this.pnlMainView.Padding = new System.Windows.Forms.Padding(6);
			this.pnlMainView.Size = new System.Drawing.Size(1272, 1303);
			this.pnlMainView.TabIndex = 6;
			// 
			// xPageControl
			// 
			this.xPageControl.Cursor = System.Windows.Forms.Cursors.Default;
			this.xPageControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.xPageControl.EmptyImagesText = "";
			this.xPageControl.Location = new System.Drawing.Point(6, 6);
			this.xPageControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.xPageControl.Name = "xPageControl";
			this.xPageControl.PaperCropCm = ((System.Nullable<System.Drawing.RectangleF>)(resources.GetObject("xPageControl.PaperCropCm")));
			this.xPageControl.PaperSizeCm = new System.Drawing.SizeF(10F, 15F);
			this.xPageControl.RullerOffset = 4;
			this.xPageControl.RullerSize = 10;
			this.xPageControl.Size = new System.Drawing.Size(1260, 1291);
			this.xPageControl.TabIndex = 0;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1865, 1335);
			this.Controls.Add(this.pnlMainView);
			this.Controls.Add(this.Splitter1);
			this.Controls.Add(this.pnlLeftMain);
			this.Controls.Add(this.sbMain);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.MinimumSize = new System.Drawing.Size(800, 600);
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Main";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.sbMain.ResumeLayout(false);
			this.sbMain.PerformLayout();
			this.pnlLeftMain.ResumeLayout(false);
			this.pnlLeftMain.PerformLayout();
			this.grpScanButtons.ResumeLayout(false);
			this.grpScanButtons.PerformLayout();
			this.tlpProfile.ResumeLayout(false);
			this.tlpProfile.PerformLayout();
			this.grpSettings.ResumeLayout(false);
			this.grpSettings.PerformLayout();
			this.tlpQuality.ResumeLayout(false);
			this.tlpQuality.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.sldFile_Quality)).EndInit();
			this.tlpPageCrop.ResumeLayout(false);
			this.tlpPageCrop.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.xudCrop_Width)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.xudCrop_Left)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.xudCrop_Height)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.xudCrop_Top)).EndInit();
			this.pnlMainView.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion



		internal StatusStrip sbMain;
		internal ToolStripStatusLabel lblStatus;
		internal Panel pnlLeftMain;
		internal TableLayoutPanel tlpProfile;
		internal Button cmdScan_FullQuality;
		internal Button cmdScan_PreView;
		internal CheckBox chkScan_НесколькоСтраницВручную;
		internal Label lblColorMode;
		internal ComboBox cboColorMode;
		internal ComboBox cboDPI;
		internal ComboBox cboFileFormat;
		internal Label lblFile_Quality;
		internal TrackBar sldFile_Quality;
		internal LinkLabel llScanFolder;
		internal ComboBox cboScannerSelect;
		internal GroupBox grpSettings;
		internal TableLayoutPanel tlpQuality;
		internal common.Controls.PathSelector.DirectorySelector xFileFolder;
		internal Splitter Splitter1;
		internal CheckBox chkUseAutoFeeder;
		internal CheckBox chkUseAutoFeederDuplex;
		internal Panel pnlMainView;
		internal LinkLabel llScanUsingSysUI;
		internal Label lblFileFormat;
		internal Label lblScanner;
		internal Panel ГоризонтальныйРазделитель_2;
		internal Label lblDPI;
		internal GroupBox grpScanButtons;
		internal Panel Panel2;
		internal Label lblPageSize;
		internal CheckBox chkCropZone_Set;
		internal TableLayoutPanel tlpPageCrop;
		internal WS.xPageview xPageControl;
		internal NumericUpDown xudCrop_Left;
		internal NumericUpDown xudCrop_Width;
		internal NumericUpDown xudCrop_Top;
		internal NumericUpDown xudCrop_Height;
		internal Label lblCropZone_X;
		internal Label lblCropZone_Y;
		internal Label lblCropZone_W;
		internal Label lblCropZone_H;
		internal Panel panel3;
		private ToolStripStatusLabel lblMousePos;
	}


}