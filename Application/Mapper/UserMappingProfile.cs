using Application.Commands;
using Application.Queries;
using Application.Responses;
using AutoMapper;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper
{
    class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserResponse>().ReverseMap();
            CreateMap<User, CreateNewUserCommand>().ReverseMap();
            CreateMap<User, GetUserByNameQuery>().ReverseMap();
        }
    }
}
