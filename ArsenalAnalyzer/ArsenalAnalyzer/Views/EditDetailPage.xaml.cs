using System;
using System.Collections.Generic;
using ArsenalAnalyzer.ViewModels;
using Xamarin.Forms;

namespace ArsenalAnalyzer.Views
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

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (viewModel.Item.BallBrand != null)
            {
                if (BrandPicker.Items.Contains(viewModel.Item.BallBrand))
                {
                    BrandPicker.SelectedItem = viewModel.Item.BallBrand;
                }
                else
                {
                    BrandPicker.SelectedItem = "Other";
                    OtherBrandEntryLayout.IsVisible = true;
                    OtherBrandEntry.Text = viewModel.Item.BallBrand;
                }
            }
            if (viewModel.Item.CoverType != null)
            {
                CoverPicker.SelectedItem = viewModel.Item.CoverType;
            }
            if (viewModel.Item.CoreType != null)
            {
                CorePicker.SelectedItem = viewModel.Item.CoreType;
            }
            if (viewModel.Item.SurfaceFinish != null)
            {
                SurfacePicker.SelectedItem = viewModel.Item.SurfaceFinish;
            }
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            await App.Database.SaveItemAsync(viewModel.Item);

            await Navigation.PopToRootAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        void CoverPicker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            var element = sender as Picker;
            viewModel.Item.CoverType = element.SelectedItem.ToString();
        }

        void CorePicker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            var element = sender as Picker;
            viewModel.Item.CoreType = element.SelectedItem.ToString();

            if (element.SelectedItem.ToString() == "Symmetrical")
            {
                RGLayout.IsVisible = true;
                DiffLayout.IsVisible = true;
                IntDiffLayout.IsVisible = false;
            }
            else if (element.SelectedItem.ToString() == "Asymmetrical")
            {
                RGLayout.IsVisible = true;
                DiffLayout.IsVisible = true;
                IntDiffLayout.IsVisible = true;
            }
            else
            {
                RGLayout.IsVisible = false;
                DiffLayout.IsVisible = false;
                IntDiffLayout.IsVisible = false;
            }

        }

        void SurfacePicker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            var element = sender as Picker;
            viewModel.Item.SurfaceFinish = element.SelectedItem.ToString();
        }

        void BrandPicker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            var element = sender as Picker;
            //Item.BallBrand = element.SelectedItem.ToString();
            if (element.SelectedItem.ToString() == "Other")
            {
                OtherBrandEntryLayout.IsVisible = true;
            }
            else
            {
                OtherBrandEntryLayout.IsVisible = false;
                viewModel.Item.BallBrand = element.SelectedItem.ToString();
            }
        }

        void OtherBrandEntry_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            var element = sender as Entry;
            viewModel.Item.BallBrand = element.Text;
        }
    }
}
