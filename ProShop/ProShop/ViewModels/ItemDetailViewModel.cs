using System;

using ProShop.Models;

namespace ProShop.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        //public bool showSaveToolbar { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Bowler_Name;
            Item = item;
            //string Purpose = v;

            //if (Purpose != null)
            //{
            //    if (Purpose == "Load")
            //    {
            //        showSaveToolbar = false;
            //    }
            //    else
            //    {
            //        showSaveToolbar = true;
            //    }
            //}
        }
    }
}
