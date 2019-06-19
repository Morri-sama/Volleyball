using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Serve : ActionBase
    {
        private string _result;

        /// <summary>
        /// Возможные варианты: "Выиграл", "Ввёл", "Проиграл".
        /// </summary>
        public override string Result { get => _result; set => Notify(ref _result, value, "Result"); }

        [NotMapped]
        public List<string> ResultOptions { get; set; } = new List<string>() { "Выиграл", "Ввёл", "Аут", "Ошибка" };

        public override string Name { get; set; } = "Подача";
        public override string Description
        {
            get
            {
                if (Result == "Выиграл")
                {
                    return $"Игрок {Player.Name} совершил подачу. Принёс своё очко своей команде.";
                }
                if(Result == "Ввёл")
                {
                    return $"Игрок {Player.Name} совершил подачу. Ввёл мяч в игру";
                }
                if (Result == "Аут")
                {
                    return $"Игрок {Player.Name} совершил подачу. Мяч попал в аут";
                }
                if (Result == "Ошибка")
                {
                    return $"Игрок {Player.Name} совершил подачу. Ошибка при подаче";
                }

                return null;
            }
        }
    }
}
