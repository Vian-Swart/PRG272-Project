using System;
using System.Windows.Forms;
using PRG272_Project.BusinessLayer;
using PRG272_Project.DataLayer;

namespace PRG272_Project
{// begin namespace

    public partial class frmAddAnimal : Form
    {// begin public partial class

        public frmAddAnimal()
        {// begin constructor

            InitializeComponent();

        }// end constructor

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
                MessageBox.Show("Age must be a valid integer.","Validation Error",
                    MessageBoxButtons.OK,MessageBoxIcon.Warning);

                txtAnimal_Age.Focus();

                return;
            }// end

            if (!int.TryParse(
                txtAnimal_Recovery_Score.Text.Trim(),
                out recoveryscore))
            {// begin 
                MessageBox.Show ("Recovery Score must be a valid integer.","Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtAnimal_Recovery_Score.Focus();

                return;
            }// end 

            // Create Animal Object

            Animal animal = new Animal(animalID, animalName, species, age, recoveryscore, "","");

            // Business Layer Validation

            if (!animal.ValidateAnimalID())
            {// begin
                MessageBox.Show("Animal ID must be in the format WR-XXXX where X represents a number.","Validation Error",
                    MessageBoxButtons.OK,MessageBoxIcon.Warning);

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
                MessageBox.Show("Species is invalid.","Validation Error",
                    MessageBoxButtons.OK,MessageBoxIcon.Warning);

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

            // Check For Duplicate Animal ID

            if (animalDAL.AnimalIDExists(animal.AnimalID))
            {// begin
                MessageBox.Show("Animal ID already exists.", "Duplicate Record",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtAnimal_ID.Focus();

                return;
            }// end 

            // Calculate Status And Housing Unit

            animal.CalculateStatusAndHousing();

            // Display Calculated Values

            txt_Animal_Status.Text = animal.Status;

            txt_Housing_Unit.Text = animal.Housingunit;

            // Save Animal

            if (animalDAL.AddAnimal(animal))
            {// begin
                MessageBox.Show("Animal added successfully.", "Success",
                    MessageBoxButtons.OK,MessageBoxIcon.Information);

                ClearFields();
            }// end 
            else
            {// begin
                MessageBox.Show("Animal could not be added to the text file.","Error",
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