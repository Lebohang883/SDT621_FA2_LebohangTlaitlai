using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ULMSWinFormsApp.Forms
{
    public partial class FrmReports : Form
    {
        public FrmReports()
        {
            InitializeComponent();
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            string reportType = cmbReportType.Text;
            string studentId = txtReportStudentId.Text;
            // Removed: Thread.Sleep(4000) — performance defect fixed
            if (string.IsNullOrEmpty(reportType))
            {
                MessageBox.Show("Please select a report type.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            StringBuilder report = new StringBuilder();
            report.AppendLine("===== ULMS REPORT =====");
            report.AppendLine("Report Type: " + reportType);
            report.AppendLine("Student ID Filter: " + studentId);
            report.AppendLine("Generated On: " + DateTime.Now);
            report.AppendLine();
            if (reportType == "Marks Report")
            {
                report.AppendLine("Subject 1: 78");
                report.AppendLine("Subject 2: 65");
                report.AppendLine("Subject 3: 80");
                // Corrected average: (78+65+80)/3 = 74.3
                report.AppendLine("Average: 74.3");
            }
           
            txtReportOutput.Text = report.ToString();
        }

        private void btnClearReport_Click(object sender, EventArgs e)
        {
            cmbReportType.SelectedIndex = -1;
            txtReportStudentId.Clear();
            txtReportOutput.Clear();
            txtReportStudentId.Focus();
        }

        private void btnBackReport_Click(object sender, EventArgs e)
        {
            this.Close();
        }




    }
}
