using System;

namespace Task_5.Models
{
    public class FoodProduct : Product
    {
        public DateTime ExpiryDate { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }

        public override string DisplayInfo
        {
            get
            {
                return $"{base.DisplayInfo}\nТермін придатності: {ExpiryDate:dd.MM.yyyy}, \n{Unit}, \nКількість: {Quantity}";
            }
        }
    }
}