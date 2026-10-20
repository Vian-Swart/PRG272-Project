using PRG272_Project.BusinessLayer;
using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace PRG272_Project.DataLayer
{// begin namespace

    public class AnimalDataAccessLayer
    {// begin class AnimalDataAccessLayer

        // Variable for text file path

        private string filePath =
    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "animals.txt");

        // Constructor

        public AnimalDataAccessLayer()
        {// begin constructor

            // Check whether the text file exists

            if (!File.Exists(filePath))
            {// begin file exists check

                File.Create(filePath).Close();

            }// end file exists check

        }// end constructor

        // Check If Animal ID Already Exists

        public bool AnimalIDExists(string animalID)
        {// begin method

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {// begin foreach

                string[] data = line.Split('|');

                if (data.Length > 0)
                {// begin if

                    if (data[0].ToUpper() == animalID.ToUpper())
                    {// begin
                        return true;
                    }// end

                }// end if

            }// end foreach

            return false;

        }// end method

        // Add Animal To Text File

        public bool AddAnimal(Animal animal)
        {// begin method
            try
            {// begin try

                string animalRecord = animal.AnimalID + "|" + animal.AnimalName.ToUpper() + "|" + animal.Species.ToUpper() + "|" +
                    animal.Age + "|" + animal.Recoveryscore + "|" + animal.Status.ToUpper() + "|" + animal.Housingunit.ToUpper();

                File.AppendAllText(filePath, animalRecord + Environment.NewLine);

                return true;

            }// end try

            catch
            {// begin catch

                return false;

            }// end catch

        }// end method


        public bool UpdateAnimal(string originalAnimalID, Animal updatedAnimal)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                bool found = false;

                string updatedRecord =
                    updatedAnimal.AnimalID + "|" +
                    updatedAnimal.AnimalName.ToUpper() + "|" +
                    updatedAnimal.Species.ToUpper() + "|" +
                    updatedAnimal.Age + "|" +
                    updatedAnimal.Recoveryscore + "|" +
                    updatedAnimal.Status.ToUpper() + "|" +
                    updatedAnimal.Housingunit.ToUpper();

                for (int i = 0; i < lines.Length; i++)
                {
                    string[] data = lines[i].Split('|');

                    if (data.Length == 7 &&
                        data[0].Equals(originalAnimalID,
                            StringComparison.OrdinalIgnoreCase))
                    {
                        lines[i] = updatedRecord;
                        found = true;
                        break;
                    }
                }

                if (!found)
                    return false;

                File.WriteAllLines(filePath, lines);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Delete Animal From Text File

        public bool DeleteAnimal(string animalID)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                bool found = false;

                List<string> remainingLines = new List<string>();

                foreach (string line in lines)
                {
                    string[] data = line.Split('|');

                    if (data.Length == 7 &&
                        data[0].Equals(animalID,
                            StringComparison.OrdinalIgnoreCase))
                    {
                        found = true;
                    }
                    else
                    {
                        remainingLines.Add(line);
                    }
                }

                if (!found)
                    return false;

                File.WriteAllLines(filePath, remainingLines);
                return true;
            }
            catch
            {
                return false;
            }
        }


    }// end class AnimalDataAccessLayer

}// end namespace