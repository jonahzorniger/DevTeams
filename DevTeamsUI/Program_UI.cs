using DevTeams_Database;
using DevTeams_POCO;
using System;
using System.Collections.Generic;
using static System.Console;

namespace DevTeams_UI
{
    public class Program_UI
    {
        private readonly DeveloperDatabase _devDatabase;
        private readonly TeamDatabase _teamDatabase;

        public Program_UI()
        {
            _devDatabase = new DeveloperDatabase();
            _teamDatabase = new TeamDatabase();
        }

        public void Run()
        {
            RunApplication();
        }

        private void RunApplication()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Welcome to DevTeams!\n" +
                   "Please enter a number to perform one of the following: \n\n" + 
                   "1. Add a Developer\n" +
                   "2. View All Existing Developers\n" +
                   "3. View an Existing Developer\n" +
                   "4. Update an Existing Developer\n" +
                   "5. Delete an Existing Developer\n" +
                   "6. Create a team \n" +
                   "7. Add Developer to Team\n" +
                   "8. Remove Developer from Team \n");

                string userInput = ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddADeveloper();
                        break;
                    case"2":
                        ViewExistingDevelopers();
                        break;
                    case "3":
                        ViewExistingDeveloper();
                        break;
                    case "4":
                        UpdateAnExistingDeveloper();
                        break;
                    case "5":
                        DeleteAnExistingDeveloper();
                        break;
                    case "6":
                        CreateATeam();
                        break;
                    case "7":
                        AddDeveloperToTeam();
                        break;
                    case "8":
                        RemoveDeveloperFromTeam();
                        break;
                    default:
                        Console.WriteLine(userInput + " is a invalid input please try again");
                        Console.ReadLine();
                        break;
                }

                Console.WriteLine("Press enter to continue.");
                Console.ReadLine();
                Clear();
            }
        }

        private void RemoveDeveloperFromTeam()
        {
            Console.WriteLine("Please enter the team ID you would like to remove a developer from");
            int teamId = Convert.ToInt32(Console.ReadLine());
            Team team = _teamDatabase.GetTeam(teamId);


            if (team != null)
            {
                Console.WriteLine("Please enter the ID of the developer you would like to remove");
                int devId = Convert.ToInt32(Console.ReadLine());
                Developer developerToRemove= _devDatabase.GetDeveloper(devId);  

                if (developerToRemove != null)
                {
                    team.RemoveDeveloperFromTeam(developerToRemove);
                    _teamDatabase.UpdateTeam(teamId, team);
                }
                else
                {
                    Console.WriteLine("A developer with the ID: " + devId + " does not exist");
                }
            }
            else
            {
                Console.WriteLine("A team with the team ID: " + teamId + " does not exist");
            }
        }

        private void AddDeveloperToTeam()
        {
            Console.WriteLine("Please enter the team ID you would like to add a developer to");
            int teamId = Convert.ToInt32(Console.ReadLine());
            Team team = _teamDatabase.GetTeam(teamId);  


            if(team != null)
            {
                Console.WriteLine("Please enter the ID of the developer you would like to add");
                int devId = Convert.ToInt32(Console.ReadLine());
                Developer developerToAdd = _devDatabase.GetDeveloper(devId);

                if(developerToAdd != null)
                {
                    team.AddDeveloperToTeam(developerToAdd);
                    _teamDatabase.UpdateTeam(teamId, team);
                }
                else
                {
                    Console.WriteLine("A developer with the ID: " + devId + " does not exist");
                }
            }
            else
            {
                Console.WriteLine("A team with the team ID: " + teamId + " does not exist");
            }

        }

        private void CreateATeam()
        {
            Console.WriteLine("You have select to add a new team");
            Console.WriteLine("Please enter the team name");
            string teamName = Console.ReadLine();
            Console.WriteLine("Please enter the team id");
            int teamId = Convert.ToInt32(Console.ReadLine());

            Team teamToAdd = new Team();
            teamToAdd.TeamName = teamName;
            teamToAdd.TeamID = teamId;
            teamToAdd.TeamOfDevelopers = new List<Developer>();

            _teamDatabase.AddTeam(teamToAdd);
        }

        private void DeleteAnExistingDeveloper()
        {
           Console.WriteLine("Please enter a developer ID");
            int inputID = Convert.ToInt32(Console.ReadLine());
            Developer existingDeveloperDelete = _devDatabase.GetDeveloper(inputID);
            if (existingDeveloperDelete != null)
            {
                _devDatabase.DeleteDeveloper(inputID);
                Console.WriteLine("This developer has been deleted");
            }

            else
            {
                Console.WriteLine("This developer does not exist!!");
            }
        }

        private void UpdateAnExistingDeveloper()
        {
            Console.WriteLine("Please enter a developer ID");
            int inputID = Convert.ToInt32(Console.ReadLine());

            
            Console.WriteLine("Please enter a number to perform one of the following: \n\n" +
                "1. Update First Name\n" +
                "2. Update Last Name\n" +
                "3. Update To Plural Sight Access\n");

            string userInput = ReadLine();

            switch (userInput)
            {
                case "1":
                    UpdateFirstName(inputID);
                    break;
                case "2":
                    UpdateLastName(inputID);
                    break;
                case "3":
                    UpdateHasPluralSightAccess(inputID);
                    break;
                default:
                    Console.WriteLine(userInput + " is a invalid input please try again");
                    Console.ReadLine();
                    break;
            }
        }

        private void UpdateFirstName(int userID)
        {
            Console.WriteLine("Please enter the new first name!!!");
            string firstnameinput = ReadLine();
            Developer existingDeveloper = _devDatabase.GetDeveloper(userID);
            existingDeveloper.FirstName = firstnameinput;
            Console.WriteLine("You have updated the first name!! YAY!");
        }

        private void UpdateLastName(int userID)
        {
            Console.WriteLine("Please enter the new last name!!!");
            string lastnameinput = ReadLine();
            Developer existingDeveloper = _devDatabase.GetDeveloper(userID);
            existingDeveloper.LastName = lastnameinput;
            Console.WriteLine("You have updated the last name!! YAY!");
        }

        private void UpdateHasPluralSightAccess(int inputID)
        {
            Console.WriteLine("Please enter the access change!!!");
            string pluralsightaccessinput = ReadLine();
            Developer existingDeveloper = _devDatabase.GetDeveloper(inputID);
            if (pluralsightaccessinput == "yes")
            {
                existingDeveloper.HasPluralSightAccess = true;
            }
            else
            {
                existingDeveloper.HasPluralSightAccess = false;
            }
            Console.WriteLine("You have updated the access of the developer!! YAY!");
        }

        private void ViewExistingDeveloper()
        {
            Console.WriteLine("Please enter a developer ID");
            int inputID = Convert.ToInt32(Console.ReadLine());
           
            Developer existingDeveloper = _devDatabase.GetDeveloper(inputID);

            Console.WriteLine("ID: " + existingDeveloper.ID + " Name: " + existingDeveloper.FirstName + " " + existingDeveloper.LastName + " Plural Sight Access: " + existingDeveloper.HasPluralSightAccess);


        }

        private void ViewExistingDevelopers()
        {
            //Print existing developers to the console
           List<Developer> existingDevelopers = _devDatabase.GetDeveloperDatabase();
            foreach (Developer dev in existingDevelopers)
            {
                Console.WriteLine("ID: " + dev.ID + " Name: " + dev.FirstName + " " + dev.LastName + " Plural Sight Access: " + dev.HasPluralSightAccess);
            }
            
        }

        private void AddADeveloper()
        {
            Console.WriteLine("You have selected to add a developer!");
            Console.WriteLine("Please enter the first name:");
            string firstName = ReadLine();
            Console.WriteLine("Please enter the last name:");
            string lastName = ReadLine();
            Console.WriteLine("Please enter the ID:");
            int id = Convert.ToInt32(ReadLine());
            Console.WriteLine("Please enter if they have PluralSight Access:");
            string accessInput = ReadLine();
            bool hasPluralSightAccess;
            
            if (accessInput == "yes")
            {
                hasPluralSightAccess = true;
            }
            else
            {
                hasPluralSightAccess = false;
            }

            Developer developerToAdd = new Developer(id, firstName, lastName, hasPluralSightAccess);

            _devDatabase.AddDeveloper(developerToAdd);

            Console.WriteLine("You have added a new developer!");
        }
    }
}
