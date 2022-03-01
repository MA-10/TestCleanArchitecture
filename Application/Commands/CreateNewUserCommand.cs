using Application.Responses;
using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CreateNewUserCommand : IRequest<UserResponse> 
    {
        public String Name { get; set; }
        public String Email { get; set; }
    }
}
