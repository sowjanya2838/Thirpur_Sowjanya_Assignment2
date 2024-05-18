using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem
{
    // Item Class
     public class Item
    {
        //properties of item class
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        //constructor
        public Item(int id, string name, decimal price, int quantity)
        {
            ID = id;
            Name = name;
            Price = price;
            Quantity = quantity;
        }
        
        //override
        public override string ToString()
        {
            return $"ID: {ID}, Name: {Name}, Price: {Price:C}, Quantity: {Quantity}";
        }
    }

    // inventory class
    public class Inventory
    {
        private List<Item> items;

        //constructor of inventory class
        public Inventory()
        {
            items = new List<Item>();
        }


        //adds an item object to the items list
        public void AddItem(Item item)
        {
            items.Add(item);
            Console.WriteLine("Item added successfully.");
        }


        //display all items in the inventory
        public void DisplayItems()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("No items in the inventory.");
            }
            else
            {
                Console.WriteLine("Items in the inventory:");
                foreach (var item in items)
                {
                    Console.WriteLine(item);
                }
            }
        }

        //searches for an item by its id and returns it
        public Item FindItemByID(int id)
        {
            return items.Find(item => item.ID == id);
        }

        //update item
        public void UpdateItem(int id, string name, decimal price, int quantity)
        {
            Item item = FindItemByID(id);
            if (item != null)
            {
                item.Name = name;
                item.Price = price;
                item.Quantity = quantity;
                Console.WriteLine("Item updated successfully.");
            }
            else
            {
                Console.WriteLine("Item not found.");
            }
        }

        //deletes an item
        public void DeleteItem(int id)
        {
            Item item = FindItemByID(id);
            if (item != null)
            {
                items.Remove(item);
                Console.WriteLine("Item deleted successfully.");
            }
            else
            {
                Console.WriteLine("Item not found.");
            }
        }
    }


    //Main method
    class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            while (true)
            {
                Console.WriteLine("Inventory Management System");
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. Display All Items");
                Console.WriteLine("3. Find Item by ID");
                Console.WriteLine("4. Update Item");
                Console.WriteLine("5. Delete Item");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();


                //switch case
                switch (choice)
                {
                    case "1":
                        AddItem(inventory);
                        break;
                    case "2":
                        inventory.DisplayItems();
                        break;
                    case "3":
                        FindItem(inventory);
                        break;
                    case "4":
                        UpdateItem(inventory);
                        break;
                    case "5":
                        DeleteItem(inventory);
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
                Console.WriteLine();
            }
        }


        //Method
        static void AddItem(Inventory inventory)
        {
            Console.Write("Enter Item ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter Item Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Item Price: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Enter Item Quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            Item newItem = new Item(id, name, price, quantity);
            inventory.AddItem(newItem);
        }

        static void FindItem(Inventory inventory)
        {
            Console.Write("Enter Item ID to find: ");
            int id = int.Parse(Console.ReadLine());

            Item item = inventory.FindItemByID(id);
            if (item != null)
            {
                Console.WriteLine("Item found:");
                Console.WriteLine(item);
            }
            else
            {
                Console.WriteLine("Item not found.");
            }
        }

        static void UpdateItem(Inventory inventory)
        {
            Console.Write("Enter Item ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter new Item Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter new Item Price: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Enter new Item Quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            inventory.UpdateItem(id, name, price, quantity);
        }

        static void DeleteItem(Inventory inventory)
        {
            Console.Write("Enter Item ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            inventory.DeleteItem(id);
        }
    }
}
    

