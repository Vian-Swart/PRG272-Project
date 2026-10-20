using System;
using System.Windows.Forms;
using PRG272_Project.BusinessLayer;
using PRG272_Project.DataLayer;

namespace PRG272_Project
{// begin namespace

    public partial class frmAddAnimal : Form
    {// begin public partial class

        private bool isEditMode = false;
        private string originalAnimalID = "";

        public frmAddAnimal()
        {// begin constructor

            InitializeComponent();
            isEditMode = false;

            // Automatically generate the next Animal ID
            AnimalDataAccessLayer animalDAL = new AnimalDataAccessLayer();
            txtAnimal_ID.Text = animalDAL.GetNextAnimalID();
            txtAnimal_ID.Enabled = false; // Lock the ID field so it cannot be changed

        }// end constructor

        public frmAddAnimal(string id, string name, string species, int age, int score)
        {
            InitializeComponent();
            isEditMode = true;
            originalAnimalID = id;

            // Pre-fill textboxes with selected row data
            txtAnimal_ID.Text = id;
            txtAnimal_ID.Enabled = false; // Prevent modifying ID
            txtAnimal_Name.Text = name;
            txtAnimal_Species.Text = species;
            txtAnimal_Age.Text = age.ToString();
            txtAnimal_Recovery_Score.Text = score.ToString();

            // Display calculated values
            Animal tempAnimal = new Animal(id, name, species, age, score, "", "");
            tempAnimal.CalculateStatusAndHousing();
            txt_Animal_Status.Text = tempAnimal.Status;
            txt_Housing_Unit.Text = tempAnimal.Housingunit;
        }

        private void ClearFields()
        {// begin method ClearFields

            txtAnimal_ID.Clear();
            txtAnimal_Name.Clear();
            txtAnimal_Species.Clear();
            txtAnimal_Age.Clear();
            txtAnimal_Recovery_Score.Clear();
            txt_Animal_Status.Clear();
            txt_Housing_Unit.Clear();

            txtAnimal_ID.Focus();

        }// end method ClearFields

        private void frmAddAnimal_Load(object sender, EventArgs e)
        {// begin form load

            txt_Animal_Status.ReadOnly = true;
            txt_Housing_Unit.ReadOnly = true;

        }// end form load

        private void btnSave_Click(object sender, EventArgs e)
        {// begin save button

            string animalID = txtAnimal_ID.Text.Trim().ToUpper();

            string animalName = txtAnimal_Name.Text.Trim();

            string species = txtAnimal_Species.Text.Trim();

            int age;
            int recoveryscore;

            if (!int.TryParse(
                txtAnimal_Age.Text.Trim(),
                out age))
            {// begin
                MessageBox.Show("Age must be a valid integer.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtAnimal_Age.Focus();

                return;
            }// end

            if (!int.TryParse(
                txtAnimal_Recovery_Score.Text.Trim(),
                out recoveryscore))
            {// begin 
                MessageBox.Show("Recovery Score must be a valid integer.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtAnimal_Recovery_Score.Focus();

                return;
            }// end 

            // Create Animal Object

            Animal animal = new Animal(animalID, animalName, species, age, recoveryscore, "", "");

            // Business Layer Validation

            if (!animal.ValidateAnimalID())
            {// begin
                MessageBox.Show("Animal ID must be in the format WR-XXXX where X represents a number.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtAnimal_ID.Focus();

                return;
            }// end 

            if (!animal.ValidateAnimalName())
            {// begin
                MessageBox.Show("Animal Name is invalid.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtAnimal_Name.Focus();

                return;
            }// end 

            if (!animal.ValidateSpecies())
            {// begin
                MessageBox.Show("Species is invalid.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtAnimal_Species.Focus();

                return;
            }// end 

            if (!animal.ValidateAge())
            {//begin
                MessageBox.Show("Age must be between 0 and 100.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtAnimal_Age.Focus();

                return;
            }// end 

            if (!animal.ValidateRecoveryScore())
            {//begin 
                MessageBox.Show("Recovery Score must be between 0 and 100.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtAnimal_Recovery_Score.Focus();

                return;
            }// end 

            // Create Data Layer Object

            AnimalDataAccessLayer animalDAL = new AnimalDataAccessLayer();

            // Check For Duplicate Animal ID (Only when adding a new record)
            if (!isEditMode)
            {
                if (animalDAL.AnimalIDExists(animal.AnimalID))
                {// begin
                    MessageBox.Show("Animal ID already exists.", "Duplicate Record",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    txtAnimal_ID.Focus();

                    return;
                }// end 
            }

            // Calculate Status And Housing Unit

            animal.CalculateStatusAndHousing();

            // Display Calculated Values

            txt_Animal_Status.Text = animal.Status;

            txt_Housing_Unit.Text = animal.Housingunit;

            // Save Animal (Handle Edit vs Add)

            bool success = false;

            if (isEditMode)
            {
                success = animalDAL.UpdateAnimal(originalAnimalID, animal);
            }
            else
            {
                success = animalDAL.AddAnimal(animal);
            }

            if (success)
            {// begin
                MessageBox.Show(isEditMode ? "Animal updated successfully." : "Animal added successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (isEditMode)
                {
                    // If updating, return directly to the manage page
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    // If adding a new record, go back to the main page
                    Form1 frmMain = new Form1();
                    frmMain.Show();
                    this.Close();
                }
            }// end 
            else
            {// begin
                MessageBox.Show("Animal could not be saved to the text file.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }// end

        }// end save button

        private void btnClear_Click(object sender, EventArgs e)
        {// begin 
            ClearFields();
        }// end 

        private void btnBackToMain_Click(object sender, EventArgs e)
        {// begin 
            this.Hide();

            Form1 frmMain =
                new Form1();

            frmMain.ShowDialog();
        }//end 
    }// end partial class

}// end namespace