﻿using System.Data.SQLite;

namespace TPP3.Models
{
    public class Personal_info
    {
        public List<Person> GetAllPerson()
        {

            List<Person> Persons = new List<Person>();



            SQLiteConnection con = new SQLiteConnection(@"Data Source=C:\Users\sourour\Downloads\2022 GL3 .NET Framework TP3 - SQLite database.db");

            con.Open();
            Console.WriteLine("connection opened");
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM personal_info", con);
            SQLiteDataReader reader = command.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    int id = (int)reader["id"];
                    string firstName = (string)reader["first_name"];
                    string lastName = (string)reader["last_name"];
                    string email = (string)reader["email"];

                    string image = (string)reader["image"];
                    string country = (string)reader["country"];
                    Persons.Add(new Person(id, firstName, lastName, email, image, country));
                }
                return Persons;

            }




        }
        public Person GetPerson(int id)
        {
            List<Person> list = GetAllPerson();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Id == id)
                {
                    return list[i];
                }
            }
            return null;

        }
    }
}
