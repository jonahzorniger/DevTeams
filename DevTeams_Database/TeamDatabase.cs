using DevTeams_POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Database
{
    public class TeamDatabase
    {
        public List<Team> teamDatabase = new List<Team>();
        
        
        
        //Create
        public void AddTeam(Team teamToAdd)
        {
            teamDatabase.Add(teamToAdd);
        }

        //Read
        public Team GetTeam(int teamID)
        {
            foreach(Team currentTeam in teamDatabase)
            {
                if(currentTeam.TeamID == teamID)
                {
                    return currentTeam;
                }
            }
            return null;
        }
        //Update
        public bool UpdateTeam(int teamID, Team inputTeam)
        {
            Team team = GetTeam(teamID);
            if(team != null)
            {
                teamDatabase.Remove(team);
                teamDatabase.Add(inputTeam);
                return true;            
            }
            else
            {
                return false;
            }
            
        }   

        //Delete
        public void RemoveTeam(int inputTeamID)
        {
            foreach (Team currentTeam in teamDatabase)
            {
                if(currentTeam.TeamID == inputTeamID) 
                {
                    teamDatabase.Remove(currentTeam);
                }
            }
        }
    }
        
}
