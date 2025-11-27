using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid1
{
    // Який принцип S.O.L.I.D. порушено? Виправте!
    // Порушено SRP (Single Responsibility Principle).

    class Item
    {
    }

    // Тепер Order відповідає тільки за роботу зі списком товарів
    class Order
    {
        private List<Item> itemList;

        internal List<Item> ItemList
        {
            get { return itemList; }
            set { itemList = value; }
        }

        public void CalculateTotalSum() { /*...*/ }
        public void GetItems() { /*...*/ }
        public void GetItemCount() { /*...*/ }
        public void AddItem(Item item) { /*...*/ }
        public void DeleteItem(Item item) { /*...*/ }
    }

    // Окремий клас для друку / показу замовлення
    class OrderPrinter
    {
        private readonly Order order;

        public OrderPrinter(Order order)
        {
            this.order = order;
        }

        public void PrintOrder() { /*...*/ }
        public void ShowOrder() { /*...*/ }
    }

    // Окремий клас для роботи з даними
    class OrderRepository
    {
        public void Load() { /*...*/ }
        public void Save() { /*...*/ }
        public void Update() { /*...*/ }
        public void Delete() { /*...*/ }
    }

    class Program
    {
        static void Main()
        {
            // Order order = new Order();
            // OrderPrinter printer = new OrderPrinter(order);
            // OrderRepository repository = new OrderRepository();
        }
    }
}