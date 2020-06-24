using System;

using App6.Models;

namespace App6.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        private SQLSource item;

        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
        }

        public ItemDetailViewModel(SQLSource item)
        {
            this.item = item;
        }
    }
}
