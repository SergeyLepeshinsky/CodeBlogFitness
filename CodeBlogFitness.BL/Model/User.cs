using System;


namespace CodeBlogFitness.BL.Model
{
    /// <summary>
    /// Пользователь. 
    /// </summary>
    [Serializable]  // выставленный атрибут указывает, что класс является сериализуемым  
    public class User
    {
        #region Свойства
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; }         

        /// <summary>
        /// Пол. 
        /// </summary>
        public Gender Gender { get; }       

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime BirthDate { get; }  

        /// <summary>
        /// Вес.
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Рост.
        /// </summary>
        public double Height { get; set; }
        #endregion
        /// <summary>
        /// Создать нового пользователя.
        /// </summary>
        /// <param name="name">Имя. </param>
        /// <param name="gender">Пол. </param>
        /// <param name="birthDate">Дата рождения. </param>
        /// <param name="weight">Вес. </param>
        /// <param name="height">Рост. </param>
        public User(string name, 
                    Gender gender, 
                    DateTime birthDate,
                    double weight,
                    double height)
        {
            #region Проверка условий
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя User не может быть пустым или null", nameof(name));
            }
            if (gender == null)
            {
                throw new ArgumentNullException("Пол не может быть null", nameof(gender));
            }
            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Невозможная дата рождения", nameof(birthDate));
            }
            if (weight <= 0)
            {
                throw new ArgumentException("Вес не может быть <= 0", nameof(weight));
            }
            if (height <= 0)
            {
                throw new ArgumentException("Рост не может быть <= 0", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }
        /// <summary>
        /// Переопределение метода Тустринг в классе User.
        /// </summary>
        /// <returns>Имя пользователя. </returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
