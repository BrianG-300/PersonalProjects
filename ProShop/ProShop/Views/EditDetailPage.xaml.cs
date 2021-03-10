using System;
using System.Collections.Generic;
using ProShop.Models;
using ProShop.ViewModels;
using Xamarin.Forms;

namespace ProShop.Views
{
    public partial class EditDetailPage : ContentPage
    {
        EditDetailViewModel viewModel;

        public EditDetailPage(EditDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public EditDetailPage()
        {
            InitializeComponent();

            viewModel = new EditDetailViewModel(viewModel.Item);
            BindingContext = viewModel;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            if (checkData())
            {
                await App.Database.SaveItemAsync(viewModel.Item);

                await Navigation.PopToRootAsync();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Missing data", "Some essential data is missing!", "OK");
            }
        }

        private bool checkData()
        {
            if (viewModel.Item != null)
            {
                if (viewModel.Item.Bowler_Name != null || viewModel.Item.Bowler_PAP != null
                    || viewModel.Item.Bowler_LeftFingerSize != null || viewModel.Item.Bowler_RightFingerSize != null || viewModel.Item.Bowler_ThumbSize != null
                    || viewModel.Item.Bowler_SpanLeft != null || viewModel.Item.Bowler_SpanRight != null)
                {
                    return true;
                }
            }
            return false;
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            bool responce = await Application.Current.MainPage.DisplayAlert("Exit", "Are you sure you want to leave, any changes to data will be lost.", "Yes", "No");

            if (responce)
            {
                await Navigation.PopToRootAsync();
            }
        }
    }
}
