using DevTeams_POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Database
{
    public class DeveloperDatabase
    {
        private readonly List<Developer> developerDatabase = new List<Developer>();
        public List<Developer> GetDeveloperDatabase() { 
            return developerDatabase; 
        }

        //Create
        public void AddDeveloper(Developer developerToAdd)
        {
            developerDatabase.Add(developerToAdd);
        }
        
        //Read
        public Developer GetDeveloper(int typedDeveloperID)
        {
            foreach (Developer currentDeveloper in developerDatabase)
            {
                if (currentDeveloper.ID == typedDeveloperID)
                {
                    return currentDeveloper;
                }
            }
            return null;
        }

        //Update
        public bool UpdateDeveloper(int typedDeveloperID, Developer updatedDeveloper)
        {
            Developer oldDeveloper = GetDeveloper(typedDeveloperID);
            if (oldDeveloper != null)
            {
                oldDeveloper.ID = updatedDeveloper.ID;
                oldDeveloper.FirstName = updatedDeveloper.FirstName;
                oldDeveloper.LastName = updatedDeveloper.LastName;
                oldDeveloper.HasPluralSightAccess = updatedDeveloper.HasPluralSightAccess;
                return true;
            }
            else
            {
                return false;
            }
        }
        
        //Delete
        public void DeleteDeveloper(int typedDeveloperID)
        {
            Developer developerToDelete = null;
            foreach (Developer currentDeveloper in developerDatabase)
            {
                if (currentDeveloper.ID == typedDeveloperID)
                {
                    developerToDelete = currentDeveloper;
                }
            }
            if (developerToDelete != null)
            {
                developerDatabase.Remove(developerToDelete);
            }
        }
    }
}
