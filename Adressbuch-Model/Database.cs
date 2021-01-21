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
        public bool SaveAddressToDatabase(Address saveAddress)
        {
            SQLiteConnectionStringBuilder builder = new();
            builder.Version = 3;
            builder.DataSource = "Adressen.db";
            if (!File.Exists(builder.DataSource))
            {
                using (SQLiteConnection connection = new (builder.ToString()))
                {
                    connection.Open(); // Open erstellt automatisch die Datenbank wenn sie nicht da ist, es fehlen nur die Tabellen.
                    SQLiteCommand command = connection.CreateCommand();
                    command.CommandText = "create table Addresses (ID integer not null primary key, forename varchar(25) not null, lastname varchar(25) not null, street varchar(25) not null, town varchar(25) not null, country varchar(25) not null)";
                    command.ExecuteNonQuery();
                }
            }

            using (SQLiteConnection connection = new(builder.ToString()))
            {
                connection.Open();
                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = "replace into Addresses (forename, lastname, street, town, country) values (@forename, @lastname, @street, @town, @country);";
                command.Parameters.AddWithValue("@forename", saveAddress.ForeName);
                command.Parameters.AddWithValue("@lastname", saveAddress.LastName);
                command.Parameters.AddWithValue("@street", saveAddress.Street);
                command.Parameters.AddWithValue("@town", saveAddress.Town);
                command.Parameters.AddWithValue("@country", saveAddress.Country);

                int linesAffected = command.ExecuteNonQuery();
                if (linesAffected == 0)
                {
                    return false;
                }
            }
            return true;
        }
        public List<Address> LoadAddressDatabase()
        {
            SQLiteConnectionStringBuilder builder = new();
            builder.Version = 3;
            builder.DataSource = "Adressen.db"; //TODO: Fehlerbehandlung

            List<Address> newAddressList = new List<Address>();

            using (SQLiteConnection connection = new(builder.ToString()))
            {

                connection.Open();
                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = "select ID, forename, lastname, street, town, country from Addresses";

                using (SQLiteDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.KeyInfo))
                {
                    while (reader.Read())
                    {
                        newAddressList.Add(new Address()
                        {
                            ID = reader.GetInt32(0),
                            ForeName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Street = reader.GetString(3),
                            Town = reader.GetString(4),
                            Country = reader.GetString(5)
                        });
                    }
                }
            }
            return newAddressList;
        }
        public bool ModifyAddressInDatabase(Address saveAddress)
        {
            SQLiteConnectionStringBuilder builder = new();
            builder.Version = 3;
            builder.DataSource = "Adressen.db"; // TODO: Fehlerbehandlung

            using (SQLiteConnection connection = new(builder.ToString()))
            {
                connection.Open();
                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = "replace into Addresses (ID, forename, lastname, street, town, country) values (@id, @forename, @lastname, @street, @town, @country);";
                command.Parameters.AddWithValue("@id", saveAddress.ID);
                command.Parameters.AddWithValue("@forename", saveAddress.ForeName);
                command.Parameters.AddWithValue("@lastname", saveAddress.LastName);
                command.Parameters.AddWithValue("@street", saveAddress.Street);
                command.Parameters.AddWithValue("@town", saveAddress.Town);
                command.Parameters.AddWithValue("@country", saveAddress.Country);

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
