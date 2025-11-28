using System;

namespace Task_5.Models
{
    public abstract class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        
        public string OriginCountry { get; set; } 
        
        public DateTime PackingDate { get; set; }
        public string Description { get; set; }

        public virtual string DisplayInfo
        {
            get
            {
                return $"{Description}\nКраїна: {OriginCountry}, \nДата пакування: {PackingDate:dd.MM.yyyy}";
            }
        }
    }
}