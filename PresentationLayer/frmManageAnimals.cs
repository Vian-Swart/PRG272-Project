using PRG272_Project.DataLayer;
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

            SetupGridColumns();
            CreateButtonPanel();
            LoadAnimalData();
        }


        private void CreateButtonPanel()
        {
            Panel buttonPanel = new Panel();

            buttonPanel.Name = "buttonPanel";
            buttonPanel.Height = 50;
            buttonPanel.Dock = DockStyle.Bottom;

            Button btnUpdate = new Button();

            btnUpdate.Name = "btnUpdate";
            btnUpdate.Text = "UPDATE ANIMAL";
            btnUpdate.Width = 150;
            btnUpdate.Dock = DockStyle.Left;
            btnUpdate.Click += btnUpdate_Click;

            Button btnDelete = new Button();

            btnDelete.Name = "btnDelete";
            btnDelete.Text = "DELETE ANIMAL";
            btnDelete.Width = 150;
            btnDelete.Dock = DockStyle.Right;
            btnDelete.Click += btnDelete_Click;

            buttonPanel.Controls.Add(btnUpdate);
            buttonPanel.Controls.Add(btnDelete);

            this.Controls.Add(buttonPanel);
            buttonPanel.BringToFront();

            dgvAnimals.Dock = DockStyle.Fill;
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
            string filePath = "";

            try
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                var directoryInfo = new DirectoryInfo(baseDir);

                string projectDirectory = baseDir;
                while (directoryInfo != null)
                {
                    if (directoryInfo.GetFiles("*.sln").Length > 0 || directoryInfo.GetFiles("*.csproj").Length > 0)
                    {
                        projectDirectory = directoryInfo.FullName;
                        break;
                    }
                    directoryInfo = directoryInfo.Parent;
                }

                filePath = Path.Combine(projectDirectory, "animals.txt");

                dgvAnimals.Rows.Clear();
                string[] allLines = File.ReadAllLines(filePath);

                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                    return;
                }

                foreach (string line in File.ReadLines(filePath))
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    string[] parts = line.Split('|');

                    if (details.Length >= 7)
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
                    "Unable to read animal records: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvAnimals.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an animal record from the grid before clicking update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dgvAnimals.SelectedRows[0];
            string id = selectedRow.Cells["AnimalID"].Value.ToString();
            string name = selectedRow.Cells["Name"].Value.ToString();
            string species = selectedRow.Cells["Species"].Value.ToString();

            int.TryParse(selectedRow.Cells["Age"].Value.ToString(), out int age);
            int.TryParse(selectedRow.Cells["RecoveryScore"].Value.ToString(), out int score);

            frmAddAnimal editForm = new frmAddAnimal(id, name, species, age, score);

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadAnimalData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAnimals.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an animal record from the grid to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dgvAnimals.SelectedRows[0];
            string animalID = selectedRow.Cells["AnimalID"].Value?.ToString();

            if (string.IsNullOrEmpty(animalID)) return;

            DialogResult confirmResult = MessageBox.Show($"Are you sure you want to delete animal record {animalID}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                AnimalDataAccessLayer animalDAL = new AnimalDataAccessLayer();
                if (animalDAL.DeleteAnimal(animalID))
                {
                    MessageBox.Show("Animal record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAnimalData();
                }
                else
                {
                    MessageBox.Show("Failed to delete the animal record from the text file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Form1 frmMain = new Form1();
            frmMain.Show();
            this.Close();
        }
    }
}