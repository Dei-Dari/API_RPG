using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPG.Models
{
    public class ServiceResponse<T>
    {
        //фактические данные, персонажи rpg
        public T Data { get; set; }

        public bool Success { get; set; } = true;

        public string Message { get; set; } = null;

    }
}
