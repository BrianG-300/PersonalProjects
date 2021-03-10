using System;

using ArsenalAnalyzer.Models;

namespace ArsenalAnalyzer.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.BallModel;

            if (item.BallSerialNumber == null)
            {
                item.BallSerialNumber = " ";
            }
            if (item.Notes == null)
            {
                item.Notes = " ";
            }

            if (item.CoreType == "Symmetrical")
            {
                ShowRG = true;
                ShowDiff = true;
                ShowIntDiff = false;
            }
            else if (item.CoreType == "Asymmetrical")
            {
                ShowRG = true;
                ShowDiff = true;
                ShowIntDiff = true;
            }
            else
            {
                ShowRG = false;
                ShowDiff = false;
                ShowIntDiff = false;
            }

            Item = item;
        }

        public bool ShowRG { get; set; }
        public bool ShowDiff { get; set; }
        public bool ShowIntDiff { get; set; }
    }
}
