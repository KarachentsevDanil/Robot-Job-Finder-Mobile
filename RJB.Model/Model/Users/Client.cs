﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RJB.Model.Model.Leases;

namespace RJB.Model.Model.Users
{
    [JsonObject(IsReference = true)]
    public class Client
    {
        public int ClientId { get; set; }

        public string FullName { get; set; }
        
        public string Username { get; set; }
        
        public string Password { get; set; }
        
        public Role Role { get; set; }

        public DateTime? DateOfBirthday  { get; set; }

        public byte[] Photo { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<Lease> Leases { get; set; }
    }
}
