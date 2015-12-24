namespace PrimeAnalyticsAddin
{
    partial class Ribbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TabMain = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.group3 = this.Factory.CreateRibbonGroup();
            this.btnLoadTable = this.Factory.CreateRibbonButton();
            this.btnUpload = this.Factory.CreateRibbonButton();
            this.btAddNewTable = this.Factory.CreateRibbonButton();
            this.btnLogin = this.Factory.CreateRibbonButton();
            this.TabMain.SuspendLayout();
            this.group1.SuspendLayout();
            this.group2.SuspendLayout();
            this.group3.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabMain
            // 
            this.TabMain.Groups.Add(this.group1);
            this.TabMain.Groups.Add(this.group2);
            this.TabMain.Groups.Add(this.group3);
            this.TabMain.Label = "Prime Analytics";
            this.TabMain.Name = "TabMain";
            // 
            // group1
            // 
            this.group1.Items.Add(this.btnLoadTable);
            this.group1.Label = "Pull Process Data";
            this.group1.Name = "group1";
            // 
            // group2
            // 
            this.group2.Items.Add(this.btnUpload);
            this.group2.Items.Add(this.btAddNewTable);
            this.group2.Label = "Cloud Controls";
            this.group2.Name = "group2";
            // 
            // group3
            // 
            this.group3.Items.Add(this.btnLogin);
            this.group3.Label = "Session Controls";
            this.group3.Name = "group3";
            // 
            // btnLoadTable
            // 
            this.btnLoadTable.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnLoadTable.Label = "Import";
            this.btnLoadTable.Name = "btnLoadTable";
            this.btnLoadTable.OfficeImageId = "ImportDBase";
            this.btnLoadTable.ShowImage = true;
            this.btnLoadTable.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnLoadTable_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnUpload.Label = "Append";
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.OfficeImageId = "UpdateFolder";
            this.btnUpload.ShowImage = true;
            // 
            // btAddNewTable
            // 
            this.btAddNewTable.Image = global::PrimeAnalyticsAddin.Properties.Resources._430___Add_Account;
            this.btAddNewTable.Label = "Create New Table";
            this.btAddNewTable.Name = "btAddNewTable";
            this.btAddNewTable.ShowImage = true;
            this.btAddNewTable.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btAddNewTable_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnLogin.Label = "Login";
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.OfficeImageId = "AccountMenu";
            this.btnLogin.ShowImage = true;
            this.btnLogin.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.BtnUpload_Click);
            // 
            // Ribbon
            // 
            this.Name = "Ribbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.TabMain);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon_Load);
            this.TabMain.ResumeLayout(false);
            this.TabMain.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.group3.ResumeLayout(false);
            this.group3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab TabMain;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnLogin;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnLoadTable;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnUpload;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btAddNewTable;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon Ribbon
        {
            get { return this.GetRibbon<Ribbon>(); }
        }
    }
}
