using MyFitnessProject.BL.Model;
using System;
using System.IO;
using System.Runtime.Serialization.Json;

namespace MyFitnessProject.BL.Controller
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
            //TODO: Проверка
            var gender = new Gender(genderName);
            User = new User(userName, gender, birthDay, weight, height);
        }
        /// <summary>
        /// Получить данные пользователя.
        /// </summary>
        /// <returns> Пользователь приложения.</returns>
        public UserController()
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(User));
            using (var fileStream = new FileStream("users.json", FileMode.OpenOrCreate))
            {
                if (jsonFormatter.ReadObject(fileStream) is User user)
                {
                    User = user;
                }
                //TODO: Что делать, если пользователя  не прочитали?
            }

        }
        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(User));
            using (var fileStream = new FileStream("users.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fileStream, User);
            }
            
        }
        
    }
}
