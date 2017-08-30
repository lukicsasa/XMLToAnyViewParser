using System;

namespace XMLToAnyViewParser.Models
{
    public class UserJwtModel
    {
        public int Id { get; set; }

        public string Username { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}