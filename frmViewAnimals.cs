using System;
using System.IO;
using System.Windows.Forms;

namespace PRG272_Project
{
    public partial class frmViewAnimals : Form
    {
        string textFilePath = Path.Combine(Application.StartupPath, "animals.txt");

        public frmViewAnimals()
        {
            InitializeComponent();
        }

        private void frmViewAnimals_Load(object sender, EventArgs e)
        {
            SetupGridViewColumns();
            LoadAnimalsData();
        }

        private void SetupGridViewColumns()
        {
            dgvAnimals.Columns.Clear();

            dgvAnimals.ReadOnly = true;
            dgvAnimals.AllowUserToAddRows = false;
            dgvAnimals.AllowUserToDeleteRows = false;
            dgvAnimals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAnimals.MultiSelect = false;

            dgvAnimals.Columns.Add("id", "Animal ID");
            dgvAnimals.Columns.Add("name", "Name");
            dgvAnimals.Columns.Add("species", "Species");
            dgvAnimals.Columns.Add("age", "Age");
            dgvAnimals.Columns.Add("score", "Recovery Score");
            dgvAnimals.Columns.Add("status", "Status");
            dgvAnimals.Columns.Add("housing", "Housing Unit");
        }

        public void LoadAnimalsData()
        {
            dgvAnimals.Rows.Clear();
            int skippedCounter = 0;

            try
            {
                if (!File.Exists(textFilePath))
                {
                    File.Create(textFilePath).Close();
                    return;
                }

                string[] allLines = File.ReadAllLines(textFilePath);

                for (int i = 0; i < allLines.Length; i++)
                {
                    string currentLine = allLines[i].Trim();

                    if (currentLine == "")
                    {
                        continue;
                    }

                    string[] dataParts = currentLine.Split('|');

                    if (dataParts.Length != 7)
                    {
                        skippedCounter++;
                        continue;
                    }

                    string id = dataParts[0].Trim().ToUpper();
                    string name = dataParts[1].Trim();
                    string species = dataParts[2].Trim();
                    string ageInput = dataParts[3].Trim();
                    string scoreInput = dataParts[4].Trim();
                    string status = dataParts[5].Trim();
                    string housing = dataParts[6].Trim();

                    if (!id.StartsWith("WR-") || id.Length != 7)
                    {
                        skippedCounter++;
                        continue;
                    }

                    int ageValue;
                    int scoreValue;

                    bool validAge = int.TryParse(ageInput, out ageValue);
                    bool validScore = int.TryParse(scoreInput, out scoreValue);

                    if (!validAge || ageValue < 0 || ageValue > 100)
                    {
                        skippedCounter++;
                        continue;
                    }

                    if (!validScore || scoreValue < 0 || scoreValue > 100)
                    {
                        skippedCounter++;
                        continue;
                    }

                    dgvAnimals.Rows.Add(id, name, species, ageValue, scoreValue, status, housing);
                }

                if (skippedCounter > 0)
                {
                    MessageBox.Show(skippedCounter + " malformed record(s) were skipped.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("The file animals.txt was not found.", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("You do not have permission to access animals.txt.", "Permission Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException)
            {
                MessageBox.Show("The file animals.txt is currently in use by another program.", "IO Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}