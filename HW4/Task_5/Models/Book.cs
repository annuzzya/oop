using System.Collections.Generic;

namespace Task_5.Models 
{
    public class Book : Product
    {
        public int PageCount { get; set; }
        public string Publisher { get; set; }
        public List<string> Authors { get; set; } = new List<string>();

        public override string DisplayInfo
        {
            get
            {
                string authors = string.Join(", ", Authors);
                return $"\nАвтори: {authors}\nВидавництво: {Publisher},\n{PageCount} стор.";
            }
        }
    }
}