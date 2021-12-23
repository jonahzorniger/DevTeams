using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_POCO
{
    public class Team
    {
        public Team() { }

        public List<Developer> TeamOfDevelopers { get; set; }
        public string TeamName { get; set; }
        public int TeamID { get; set; }

        //To Do:
        //Add developer to TEAM of developers

        public void AddDeveloperToTeam(Developer developerToAdd)
        {
            TeamOfDevelopers.Add(developerToAdd);
        }

        //To Do:
        //Remove developer from TEAM of developers
       public void RemoveDeveloperFromTeam(Developer developerToDelete)
        {
            TeamOfDevelopers.Remove(developerToDelete);
        }

        public List<Developer> GetAllDevelopers()
        {
            return TeamOfDevelopers;
        }
    }

}
