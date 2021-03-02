using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace kululaAndroid.Model
{
    class Groceries
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string ImageFilename { get; set; }

        public Groceries(string name, string category, string imageFilename)
        {
            Name = name;
            Category = category;
            ImageFilename = imageFilename;
        }

        public static List<Groceries> GetList()
        {
            var data = new List<Groceries>();

            data.Add(new Groceries("Asparagus", "Vegetables", "Vegetables"));
            data.Add(new Groceries("Avocados", "Vegetables", "Vegetables"));
            data.Add(new Groceries("Beetroots", "Vegetables", "Vegetables"));
            data.Add(new Groceries("Capsicum", "Vegetables", "Vegetables"));
            data.Add(new Groceries("Broccoli", "Vegetables", "Vegetables"));
            data.Add(new Groceries("Brussel sprouts", "Vegetables", "Vegetables"));
            data.Add(new Groceries("Cabbage", "Vegetables", "Vegetables"));
            data.Add(new Groceries("Carrots", "Vegetables", "Vegetables"));
            data.Add(new Groceries("Cauliflower", "Vegetables", "Vegetables"));
            data.Add(new Groceries("Celery", "Vegetables", "Vegetables"));
            data.Add(new Groceries("Corn", "Vegetables", "Vegetables"));
            data.Add(new Groceries("Cucumbers", "Vegetables", "Vegetables"));
            data.Add(new Groceries("Eggplant", "Vegetables", "Vegetables"));
            data.Add(new Groceries("Fennel", "Vegetables", "Vegetables"));
            data.Add(new Groceries("Garlic", "Vegetables", "Vegetables"));
            data.Add(new Groceries("Beans", "Vegetables", "Vegetables"));
            data.Add(new Groceries("Peas", "Vegetables", "Vegetables"));
            data.Add(new Groceries("Kale", "Vegetables", "Vegetables"));
            data.Add(new Groceries("Leeks", "Vegetables", "Vegetables"));
            data.Add(new Groceries("Mushrooms", "Vegetables", "Vegetables"));
            data.Add(new Groceries("Olives", "Vegetables", "Vegetables"));
            data.Add(new Groceries("Onions", "Vegetables", "Vegetables"));
            data.Add(new Groceries("Potatoes", "Vegetables", "Vegetables"));
            data.Add(new Groceries("Lettuce", "Vegetables", "Vegetables"));
            data.Add(new Groceries("Spinach", "Vegetables", "Vegetables"));
            data.Add(new Groceries("Squash", "Vegetables", "Vegetables"));
            data.Add(new Groceries("Sweet potatoes", "Vegetables", "Vegetables"));
            data.Add(new Groceries("Tomatoes", "Vegetables", "Vegetables"));
            data.Add(new Groceries("Turnips", "Vegetables", "Vegetables"));
            data.Add(new Groceries("Apples", "Fruits", "Fruits"));
            data.Add(new Groceries("Apricots", "Fruits", "Fruits"));
            data.Add(new Groceries("Bananas", "Fruits", "Fruits"));
            data.Add(new Groceries("Blueberries", "Fruits", "Fruits"));
            data.Add(new Groceries("Rockmelon", "Fruits", "Fruits"));
            data.Add(new Groceries("Figs", "Fruits", "Fruits"));
            data.Add(new Groceries("Grapefruit", "Fruits", "Fruits"));
            data.Add(new Groceries("Grapes", "Fruits", "Fruits"));
            data.Add(new Groceries("Honeydew Melon", "Fruits", "Fruits"));
            data.Add(new Groceries("Kiwifruit", "Fruits", "Fruits"));
            data.Add(new Groceries("Lemons", "Fruits", "Fruits"));
            data.Add(new Groceries("Oranges", "Fruits", "Fruits"));
            data.Add(new Groceries("Pears", "Fruits", "Fruits"));
            data.Add(new Groceries("Pineapple", "Fruits", "Fruits"));
            data.Add(new Groceries("Plums", "Fruits", "Fruits"));
            data.Add(new Groceries("Raspberries", "Fruits", "Fruits"));
            data.Add(new Groceries("Strawberries", "Fruits", "Fruits"));
            data.Add(new Groceries("Watermelon", "Fruits", "Fruits"));
            data.Add(new Groceries("Balmain Bugs", "Seafood", ""));
            data.Add(new Groceries("Calamari", "Seafood", ""));
            data.Add(new Groceries("Cod", "Seafood", ""));
            data.Add(new Groceries("Prawns", "Seafood", ""));
            data.Add(new Groceries("Lobster", "Seafood", ""));
            data.Add(new Groceries("Salmon", "Seafood", ""));
            data.Add(new Groceries("Scallops", "Seafood", ""));
            data.Add(new Groceries("Shrimp", "Seafood", ""));
            data.Add(new Groceries("Tuna", "Seafood", ""));
            data.Add(new Groceries("Almonds", "Nuts", ""));
            data.Add(new Groceries("Cashews", "Nuts", ""));
            data.Add(new Groceries("Peanuts", "Nuts", ""));
            data.Add(new Groceries("Walnuts", "Nuts", ""));
            data.Add(new Groceries("Black beans", "Beans & Legumes", "Legumes"));
            data.Add(new Groceries("Dried peas", "Beans & Legumes", "Legumes"));
            data.Add(new Groceries("Kidney beans", "Beans & Legumes", "Legumes"));
            data.Add(new Groceries("Lentils", "Beans & Legumes", "Legumes"));
            data.Add(new Groceries("Lima beans", "Beans & Legumes", "Legumes"));
            data.Add(new Groceries("Miso", "Beans & Legumes", "Legumes"));
            data.Add(new Groceries("Soybeans", "Beans & Legumes", "Legumes"));
            data.Add(new Groceries("Beef", "Meat", ""));
            data.Add(new Groceries("Buffalo", "Meat", ""));
            data.Add(new Groceries("Chicken", "Meat", ""));
            data.Add(new Groceries("Lamb", "Meat", ""));
            data.Add(new Groceries("Cheese", "Dairy", ""));
            data.Add(new Groceries("Milk", "Dairy", ""));
            data.Add(new Groceries("Eggs", "Dairy", ""));
            data.Add(new Groceries("Basil", "Herbs & Spices", "FlowerBuds"));
            data.Add(new Groceries("Black pepper", "Herbs & Spices", "FlowerBuds"));
            data.Add(new Groceries("Chili pepper, dried", "Herbs & Spices", "FlowerBuds"));
            data.Add(new Groceries("Cinnamon", "Herbs & Spices", "FlowerBuds"));
            data.Add(new Groceries("Cloves", "Herbs & Spices", "FlowerBuds"));
            data.Add(new Groceries("Cumin", "Herbs & Spices", "FlowerBuds"));
            data.Add(new Groceries("Dill", "Herbs & Spices", "FlowerBuds"));
            data.Add(new Groceries("Ginger", "Herbs & Spices", "FlowerBuds"));
            data.Add(new Groceries("Mustard", "Herbs & Spices", "FlowerBuds"));
            data.Add(new Groceries("Oregano", "Herbs & Spices", "FlowerBuds"));
            data.Add(new Groceries("Parsley", "Herbs & Spices", "FlowerBuds"));
            data.Add(new Groceries("Peppermint", "Herbs & Spices", "FlowerBuds"));
            data.Add(new Groceries("Rosemary", "Herbs & Spices", "FlowerBuds"));
            data.Add(new Groceries("Sage", "Herbs & Spices", "FlowerBuds"));
            data.Add(new Groceries("Thyme", "Herbs & Spices", "FlowerBuds"));
            data.Add(new Groceries("Turmeric", "Herbs & Spices", "FlowerBuds"));

            return data;
        }
    }
}