
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PRG272_Project
{
    public class frmManageAnimals : Form
    {
        private DataGridView dgvAnimals;

        public frmManageAnimals()
        {
            Text = "Manage Animals";
            Size = new Size(1000, 450);
            StartPosition = FormStartPosition.CenterScreen;

            dgvAnimals = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false
            };

            dgvAnimals.Columns.Add("AnimalID", "Animal ID");
            dgvAnimals.Columns.Add("Name", "Name");
            dgvAnimals.Columns.Add("Species", "Species");
            dgvAnimals.Columns.Add("Age", "Age");
            dgvAnimals.Columns.Add("RecoveryScore", "Recovery Score");
            dgvAnimals.Columns.Add("Status", "Status");
            dgvAnimals.Columns.Add("HousingUnit", "Housing Unit");

            Controls.Add(dgvAnimals);

            LoadAnimalData();
        }

        private void LoadAnimalData()
        {
            string filePath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "animals.txt"
            );

            if (!File.Exists(filePath))
            {
                MessageBox.Show(
                    "The animals.txt file could not be found.",
                    "File Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            try
            {
                foreach (string line in File.ReadLines(filePath))
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    string[] details = line.Split('|');

                    if (details.Length == 7)
                    {
                        dgvAnimals.Rows.Add(details);
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(
                    "Unable to read animal records: " + ex.Message
                );
            }
        }
    }
}
