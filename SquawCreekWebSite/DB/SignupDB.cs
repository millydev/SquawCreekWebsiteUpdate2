using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SquawCreekWebSite.Models;

namespace SquawCreekWebSite.DB
{
    public class SignupDB : DatabaseLayer
    {
        private object firstName;
        private object lastName;
        private object phone;
        private object email;

        public List<Models.Signup> SelectAll()
        {
            string query = "SELECT * FROM customers";


            List<Signup> list = new List<Signup>();


            if (this.OpenDBConnection() == true)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, dbConnection);

                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    dataReader.Close();

                    this.CloseDBConnection();

                }
                catch (MySqlException ex)
                {
                    return list;
                }

                return list;
            }
            return list; 
        }

        public long Insert(Signup ev)
        {
            long newID = -1;

            if (this.OpenDBConnection() == true)
            {
                try
                {
                    MySqlCommand cmd = dbConnection.CreateCommand();
                    cmd.CommandText = "INSERT INTO customers(lastName, firstName, phone, email) VALUES(@lastName, @firstName, @phone, @email)";
                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@lastName", lastName);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.ExecuteNonQuery();
                    newID = cmd.LastInsertedId;
                    this.CloseDBConnection();
                    return newID;

                }
                catch (MySqlException ex)
                {
                    return newID;
                }
            }
            else
            {
                return newID;
            }
        }
    }


}