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

                cmd.CommandText = "INSERT INTO bug (Titel, Description, Priority) VALUES (@Param1, @Param2, @Param3);";

                //Skickar in värden
                cmd.Parameters.AddWithValue("@Param1", bug.Title);
                cmd.Parameters.AddWithValue("@Param2", bug.Description);
                cmd.Parameters.AddWithValue("@Param3", bug.Priority);
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
                cmd.CommandText = "SELECT * FROM bug;";
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
                        //Lägger till objektet i en lista
                        buglist.Add(b);
                    }
                    cmd.Connection.Close();
                }
            }
            return buglist;
       }

    }
}
