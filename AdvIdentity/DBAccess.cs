using AdvIdentity.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdvIdentity
{
    public class DBAccess
    {
        MySqlConnection Connection;
        string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public DBAccess()
        {
            Connection = new MySqlConnection(ConnectionString);
            Connection.Open();
        }
        public IEnumerable<UsersViewModel> GetAllUsers()
        {
            List<UsersViewModel> users = new List<UsersViewModel>();
            MySqlCommand command = new MySqlCommand
            {
                CommandText = String.Format("SELECT Email, PhoneNumber, Name, Surname, Id FROM users"),
                Connection = Connection
            };        
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while(reader.Read())
                    {
                        UsersViewModel user = new UsersViewModel();
                        user.Email = reader.GetString(0);
                        user.Phone = reader.GetString(1);
                        user.Name = reader.GetString(2);
                        user.Surname = reader.GetString(3);
                        user.ID = reader.GetString(4);
                        users.Add(user);
                    }
                    return users;
                }
                else
                {
                    throw new Exception("No Entries in database");
                }
            }
        }
        public IEnumerable<AdvertisementsViewModel> GetAllAdv()
        {
            List<AdvertisementsViewModel> ads = new List<AdvertisementsViewModel>();
            MySqlCommand command = new MySqlCommand
            {
                CommandText = String.Format("SELECT * FROM advertisements"),
                Connection = Connection
            };
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        AdvertisementsViewModel adv = new AdvertisementsViewModel();
                        adv.CreatorId = reader.GetString(0);
                        adv.AdvId = reader.GetUInt32(1);
                        adv.Type = reader.GetString(2);
                        adv.Description = reader.GetString(3);
                        adv.Price = reader.GetInt32(4);
                        ads.Add(adv);
                    }
                    return ads;
                }
                else
                {
                    throw new Exception("No Advertisement Created!");
                }
            }
        }
        public void CreateAdv(AdvertisementsCreateModel adv)
        {
            MySqlCommand command = new MySqlCommand
            {
                CommandText = String.Format("INSERT INTO advertisements (CreatorId, Type, Description, Price) VALUES('{0}','{1}','{2}','{3}')", 
                        adv.CreatorId, adv.Type, adv.Description, adv.Price),
                Connection = Connection
            };
            using (Connection)
            {
                command.ExecuteNonQuery();
            }
        }
        public IEnumerable<AdvertisementsViewModel> GetCreatorsAds(string creatorId)
        {
            List<AdvertisementsViewModel> ads = new List<AdvertisementsViewModel>();
            MySqlCommand command = new MySqlCommand
            {
                CommandText = String.Format("SELECT * FROM advertisements WHERE CreatorId = '{0}'", creatorId),
                Connection = Connection
            };
            using (Connection)
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            AdvertisementsViewModel adv = new AdvertisementsViewModel();
                            adv.CreatorId = reader.GetString(0);
                            adv.AdvId = reader.GetUInt32(1);
                            adv.Type = reader.GetString(2);
                            adv.Description = reader.GetString(3);
                            adv.Price = reader.GetInt32(4);
                            ads.Add(adv);
                        }
                        return ads;
                    }
                    else
                    {
                        throw new Exception("User not created any advertisements!");
                    }
                } 
            }
        }
        public void UpdateAd(AdvertisementsCreateModel adv)
        {
            MySqlCommand command = new MySqlCommand
            {
                CommandText = String.Format("UPDATE advertisements SET Type = '{0}', Description = '{1}' Price = '{2}' WHERE AdvId = '{3}'", adv.Type, adv.Description, adv.Price, adv.AdvId),
                Connection = Connection
            };
        }
        public UsersViewModel GetUserById(string advId)
        {
            UsersViewModel user = new UsersViewModel();
            MySqlCommand command = new MySqlCommand
            {
                CommandText = String.Format("SELECT Email, PhoneNumber, Name, Surname, Id FROM users WHERE Id = '{0}'", advId),
                Connection = Connection
            };
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        user.Email = reader.GetString(0);
                        user.Phone = reader.GetString(1);
                        user.Name = reader.GetString(2);
                        user.Surname = reader.GetString(3);
                        user.ID = reader.GetString(4);
                    }
                    return user;
                }
                else
                {
                    throw new Exception("No such User!");
                }
            }
        }
    }
}