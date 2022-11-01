using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BoltsAndPrices.Ui.Wpf
{
    /// <summary>
    /// Interaction logic for ReportsWindows.xaml
    /// </summary>
    public partial class ReportsWindow : Window
    {

        public EventHandler PrepateReport { get; set; }
        public string ReportPath { get; set; }
        public string DataSourceName { get; set; }
        public Object DataSourceValue { get; set; }

        public ReportsWindow()
        {
            InitializeComponent();
        }

        private void ReportViewer_Load(object sender, EventArgs e)
        {
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource = new Microsoft.Reporting.WinForms.ReportDataSource();

            if(PrepateReport != null)
            {
                PrepateReport.Invoke(this, null);
            }

            reportDataSource.Name = this.DataSourceName;
            reportDataSource.Value = this.DataSourceValue;


            this._reportViewer.LocalReport.DataSources.Add(reportDataSource);
            this._reportViewer.LocalReport.ReportPath = ReportPath;

            _reportViewer.RefreshReport();

        }



        private void ReportViewer_ViewButtonClick(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
