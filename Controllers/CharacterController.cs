using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RPG.Models;
using RPG.Services.CharacterService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ILogger<CharacterController> _logger;
        private readonly ICharacterService _characterService;

        //private static List<Character> characters = new List<Character>
        //{
        //    new Character(),
        //    new Character{ Id = 1, Name = "Sam"}
        //};

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            // return Ok(characters);
            return Ok(await _characterService.GetAllCharacters());
        }


        //public CharacterController(ILogger<CharacterController> logger)
        //{
        //    _logger = logger;
        //}

        // функция с параметром метода 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            // return Ok(characters.FirstOrDefault(c => c.Id == id));
            return Ok(await _characterService.GetCharacterById(id));
        }

        // новый персонаж
        [HttpPost]
        public async Task<IActionResult> AddCharacter(Character newCharacter)
        {            
            return Ok(await _characterService.AddCharacter(newCharacter));
        }
    }
}
