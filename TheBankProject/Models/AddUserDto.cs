﻿namespace TheBankProject.Models
{
    public class AddUserDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }

        public string Password { get; set; }
        public string Pesel { get; set; }
    }
}
