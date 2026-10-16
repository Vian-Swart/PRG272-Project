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
        }

        private void GenerateAndDisplaySummary()
        {

            string filePath = "animals.txt";
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
                lblAvgAgeVal.Text = avgAgeStr;
                lblAvgScoreVal.Text = avgScoreStr;
                lblCriticalVal.Text = countCritical.ToString();
                lblSeriousVal.Text = countSerious.ToString();
                lblStableVal.Text = countStable.ToString();
                lblRecoveringVal.Text = countRecovering.ToString();
                lblReleaseReadyVal.Text = countReleaseReady.ToString();

                // Export to summary.txt
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

                // Navigate up from bin/Debug (or bin/Release) to the main project directory
                string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                string summaryFilePath = Path.Combine(projectDirectory, "summary.txt");

                // Write the lines to the project root folder instead
                File.WriteAllLines(summaryFilePath, summaryLines);

                MessageBox.Show("Summary report successfully generated and exported to summary.txt.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IOException ioEx)
            {
                MessageBox.Show($"File error while generating summary: {ioEx.Message}","File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException uaEx)
            {
                MessageBox.Show($"Permission denied: {uaEx.Message}","Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
