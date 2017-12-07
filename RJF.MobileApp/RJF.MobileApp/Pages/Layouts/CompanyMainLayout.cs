using System;
using RJF.MobileApp.Pages.Robots;
using Xamarin.Forms;

namespace RJF.MobileApp.Pages.Layouts
{
    public class CompanyMainLayout : TabbedPage
    {
        public CompanyMainLayout()
        {
            Page robotsPage = new NavigationPage(new Robots.Robots())
            {
                Title = "My Robots"
            };

            Children.Add(robotsPage);

            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}