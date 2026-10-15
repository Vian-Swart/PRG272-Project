using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; // added for file handling

namespace PRG272_Project
{// begin namespace
    public partial class frmAddAnimal : Form
    {// begin partial class
        public frmAddAnimal()
        {// begin constructor   
            InitializeComponent();
        }// end constructor

        // Methods will be added below 
        private void CalculateStatusAndHousing(int recoveryScore, out string status,out string housingUnit)
        {// begin CalculateStatusAndHousing
            if (recoveryScore <= 19)
            {//begin if recovery score is less than or equal to 19
                status = "Critical";
                housingUnit = "Intensive Care Unit";
            }//end if recovery score is less than or equal to 19
            else if (recoveryScore <= 39)
            {// begin else if recovery score is less than or equal to 39
                status = "Serious";
                housingUnit = "High-Dependency Ward";
            }// end else if recovery score is less than or equal to 39
            else if (recoveryScore <= 59)
            {//  begi else if recovery score is less than or equal to 59
                status = "Stable";
                housingUnit = "Recovery Ward";
            }// end else if recovery score is less than or equal to 59
            else if (recoveryScore <= 79)
            {// begin else if recovery score is less than or equal to 79
                status = "Recovering";
                housingUnit = "Outdoor Enclosure";
            }// end else if recovery score is less than or equal to 79
            else
            {// begin else for recovery score greater than 79
                status = "Release-Ready";
                housingUnit = "Pre-Release Camp";
            }// end else for recovery score greater than 79
        }// end CalculateStatusAndHousing

        private void ClearFields()
        {//begin method ClearFields 
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
        {//begin frmAddAnimal_Load
         
            // Satus and Housing unit set to read only as they will be calculated later 
            txt_Animal_Status.ReadOnly = true;
            txt_Housing_Unit.ReadOnly = true;

            if (!File.Exists("animals.txt")) // if file does not exist this creates the textfile 
            {// begin check if file exists
                File.Create("animals.txt").Close();
            }// end check if file exists

        }// end frmAddAnimal_Load
        private void btnSave_Click(object sender, EventArgs e)
        {// begin btn Click Save

            //Variables 
            string animalID = txtAnimal_ID.Text.Trim().ToUpper(); // can we trim to the correct amount of characters?
            string animalName = txtAnimal_Name.Text.Trim();
            string species = txtAnimal_Species.Text.Trim();
            int age;
            int recoveryscore;
            string status = "";
            string housingunit = "";

            // VANIMAL ID VALIDATION

            if (string.IsNullOrWhiteSpace(animalID))
            {// begin if animal ID is empty
                MessageBox.Show("Animal ID cannot be empty as it is required.");
                txtAnimal_ID.Focus();
                return;

            }// end if animal ID is empty

            //CHECK IF THE ANIMAL ID IS IN THE CORRECT FORMAT 

            if (!Regex.IsMatch(animalID, @"^WR-\d{4}$"))
            {// begin if animal ID is not in the correct format
                MessageBox.Show("Animal ID must be in the format WR-XXXX, where XXXX is a 4-digit number for instance WR-0001.");
                txtAnimal_ID.Focus();
                return;
            }// end if animal ID is not in the correct format

            // ANIMAL NAME VALIDATION

            if (string.IsNullOrWhiteSpace(animalName))
            {//begin if animal name is empty
                MessageBox.Show("Animal Name cannot be empty as it is required.");
                txtAnimal_Name.Focus();
                return;
            }//end if animal name is empty

            if (animalName.Length > 30)
            {// begin if animal name is too long
                MessageBox.Show("Animal Name cannot exceed 30 characters.");
                txtAnimal_Name.Focus();
                return;

            }// end if animal name is too long

            //CHECK THAT NAME ONLY CONTAINS ALPHABETIC CHARACTERS AND SPACES

            if (!Regex.IsMatch(animalName, @"^[A-Za-z ]+$"))
            {//begin if animal name contains invalid characters
                MessageBox.Show("Animal Name may only contain letters and spaces.");
                txtAnimal_Name.Focus();
                return;
            }//end if animal name contains invalid characters

            //ANIMAL PIPE CHARACTER VALIDATION

            if (animalName.Contains("|"))
            {// begin if animal name contains pipe character
                MessageBox.Show("Animal Name cannot contain the pipe character '|'.");
                txtAnimal_Name.Focus();
                return;
            }// end if animal name contains pipe character)

            //SPECIES VALIDATION   
            
            if(string.IsNullOrWhiteSpace(species))
            {// begin if species is empty
                MessageBox.Show("Species cannot be empty as it is required.");
                txtAnimal_Species.Focus();
                return;
            }// end if species is empty

            //SPECIES LENGTH VALIDATION

            if(species.Length> 30)
            {// begin if species is too long
                MessageBox.Show("Species cannot exceed 30 characters.");
                txtAnimal_Species.Focus();
                return;
            }// begin if species is too long

            //CHECK THAT SPECIES ONLY CONTAINS ALPHABETIC CHARACTERS AND SPACES
            if (!Regex.IsMatch(species, @"^[A-Za-z ]+$"))
            {//begin if species contains invalid characters
                MessageBox.Show("Species may only contain letters and spaces.");
                txtAnimal_Species.Focus();
                return;
            }//end if species contains invalid characters

            //SPECIES PIPE CHARACTER VALIDATION

            if (species.Contains("|"))
            {// begin if species contains pipe character
                MessageBox.Show("Species cannot contain the pipe character '|'.");
                txtAnimal_Species.Focus();
                return;
            }// end if species contains pipe character

            //AGE VALIDATION    

            if(!int.TryParse(txtAnimal_Age.Text.Trim(), out age))
            {// begin if age is not a valid integer
                MessageBox.Show("Age must be a valid integer.");
                txtAnimal_Age.Focus();
                return;
            }// end if age is not a valid integer)

            //AGE RANGE VALIDATION

            if(age < 0 || age > 100)
            {// begin if age is out of range
                MessageBox.Show("Age must be between 0 and 100.");
                txtAnimal_Age.Focus();
                return;
            }// end if age is out of range


            //RECOVERY SCORE VALIDATION

            if(!int.TryParse(txtAnimal_Recovery_Score.Text.Trim(), out recoveryscore))
            {// begin if recovery score is not a valid integer
                MessageBox.Show("Recovery Score must be a valid integer.");
                txtAnimal_Recovery_Score.Focus();
                return;
            }// end if recovery score is not a valid integer

            //RECOVERY SCORE RANGE VALIDATION

            if (recoveryscore < 0 || recoveryscore > 100)
            {// begin if recovery score is out of range
                MessageBox.Show("Recovery Score must be between 0 and 100.");
                txtAnimal_Recovery_Score.Focus();
                return;
            }// end if recovery score is out of range

            // calling the method to calculate status and housing unit based on recovery score
            CalculateStatusAndHousing(recoveryscore, out status, out housingunit);

            // Display the values in the text boxes
            txt_Animal_Status.Text = status;
            txt_Housing_Unit.Text = housingunit;

        }// end btn Click Save 

        private void btnBackToMain_Click(object sender, EventArgs e)
        {// begin btin click Back to main
            this.Hide();
            Form1 mainMenu = new Form1();
            mainMenu.ShowDialog();

        }// end btn Click Back to main

        private void btnClear_Click(object sender, EventArgs e)
        {// begin btn click Clear
            ClearFields();
        }// end btn click Clear
    }// end partial class
}// end namespace 
