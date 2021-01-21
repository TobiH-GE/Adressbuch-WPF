using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Xml.Serialization;

namespace Adressbuch_Model
{
    public class Database
    {
        private bool SaveDatabase(string FileName)
        {
            SQLiteConnectionStringBuilder builder = new();
            builder.Version = 3;
            builder.DataSource = "Adressen.db";
            if (!File.Exists(builder.DataSource))
            {
                using (SQLiteConnection connection = new (builder.ToString()))
                {
                    connection.Open(); // Open erstellt automatisch die datenbank wenn sie nicht da ist, es fehlen nur die tabellen.
                    SQLiteCommand command = connection.CreateCommand();
                    command.CommandText = "create table Addresses (ID integer not null primary key, fname varchar(25) not null, name varchar(25) not null, street varchar(25) not null, town varchar(25) not null, country varchar(25) not null)";
                    command.ExecuteNonQuery();
                }
            }

            using (SQLiteConnection connection = new(builder.ToString()))
            {
                connection.Open();
                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = "replace into Addresses (fname, name, street, town, country) values (@fname, @name, @street, @town, @country);";
                command.Parameters.AddWithValue("@name", FileName);


                int linesAffected = command.ExecuteNonQuery();
                if (linesAffected == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
