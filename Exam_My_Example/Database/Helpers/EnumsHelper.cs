using Exam_My_Example.Database.Models;
using System.Collections.Generic;

namespace Exam_My_Example.Database.Helpers
{
    /// <summary>
    /// Класс-предоставляющий различные методы для работы с перечислениями
    /// </summary>
    internal class EnumsHelper
    {
        #region Gender (Нужно будет переименовать на свое перечисление)
        /// <summary>
        /// Метод получения строкового значения для перечисления
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        public static string GetStringValueForGender(Gender gender)
        {
            switch (gender)
            {
                case Gender.Man:
                    return "Мужчина";
                case Gender.Women:
                    return "Женщина";
            }

            //по идее до сюда не должен никогда дойти
            return string.Empty;
        }

        /// <summary>
        /// Метод получения списка значений перечесления для комбобокса
        /// </summary>
        /// <returns></returns>
        public static List<EnumComboBoxModel> GetComboBoxModelForGender()
        {
            var result = new List<EnumComboBoxModel>();

            result.Add(new EnumComboBoxModel
            {
                DisplayName = GetStringValueForGender(Gender.Man),
                Value = (int)Gender.Man
            });

            result.Add(new EnumComboBoxModel
            {
                DisplayName = GetStringValueForGender(Gender.Women),
                Value = (int)Gender.Women
            });

            return result;
        }

        #endregion

        #region TypePriema (Нужно будет переименовать на свое перечисление)
        /// <summary>
        /// Метод получения строкового значения для перечисления
        /// </summary>
        /// <param name="typePriema"></param>
        /// <returns></returns>
        public static string GetStringValueForTypePriema(TypePriema typePriema)
        {
            switch (typePriema)
            {
                case TypePriema.Pervich:
                    return "Первичный";
                case TypePriema.Povtorn:
                    return "Повторный";
            }

            //по идее до сюда не должен никогда дойти
            return string.Empty;
        }

        /// <summary>
        /// Метод получения списка значений перечесления для комбобокса
        /// </summary>
        /// <returns></returns>
        public static List<EnumComboBoxModel> GetComboBoxModelForTypePriema()
        {
            var result = new List<EnumComboBoxModel>();

            result.Add(new EnumComboBoxModel
            {
                DisplayName = GetStringValueForTypePriema(TypePriema.Pervich),
                Value = (int)TypePriema.Pervich
            });

            result.Add(new EnumComboBoxModel
            {
                DisplayName = GetStringValueForTypePriema(TypePriema.Povtorn),
                Value = (int)TypePriema.Povtorn
            });

            return result;
        }

        #endregion
    }

    /// <summary>
    /// Класс-обертка для представления перечислений в комбо боксах
    /// </summary>
    class EnumComboBoxModel
    {
        /// <summary>
        /// То что будет видеть пользователь при выборе (строка)
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Фактическое значение в виде числа
        /// </summary>
        public int Value { get; set; }
    }
}
