using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RJF.MobileApp.Pages.Leases;
using Xamarin.Forms;

namespace RJF.MobileApp.Pages.Layouts
{
    public class ClientMainLayoutPage : TabbedPage
    {
        public ClientMainLayoutPage()
        {
            Page addLeasePage = new NavigationPage(new AddLease())
            {
                Title = "Lease a robots"
            };

            Page myLeases = new NavigationPage(new Leases.Leases())
            {
                Title = "My Leases"
            };

            Children.Add(addLeasePage);
            Children.Add(myLeases);

            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}