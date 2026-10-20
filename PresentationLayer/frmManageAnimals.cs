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
            string filePath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "animals.txt");

            if (!File.Exists(filePath))
            {
                MessageBox.Show(
                    "animals.txt could not be found.",
                    "File Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                dgvAnimals.Rows.Clear();

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
                MessageBox.Show(
                    "Please select an animal from the grid first.",
                    "No Animal Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            string[] animalDetails = new string[7];

            for (int i = 0; i < 7; i++)
            {
                animalDetails[i] =
                    Convert.ToString(
                        dgvAnimals.SelectedRows[0].Cells[i].Value);
            }

            using (frmAddAnimal editForm = new frmAddAnimal(animalDetails))
            {
                editForm.ShowDialog();
            }

            LoadAnimalData();
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAnimals.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select an animal to delete.",
                    "No Animal Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string animalID = Convert.ToString(
                dgvAnimals.SelectedRows[0].Cells[0].Value);

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete animal " + animalID + "?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            PRG272_Project.DataLayer.AnimalDataAccessLayer animalDAL =
                new PRG272_Project.DataLayer.AnimalDataAccessLayer();

            bool deleted = animalDAL.DeleteAnimal(animalID);

            if (deleted)
            {
                MessageBox.Show(
                    "Animal deleted successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadAnimalData();
            }
            else
            {
                MessageBox.Show(
                    "The animal could not be deleted.",
                    "Delete Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


    }
}
