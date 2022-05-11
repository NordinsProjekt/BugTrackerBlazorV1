using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace BugTrackerUI
{
    public class Data
    {
       public void SaveBug(Bug bug)
       {
            using (MySqlConnection conn = new MySqlConnection())
            using (MySqlCommand cmd = new MySqlCommand())
            {

                // ensure your connection is set
                conn.ConnectionString = "server=localhost;database=bugtracker;uid=root;pwd=;";
                cmd.Connection = conn;

                cmd.CommandText = "INSERT INTO bug (Titel, Description, Priority, ProjectId) VALUES (@Param1, @Param2, @Param3, @Param4);";

                //Skickar in värden
                cmd.Parameters.AddWithValue("@Param1", bug.Title);
                cmd.Parameters.AddWithValue("@Param2", bug.Description);
                cmd.Parameters.AddWithValue("@Param3", bug.Priority);
                cmd.Parameters.AddWithValue("@Param4", bug.ProjectId);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
       }

       public List<Bug> GetBugs()
       {
            List<Bug> buglist = new List<Bug>();
            using (MySqlConnection conn = new MySqlConnection())
            using (MySqlCommand cmd = new MySqlCommand())
            {

                // ensure your connection is set
                conn.ConnectionString = "server=localhost;database=bugtracker;uid=root;pwd=;";
                cmd.Connection = conn;
                cmd.CommandText = "SELECT bug.*,p.Title FROM bug INNER JOIN projects AS p ON ProjectId = p.Id;";
                cmd.Connection.Open();
                MySqlDataReader myReader;
                using (myReader = cmd.ExecuteReader())
                {
                    //fyler informationen från databasen och lägger det i ett objekt.
                    while (myReader.Read())
                    {
                        Bug b = new Bug();
                        b.Id = myReader.GetInt32(0);
                        b.Title = myReader.GetString(1);
                        b.Description = myReader.GetString(2);
                        b.Priority = myReader.GetInt32(3);
                        b.Created = myReader.GetString(4);
                        b.ProjectId = myReader.GetInt32(5);
                        b.ProjectTitle = myReader.GetString(6);
                        //Lägger till objektet i en lista
                        buglist.Add(b);
                    }
                    cmd.Connection.Close();
                }
            }
            return buglist;
       }

        public List<Project> GetAllProjects()
        {
            List<Project> projects = new List<Project>();
            using (MySqlConnection conn = new MySqlConnection())
            using (MySqlCommand cmd = new MySqlCommand())
            {

                // ensure your connection is set
                conn.ConnectionString = "server=localhost;database=bugtracker;uid=root;pwd=;";
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM projects;";
                cmd.Connection.Open();
                MySqlDataReader myReader;
                using (myReader = cmd.ExecuteReader())
                {
                    //fyler informationen från databasen och lägger det i ett objekt.
                    while (myReader.Read())
                    {
                        Project p = new Project();
                        p.Id = myReader.GetInt32(0);
                        p.Title = myReader.GetString(1);
                        p.Description = myReader.GetString(2);
                        //Lägger till objektet i en lista
                        projects.Add(p);
                    }
                    cmd.Connection.Close();
                }
            }
            return projects;
        }

    }
}
