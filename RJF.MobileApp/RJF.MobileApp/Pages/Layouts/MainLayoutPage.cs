using Xamarin.Forms;

namespace RJF.MobileApp.Pages.Layouts
{
    public class MainLayoutPage : TabbedPage
    {
        public MainLayoutPage()
        {
            Page itemsPage = new NavigationPage(new LoginClientPage())
            {
                Title = "Sign in to client"
            };

            Page aboutPage = new NavigationPage(new LoginCompanyPage())
            {
                Title = "Sign in to company"
            };

            Children.Add(itemsPage);
            Children.Add(aboutPage);

            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}