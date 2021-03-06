using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetUserByNameQuery : IRequest<User>
    {
        public String Name { get; set; }
    }
}
