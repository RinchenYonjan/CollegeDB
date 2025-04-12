﻿using WebApplication1.Constants;

namespace WebApplication1.Dtos
{
    public class UserGetById
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public GenderType Gender { get; set; }

        public string? ImageURL { get; set; }

        public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
    }
}
