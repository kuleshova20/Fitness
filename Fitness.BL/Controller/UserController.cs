using Fitness.BL.Model;
using System;
using System.IO;
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
        public User User { get; }

        /// <summary>
        /// Create new user's controller.
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName, string genderName, DateTime birthDay, double weight, double height)
        {
            // TODO: cheking
            var gender = new Gender(genderName);
            this.User = new User(userName, gender, birthDay, weight, height);
        }

        /// <summary>
        /// Get user's data.
        /// </summary>
        /// <returns> User of application. </returns>
        public UserController()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }

                //Todo: What to do, if user didn't read?

            }
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
                formatter.Serialize(fs, User);
            }
        }

        
    }
}
