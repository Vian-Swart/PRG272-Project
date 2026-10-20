using System;
using System.IO;
using System.Windows.Forms;

namespace PRG272_Project
{
    public partial class frmViewAnimals : Form
    {
        private string filePath = "animals.txt";

        public frmViewAnimals()
        {
            InitializeComponent();
        }

        private void frmViewAnimals_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvAnimals.Rows.Clear();

            try
            {
                if (!File.Exists(filePath))
                {
                    File.WriteAllText(filePath, "");
                    return;
                }

                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    string[] parts = line.Split('|');

                    if (parts.Length == 7)
                    {
                        dgvAnimals.Rows.Add(
                            parts[0].Trim(),
                            parts[1].Trim(),
                            parts[2].Trim(),
                            parts[3].Trim(),
                            parts[4].Trim(),
                            parts[5].Trim(),
                            parts[6].Trim()
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading file: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
