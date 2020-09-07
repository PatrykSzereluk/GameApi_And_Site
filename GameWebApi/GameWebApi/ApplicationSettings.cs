﻿namespace GameWebApi
{
    public class ApplicationSettings
    {
        public string Secret { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int PasswordChangePeriod { get; set; }
    }
}
