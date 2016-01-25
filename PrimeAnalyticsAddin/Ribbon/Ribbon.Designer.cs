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
            this.group3 = this.Factory.CreateRibbonGroup();
            this.btnLogin = this.Factory.CreateRibbonButton();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.btnUpload = this.Factory.CreateRibbonButton();
            this.btAddNewTable = this.Factory.CreateRibbonButton();
            this.group4 = this.Factory.CreateRibbonGroup();
            this.btnPullReport = this.Factory.CreateRibbonButton();
            this.btnEditReport = this.Factory.CreateRibbonButton();
            this.btnCreateNewReport = this.Factory.CreateRibbonButton();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.btnLoadTable = this.Factory.CreateRibbonButton();
            this.btSubmitDataToProcess = this.Factory.CreateRibbonButton();
            this.TabMain.SuspendLayout();
            this.group3.SuspendLayout();
            this.group2.SuspendLayout();
            this.group4.SuspendLayout();
            this.group1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabMain
            // 
            this.TabMain.Groups.Add(this.group3);
            this.TabMain.Groups.Add(this.group2);
            this.TabMain.Groups.Add(this.group4);
            this.TabMain.Groups.Add(this.group1);
            this.TabMain.Label = "Prime Analytics";
            this.TabMain.Name = "TabMain";
            // 
            // group3
            // 
            this.group3.Items.Add(this.btnLogin);
            this.group3.Label = "Session Controls";
            this.group3.Name = "group3";
            // 
            // btnLogin
            // 
            this.btnLogin.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnLogin.Label = "Login";
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.OfficeImageId = "AccountMenu";
            this.btnLogin.ShowImage = true;
            this.btnLogin.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnLogin_Click);
            // 
            // group2
            // 
            this.group2.Items.Add(this.btnUpload);
            this.group2.Items.Add(this.btAddNewTable);
            this.group2.Label = "Cloud Controls";
            this.group2.Name = "group2";
            // 
            // btnUpload
            // 
            this.btnUpload.Label = "Append Records";
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.OfficeImageId = "AddAccount";
            this.btnUpload.ShowImage = true;
            this.btnUpload.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnAppend_Click);
            // 
            // btAddNewTable
            // 
            this.btAddNewTable.Label = "Create New Table";
            this.btAddNewTable.Name = "btAddNewTable";
            this.btAddNewTable.OfficeImageId = "AdpDiagramAddTable";
            this.btAddNewTable.ShowImage = true;
            this.btAddNewTable.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btAddNewTable_Click);
            // 
            // group4
            // 
            this.group4.Items.Add(this.btnPullReport);
            this.group4.Items.Add(this.btnEditReport);
            this.group4.Items.Add(this.btnCreateNewReport);
            this.group4.Label = "Report Utilities";
            this.group4.Name = "group4";
            // 
            // btnPullReport
            // 
            this.btnPullReport.Label = "Pull Report";
            this.btnPullReport.Name = "btnPullReport";
            this.btnPullReport.OfficeImageId = "DownloadContents";
            this.btnPullReport.ShowImage = true;
            // 
            // btnEditReport
            // 
            this.btnEditReport.Label = "Edit Report";
            this.btnEditReport.Name = "btnEditReport";
            this.btnEditReport.OfficeImageId = "EditPage";
            this.btnEditReport.ShowImage = true;
            // 
            // btnCreateNewReport
            // 
            this.btnCreateNewReport.Label = "Create New Report";
            this.btnCreateNewReport.Name = "btnCreateNewReport";
            this.btnCreateNewReport.OfficeImageId = "AdpDiagramNewTable";
            this.btnCreateNewReport.ShowImage = true;
            // 
            // group1
            // 
            this.group1.Items.Add(this.btnLoadTable);
            this.group1.Items.Add(this.btSubmitDataToProcess);
            this.group1.Label = "Process Controls";
            this.group1.Name = "group1";
            // 
            // btnLoadTable
            // 
            this.btnLoadTable.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnLoadTable.Label = "Import Process Result";
            this.btnLoadTable.Name = "btnLoadTable";
            this.btnLoadTable.OfficeImageId = "ImportDBase";
            this.btnLoadTable.ShowImage = true;
            this.btnLoadTable.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnLoadTable_Click);
            // 
            // btSubmitDataToProcess
            // 
            this.btSubmitDataToProcess.Label = "Processes";
            this.btSubmitDataToProcess.Name = "btSubmitDataToProcess";
            this.btSubmitDataToProcess.OfficeImageId = "PivotDiagramTopToBottom";
            this.btSubmitDataToProcess.ShowImage = true;
            this.btSubmitDataToProcess.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btSubmitDataToProcess_Click);
            // 
            // Ribbon
            // 
            this.Name = "Ribbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.TabMain);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon_Load);
            this.TabMain.ResumeLayout(false);
            this.TabMain.PerformLayout();
            this.group3.ResumeLayout(false);
            this.group3.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.group4.ResumeLayout(false);
            this.group4.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab TabMain;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnLogin;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnLoadTable;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnUpload;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btAddNewTable;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group4;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnPullReport;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnEditReport;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnCreateNewReport;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btSubmitDataToProcess;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon Ribbon
        {
            get { return this.GetRibbon<Ribbon>(); }
        }
    }
}
