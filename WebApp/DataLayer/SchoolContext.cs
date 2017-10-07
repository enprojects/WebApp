using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.DataLayer
{
    public class SchoolContext : DbContext
    {
        // Cretae context etc
        //Enable-Migrations
        //Add-Migration InitialModel (Initial migration)
        //Update-Databas -force (from "no database" to having a database that matches your current model.)
        
         //Add miration foreach change
         //Update-Database 
        public SchoolContext() :base("studentSchool")
        {

        }
        public DbSet<Student> Students {get; set;} 
    }
}