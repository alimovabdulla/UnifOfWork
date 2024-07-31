using App.Application.DTOs.PersonDTOs;
using App.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Profiles.AutoMapper
{
    public class Mapper: Profile
    {
        public Mapper()
        {
            
           CreateMap<Person, PersonCreateDTO>().ReverseMap();


        }

         
    }
}
