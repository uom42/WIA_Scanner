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
			ComponentResourceManager resources = new ComponentResourceManager(typeof(frmMain));
			sbMain = new StatusStrip();
			lblStatus = new ToolStripStatusLabel();
			lblMousePos = new ToolStripStatusLabel();
			pnlLeftMain = new Panel();
			grpScanButtons = new GroupBox();
			tlpProfile = new TableLayoutPanel();
			Panel2 = new Panel();
			cmdScan_FullQuality = new Button();
			chkScan_НесколькоСтраницВручную = new CheckBox();
			llScanUsingSysUI = new LinkLabel();
			grpSettings = new GroupBox();
			tlpQuality = new TableLayoutPanel();
			panel3 = new Panel();
			cmdScan_PreView = new Button();
			lblPageSize = new Label();
			lblDPI = new Label();
			ГоризонтальныйРазделитель_2 = new Panel();
			cboScannerSelect = new ComboBox();
			lblColorMode = new Label();
			cboColorMode = new ComboBox();
			cboDPI = new ComboBox();
			chkUseAutoFeeder = new CheckBox();
			chkUseAutoFeederDuplex = new CheckBox();
			lblFileFormat = new Label();
			lblScanner = new Label();
			cboFileFormat = new ComboBox();
			lblFile_Quality = new Label();
			sldFile_Quality = new TrackBar();
			llScanFolder = new LinkLabel();
			xFileFolder = new uom.controls.PathSelector.DirectorySelector();
			chkCropZone_Set = new CheckBox();
			tlpPageCrop = new TableLayoutPanel();
			xudCrop_Width = new NumericUpDown();
			xudCrop_Left = new NumericUpDown();
			xudCrop_Height = new NumericUpDown();
			xudCrop_Top = new NumericUpDown();
			lblCropZone_X = new Label();
			lblCropZone_Y = new Label();
			lblCropZone_W = new Label();
			lblCropZone_H = new Label();
			Splitter1 = new Splitter();
			pnlMainView = new Panel();
			xPageControl = new xPageview();
			sbMain.SuspendLayout();
			pnlLeftMain.SuspendLayout();
			grpScanButtons.SuspendLayout();
			tlpProfile.SuspendLayout();
			grpSettings.SuspendLayout();
			tlpQuality.SuspendLayout();
			((ISupportInitialize)sldFile_Quality).BeginInit();
			tlpPageCrop.SuspendLayout();
			((ISupportInitialize)xudCrop_Width).BeginInit();
			((ISupportInitialize)xudCrop_Left).BeginInit();
			((ISupportInitialize)xudCrop_Height).BeginInit();
			((ISupportInitialize)xudCrop_Top).BeginInit();
			pnlMainView.SuspendLayout();
			SuspendLayout();
			// 
			// sbMain
			// 
			sbMain.ImageScalingSize = new Size(24, 24);
			sbMain.Items.AddRange(new ToolStripItem[] { lblStatus, lblMousePos });
			sbMain.Location = new Point(0, 1637);
			sbMain.Name = "sbMain";
			sbMain.Padding = new Padding(2, 0, 23, 0);
			sbMain.Size = new Size(2072, 32);
			sbMain.TabIndex = 3;
			sbMain.Text = "ss1";
			// 
			// lblStatus
			// 
			lblStatus.Name = "lblStatus";
			lblStatus.Size = new Size(2018, 25);
			lblStatus.Spring = true;
			lblStatus.Text = "*";
			lblStatus.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// lblMousePos
			// 
			lblMousePos.DisplayStyle = ToolStripItemDisplayStyle.Text;
			lblMousePos.Name = "lblMousePos";
			lblMousePos.Size = new Size(29, 25);
			lblMousePos.Text = "xy";
			// 
			// pnlLeftMain
			// 
			pnlLeftMain.Controls.Add(grpScanButtons);
			pnlLeftMain.Controls.Add(grpSettings);
			pnlLeftMain.Dock = DockStyle.Left;
			pnlLeftMain.Location = new Point(0, 0);
			pnlLeftMain.Margin = new Padding(4, 6, 4, 6);
			pnlLeftMain.Name = "pnlLeftMain";
			pnlLeftMain.Padding = new Padding(13, 15, 13, 15);
			pnlLeftMain.Size = new Size(648, 1637);
			pnlLeftMain.TabIndex = 4;
			// 
			// grpScanButtons
			// 
			grpScanButtons.AutoSize = true;
			grpScanButtons.Controls.Add(tlpProfile);
			grpScanButtons.Dock = DockStyle.Bottom;
			grpScanButtons.Location = new Point(13, 1358);
			grpScanButtons.Margin = new Padding(4, 6, 4, 6);
			grpScanButtons.Name = "grpScanButtons";
			grpScanButtons.Padding = new Padding(4, 6, 4, 6);
			grpScanButtons.Size = new Size(622, 264);
			grpScanButtons.TabIndex = 28;
			grpScanButtons.TabStop = false;
			grpScanButtons.Text = "Начать сканирование:";
			// 
			// tlpProfile
			// 
			tlpProfile.AutoSize = true;
			tlpProfile.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			tlpProfile.ColumnCount = 3;
			tlpProfile.ColumnStyles.Add(new ColumnStyle());
			tlpProfile.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tlpProfile.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 53F));
			tlpProfile.Controls.Add(Panel2, 0, 1);
			tlpProfile.Controls.Add(cmdScan_FullQuality, 0, 4);
			tlpProfile.Controls.Add(chkScan_НесколькоСтраницВручную, 0, 3);
			tlpProfile.Controls.Add(llScanUsingSysUI, 0, 0);
			tlpProfile.Dock = DockStyle.Bottom;
			tlpProfile.Location = new Point(4, 30);
			tlpProfile.Margin = new Padding(4, 6, 4, 6);
			tlpProfile.Name = "tlpProfile";
			tlpProfile.RowCount = 5;
			tlpProfile.RowStyles.Add(new RowStyle());
			tlpProfile.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
			tlpProfile.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
			tlpProfile.RowStyles.Add(new RowStyle());
			tlpProfile.RowStyles.Add(new RowStyle(SizeType.Absolute, 122F));
			tlpProfile.Size = new Size(614, 228);
			tlpProfile.TabIndex = 0;
			// 
			// Panel2
			// 
			Panel2.BackColor = SystemColors.ControlDarkDark;
			tlpProfile.SetColumnSpan(Panel2, 3);
			Panel2.Dock = DockStyle.Fill;
			Panel2.Location = new Point(4, 31);
			Panel2.Margin = new Padding(4, 6, 4, 6);
			Panel2.Name = "Panel2";
			Panel2.Size = new Size(606, 3);
			Panel2.TabIndex = 30;
			// 
			// cmdScan_FullQuality
			// 
			tlpProfile.SetColumnSpan(cmdScan_FullQuality, 3);
			cmdScan_FullQuality.Dock = DockStyle.Fill;
			cmdScan_FullQuality.Location = new Point(4, 112);
			cmdScan_FullQuality.Margin = new Padding(4, 6, 4, 6);
			cmdScan_FullQuality.Name = "cmdScan_FullQuality";
			cmdScan_FullQuality.Size = new Size(606, 110);
			cmdScan_FullQuality.TabIndex = 3;
			cmdScan_FullQuality.Text = "Сканировать и сохранить в файл";
			cmdScan_FullQuality.TextImageRelation = TextImageRelation.TextBeforeImage;
			cmdScan_FullQuality.UseVisualStyleBackColor = true;
			// 
			// chkScan_НесколькоСтраницВручную
			// 
			chkScan_НесколькоСтраницВручную.AutoSize = true;
			tlpProfile.SetColumnSpan(chkScan_НесколькоСтраницВручную, 2);
			chkScan_НесколькоСтраницВручную.Dock = DockStyle.Fill;
			chkScan_НесколькоСтраницВручную.Location = new Point(4, 71);
			chkScan_НесколькоСтраницВручную.Margin = new Padding(4, 6, 4, 6);
			chkScan_НесколькоСтраницВручную.Name = "chkScan_НесколькоСтраницВручную";
			chkScan_НесколькоСтраницВручную.Size = new Size(553, 29);
			chkScan_НесколькоСтраницВручную.TabIndex = 9;
			chkScan_НесколькоСтраницВручную.Text = "Несколько страниц вручную";
			chkScan_НесколькоСтраницВручную.UseVisualStyleBackColor = true;
			// 
			// llScanUsingSysUI
			// 
			llScanUsingSysUI.AutoSize = true;
			tlpProfile.SetColumnSpan(llScanUsingSysUI, 3);
			llScanUsingSysUI.Dock = DockStyle.Top;
			llScanUsingSysUI.Location = new Point(4, 0);
			llScanUsingSysUI.Margin = new Padding(4, 0, 4, 0);
			llScanUsingSysUI.Name = "llScanUsingSysUI";
			llScanUsingSysUI.Size = new Size(606, 25);
			llScanUsingSysUI.TabIndex = 29;
			llScanUsingSysUI.TabStop = true;
			llScanUsingSysUI.Text = "Сканировать через системный интерфейс ОС.";
			// 
			// grpSettings
			// 
			grpSettings.AutoSize = true;
			grpSettings.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			grpSettings.Controls.Add(tlpQuality);
			grpSettings.Dock = DockStyle.Top;
			grpSettings.Location = new Point(13, 15);
			grpSettings.Margin = new Padding(4, 6, 4, 6);
			grpSettings.Name = "grpSettings";
			grpSettings.Padding = new Padding(13, 15, 13, 15);
			grpSettings.Size = new Size(622, 620);
			grpSettings.TabIndex = 27;
			grpSettings.TabStop = false;
			grpSettings.Text = "Параметры:";
			// 
			// tlpQuality
			// 
			tlpQuality.AutoSize = true;
			tlpQuality.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			tlpQuality.ColumnCount = 4;
			tlpQuality.ColumnStyles.Add(new ColumnStyle());
			tlpQuality.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
			tlpQuality.ColumnStyles.Add(new ColumnStyle());
			tlpQuality.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
			tlpQuality.Controls.Add(panel3, 0, 5);
			tlpQuality.Controls.Add(cmdScan_PreView, 0, 4);
			tlpQuality.Controls.Add(lblPageSize, 1, 2);
			tlpQuality.Controls.Add(lblDPI, 2, 3);
			tlpQuality.Controls.Add(ГоризонтальныйРазделитель_2, 0, 8);
			tlpQuality.Controls.Add(cboScannerSelect, 1, 0);
			tlpQuality.Controls.Add(lblColorMode, 0, 3);
			tlpQuality.Controls.Add(cboColorMode, 1, 3);
			tlpQuality.Controls.Add(cboDPI, 3, 3);
			tlpQuality.Controls.Add(chkUseAutoFeeder, 1, 1);
			tlpQuality.Controls.Add(chkUseAutoFeederDuplex, 2, 1);
			tlpQuality.Controls.Add(lblFileFormat, 0, 9);
			tlpQuality.Controls.Add(lblScanner, 0, 0);
			tlpQuality.Controls.Add(cboFileFormat, 1, 9);
			tlpQuality.Controls.Add(lblFile_Quality, 0, 10);
			tlpQuality.Controls.Add(sldFile_Quality, 1, 10);
			tlpQuality.Controls.Add(llScanFolder, 0, 12);
			tlpQuality.Controls.Add(xFileFolder, 1, 12);
			tlpQuality.Controls.Add(chkCropZone_Set, 1, 6);
			tlpQuality.Controls.Add(tlpPageCrop, 0, 7);
			tlpQuality.Dock = DockStyle.Top;
			tlpQuality.Location = new Point(13, 39);
			tlpQuality.Margin = new Padding(4, 6, 4, 6);
			tlpQuality.Name = "tlpQuality";
			tlpQuality.RowCount = 13;
			tlpQuality.RowStyles.Add(new RowStyle());
			tlpQuality.RowStyles.Add(new RowStyle());
			tlpQuality.RowStyles.Add(new RowStyle());
			tlpQuality.RowStyles.Add(new RowStyle());
			tlpQuality.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
			tlpQuality.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
			tlpQuality.RowStyles.Add(new RowStyle());
			tlpQuality.RowStyles.Add(new RowStyle());
			tlpQuality.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
			tlpQuality.RowStyles.Add(new RowStyle());
			tlpQuality.RowStyles.Add(new RowStyle());
			tlpQuality.RowStyles.Add(new RowStyle());
			tlpQuality.RowStyles.Add(new RowStyle());
			tlpQuality.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
			tlpQuality.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
			tlpQuality.Size = new Size(596, 566);
			tlpQuality.TabIndex = 0;
			// 
			// panel3
			// 
			panel3.BackColor = SystemColors.ControlDarkDark;
			tlpQuality.SetColumnSpan(panel3, 4);
			panel3.Dock = DockStyle.Fill;
			panel3.Location = new Point(4, 242);
			panel3.Margin = new Padding(4, 6, 4, 6);
			panel3.Name = "panel3";
			panel3.Size = new Size(588, 3);
			panel3.TabIndex = 38;
			// 
			// cmdScan_PreView
			// 
			tlpQuality.SetColumnSpan(cmdScan_PreView, 4);
			cmdScan_PreView.Dock = DockStyle.Fill;
			cmdScan_PreView.Location = new Point(4, 162);
			cmdScan_PreView.Margin = new Padding(4, 6, 4, 6);
			cmdScan_PreView.Name = "cmdScan_PreView";
			cmdScan_PreView.Size = new Size(588, 68);
			cmdScan_PreView.TabIndex = 5;
			cmdScan_PreView.Text = "Предварительный просмотр";
			cmdScan_PreView.UseVisualStyleBackColor = true;
			// 
			// lblPageSize
			// 
			lblPageSize.AutoSize = true;
			tlpQuality.SetColumnSpan(lblPageSize, 3);
			lblPageSize.Dock = DockStyle.Top;
			lblPageSize.Location = new Point(101, 86);
			lblPageSize.Margin = new Padding(4, 0, 4, 0);
			lblPageSize.Name = "lblPageSize";
			lblPageSize.Size = new Size(491, 25);
			lblPageSize.TabIndex = 34;
			lblPageSize.Text = "Page Size:";
			lblPageSize.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// lblDPI
			// 
			lblDPI.AutoSize = true;
			lblDPI.Dock = DockStyle.Fill;
			lblDPI.Location = new Point(363, 111);
			lblDPI.Margin = new Padding(4, 0, 4, 0);
			lblDPI.Name = "lblDPI";
			lblDPI.Size = new Size(116, 45);
			lblDPI.TabIndex = 31;
			lblDPI.Text = "разрешение:";
			lblDPI.TextAlign = ContentAlignment.MiddleRight;
			// 
			// ГоризонтальныйРазделитель_2
			// 
			ГоризонтальныйРазделитель_2.BackColor = SystemColors.ControlDarkDark;
			tlpQuality.SetColumnSpan(ГоризонтальныйРазделитель_2, 4);
			ГоризонтальныйРазделитель_2.Dock = DockStyle.Fill;
			ГоризонтальныйРазделитель_2.Location = new Point(4, 388);
			ГоризонтальныйРазделитель_2.Margin = new Padding(4, 6, 4, 6);
			ГоризонтальныйРазделитель_2.Name = "ГоризонтальныйРазделитель_2";
			ГоризонтальныйРазделитель_2.Size = new Size(588, 3);
			ГоризонтальныйРазделитель_2.TabIndex = 29;
			// 
			// cboScannerSelect
			// 
			tlpQuality.SetColumnSpan(cboScannerSelect, 3);
			cboScannerSelect.Dock = DockStyle.Top;
			cboScannerSelect.DropDownStyle = ComboBoxStyle.DropDownList;
			cboScannerSelect.Location = new Point(101, 6);
			cboScannerSelect.Margin = new Padding(4, 6, 4, 6);
			cboScannerSelect.Name = "cboScannerSelect";
			cboScannerSelect.Size = new Size(491, 33);
			cboScannerSelect.TabIndex = 1;
			// 
			// lblColorMode
			// 
			lblColorMode.AutoSize = true;
			lblColorMode.Dock = DockStyle.Right;
			lblColorMode.Location = new Point(22, 111);
			lblColorMode.Margin = new Padding(4, 0, 4, 0);
			lblColorMode.Name = "lblColorMode";
			lblColorMode.Size = new Size(71, 45);
			lblColorMode.TabIndex = 10;
			lblColorMode.Text = "Режим:";
			lblColorMode.TextAlign = ContentAlignment.MiddleRight;
			// 
			// cboColorMode
			// 
			cboColorMode.Dock = DockStyle.Top;
			cboColorMode.DropDownStyle = ComboBoxStyle.DropDownList;
			cboColorMode.FormattingEnabled = true;
			cboColorMode.Location = new Point(101, 117);
			cboColorMode.Margin = new Padding(4, 6, 4, 6);
			cboColorMode.Name = "cboColorMode";
			cboColorMode.Size = new Size(254, 33);
			cboColorMode.TabIndex = 11;
			// 
			// cboDPI
			// 
			cboDPI.Dock = DockStyle.Top;
			cboDPI.DropDownStyle = ComboBoxStyle.DropDownList;
			cboDPI.FormattingEnabled = true;
			cboDPI.Location = new Point(487, 117);
			cboDPI.Margin = new Padding(4, 6, 4, 6);
			cboDPI.Name = "cboDPI";
			cboDPI.Size = new Size(105, 33);
			cboDPI.TabIndex = 18;
			// 
			// chkUseAutoFeeder
			// 
			chkUseAutoFeeder.AutoSize = true;
			chkUseAutoFeeder.Dock = DockStyle.Top;
			chkUseAutoFeeder.Location = new Point(101, 51);
			chkUseAutoFeeder.Margin = new Padding(4, 6, 4, 6);
			chkUseAutoFeeder.Name = "chkUseAutoFeeder";
			chkUseAutoFeeder.Size = new Size(254, 29);
			chkUseAutoFeeder.TabIndex = 19;
			chkUseAutoFeeder.Text = "Через автоподатчик";
			chkUseAutoFeeder.UseVisualStyleBackColor = true;
			// 
			// chkUseAutoFeederDuplex
			// 
			chkUseAutoFeederDuplex.AutoSize = true;
			tlpQuality.SetColumnSpan(chkUseAutoFeederDuplex, 2);
			chkUseAutoFeederDuplex.Dock = DockStyle.Top;
			chkUseAutoFeederDuplex.Location = new Point(363, 51);
			chkUseAutoFeederDuplex.Margin = new Padding(4, 6, 4, 6);
			chkUseAutoFeederDuplex.Name = "chkUseAutoFeederDuplex";
			chkUseAutoFeederDuplex.Size = new Size(229, 29);
			chkUseAutoFeederDuplex.TabIndex = 20;
			chkUseAutoFeederDuplex.Text = "С обеих строн листа";
			chkUseAutoFeederDuplex.UseVisualStyleBackColor = true;
			// 
			// lblFileFormat
			// 
			lblFileFormat.AutoSize = true;
			lblFileFormat.Dock = DockStyle.Right;
			lblFileFormat.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
			lblFileFormat.Location = new Point(4, 397);
			lblFileFormat.Margin = new Padding(4, 0, 4, 0);
			lblFileFormat.Name = "lblFileFormat";
			lblFileFormat.Size = new Size(89, 45);
			lblFileFormat.TabIndex = 21;
			lblFileFormat.Text = "Формат:";
			lblFileFormat.TextAlign = ContentAlignment.MiddleRight;
			// 
			// lblScanner
			// 
			lblScanner.AutoSize = true;
			lblScanner.Dock = DockStyle.Fill;
			lblScanner.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
			lblScanner.Location = new Point(4, 0);
			lblScanner.Margin = new Padding(4, 0, 4, 0);
			lblScanner.Name = "lblScanner";
			lblScanner.Size = new Size(89, 45);
			lblScanner.TabIndex = 22;
			lblScanner.TextAlign = ContentAlignment.MiddleRight;
			// 
			// cboFileFormat
			// 
			tlpQuality.SetColumnSpan(cboFileFormat, 3);
			cboFileFormat.Dock = DockStyle.Top;
			cboFileFormat.DropDownStyle = ComboBoxStyle.DropDownList;
			cboFileFormat.FormattingEnabled = true;
			cboFileFormat.Location = new Point(101, 403);
			cboFileFormat.Margin = new Padding(4, 6, 4, 6);
			cboFileFormat.Name = "cboFileFormat";
			cboFileFormat.Size = new Size(491, 33);
			cboFileFormat.TabIndex = 21;
			// 
			// lblFile_Quality
			// 
			lblFile_Quality.AutoSize = true;
			lblFile_Quality.Dock = DockStyle.Right;
			lblFile_Quality.Location = new Point(93, 442);
			lblFile_Quality.Margin = new Padding(4, 0, 4, 0);
			lblFile_Quality.Name = "lblFile_Quality";
			lblFile_Quality.Size = new Size(0, 81);
			lblFile_Quality.TabIndex = 22;
			lblFile_Quality.TextAlign = ContentAlignment.MiddleRight;
			// 
			// sldFile_Quality
			// 
			tlpQuality.SetColumnSpan(sldFile_Quality, 3);
			sldFile_Quality.Dock = DockStyle.Top;
			sldFile_Quality.Location = new Point(101, 448);
			sldFile_Quality.Margin = new Padding(4, 6, 4, 6);
			sldFile_Quality.Maximum = 100;
			sldFile_Quality.Name = "sldFile_Quality";
			sldFile_Quality.Size = new Size(491, 69);
			sldFile_Quality.TabIndex = 23;
			sldFile_Quality.Value = 75;
			// 
			// llScanFolder
			// 
			llScanFolder.AutoSize = true;
			llScanFolder.Dock = DockStyle.Right;
			llScanFolder.Location = new Point(93, 523);
			llScanFolder.Margin = new Padding(4, 0, 4, 0);
			llScanFolder.Name = "llScanFolder";
			llScanFolder.Size = new Size(0, 43);
			llScanFolder.TabIndex = 24;
			llScanFolder.TextAlign = ContentAlignment.MiddleRight;
			// 
			// xFileFolder
			// 
			tlpQuality.SetColumnSpan(xFileFolder, 3);
			xFileFolder.Description = "";
			xFileFolder.Dock = DockStyle.Top;
			xFileFolder.EmptyText = "";
			xFileFolder.FullPath = "";
			xFileFolder.Location = new Point(101, 529);
			xFileFolder.Margin = new Padding(4, 6, 4, 6);
			xFileFolder.Name = "xFileFolder";
			xFileFolder.ReadOnly = true;
			xFileFolder.RootFolder = Environment.SpecialFolder.Desktop;
			xFileFolder.SelectButtonToolTip = "Select...";
			xFileFolder.SeparatorWidth = 8;
			xFileFolder.Size = new Size(491, 31);
			xFileFolder.TabIndex = 25;
			xFileFolder.TextBackColor = SystemColors.Control;
			// 
			// chkCropZone_Set
			// 
			chkCropZone_Set.AutoSize = true;
			tlpQuality.SetColumnSpan(chkCropZone_Set, 3);
			chkCropZone_Set.Dock = DockStyle.Top;
			chkCropZone_Set.Location = new Point(101, 257);
			chkCropZone_Set.Margin = new Padding(4, 6, 4, 6);
			chkCropZone_Set.Name = "chkCropZone_Set";
			chkCropZone_Set.Size = new Size(491, 21);
			chkCropZone_Set.TabIndex = 35;
			chkCropZone_Set.UseVisualStyleBackColor = true;
			// 
			// tlpPageCrop
			// 
			tlpPageCrop.AutoSize = true;
			tlpPageCrop.ColumnCount = 4;
			tlpQuality.SetColumnSpan(tlpPageCrop, 4);
			tlpPageCrop.ColumnStyles.Add(new ColumnStyle());
			tlpPageCrop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tlpPageCrop.ColumnStyles.Add(new ColumnStyle());
			tlpPageCrop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tlpPageCrop.Controls.Add(xudCrop_Width, 3, 0);
			tlpPageCrop.Controls.Add(xudCrop_Left, 1, 0);
			tlpPageCrop.Controls.Add(xudCrop_Height, 3, 1);
			tlpPageCrop.Controls.Add(xudCrop_Top, 1, 1);
			tlpPageCrop.Controls.Add(lblCropZone_X, 0, 0);
			tlpPageCrop.Controls.Add(lblCropZone_Y, 0, 1);
			tlpPageCrop.Controls.Add(lblCropZone_W, 2, 0);
			tlpPageCrop.Controls.Add(lblCropZone_H, 2, 1);
			tlpPageCrop.Dock = DockStyle.Top;
			tlpPageCrop.Location = new Point(4, 290);
			tlpPageCrop.Margin = new Padding(4, 6, 4, 6);
			tlpPageCrop.Name = "tlpPageCrop";
			tlpPageCrop.RowCount = 2;
			tlpPageCrop.RowStyles.Add(new RowStyle());
			tlpPageCrop.RowStyles.Add(new RowStyle());
			tlpPageCrop.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
			tlpPageCrop.Size = new Size(588, 86);
			tlpPageCrop.TabIndex = 37;
			// 
			// xudCrop_Width
			// 
			xudCrop_Width.DecimalPlaces = 2;
			xudCrop_Width.Dock = DockStyle.Top;
			xudCrop_Width.Location = new Point(384, 6);
			xudCrop_Width.Margin = new Padding(4, 6, 4, 6);
			xudCrop_Width.Name = "xudCrop_Width";
			xudCrop_Width.Size = new Size(200, 31);
			xudCrop_Width.TabIndex = 1;
			// 
			// xudCrop_Left
			// 
			xudCrop_Left.DecimalPlaces = 2;
			xudCrop_Left.Dock = DockStyle.Top;
			xudCrop_Left.Location = new Point(86, 6);
			xudCrop_Left.Margin = new Padding(4, 6, 4, 6);
			xudCrop_Left.Name = "xudCrop_Left";
			xudCrop_Left.Size = new Size(199, 31);
			xudCrop_Left.TabIndex = 0;
			// 
			// xudCrop_Height
			// 
			xudCrop_Height.DecimalPlaces = 2;
			xudCrop_Height.Dock = DockStyle.Top;
			xudCrop_Height.Location = new Point(384, 49);
			xudCrop_Height.Margin = new Padding(4, 6, 4, 6);
			xudCrop_Height.Name = "xudCrop_Height";
			xudCrop_Height.Size = new Size(200, 31);
			xudCrop_Height.TabIndex = 3;
			// 
			// xudCrop_Top
			// 
			xudCrop_Top.DecimalPlaces = 2;
			xudCrop_Top.Dock = DockStyle.Top;
			xudCrop_Top.Location = new Point(86, 49);
			xudCrop_Top.Margin = new Padding(4, 6, 4, 6);
			xudCrop_Top.Name = "xudCrop_Top";
			xudCrop_Top.Size = new Size(199, 31);
			xudCrop_Top.TabIndex = 2;
			// 
			// lblCropZone_X
			// 
			lblCropZone_X.AutoSize = true;
			lblCropZone_X.Dock = DockStyle.Right;
			lblCropZone_X.Location = new Point(14, 0);
			lblCropZone_X.Margin = new Padding(4, 0, 4, 0);
			lblCropZone_X.Name = "lblCropZone_X";
			lblCropZone_X.Size = new Size(64, 43);
			lblCropZone_X.TabIndex = 4;
			lblCropZone_X.Text = "Слева:";
			lblCropZone_X.TextAlign = ContentAlignment.MiddleRight;
			// 
			// lblCropZone_Y
			// 
			lblCropZone_Y.AutoSize = true;
			lblCropZone_Y.Dock = DockStyle.Right;
			lblCropZone_Y.Location = new Point(4, 43);
			lblCropZone_Y.Margin = new Padding(4, 0, 4, 0);
			lblCropZone_Y.Name = "lblCropZone_Y";
			lblCropZone_Y.Size = new Size(74, 43);
			lblCropZone_Y.TabIndex = 5;
			lblCropZone_Y.Text = "Сверху:";
			lblCropZone_Y.TextAlign = ContentAlignment.MiddleRight;
			// 
			// lblCropZone_W
			// 
			lblCropZone_W.AutoSize = true;
			lblCropZone_W.Dock = DockStyle.Right;
			lblCropZone_W.Location = new Point(293, 0);
			lblCropZone_W.Margin = new Padding(4, 0, 4, 0);
			lblCropZone_W.Name = "lblCropZone_W";
			lblCropZone_W.Size = new Size(83, 43);
			lblCropZone_W.TabIndex = 6;
			lblCropZone_W.Text = "Ширина:";
			lblCropZone_W.TextAlign = ContentAlignment.MiddleRight;
			// 
			// lblCropZone_H
			// 
			lblCropZone_H.AutoSize = true;
			lblCropZone_H.Dock = DockStyle.Right;
			lblCropZone_H.Location = new Point(302, 43);
			lblCropZone_H.Margin = new Padding(4, 0, 4, 0);
			lblCropZone_H.Name = "lblCropZone_H";
			lblCropZone_H.Size = new Size(74, 43);
			lblCropZone_H.TabIndex = 7;
			lblCropZone_H.Text = "Высота:";
			lblCropZone_H.TextAlign = ContentAlignment.MiddleRight;
			// 
			// Splitter1
			// 
			Splitter1.BackColor = SystemColors.ControlDarkDark;
			Splitter1.Location = new Point(648, 0);
			Splitter1.Margin = new Padding(4, 6, 4, 6);
			Splitter1.MinExtra = 100;
			Splitter1.MinSize = 150;
			Splitter1.Name = "Splitter1";
			Splitter1.Size = new Size(11, 1637);
			Splitter1.TabIndex = 5;
			Splitter1.TabStop = false;
			// 
			// pnlMainView
			// 
			pnlMainView.Controls.Add(xPageControl);
			pnlMainView.Dock = DockStyle.Fill;
			pnlMainView.Location = new Point(659, 0);
			pnlMainView.Margin = new Padding(4, 6, 4, 6);
			pnlMainView.Name = "pnlMainView";
			pnlMainView.Padding = new Padding(7, 8, 7, 8);
			pnlMainView.Size = new Size(1413, 1637);
			pnlMainView.TabIndex = 6;
			// 
			// xPageControl
			// 
			xPageControl.CropZoneString = "Crop area";
			xPageControl.CropZoneUnitsCm = "cm";
			xPageControl.Dock = DockStyle.Fill;
			xPageControl.EmptyImagesText = "";
			xPageControl.Location = new Point(7, 8);
			xPageControl.Margin = new Padding(4, 6, 4, 6);
			xPageControl.Name = "xPageControl";
			xPageControl.CropZoneCm = (RectangleF?)resources.GetObject("xPageControl.PaperCropCm");
			xPageControl.PaperSizeCm = new SizeF(10F, 15F);
			xPageControl.RullerOffsetMM = 4;
			xPageControl.RullerSizeMM = 10;
			xPageControl.Size = new Size(1399, 1621);
			xPageControl.TabIndex = 0;
			// 
			// frmMain
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(2072, 1669);
			Controls.Add(pnlMainView);
			Controls.Add(Splitter1);
			Controls.Add(pnlLeftMain);
			Controls.Add(sbMain);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(4, 6, 4, 6);
			MinimumSize = new Size(886, 736);
			Name = "frmMain";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Main";
			WindowState = FormWindowState.Maximized;
			sbMain.ResumeLayout(false);
			sbMain.PerformLayout();
			pnlLeftMain.ResumeLayout(false);
			pnlLeftMain.PerformLayout();
			grpScanButtons.ResumeLayout(false);
			grpScanButtons.PerformLayout();
			tlpProfile.ResumeLayout(false);
			tlpProfile.PerformLayout();
			grpSettings.ResumeLayout(false);
			grpSettings.PerformLayout();
			tlpQuality.ResumeLayout(false);
			tlpQuality.PerformLayout();
			((ISupportInitialize)sldFile_Quality).EndInit();
			tlpPageCrop.ResumeLayout(false);
			tlpPageCrop.PerformLayout();
			((ISupportInitialize)xudCrop_Width).EndInit();
			((ISupportInitialize)xudCrop_Left).EndInit();
			((ISupportInitialize)xudCrop_Height).EndInit();
			((ISupportInitialize)xudCrop_Top).EndInit();
			pnlMainView.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
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
		internal uom.controls.PathSelector.DirectorySelector xFileFolder;
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