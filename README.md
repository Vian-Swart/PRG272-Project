# PRG272-Project
Baobab Ridge Wildlife Rehabilitation Records System
-------------------------------------------------------------------------------------------------------------------------------------------------------------
A C# Windows Forms application developed for the PRG2782 Project 2026 module at Belgium Campus.

The Baobab Ridge Wildlife Rehabilitation Records System helps wildlife rehabilitation staff manage animal records, monitor recovery progress, assign housing units, and generate summary reports. The application stores all data using plain text files and follows version control best practices through Git and GitHub.
-------------------------------------------------------------------------------------------------------------------------------------------------------------
Team Members
Name	Student Number
Vian Swart 603351
Ruan Jordaan	603551
Intiesaar Allie 603504
Tshedza Nengovhela 604226

-------------------------------------------------------------------------------------------------------------------------------------------------------------

Project Overview
Baobab Ridge Wildlife Rehabilitation Centre cares for injured and orphaned wild animals until they are ready to return to the wild.

This desktop application replaces manual paperwork and spreadsheets by providing a centralized system to:

Record animal information
Track recovery progress
Automatically calculate rehabilitation status
Automatically assign housing units
Generate management reports
Maintain records using text-file storage

-------------------------------------------------------------------------------------------------------------------------------------------------------------

Technologies Used
C#
.NET 8.0
Windows Forms
Visual Studio 2022
Git
GitHub
UTF-8 Text Files

-------------------------------------------------------------------------------------------------------------------------------------------------------------
Features
Add New Animal
The user can add a new animal by entering:

Animal ID
Name
Species
Age
Recovery Score
The application validates all input before saving and automatically calculates:

Status
Housing Unit
View All Animals
Displays all records in a read-only DataGridView.
Loads data from animals.txt when the application starts.
Refreshes automatically after updates.
Update Animal
Animals can be updated by:

Selecting a row in the DataGridView
Searching by Animal ID
The system recalculates Status and Housing Unit whenever changes are saved.

Delete Animal
Users can delete records by:

Selecting an animal
Confirming the deletion request
Deleted records are permanently removed from the data file.

Generate Summary Report
The application generates:

Total animals
Average age
Average recovery score
Animal count per status category
The report is displayed on the application and saved to a summary.txt file.

Classification Rules
Recovery Score	Status	Housing Unit
0 - 19	Critical	Intensive Care Unit
20 - 39	Serious	High-Dependency Ward
40 - 59	Stable	Recovery Ward
60 - 79	Recovering	Outdoor Enclosure
80 - 100	Release-Ready	Pre-Release Camp
Animal Record Structure
Each animal record contains:

Animal ID
Name
Species
Age
Recovery Score
Status
Housing Unit
Example:

WR-0001|Thabo|African Penguin|4|85|Release-Ready|Pre-Release Camp
File Formats
animals.txt
Stores all animal records.

Format:

ID|Name|Species|Age|Score|Status|Housing Unit
Example:

WR-0001|Thabo|African Penguin|4|85|Release-Ready|Pre-Release Camp
WR-0002|Naledi|Serval|3|62|Recovering|Outdoor Enclosure
WR-0003|Zola|Cape Vulture|12|19|Critical|Intensive Care Unit
Rules:

One record per line
No header row
UTF-8 encoding
Stored in the same directory as the executable
Invalid records are skipped during loading
summary.txt
Generated whenever the user clicks Generate Summary.

Example:

BAOBAB RIDGE WILDLIFE REHABILITATION CENTRE
ANIMAL SUMMARY REPORT
Generated: 2026-10-14 09:32

----------------------------------------
Total animals:            12
Average age (years):      7.75
Average recovery score:   54.00
----------------------------------------

Animals per status:
Critical:                2
Serious:                 2
Stable:                  2
Recovering:              3
Release-Ready:           3
Validation Rules
Animal ID
Required
Format must be WR-####
Exactly 4 digits after WR-
Automatically converted to uppercase
Must be unique
Cannot be edited after creation
Example:

WR-0007
Name
Required
1 to 30 characters
Cannot contain the pipe character (|)
Species
Required
1 to 30 characters
Cannot contain the pipe character (|)
Age
Required
Whole number between 0 and 100
Recovery Score
Required
Whole number between 0 and 100
Error Handling
The system includes exception handling for:

Missing files
Invalid file data
Read-only files
Files currently in use
Unauthorized access
Empty records
Invalid user input
User-friendly error messages are displayed and the application continues running without crashing.

-------------------------------------------------------------------------------------------------------------------------------------------------------------

How to Build and Run
Prerequisites
Install:

Visual Studio 2022 or later
.NET 8.0 SDK
Clone the Repository
git clone https://github.com/your-username/your-repository-name.git
Open the Project
Open the solution file in Visual Studio.

-------------------------------------------------------------------------------------------------------------------------------------------------------------

Build the Project
Build > Build Solution
Run the Application
F5
or click:

Start Debugging
Project Structure
BaobabRidgeWildlifeRehabilitationSystem/
│
├── Models/
│   └── Animal.cs
│
├── Services/
│   ├── FileService.cs
│   └── ClassificationService.cs
│
├── Forms/
│   └── MainForm.cs
│
├── animals.txt
├── README.md
├── .gitignore
└── Program.cs

-------------------------------------------------------------------------------------------------------------------------------------------------------------

Git Workflow
This project follows a feature-branch workflow.

Example branches:

feature/add-animal
feature/view-animals
feature/update-animal
feature/delete-animal
feature/summary-report
Features are developed separately and merged into the main branch using Pull Requests.

Known Limitations
Uses text-file storage rather than a database.
Supports only local, single-user operation.
Corrupted records are skipped during loading.
Summary reports are overwritten each time they are generated.
No cloud synchronization is implemented.
Learning Outcomes
This project demonstrates:

Object-Oriented Programming
Windows Forms Development
File Handling
Data Validation
Exception Handling
Git Version Control
GitHub Collaboration
Software Documentation
License
This project was developed for academic purposes as part of the PRG2782 Programming module at Belgium Campus.

© 2026 Belgium Campus. All rights reserved.
