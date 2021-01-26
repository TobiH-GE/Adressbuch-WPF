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
        public bool SaveContactToDatabase(Contact saveContact)
        {
            SQLiteConnectionStringBuilder builder = new();
            builder.Version = 3;
            builder.DataSource = "Contacts.db";
            if (!File.Exists(builder.DataSource))
            {
                using (SQLiteConnection connection = new (builder.ToString()))
                {
                    connection.Open(); // Open erstellt automatisch die Datenbank wenn sie nicht da ist, es fehlen nur die Tabellen.
                    SQLiteCommand command = connection.CreateCommand();
                    command.CommandText = "create table Contacts (ID integer not null primary key, forename varchar(25) not null, lastname varchar(25) not null, street varchar(25) not null, town varchar(25) not null, country varchar(25) not null, email varchar(25) not null, facebook varchar(25) not null, instagram varchar(25) not null, twitter varchar(25) not null, xing varchar(25) not null)";
                    command.ExecuteNonQuery();
                }
            }

            using (SQLiteConnection connection = new(builder.ToString()))
            {
                connection.Open();
                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = "replace into Contacts (forename, lastname, street, town, country, email, facebook, instagram, twitter, xing) values (@forename, @lastname, @street, @town, @country, @email, @facebook, @instagram, @twitter, @xing);";
                command.Parameters.AddWithValue("@forename", saveContact.ForeName);
                command.Parameters.AddWithValue("@lastname", saveContact.LastName);
                command.Parameters.AddWithValue("@street", saveContact.Street);
                command.Parameters.AddWithValue("@town", saveContact.Town);
                command.Parameters.AddWithValue("@country", saveContact.Country);
                command.Parameters.AddWithValue("@email", saveContact.EMail);
                command.Parameters.AddWithValue("@facebook", saveContact.Facebook);
                command.Parameters.AddWithValue("@instagram", saveContact.Instagram);
                command.Parameters.AddWithValue("@twitter", saveContact.Twitter);
                command.Parameters.AddWithValue("@xing", saveContact.Xing);

                int linesAffected = command.ExecuteNonQuery();
                if (linesAffected == 0)
                {
                    return false;
                }
            }
            return true;
        }
        public List<Contact> LoadContactsDatabase()
        {
            List<Contact> newContactsList = new List<Contact>();

            SQLiteConnectionStringBuilder builder = new();
            builder.Version = 3;
            builder.DataSource = "Contacts.db"; //TODO: Fehlerbehandlung verbessern

            if (!File.Exists(builder.DataSource))
            {
                return newContactsList;
            }

            using (SQLiteConnection connection = new(builder.ToString()))
            {

                connection.Open();
                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = "select ID, forename, lastname, street, town, country, email, facebook, instagram, twitter, xing from Contacts";

                using (SQLiteDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.KeyInfo))
                {
                    while (reader.Read())
                    {
                        newContactsList.Add(new Contact()
                        {
                            ID = reader.GetInt32(0),
                            ForeName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Street = reader.GetString(3),
                            Town = reader.GetString(4),
                            Country = reader.GetString(5),
                            EMail = reader.GetString(6),
                            Facebook = reader.GetString(7),
                            Instagram = reader.GetString(8),
                            Twitter = reader.GetString(9),
                            Xing = reader.GetString(10)
                        });
                    }
                }
            }
            return newContactsList;
        }
        public bool ModifyContactInDatabase(Contact saveContact)
        {
            SQLiteConnectionStringBuilder builder = new();
            builder.Version = 3;
            builder.DataSource = "Contacts.db"; // TODO: Fehlerbehandlung

            using (SQLiteConnection connection = new(builder.ToString()))
            {
                connection.Open();
                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = "replace into Contacts (ID, forename, lastname, street, town, country, email, facebook, instagram, twitter, xing) values (@id, @forename, @lastname, @street, @town, @country, @email, @facebook, @instagram, @twitter, @xing);";
                command.Parameters.AddWithValue("@id", saveContact.ID);
                command.Parameters.AddWithValue("@forename", saveContact.ForeName);
                command.Parameters.AddWithValue("@lastname", saveContact.LastName);
                command.Parameters.AddWithValue("@street", saveContact.Street);
                command.Parameters.AddWithValue("@town", saveContact.Town);
                command.Parameters.AddWithValue("@country", saveContact.Country);
                command.Parameters.AddWithValue("@email", saveContact.EMail);
                command.Parameters.AddWithValue("@facebook", saveContact.Facebook);
                command.Parameters.AddWithValue("@instagram", saveContact.Instagram);
                command.Parameters.AddWithValue("@twitter", saveContact.Twitter);
                command.Parameters.AddWithValue("@xing", saveContact.Xing);

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
