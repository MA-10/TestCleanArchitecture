using Application.Commands;
using Application.Mapper;
using Application.Responses;
using Core.Entities;
using Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.CommandHandlers
{
    public class CreateNewUserHandler : IRequestHandler<CreateNewUserCommand, UserResponse>
    {
        private readonly IUserRepository _userRepository;

        public CreateNewUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponse> Handle(CreateNewUserCommand request, CancellationToken cancellationToken)
        {
            var user = UserMapper.Mapper.Map<User>(request); 
            if (user is null) throw new ApplicationException("Issue with mapper");
            var newUser =  await _userRepository.AddAsync(user);
            var userResponse = UserMapper.Mapper.Map<UserResponse>(newUser);
            return userResponse; 
        }
    }
}
