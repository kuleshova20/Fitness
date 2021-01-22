using System;


namespace Fitness.BL.Model
{
    [Serializable]
    public class User
    {
        #region Свойства
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gender.
        /// </summary>
        public Gender Gender { get; }

        /// <summary>
        /// BirthDate.
        /// </summary>
        public DateTime BirthDate { get; }

        /// <summary>
        /// Weight.
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Height.
        /// </summary>
        public double Height { get; set; }
        #endregion

        /// <summary>
        /// Create new user.
        /// </summary>
        /// <param name="name"> Name. </param>
        /// <param name="gender"> Gender. </param>
        /// <param name="birthDate"> BirthDate. </param>
        /// <param name="weight"> Weight. </param>
        /// <param name="height"> Height. </param>
        public User(string name, 
                    Gender gender, 
                    DateTime birthDate, 
                    double weight, 
                    double height)
        {
            #region Checking conditions
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name of user can't be empty or null.", nameof(name));
            }

            if (gender == null)
            {
                throw new ArgumentNullException("Gender can't be empty or null.", nameof(gender));
            }

            if(birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Impossible birthDate.", nameof(birthDate));
            }

            if (weight <= 0)
            {
                throw new ArgumentException("Weight can't be less or equal of null.", nameof(weight));
            }

            if (height <= 0)
            {
                throw new ArgumentException("Height can't be less or equal of null.", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;

        }
      
        public override string ToString()
        {
            return Name;
        }


    }
}
