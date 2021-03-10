using System;
using ProShop.Models;

namespace ProShop.ViewModels
{
    public class EditDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public EditDetailViewModel(Item item = null)
        {
            Title = "Edit Player Detail";
            Item = item;
        }
    }
}