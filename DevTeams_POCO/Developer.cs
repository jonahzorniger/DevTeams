﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_POCO
{
    //Plain Old C# Object
    /*
     * Developers have names and ID numbers;
     * we need to be able to identify one developer without mistaking them for another.
     * We also need to know whether or not they have access to the online learning tool: Pluralsight.
     */
    public class Developer
    {
        public Developer() { }
        public Developer
            (int id,
            string firstName,
            string lastName,
            bool hasPluralSightAccess)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            HasPluralSightAccess = hasPluralSightAccess;
          
        }
        //unique identifier
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool HasPluralSightAccess { get; set; } 
    }
}
