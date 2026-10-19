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
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    string[] details = line.Split('|');

                    if (details.Length == 7)
                        dgvAnimals.Rows.Add(details);
                }
            }
            catch (IOException ex)
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
