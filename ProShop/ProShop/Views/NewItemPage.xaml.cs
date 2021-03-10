using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ProShop.Models;

namespace ProShop.Views
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
            if (checkData())
            {
                MessagingCenter.Send(this, "AddItem", Item);
                await Navigation.PopModalAsync();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Missing data", "Some essential data is missing!", "OK");
            }
        }

        private bool checkData()
        {
            if (Item != null)
            {
                if(Item.Bowler_Name != null || Item.Bowler_PAP !=null || Item.Bowler_LeftFingerSize != null || Item.Bowler_RightFingerSize != null || Item.Bowler_ThumbSize != null
                    || Item.Bowler_SpanLeft != null || Item.Bowler_SpanRight != null)
                {
                    return true;
                }
            }
            return false;
        }
        
        async void Cancel_Clicked(object sender, EventArgs e)
        {
            bool responce = await Application.Current.MainPage.DisplayAlert("Exit","Are you sure you want to leave, any entered data will be lost.","Yes","No");

            if (responce)
            {
                await Navigation.PopModalAsync();
            }
        }
    }
}