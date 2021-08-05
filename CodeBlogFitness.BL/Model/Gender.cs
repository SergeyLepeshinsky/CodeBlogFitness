﻿using System;


namespace CodeBlogFitness.BL.Model
{
    /// <summary>
    /// Пол.
    /// </summary>
    public class Gender
    {
        /// <summary>
        /// Название пола.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Создать новый пол.
        /// </summary>
        /// <param name="name">Имя пола. </param>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пола не может быть пустым или null", nameof(name));
            }
            Name = name;
        }
        /// <summary>
        /// Переопределение метода Тустринг в классе Gender.
        /// </summary>
        /// <returns>Имя пола. </returns>
        public override string ToString()  
        {
            return Name;
        }
    }
}
