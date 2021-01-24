using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// User's controller.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// User of application.
        /// </summary>
        public List<User> Users { get; }

        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Create new user's controller.
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("User's name can't be empty", nameof(userName));
            }

            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if(CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }

        /// <summary>
        /// Get saved list of user's data.
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is List<User> users)
                {
                    return users;
                }
                else
                {
                    return new List<User>();
                }
            }
        }

        public void SetNewUserData(string genderName, DateTime birthData, double weight = 1, double height = 1)
        {
            //сделать проверку

            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthData;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }


        /// <summary>
        /// Save user's data.
        /// </summary>
        public void Save()
        {
            //создаем объект BinaryFormatter
            var formatter = new BinaryFormatter();

            //получаем поток, куда будем записывать сериализованный объект
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Users);
            }
        }

        
    }
}
