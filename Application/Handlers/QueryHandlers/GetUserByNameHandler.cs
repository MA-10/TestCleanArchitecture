using Application.Queries;
using Core.Entities;
using Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.QueryHandlers
{
    class GetUserByNameHandler : IRequestHandler<GetUserByNameQuery, User?>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByNameHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> Handle(GetUserByNameQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUserByName(request.Name); 
        }
    }
}
