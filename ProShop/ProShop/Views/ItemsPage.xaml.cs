using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ProShop.Models;
using ProShop.Views;
using ProShop.ViewModels;
using System.Diagnostics;

namespace ProShop.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            viewModel.IsBusy = true;

            try
            {
                var layout = (BindableObject)sender;
                var item = (Item)layout.BindingContext;
                await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                viewModel.IsBusy = false;
            }
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        async void EditItem_Clicked(object sender, EventArgs e)
        {
            viewModel.IsBusy = true;

            try
            {
                var layout = (BindableObject)sender;
                var item = (Item)layout.BindingContext;
                //await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
                await Navigation.PushAsync(new EditDetailPage(new EditDetailViewModel(item)));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                viewModel.IsBusy = false;
            }
        }

        async void DeleteItem_Clicked(object sender, EventArgs e)
        {
            var layout = (BindableObject)sender;
            var item = (Item)layout.BindingContext;
            await viewModel.DeleteItemCommand(item);

            await Task.Run(async () =>
             {
                 viewModel.LoadItemsCommand.Execute(null);
             });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}