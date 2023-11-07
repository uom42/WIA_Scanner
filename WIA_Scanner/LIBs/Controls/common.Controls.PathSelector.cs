#nullable enable

using System.Drawing;

namespace common.Controls.PathSelector
{


	[DefaultProperty("FullPath"), DefaultEvent("ValueChanged")]
	internal abstract partial class SelectorBase : UserControl
	{
		#region Designer

		// Required by the Windows Form Designer
		protected IContainer components;

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
		protected Panel _pnlSeparetor;
		protected ToolTip _ttMain;
		protected Button _cmdBrowse;

		#endregion

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		public SelectorBase() : base()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			SelectButtonToolTip = _selectButtonToolTip;
			Resize += delegate { ProceesResize(); };
			_txtPath!.TextChanged += (_, __) => OnTextBoxValueChanged();

			// Add any initialization after the InitializeComponent() call
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
			components = new Container();
			_txtPath = new TextBox();
			_cmdBrowse = new Button();
			_pnlSeparetor = new Panel();
			_ttMain = new ToolTip(components);

			SuspendLayout();
			// 
			// txtPath
			// 
			_txtPath.Dock = DockStyle.Fill;
			_txtPath.Location = new Point(0, 0);
			_txtPath.ReadOnly = true;
			_txtPath.Size = new Size(192, 20);
			_txtPath.TabIndex = 1;
			_txtPath.TabStop = false;
			// 
			// cmdBrowse
			// 
			_cmdBrowse.Dock = DockStyle.Right;
			_cmdBrowse.FlatStyle = FlatStyle.System;
			_cmdBrowse.Location = new Point(200, 0);
			_cmdBrowse.Size = new Size(24, 48);
			_cmdBrowse.TabIndex = 0;
			_cmdBrowse.Text = "...";

			// 
			// pnlSeparetor
			// 
			_pnlSeparetor.Dock = DockStyle.Right;
			_pnlSeparetor.Location = new Point(192, 0);
			_pnlSeparetor.Size = new Size(8, 48);
			_pnlSeparetor.TabIndex = 2;
			// 
			// SelectorBase
			// 
			Controls.Add(_txtPath);
			Controls.Add(_pnlSeparetor);
			Controls.Add(_cmdBrowse);
			Size = new Size(224, 48);
			ResumeLayout(false);
			PerformLayout();

		}

		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
			UpdateVistaCueBanner();
		}

		private void UpdateVistaCueBanner() => _txtPath.e_SetVistaCueBanner(_emptyText);


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
				_pnlSeparetor.Width = _separatorWidth;
				ProceesResize();
			}
		}


		public bool ReadOnly { get => _txtPath.ReadOnly; set => _txtPath.ReadOnly = value; }

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

		protected void OnChanged(object sender, string NewPath) => ValueChanged?.Invoke(sender, NewPath);

		protected void AllowHandleTextBoxChanges(bool allow = true) => _canHandleTextBoxChanges = allow;

	}

	[ToolboxItem(true)]
	internal sealed partial class DirectorySelector : SelectorBase
	{
		private FolderBrowserDialog _BFFD = new();

		public DirectorySelector() : base()
		{
			_cmdBrowse.Click += delegate { BrowseFolder(); };
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

		private void BrowseFolder()
		{
			_BFFD.RootFolder = Environment.SpecialFolder.MyComputer;
			_BFFD.SelectedPath = this.FullPath;
			if (_BFFD.ShowDialog() != DialogResult.OK) return;
			FullPath = _BFFD.SelectedPath;
		}
	}

	[ToolboxItem(true)]
	internal sealed class FileOpenSelector : SelectorBase
	{
		private System.Windows.Forms.OpenFileDialog _ofd;

		public FileOpenSelector() : base()
		{
			_ofd = new()
			{
				CheckPathExists = true,
				AutoUpgradeEnabled = true,
				Multiselect = false,
				ShowReadOnly = false,
				ValidateNames = true,
				SupportMultiDottedExtensions = true,
				ShowHelp = false,
			};

			_cmdBrowse.Click += delegate { BrowseForFilder(); };
		}

		#region Properties

		// Private _Filter As String = "Все файлы|*.*"
		public string Filter { get => _ofd.Filter; set => _ofd.Filter = value; }

		public bool DereferenceLinks { get => _ofd.DereferenceLinks; set => _ofd.DereferenceLinks = value; }

		public bool CheckFileExists { get => _ofd.CheckFileExists; set => _ofd.CheckFileExists = value; }

		public string InitialDir { get => _ofd.InitialDirectory; set => _ofd.InitialDirectory = value; }

		#endregion

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public System.IO.FileInfo File
		{
			get => new System.IO.FileInfo(FullPath);
			set => FullPath = value.FullName;
		}

		protected override void OnFullPathSet()
		{
			base.OnFullPathSet();
			_ofd.FileName = FullPath;
		}

		public override FileSystemInfo GetFileSystemInfo() => File;

		private void BrowseForFilder()
		{
			if (_ofd.ShowDialog() != DialogResult.OK) return;
			this.FullPath = _ofd.FileName;
		}
	}


	[ToolboxItem(true)]
	internal sealed class FileSaveSelector : SelectorBase
	{
		private System.Windows.Forms.SaveFileDialog _sfd = new();

		public FileSaveSelector() : base()
		{
			_sfd.CheckPathExists = true;
			_sfd.AddExtension = true;
			_sfd.AutoUpgradeEnabled = true;
			_sfd.CheckPathExists = true;
			_sfd.CreatePrompt = false;
			_sfd.DefaultExt = "tmp";
			_sfd.OverwritePrompt = true;
			_sfd.SupportMultiDottedExtensions = true;
			_sfd.ShowHelp = false;
			_sfd.ValidateNames = true;

			//_sfd.FilterIndex
			//;
			_cmdBrowse.Click += delegate { BrowseForFilder(); };
		}

		#region Properties

		// Private _Filter As String = "Все файлы|*.*"
		public string Filter { get => _sfd.Filter; set => _sfd.Filter = value; }

		[DefaultValue(true)]
		public bool DereferenceLinks { get => _sfd.DereferenceLinks; set => _sfd.DereferenceLinks = value; }

		[DefaultValue(true)]
		public bool CheckPathExists { get => _sfd.CheckPathExists; set => _sfd.CheckPathExists = value; }

		[DefaultValue(false)]
		public bool CreatePrompt { get => _sfd.CreatePrompt; set => _sfd.CreatePrompt = value; }

		[DefaultValue(true)]
		public bool OverwritePrompt { get => _sfd.OverwritePrompt; set => _sfd.OverwritePrompt = value; }

		public string DefaultExt { get => _sfd.DefaultExt; set => _sfd.DefaultExt = value; }

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int FilterIndex { get => _sfd.FilterIndex; set => _sfd.FilterIndex = value; }



		public string InitialDir { get => _sfd.InitialDirectory; set => _sfd.InitialDirectory = value; }


		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public System.IO.FileInfo File { get => new System.IO.FileInfo(FullPath); set => FullPath = value.FullName; }

		public override FileSystemInfo GetFileSystemInfo() => File;


		#endregion

		private void BrowseForFilder()
		{
			_sfd.FileName = this.FullPath;
			if (_sfd.ShowDialog() != DialogResult.OK) return;
			this.FullPath = _sfd.FileName;
		}
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
