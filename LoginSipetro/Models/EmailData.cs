﻿
namespace LoginSipetro.Models
{
    public class EmailData
    {

        public string? From { get; set; }
        public string? To { get; set; }
        public string? Cc { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public string? Password { get; set; }

        public List<IFormFile>? File { get; set; }


        public EmailData()
        {
            From = "ihsansepriawal@gmail.com";
            Password = "ipzywujgeitfrgob";
        }
    }
}
