﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ArsenalAnalyzer.Models;
using Xamarin.Essentials;

namespace ArsenalAnalyzer.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            Item = new Item();

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        void CoverPicker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            var element = sender as Picker;
            Item.CoverType = element.SelectedItem.ToString();
        }

        void CorePicker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            var element = sender as Picker;
            Item.CoreType = element.SelectedItem.ToString();

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
            Item.SurfaceFinish = element.SelectedItem.ToString();
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
                Item.BallBrand = element.SelectedItem.ToString();
            }
        }

        void OtherBrandEntry_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            var element = sender as Entry;
            Item.BallBrand = element.Text;
        }

        void TapGestureRecognizer_Tapped_Image1(object sender, EventArgs args)
        {
            //if (MediaPicker.IsCaptureSupported)
            //{
            //    var res = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions());
            //    var stream = await res.OpenReadAsync();
            //    Item.Image1 = res.FullPath;

            //    Image1.Source = ImageSource.FromStream(() => stream);
            //}
        }

        void TapGestureRecognizer_Tapped_Image2(object sender, EventArgs args)
        {
            //if (MediaPicker.IsCaptureSupported)
            //{
            //    var res = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions());
            //    var stream = await res.OpenReadAsync();
            //    Item.Image2 = res.FullPath;

            //    Image2.Source = ImageSource.FromStream(() => stream);
            //}
        }

        async void Image1Button_Clicked(object sender, EventArgs args)
        {
            if (MediaPicker.IsCaptureSupported)
            {
                var res = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions());

                if (res != null)
                {
                    var stream = await res.OpenReadAsync();
                    Item.Image1 = res.FullPath;
                    Image1.Source = ImageSource.FromStream(() => stream);
                }
            }
        }

        async void Image2Button_Clicked(object sender, EventArgs args)
        {
            if (MediaPicker.IsCaptureSupported)
            {
                var res = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions());

                if (res != null)
                {
                    var stream = await res.OpenReadAsync();
                    Item.Image2 = res.FullPath;
                    Image2.Source = ImageSource.FromStream(() => stream);
                }
            }
        }
    }
}