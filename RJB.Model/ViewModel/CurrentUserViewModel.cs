﻿using RJB.Model.Model.Users;

namespace RJB.Model.ViewModel
{
    public class CurrentUserViewModel
    {
        public int UserId { get; set; }

        public bool IsClient { get; set; }

        public string Name { get; set; }

        public Role? Role { get; set; }

        public string Password { get; set; }
    }
}