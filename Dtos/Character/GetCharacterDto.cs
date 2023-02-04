using RPG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPG.Dtos.Character
{
    public class GetCharacterDto
    {
        public int Id { get; set; }
        // значение по умолчанию
        public string Name { get; set; } = "Frodo";
        // Очки
        public int HitPoints { get; set; } = 100;
        // Сила
        public int Strength { get; set; } = 10;
        // Защита
        public int Defense { get; set; } = 10;
        // Интеллект
        public int Intelligence { get; set; } = 10;
        // класс персонажа
        public RpgClass Class { get; set; } = RpgClass.Knight;
    }
}
