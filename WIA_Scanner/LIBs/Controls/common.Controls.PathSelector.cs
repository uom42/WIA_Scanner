#nullable enable

using System.Drawing;

namespace uom.controls.PathSelector
{


	[DefaultProperty("FullPath"), DefaultEvent("ValueChanged")]
	internal abstract partial class FileSystemObjectSelectorBase : UserControl
	{
		private IContainer components;
		#region Designer

		// UserControl overrides dispose to clean up the component list.
		protected override void Dispose(bool disposing)
		{
			if (disposing)
				components?.Dispose();
			base.Dispose(disposing);
		}

		#endregion

		protected int _separatorWidth = 8;
		private string _fullPath = "";
		private bool _canHandleTextBoxChanges = false;
		private string _emptyText = string.Empty;

		public event EventHandler<string> ValueChanged = delegate { };

		#region  Windows Form Designer generated code 

		protected TextBox _txtPath;
		protected Panel _pnlSeparator;
		protected ToolTip _ttMain;
		protected Button _cmdBrowse;

		#endregion

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		public FileSystemObjectSelectorBase() : base()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			SelectButtonToolTip = _selectButtonToolTip;


			this.Resize += delegate { ProceesResize(); };
			_cmdBrowse!.Click += (_, _) => ShowDialog();
			_txtPath!.TextChanged += (_, __) => OnTextBoxValueChanged();
			_txtPath!.Click += (_, __) => OnTextBoxClick();



			this.AllowHandleTextBoxChanges();
		}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

