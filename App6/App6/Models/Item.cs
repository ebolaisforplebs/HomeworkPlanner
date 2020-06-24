using System;

namespace App6.Models
{
    public class Item
    {
        public static object Date { get; internal set; }
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }

        public string Department { get; set; }

        public int Index { get; set; }
        public string DueDate { get;  set; }

        public string ItemId { get; set; }

        public int Percentage { get; set; }


    }


}