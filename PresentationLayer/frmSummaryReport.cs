using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRG272_Project
{
    public partial class frmSummaryReport : Form
    {
        public frmSummaryReport()
        {
            InitializeComponent();

            GenerateAndDisplaySummary();

            ApplyStyling();
        }

        private void ApplyStyling()
        {
            // Form & Layout Colors
            this.BackColor = Color.FromArgb(245, 247, 245); // Soft off-white
            this.ForeColor = Color.FromArgb(40, 50, 40);     // Dark charcoal
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);

            btnGenerate.BackColor = Color.FromArgb(46, 117, 89); // Forest Green
            btnGenerate.ForeColor = Color.White;
            btnGenerate.FlatStyle = FlatStyle.Flat;
            btnGenerate.FlatAppearance.BorderSize = 0;
            btnGenerate.Cursor = Cursors.Hand;
            btnGenerate.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            
            btnClose.BackColor = Color.FromArgb(220, 224, 220);
            btnClose.ForeColor = Color.FromArgb(50, 60, 50);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Cursor = Cursors.Hand;
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
         
        }

        private void GenerateAndDisplaySummary()
        {
            //reads from the main folder root directoryreads from the main folder
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string filePath = Path.Combine(projectDirectory, "animals.txt");

            int totalAnimals = 0;
            double totalAge = 0;
            double totalScore = 0;

            int countCritical = 0;
            int countSerious = 0;
            int countStable = 0;
            int countRecovering = 0;
            int countReleaseReady = 0;

            try
            {
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);
                    foreach (string line in lines)
                    {
                        if (string.IsNullOrWhiteSpace(line)) continue;

                        string[] parts = line.Split('|');
                        if (parts.Length == 7)
                        {
                            if (int.TryParse(parts[3].Trim(), out int age) &&
                                int.TryParse(parts[4].Trim(), out int score))
                            {
                                totalAnimals++;
                                totalAge += age;
                                totalScore += score;

                                string status = parts[5].Trim();

                                switch (status.ToLower())
                                {
                                    case "critical":
                                        countCritical++;
                                        break;
                                    case "serious":
                                        countSerious++;
                                        break;
                                    case "stable":
                                        countStable++;
                                        break;
                                    case "recovering":
                                        countRecovering++;
                                        break;
                                    case "release-ready":
                                        countReleaseReady++;
                                        break;
                                }
                            }
                        }
                    }
                }

                string avgAgeStr = "N/A";
                string avgScoreStr = "N/A";

                if (totalAnimals > 0)
                {
                    double avgAge = totalAge / totalAnimals;
                    double avgScore = totalScore / totalAnimals;
                    avgAgeStr = avgAge.ToString("F2", CultureInfo.InvariantCulture);
                    avgScoreStr = avgScore.ToString("F2", CultureInfo.InvariantCulture);
                }

                // Update UI Labels 
                if (lblTotalAnimalsVal != null) lblTotalAnimalsVal.Text = totalAnimals.ToString();
                if (lblAvgAgeVal != null) lblAvgAgeVal.Text = avgAgeStr;
                if (lblAvgScoreVal != null) lblAvgScoreVal.Text = avgScoreStr;
                if (lblCriticalVal != null) lblCriticalVal.Text = countCritical.ToString();
                if (lblSeriousVal != null) lblSeriousVal.Text = countSerious.ToString();
                if (lblStableVal != null) lblStableVal.Text = countStable.ToString();
                if (lblRecoveringVal != null) lblRecoveringVal.Text = countRecovering.ToString();
                if (lblReleaseReadyVal != null) lblReleaseReadyVal.Text = countReleaseReady.ToString();

                // Export to summary.txt in the project root directory
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);

                List<string> summaryLines = new List<string>
                {
                    "BAOBAB RIDGE WILDLIFE REHABILITATION CENTRE",
                    "ANIMAL SUMMARY REPORT",
                    $"Generated: {timestamp}",
                    "Total animals:",
                    totalAnimals.ToString(),
                    "Average age (years):",
                    avgAgeStr,
                    "Average recovery score:",
                    avgScoreStr,
                    "Animals per status:",
                    "Critical:",
                    countCritical.ToString(),
                    "Serious:",
                    countSerious.ToString(),
                    "Stable:",
                    countStable.ToString(),
                    "Recovering:",
                    countRecovering.ToString(),
                    "Release-Ready:",
                    countReleaseReady.ToString()
                };

                string summaryFilePath = Path.Combine(projectDirectory, "summary.txt");
                File.WriteAllLines(summaryFilePath, summaryLines);

                MessageBox.Show("Summary report successfully generated and exported to summary.txt.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IOException ioEx)
            {
                MessageBox.Show($"File error while generating summary: {ioEx.Message}", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException uaEx)
            {
                MessageBox.Show($"Permission denied: {uaEx.Message}", "Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 mainMenuForm = new Form1();
            mainMenuForm.ShowDialog();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            GenerateAndDisplaySummary();
        }
    }
}
