using System;
using System.Linq;
using RJB.HttpExtinction.HttpRequests.RequestHelpers;
using RJB.Model.Model.Specializations;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RJF.MobileApp.Pages.Robots
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddSpecializationPage : ContentPage
	{
		public AddSpecializationPage ()
		{
			InitializeComponent ();
		}

	    private async void AddSpecializationButton_Clicked(object sender, EventArgs e)
	    {
	        var specialization = new Specialization
	        {
	            Name = Name.Text
	        };

	        var isSuccess = SpecializationClientService.AddSpecialization(specialization);
	        if (!isSuccess)
	        {
	            AddSpecializationFailed.IsVisible = true;
	        }
	        else
	        {
	            ClearForm();
	            AddRobotModel.Specializations = SpecializationClientService.GetAllSpecializations().ToList();
	            await Navigation.PopAsync();
	        }
        }

	    private void ClearForm()
	    {
	        Name.Text = string.Empty;
	        AddSpecializationFailed.IsVisible = false;
	    }

	    private async void BackButton_Clicked(object sender, EventArgs e)
	    {
	        await Navigation.PopAsync();
	    }
    }
}