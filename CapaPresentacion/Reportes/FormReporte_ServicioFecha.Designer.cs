namespace CapaPresentacion
{
    partial class FormReporte_ServicioFecha
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dsPrincipal = new CapaPresentacion.dsPrincipal();
            this.sp_mantenimiento_servicio_mes1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sp_mantenimiento_servicio_mes1TableAdapter = new CapaPresentacion.dsPrincipalTableAdapters.sp_mantenimiento_servicio_mes1TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_mantenimiento_servicio_mes1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.sp_mantenimiento_servicio_mes1BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Reportes.ReporteServicioMes.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(884, 531);
            this.reportViewer1.TabIndex = 0;
            // 
            // dsPrincipal
            // 
            this.dsPrincipal.DataSetName = "dsPrincipal";
            this.dsPrincipal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sp_mantenimiento_servicio_mes1BindingSource
            // 
            this.sp_mantenimiento_servicio_mes1BindingSource.DataMember = "sp_mantenimiento_servicio_mes1";
            this.sp_mantenimiento_servicio_mes1BindingSource.DataSource = this.dsPrincipal;
            // 
            // sp_mantenimiento_servicio_mes1TableAdapter
            // 
            this.sp_mantenimiento_servicio_mes1TableAdapter.ClearBeforeFill = true;
            // 
            // FormReporte_ServicioFecha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 531);
            this.Controls.Add(this.reportViewer1);
            this.Location = new System.Drawing.Point(340, 150);
            this.Name = "FormReporte_ServicioFecha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Reporte Servicio  Fecha";
            this.Load += new System.EventHandler(this.FormReporte_ServicioFecha_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_mantenimiento_servicio_mes1BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource sp_mantenimiento_servicio_mes1BindingSource;
        private dsPrincipal dsPrincipal;
        private dsPrincipalTableAdapters.sp_mantenimiento_servicio_mes1TableAdapter sp_mantenimiento_servicio_mes1TableAdapter;
    }
}