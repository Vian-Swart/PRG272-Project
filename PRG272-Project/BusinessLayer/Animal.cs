using System;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PRG272_Project.BusinessLayer
{// begin namesapce 
     public class Animal
    {// begin class animal 

        // Variables for the AddAnimal function
        private string animalID;
        private string animalName;
        private string species;
        private int age;
        private int recoveryscore;
        private string status;
        private string housingunit;

        // Encapsulation of the variables 

        public string AnimalID { get => animalID; set => animalID = value; }
        public string AnimalName { get => animalName; set => animalName = value; }
        public string Species { get => species; set => species = value; }
        public int Age { get => age; set => age = value; }
        public int Recoveryscore { get => recoveryscore; set => recoveryscore = value; }
        public string Status { get => status; set => status = value; }
        public string Housingunit { get => housingunit; set => housingunit = value; }

        public Animal(string AnimalID, string AnimalName, string Species, int Age, int Recoveryscore, string Status, string Housingunit)
        {// begin constructor

            animalID = AnimalID;
            animalName = AnimalName;
            species = Species;
            age = Age;
            recoveryscore = Recoveryscore;
            status = Status;
            housingunit = Housingunit;

        }// end constructor 

        // Validate Animal ID
        public bool ValidateAnimalID()
        {// begin 
            if (string.IsNullOrWhiteSpace(animalID))
            { // begin
                return false;
            }// end 

            if (!Regex.IsMatch(animalID, @"^WR-\d{4}$"))
            {// begin 
                return false;
            }// end 

            return true;
        }// end 

        // Validate Animal Name

        public bool ValidateAnimalName()
        {// beign 
            if (string.IsNullOrWhiteSpace(animalName))
            {//  begin
                return false;
            }// end 

            if (animalName.Length > 30)
            {// begin 
                return false;
            }// end

            if (animalName.Contains("|"))
            {// begin 
                return false;
            }// end 

            if (!Regex.IsMatch(animalName, @"^[A-Za-z ]+$"))
            {// begin 
                return false;
            }// end

            return true;
        }// end 

        // Validate Species
        public bool ValidateSpecies()
        {// begin 
            if (string.IsNullOrWhiteSpace(species))
            {// begin
                return false;
            }// end 

            if (species.Length > 30)
            {// begin 
                return false;
            }// end 

            if (species.Contains("|"))
            {// begin 
                return false;
            }// end 

            if (!Regex.IsMatch(species, @"^[A-Za-z ]+$"))
            {// begin 
                return false;
            }// end 

            return true;
        }// end 

        // Validate Age
        public bool ValidateAge()
        {// beign
            if (age < 0 || age > 100)
            {// begin
                return false;
            }// end 

            return true;
        }// end 

        // Validate Recovery Score

        public bool ValidateRecoveryScore()
        {// begin 
            if (recoveryscore < 0 || recoveryscore > 100)
            {// begin
                return false;
            }// end 

            return true;
        }// end 

        // Calculate Status And Housing Unit

        public void CalculateStatusAndHousing()
        {// begin
            if (recoveryscore <= 19)
            {// begin
                status = "Critical";
                housingunit = "Intensive Care Unit";
            }// end 
            else if (recoveryscore <= 39)
            {// begin
                status = "Serious";
                housingunit = "High-Dependency Ward";
            }// end 
            else if (recoveryscore <= 59)
            {// begin
                status = "Stable";
                housingunit = "Recovery Ward";
            }// end 
            else if (recoveryscore <= 79)
            {// begin
                status = "Recovering";
                housingunit = "Outdoor Enclosure";
            }// end 
            else
            {// begin
                status = "Release-Ready";
                housingunit = "Pre-Release Camp";
            }// end 
        }// end 

        // Validate Entire Animal Record

        public bool ValidateAnimal()
        {// begin
            return ValidateAnimalID() && ValidateAnimalName() && ValidateSpecies() && ValidateAge() && ValidateRecoveryScore();
        }// end 


    }// end class animal 
}// end namespace 
