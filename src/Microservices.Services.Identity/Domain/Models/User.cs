﻿using Microservices.Common.Exceptions;
using Microservices.Services.Identity.Domain.Services;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Microservices.Services.Identity.Domain.Models
{
    public class User
    {
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public string Name { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        protected User()
        {
        }

        public User(string email, string name)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new MicroException("empty_user_email", $"User: email can not be empty.");
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new MicroException("empty_user_name", $"User: name can not be empty.");
            }
            Id = Guid.NewGuid();
            Email = email.ToLowerInvariant();
            Name = name;
            CreatedAt = DateTime.UtcNow;
        }

        public void SetPassword(string password, IEncrypter encrypter)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new MicroException("empty_password", $"Password can not be empty.");
            }

            Salt = encrypter.GetSalt();
            Password = encrypter.GetHash(password, Salt);
        }

        public bool ValidatePassword(string password, IEncrypter encrypter)
            => Password.Equals(encrypter.GetHash(password, Salt));
    }
}
