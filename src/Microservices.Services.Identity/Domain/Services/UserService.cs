﻿
using Microservices.Common.Auth;
using Microservices.Common.Exceptions;
using Microservices.Services.Identity.Domain.Models;
using Microservices.Services.Identity.Domain.Repositories;

namespace Microservices.Services.Identity.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncrypter _encrypter;
        private readonly IJWTHandler _jWTHandler;

        public UserService(IUserRepository userRepository, IEncrypter encrypter, IJWTHandler jWTHandler)
        {
            _userRepository = userRepository;
            _encrypter = encrypter;
            _jWTHandler = jWTHandler;
        }


        public async Task RegisterAsync(string email, string password, string name)
        {
            var user = await _userRepository.GetAsync(email);

            if (user != null)
            {
                throw new MicroException("email_in_use", $"User with email: '{email}' already exists.");
            }

            user = new User(email, name);
            user.SetPassword(password, _encrypter);
            await _userRepository.AddAsync(user);
        }

        public async Task<JsonWebToken> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);

            if (user == null)
            {
                throw new MicroException("invalid_credentials", $"User with email: '{email}' does not exists.");
            }

            if (!user.ValidatePassword(password, _encrypter))
            {
                throw new MicroException("invalid_credentials", $"Invalid credentials.");
            }

            return _jWTHandler.Create(user.Id);
        }
    }
}

