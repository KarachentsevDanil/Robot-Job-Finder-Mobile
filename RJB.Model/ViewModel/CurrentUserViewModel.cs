using RJF.MobileApp.Model.Users;

namespace RJF.MobileApp.ViewModel
{
    public class CurrentUserViewModel
    {
        public int UserId { get; set; }

        public bool IsClient { get; set; }

        public string Name { get; set; }

        public Role? Role { get; set; }
    }
}