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
    public partial class frmManageAnimals : Form
    {
        public frmManageAnimals()
        {
            InitializeComponent();
            dgvAnimals.Dock = DockStyle.Fill;
            SetupGridColumns();
            AddUpdateButton();
            LoadAnimalData();
        }


        private void AddUpdateButton()
        {
            Button btnUpdate = new Button();

            btnUpdate.Name = "btnUpdate";
            btnUpdate.Text = "UPDATE ANIMAL";
            btnUpdate.Height = 40;
            btnUpdate.Dock = DockStyle.Bottom;

            btnUpdate.Click += btnUpdate_Click;

            this.Controls.Add(btnUpdate);
            btnUpdate.BringToFront();
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
    
            string filePath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "animals.txt");
                
                MessageBox.Show("Grid is reading from:\n" + filePath);

            if (!File.Exists(filePath))
            {
                MessageBox.Show("animals.txt could not be found.",
                    "File Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            dgvAnimals.Rows.Clear();

            try
            {
                foreach (string line in File.ReadLines(filePath))
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

                    if (details.Length == 7)
                        dgvAnimals.Rows.Add(details);
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
                MessageBox.Show("Unable to read animal records: " + ex.Message);
            }
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvAnimals.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select an animal from the grid first.",
                    "No Animal Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
                    "Error loading animal records: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            string[] animalDetails = new string[7];

            for (int i = 0; i < 7; i++)
            {
                animalDetails[i] =
                    Convert.ToString(dgvAnimals.SelectedRows[0].Cells[i].Value);
            }

            using (frmAddAnimal editForm = new frmAddAnimal(animalDetails))
            {
                editForm.ShowDialog();
            }

            LoadAnimalData();
        }

    }
}
