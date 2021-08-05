using System;
using CodeBlogFitness.BL.Model;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CodeBlogFitness.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя. 
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователь приложения. 
        /// </summary>
        public User User { get; }
        /// <summary>
        /// Создание нового контроллера пользователя. 
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName, string genderName, DateTime birthDay, double weight, double height)
        {
            // TODO: Проверка
            var gender = new Gender(genderName);
            User = new User(userName, gender, birthDay, weight, height);


            //if (user == null)   // проверка на null
            //{
            //    throw new ArgumentNullException("Объект User не существует. ", nameof(user));
            //}
            //User = user;
            //User = user ?? throw new ArgumentNullException("Объект User не существует. ", nameof(user));
        }
        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();  // класс для сериализации в бинарный файл
            using (var fs = new FileStream("user.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }
        /// <summary>
        /// Получить данные пользователя через конструктор без параметров.
        /// </summary>
        /// <returns>Пользователь приложения. </returns>
        public UserController()
        {
            var formatter = new BinaryFormatter();  // класс для десериализации в бинарный файл
            using (var fs = new FileStream("user.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }
                
                // TODO: Что делать, если пользователя не прочитали?
            }
        }
    }
}