		string _selectButtonToolTip = "Select...";
		public string SelectButtonToolTip
		{
			get => _selectButtonToolTip; set
			{
				_selectButtonToolTip = value;
				_ttMain!.SetToolTip(_cmdBrowse, _selectButtonToolTip);
			}
		}



		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this._txtPath = new System.Windows.Forms.TextBox();
			this._cmdBrowse = new System.Windows.Forms.Button();
			this._pnlSeparator = new System.Windows.Forms.Panel();
			this._ttMain = new System.Windows.Forms.ToolTip(this.components);
			this.SuspendLayout();
			// 
			// _txtPath
			// 
			this._txtPath.Dock = System.Windows.Forms.DockStyle.Fill;
			this._txtPath.Location = new System.Drawing.Point(0, 0);
			this._txtPath.Name = "_txtPath";
			this._txtPath.ReadOnly = true;
			this._txtPath.Size = new System.Drawing.Size(192, 26);
			this._txtPath.TabIndex = 1;
			this._txtPath.TabStop = false;
			// 
			// _cmdBrowse
			// 
			this._cmdBrowse.Dock = System.Windows.Forms.DockStyle.Right;
			this._cmdBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this._cmdBrowse.Location = new System.Drawing.Point(200, 0);
			this._cmdBrowse.Name = "_cmdBrowse";
			this._cmdBrowse.Size = new System.Drawing.Size(24, 48);
			this._cmdBrowse.TabIndex = 0;
			this._cmdBrowse.Text = "...";
			// 
			// _pnlSeparetor
			// 
			this._pnlSeparator.Dock = System.Windows.Forms.DockStyle.Right;
			this._pnlSeparator.Location = new System.Drawing.Point(192, 0);
			this._pnlSeparator.Name = "_pnlSeparetor";
			this._pnlSeparator.Size = new System.Drawing.Size(8, 48);
			this._pnlSeparator.TabIndex = 2;
			// 
			// SelectorBase
			// 
			this.Controls.Add(this._txtPath);
			this.Controls.Add(this._pnlSeparator);
			this.Controls.Add(this._cmdBrowse);
			this.Name = "SelectorBase";
			this.Size = new System.Drawing.Size(224, 48);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
			UpdateVistaCueBanner();
		}

		private void UpdateVistaCueBanner() => _txtPath.eSetVistaCueBanner(_emptyText);


		#region Properties

		public override Font Font
		{
			get => base.Font;
			set
			{
				base.Font = value;
				ProceesResize();
			}
		}

		public int SeparatorWidth
		{
			get => _separatorWidth;
			set
			{
				_separatorWidth = value;
				_pnlSeparator.Width = _separatorWidth;
				ProceesResize();
			}
		}


		public bool ReadOnly
		{
			get => _txtPath.ReadOnly;
			set
			{
				//if (_txtPath.ReadOnly != value)
				{
					_cmdBrowse.Visible = !value;
					_pnlSeparator.Visible = !value;
				}
				_txtPath.ReadOnly = value;
			}
		}

		public Color TextBackColor { get => _txtPath.BackColor; set => _txtPath.BackColor = value; }

		public string EmptyText
		{
			get => _emptyText;
			set
			{
				_emptyText = value;
				UpdateVistaCueBanner();
			}
		}

		public string FullPath
		{
			get => _fullPath;
			set
			{
				AllowHandleTextBoxChanges(false);
				try
				{
					_fullPath = value;
					_txtPath.Text = value;
					OnFullPathSet();
					OnChanged(this, FullPath);
				}
				finally { AllowHandleTextBoxChanges(); }
			}
		}

		protected virtual void OnFullPathSet()
		{

		}


		public abstract System.IO.FileSystemInfo GetFileSystemInfo();

		#endregion


		protected void ProceesResize()
		{
			int H = this._txtPath.Size.Height;
			this._cmdBrowse.Width = H;
			this.ClientSize = new Size(this.ClientSize.Width, H);
		}

		private void OnTextBoxValueChanged()
		{
			if (!_canHandleTextBoxChanges || ReadOnly) return;
			FullPath = _txtPath.Text.Trim();
		}

		private void OnTextBoxClick()
		{
			if (ReadOnly) ShowDialog();
		}

		protected void OnChanged(object sender, string NewPath) => ValueChanged?.Invoke(sender, NewPath);

		protected void AllowHandleTextBoxChanges(bool allow = true) => _canHandleTextBoxChanges = allow;

		public abstract DialogResult ShowDialog();

	}

	[ToolboxItem(true)]
	internal sealed partial class DirectorySelector : FileSystemObjectSelectorBase
	{
		private FolderBrowserDialog _BFFD = new();

		public DirectorySelector() : base()
		{
			_txtPath.AutoCompleteSource = AutoCompleteSource.FileSystemDirectories;
			_txtPath.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

			AllowHandleTextBoxChanges();
		}


		public string Description { get => _BFFD.Description; set => _BFFD.Description = value; }
		public Environment.SpecialFolder RootFolder { get => _BFFD.RootFolder; set => _BFFD.RootFolder = value; }

		[DefaultValue(true)]
		public bool ShowNewFolderButton { get => _BFFD.ShowNewFolderButton; set => _BFFD.ShowNewFolderButton = value; }


		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public System.IO.DirectoryInfo Directory { get => new System.IO.DirectoryInfo(this.FullPath); set => FullPath = value.FullName; }

		private new string Text { get => ""; set { } }

		public override FileSystemInfo GetFileSystemInfo() => Directory;

		public override DialogResult ShowDialog()
		{
			_BFFD.RootFolder = Environment.SpecialFolder.MyComputer;
			_BFFD.SelectedPath = this.FullPath;
			DialogResult dr = _BFFD.ShowDialog();
			if (dr == DialogResult.OK) this.FullPath = _BFFD.SelectedPath;
			return dr;
		}
	}




	internal abstract class FileSelectorBase : FileSystemObjectSelectorBase
	{
		protected System.Windows.Forms.FileDialog _fd;

		public FileSelectorBase(System.Windows.Forms.FileDialog fd) : base() { _fd = fd; }

		#region Properties

		// Private _Filter As String = "Все файлы|*.*"
		public string Filter { get => _fd.Filter; set => _fd.Filter = value; }

		[DefaultValue(true)]
		public bool DereferenceLinks { get => _fd.DereferenceLinks; set => _fd.DereferenceLinks = value; }

		[DefaultValue(true)]
		public bool CheckPathExists { get => _fd.CheckPathExists; set => _fd.CheckPathExists = value; }

		public string DefaultExt { get => _fd.DefaultExt; set => _fd.DefaultExt = value; }

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int FilterIndex { get => _fd.FilterIndex; set => _fd.FilterIndex = value; }

		public string InitialDir { get => _fd.InitialDirectory; set => _fd.InitialDirectory = value; }

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public System.IO.FileInfo File { get => new System.IO.FileInfo(FullPath); set => FullPath = value.FullName; }

		public override FileSystemInfo GetFileSystemInfo() => File;


		#endregion


		public override DialogResult ShowDialog()
		{
			if (_fd.FileName.eIsNotNullOrWhiteSpace())
			{
				try
				{
					_fd.InitialDirectory = null;
					_fd.RestoreDirectory = false;

					FileInfo fi = this.File;
					DirectoryInfo di = fi.Directory;

					if (di.Exists) _fd.InitialDirectory = fi.DirectoryName;
				}
				catch { }

				_fd.FileName = this.FullPath;
			}

			DialogResult dr = _fd.ShowDialog();
			if (dr == DialogResult.OK) this.FullPath = _fd.FileName;
			return dr;
		}
	}






	[ToolboxItem(true)]
	internal sealed class FileOpenSelector : FileSelectorBase
	{
		public FileOpenSelector() : base(new System.Windows.Forms.OpenFileDialog()
		{
			CheckPathExists = true,
			AutoUpgradeEnabled = true,
			Multiselect = false,
			ShowReadOnly = false,
			ValidateNames = true,
			SupportMultiDottedExtensions = true,
			ShowHelp = false
		})
		{ }

		private System.Windows.Forms.OpenFileDialog _ofd => (System.Windows.Forms.OpenFileDialog)_fd;




		#region Properties

		public bool CheckFileExists { get => _ofd.CheckFileExists; set => _ofd.CheckFileExists = value; }


		#endregion


		protected override void OnFullPathSet()
		{
			base.OnFullPathSet();
			_ofd.FileName = FullPath;
		}

		public override FileSystemInfo GetFileSystemInfo() => File;

		/*
		public override DialogResult ShowDialog()
		{
			DialogResult dr = _ofd.ShowDialog();
			if (dr == DialogResult.OK) this.FullPath = _ofd.FileName;
			return dr;
		}
		 */
	}






	[ToolboxItem(true)]
	internal sealed class FileSaveSelector : FileSelectorBase
	{
		public FileSaveSelector() : base(new System.Windows.Forms.SaveFileDialog()
		{
			AutoUpgradeEnabled = true,
			CheckPathExists = true,
			AddExtension = true,
			CreatePrompt = false,
			DefaultExt = "tmp",
			OverwritePrompt = true,
			SupportMultiDottedExtensions = true,
			ShowHelp = false,
			ValidateNames = true
		})
		{ }

		private System.Windows.Forms.SaveFileDialog _sfd => (System.Windows.Forms.SaveFileDialog)_fd;


		#region Properties

		[DefaultValue(false)]
		public bool CreatePrompt { get => _sfd.CreatePrompt; set => _sfd.CreatePrompt = value; }

		[DefaultValue(true)]
		public bool OverwritePrompt { get => _sfd.OverwritePrompt; set => _sfd.OverwritePrompt = value; }

		public override FileSystemInfo GetFileSystemInfo() => File;

		#endregion



	}


	/*

[ToolboxItem(true)]
internal sealed class PathOrFileSelector : SelectorBase
{
protected const string CS_FILE_SELECTOR_CATEGORY = "File Selector";
protected const string CS_FOLDER_SELECTOR_CATEGORY = "Folder Selector";

protected OpenFileDialog _FileDlg;
protected FolderBrowserDialog _FolderDlg = new FolderBrowserDialog();

protected Environment.SpecialFolder _FolderSelector_Root;
protected bool _FolderSelector_NewFolderButton = true;
protected string _FolderSelector_Description = "Выбор папки";

protected string _FileSelector_Filter = "Все файлы|*.*";
protected bool _FileSelector_DereferenceLinks = true;
protected bool _FileSelector_CheckFileExists = true;

public enum Modes : int
{
FolderSelector,
FileSelector
}

protected Modes _Mode = Modes.FolderSelector;

public PathOrFileSelector()
{
cmdBrowse.Click += (_, __) => _OpenBrowseDialog();
base..ctor();

_FileDlg = new OpenFileDialog()
{
 CheckPathExists = true,
 Multiselect = false,
 ShowReadOnly = false,
 ValidateNames = true
};

_FolderDlg = new FolderBrowserDialog();

this._canHandleTextBoxChanges = true;
}

public Modes Mode
{
get
{
 return _Mode;
}
set
{
 _Mode = value;
 {
	 var withBlock = txtPath;
	 switch (_Mode)
	 {
		 case Modes.FileSelector:
			 {
				 withBlock.AutoCompleteSource = AutoCompleteSource.FileSystem;
				 break;
			 }

		 case Modes.FolderSelector:
			 {
				 withBlock.AutoCompleteSource = AutoCompleteSource.FileSystemDirectories;
				 break;
			 }

	 }
	 withBlock.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
 }
}
}

#region FileSelector Properties

[Category(CS_FILE_SELECTOR_CATEGORY)]
public string FileSelector_Filter
{
get
{
 return _FileSelector_Filter;
}
set
{
 _FileSelector_Filter = value;
 _FileDlg.Filter = _FileSelector_Filter;
}
}

[Category(CS_FILE_SELECTOR_CATEGORY)]
public bool FileSelector_DereferenceLinks
{
get
{
 return _FileSelector_DereferenceLinks;
}
set
{
 _FileSelector_DereferenceLinks = value;
 _FileDlg.DereferenceLinks = _FileSelector_DereferenceLinks;
}
}

[Category(CS_FILE_SELECTOR_CATEGORY)]
public bool FileSelector_CheckFileExists
{
get
{
 return _FileSelector_CheckFileExists;
}
set
{
 _FileSelector_CheckFileExists = value;
 _FileDlg.CheckFileExists = _FileSelector_CheckFileExists;
}
}

#endregion

#region FolderSelector Properties

[Category(CS_FOLDER_SELECTOR_CATEGORY)]
public Environment.SpecialFolder FolderSelector_Root
{
get
{
 return _FolderSelector_Root;
}
set
{
 _FolderSelector_Root = value;
 _FolderDlg.RootFolder = _FolderSelector_Root;
}
}

[DefaultValue(true)]
[Category(CS_FOLDER_SELECTOR_CATEGORY)]
public bool FolderSelector_NewFolderButton
{
get
{
 return _FolderSelector_NewFolderButton;
}
set
{
 _FolderSelector_NewFolderButton = value;
 try
 {
	 _FolderDlg.ShowNewFolderButton = _FolderSelector_NewFolderButton;
 }
 catch
 {
 }
}
}

[Category(CS_FOLDER_SELECTOR_CATEGORY)]
public string FolderSelector_Description
{
get
{
 return _FolderSelector_Description;
}
set
{
 _FolderSelector_Description = value;
 _FolderDlg.Description = _FolderSelector_Description;
}
}

[Browsable(false)]
private new string Text
{
get
{
 return "";
}
set
{
 // ""
}
}

#endregion

#region FullPathAs 

[Browsable(false)]
public System.IO.DirectoryInfo FullPathAsDirectory
{
get
{
 // If Mode<>Modes.FolderSelector Then Throw New Exception("Mode is " & Mode.ToString)
 return new System.IO.DirectoryInfo(this.FullPath);
}
}

[Browsable(false)]
public System.IO.FileInfo FullPathAsFile
{
get
{
 // If Mode<>Modes.FileSelector Then Throw New Exception("Mode is " & Mode.ToString)
 return new System.IO.FileInfo(this.FullPath);
}
}

[Browsable(false)]
public System.IO.FileSystemInfo FullPathAsFileSystemInfo
{
get
{
 if (Mode == Modes.FolderSelector)
 {
	 return FullPathAsDirectory;
 }
 else
 {
	 return FullPathAsFile;
 }
}
}

#endregion

private void _OpenBrowseDialog()
{
switch (Mode)
{
 case Modes.FolderSelector:
	 {
		 try
		 {
			 _FolderDlg.SelectedPath = this.FullPath;
			 if (_FolderDlg.ShowDialog() != DialogResult.OK)
				 return;
		 }
		 catch
		 {
		 }
		 this.FullPath = _FolderDlg.SelectedPath;
		 break;
	 }

 case Modes.FileSelector:
	 {
		 try
		 {
			 _FileDlg.FileName = this.FullPath;
			 if (_FileDlg.ShowDialog() != DialogResult.OK)
				 return;
		 }
		 catch
		 {
		 }
		 this.FullPath = _FileDlg.FileName;
		 break;
	 }

 default:
	 {
		 throw new NotImplementedException();
	 }
}
this.OnChanged(this, this.FullPath);
}

/// <summary>Проверяет соответствует-ли FullPath режиму выбора (файл/папка)</summary>
public bool ValidateModeAndFullPath()
{
bool bIsFolder = uomvb.Win32.Shell.mWin32_ShellAPI.PathIsDirectory(this.FullPath);
if (bIsFolder)
{
 var DI = FullPathAsDirectory;
 if (DI.Exists)
	 return true;
}
else
{
 var FI = FullPathAsFile;
 if (FI.Exists)
	 return true;
}
return false;
}

}
*/



}
