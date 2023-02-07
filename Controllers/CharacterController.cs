using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RPG.Data;
using RPG.Dtos.Character;
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
        private readonly DataContext _context;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        public CharacterController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            // return Ok(characters);
            return Ok(await _characterService.GetAllCharacters());
        }

        // функция с параметром метода 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            // return Ok(characters.FirstOrDefault(c => c.Id == id));
            // return Ok(await _characterService.GetCharacterById(id));
            ServiceResponse<GetCharacterDto> response = await _characterService.GetCharacterById(id);
            if (response.Data == null)
            {
                return BadRequest("Character not found.");
            }
            return Ok(response);
        }

        // новый персонаж
        [HttpPost]
        public async Task<IActionResult> AddCharacter(AddCharacterDto newCharacter)
        {            
            return Ok(await _characterService.AddCharacter(newCharacter));
        }

        // обновление персонажа
        [HttpPut]
        public async Task<IActionResult> UpdateCharacter(UpdateCharacterDto updateCharacter)
        {
            ServiceResponse<GetCharacterDto> response = await _characterService.UpdateCharacter(updateCharacter);
            if (response.Data == null)
            {
                return NotFound("Character for update not found.");
            }
            return Ok(response);
        }

        // функция с параметром метода 
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ServiceResponse<List<GetCharacterDto>> response = await _characterService.DeleteCharacter(id);
            if (response.Data == null)
            {
                return NotFound("Character dor delete not found.");
            }
            return Ok(response);
        }
    }
}
