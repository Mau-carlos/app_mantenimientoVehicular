namespace CapaPresentacion
{
    partial class FormReporteMantenimientoFechas
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.sp_mantenimiento_fecha_mesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsPrincipal = new CapaPresentacion.dsPrincipal();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sp_mantenimiento_fecha_mesTableAdapter = new CapaPresentacion.dsPrincipalTableAdapters.sp_mantenimiento_fecha_mesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sp_mantenimiento_fecha_mesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrincipal)).BeginInit();
            this.SuspendLayout();
            // 
            // sp_mantenimiento_fecha_mesBindingSource
            // 
            this.sp_mantenimiento_fecha_mesBindingSource.DataMember = "sp_mantenimiento_fecha_mes";
            this.sp_mantenimiento_fecha_mesBindingSource.DataSource = this.dsPrincipal;
            // 
            // dsPrincipal
            // 
            this.dsPrincipal.DataSetName = "dsPrincipal";
            this.dsPrincipal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.sp_mantenimiento_fecha_mesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Reportes.ReporteMes.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(884, 531);
            this.reportViewer1.TabIndex = 0;
            // 
            // sp_mantenimiento_fecha_mesTableAdapter
            // 
            this.sp_mantenimiento_fecha_mesTableAdapter.ClearBeforeFill = true;
            // 
            // FormReporteMantenimientoFechas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 531);
            this.Controls.Add(this.reportViewer1);
            this.Location = new System.Drawing.Point(340, 150);
            this.Name = "FormReporteMantenimientoFechas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Reporte Mantenimiento Fechas";
            this.Load += new System.EventHandler(this.FormReporteMantenimientoFechas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sp_mantenimiento_fecha_mesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrincipal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource sp_mantenimiento_fecha_mesBindingSource;
        private dsPrincipal dsPrincipal;
        private dsPrincipalTableAdapters.sp_mantenimiento_fecha_mesTableAdapter sp_mantenimiento_fecha_mesTableAdapter;
    }
}