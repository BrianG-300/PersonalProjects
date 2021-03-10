using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ArsenalAnalyzer.Models;
using ArsenalAnalyzer.ViewModels;

namespace ArsenalAnalyzer.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;
        Item item;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();
            item = new Item();

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        void TapGestureRecognizer_Tapped_Image1(object sender, EventArgs args)
        {
            var element = sender as Image;
            var source = element.Source;

            if (source != null)
            {
                FullSizeImageView.IsVisible = true;
                FullImage.Source = source;
            }
        }

        void TapGestureRecognizer_Tapped_Image2(object sender, EventArgs args)
        {
            var element = sender as Image;
            var source = element.Source;

            if (source != null)
            {
                FullSizeImageView.IsVisible = true;
                FullImage.Source = source;
            }
        }

        void TapGestureRecognizer_Tapped_FullImage(object sender, EventArgs args)
        {
            FullSizeImageView.IsVisible = false;
            FullImage.Source = null;
        }
    }
}