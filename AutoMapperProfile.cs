using AutoMapper;
using RPG.Dtos.Character;
using RPG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPG
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //персонаж - Dto
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
        }
    }
}
