
namespace GestionDesEtudiants.Forms
{
    partial class allStudentsReportViewerForm
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(allStudentsReportViewerForm));
            this.AllStudentsReportAdapterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.AllStudentsReportAdapterBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // AllStudentsReportAdapterBindingSource
            // 
            this.AllStudentsReportAdapterBindingSource.DataSource = typeof(GestionDesEtudiants.ReportAdapters.AllStudentsReportAdapter);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.reportViewer1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            reportDataSource1.Name = "BranchesDataSet";
            reportDataSource1.Value = this.AllStudentsReportAdapterBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GestionDesEtudiants.Reports.AllStudentsMainReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 68);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.ShowExportButton = false;
            this.reportViewer1.ShowPrintButton = false;
            this.reportViewer1.Size = new System.Drawing.Size(783, 494);
            this.reportViewer1.TabIndex = 0;
            // 
            // iconButton2
            // 
            this.iconButton2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.iconButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(78)))), ((int)(((byte)(132)))));
            this.iconButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton2.ForeColor = System.Drawing.Color.White;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.FileDownload;
            this.iconButton2.IconColor = System.Drawing.Color.White;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.IconSize = 35;
            this.iconButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton2.Location = new System.Drawing.Point(280, 3);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.iconButton2.Size = new System.Drawing.Size(230, 59);
            this.iconButton2.TabIndex = 4;
            this.iconButton2.Text = "Télécharger la version PDF";
            this.iconButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton2.UseVisualStyleBackColor = false;
            this.iconButton2.Click += new System.EventHandler(this.iconButton2_Click);
            // 
            // allStudentsReportViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.iconButton2);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "allStudentsReportViewerForm";
            this.Text = "Reporting";
            this.Load += new System.EventHandler(this.allStudentsReportViewerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AllStudentsReportAdapterBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource AllStudentsReportAdapterBindingSource;
        private FontAwesome.Sharp.IconButton iconButton2;
    }
}