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
            var currentDir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

            while (currentDir != null)
            {
                string candidatePath = Path.Combine(currentDir.FullName, fileName);
                if (File.Exists(candidatePath))
                {
                    filePath = candidatePath;
                    break;
                }
                currentDir = currentDir.Parent;
            }

            if (filePath == null || !File.Exists(filePath))
            {
                MessageBox.Show(
                    "The animals.txt file could not be found anywhere in the project directories.",
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
