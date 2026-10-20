using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRG272_Project.PresentationLayer
{
    public partial class frmManageAnimals: Form
    {
        public frmManageAnimals()
        {
            InitializeComponent();

            SetupGridColumns();

            LoadAnimalData();
        }

        private void SetupGridColumns()
        {
            dgvAnimals.ReadOnly = true;
            dgvAnimals.AllowUserToAddRows = false;
            dgvAnimals.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAnimals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAnimals.MultiSelect = false;

            dgvAnimals.Columns.Add("AnimalID", "Animal ID");
            dgvAnimals.Columns.Add("Name", "Name");
            dgvAnimals.Columns.Add("Species", "Species");
            dgvAnimals.Columns.Add("Age", "Age");
            dgvAnimals.Columns.Add("RecoveryScore", "Recovery Score");
            dgvAnimals.Columns.Add("Status", "Status");
            dgvAnimals.Columns.Add("HousingUnit", "Housing Unit");
        }

        private void LoadAnimalData()
        {
            string fileName = "animals.txt";
            string filePath = null;

            try
            {
                // Checks the main project root folder first
                var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var parentDir = Directory.GetParent(baseDirectory);

                if (parentDir != null && parentDir.Parent != null)
                {
                    string projectRootPath = Path.Combine(parentDir.Parent.FullName, fileName);
                    if (File.Exists(projectRootPath))
                    {
                        filePath = projectRootPath;
                    }
                }

                // Fallback: Check standard directory traversal if not in root folder
                if (filePath == null || !File.Exists(filePath))
                {
                    var currentDir = new DirectoryInfo(baseDirectory);
                    while (currentDir != null)
                    {
                        string candidatePath = Path.Combine(currentDir.FullName, fileName);
                        
                        if (!candidatePath.Contains("\\bin\\") && !candidatePath.Contains("\\obj\\") && File.Exists(candidatePath))
                        {
                            filePath = candidatePath;
                            break;
                        }
                        currentDir = currentDir.Parent;
                    }
                }

                if (filePath == null || !File.Exists(filePath))
                {
                    MessageBox.Show(
                        "The animals.txt file could not be found in the project root directory.",
                        "File Not Found",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                dgvAnimals.Rows.Clear();
                string[] allLines = File.ReadAllLines(filePath);

                foreach (string line in allLines)
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    string[] parts = line.Split('|');

                    if (parts.Length >= 7)
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
                MessageBox.Show(
                    "Error loading animal records: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
