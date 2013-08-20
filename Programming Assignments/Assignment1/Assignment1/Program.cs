using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Program
    {

        private decimal /* */
            wholesealeDecimal;

        private string /* */
            productDescription;

        internal static bool repeat;

        private Array[] skuArrays;

        //So these are the keys available to the user upon selection
        internal enum MenuI
        {
            A = 1, F, U, S, R, X
        }
        //We then tie this key to a value
        Dictionary<MenuI, string> menuOptions = new Dictionary<MenuI, string>();
        
        //The Option is then cached
        public static MenuI OptionSel { get; set; }

        private enum AvailablePlc
        {
                    
        }

        static void Main(string[] args)
        {
            string title;
            var p = new Program();
            do
            {
                OptionSel = p.Menu();

                Console.Clear();

                switch (OptionSel)
                {
                        //Each case follows this structure
                    case MenuI.A:
                        //Instructions
                        const string helpAddProduct = "To add a product  *something*";
                        //Set title of Console to Menu Option title
                        p.menuOptions.TryGetValue(MenuI.A, out title);
                        //Test if title is not null
                        Console.Title = title ?? "Stock Control Alpha";
                        //Right align
                        Console.CursorLeft = Console.BufferWidth - helpAddProduct.Length;
                        //Print instructions
                        Console.WriteLine(helpAddProduct);
                        //Call Method that relates to the action
                        p.AddProduct();
                        //Break it
                        break;
                    case MenuI.F:
                        const string helpFindProduct = "To Find a product type something";
                        p.menuOptions.TryGetValue(MenuI.F, out title);
                        Console.Title = title ?? "Stock Control Alpha";
                        Console.CursorLeft = Console.BufferWidth - helpFindProduct.Length;
                        Console.WriteLine(helpFindProduct);
                        p.FindProduct();
                        break;
                    case MenuI.R:
                        const string helpProduceSt = "To produce a stock-take report do THIS";
                        p.menuOptions.TryGetValue(MenuI.R, out title);
                        Console.Title = title ?? "Stock Control Alpha";
                        Console.CursorLeft = Console.BufferWidth - helpProduceSt.Length;
                        Console.WriteLine(helpProduceSt);
                        p.ProduceST();
                        break;
                    case MenuI.S:
                        const string helpUpdateStock = "To update stock levels for products do THIS";
                        p.menuOptions.TryGetValue(MenuI.S, out title);
                        Console.Title = title ?? "Stock Control Alpha";
                        Console.CursorLeft = Console.BufferWidth - helpUpdateStock.Length;
                        Console.WriteLine(helpUpdateStock);
                        p.UpdateStock();
                        break;
                    case MenuI.U:
                        const string helpUpdateProduct = "To update your product details do THIS";
                        p.menuOptions.TryGetValue(MenuI.U, out title);
                        Console.Title = title ?? "Stock Control Alpha";
                        Console.CursorLeft = Console.BufferWidth - helpUpdateProduct.Length;
                        Console.WriteLine(helpUpdateProduct);
                        p.UpdateProduct();
                        break;
                    case MenuI.X:
                        p.menuOptions.TryGetValue(MenuI.X, out title);
                        Console.Title = title ?? "Stock Control Alpha";
                        Console.SetCursorPosition(35, 0);
                        Console.WriteLine("Exiting Now..");
                        Environment.Exit(0);
                        break;
                }
            } while (repeat); 
            Console.ReadKey();
        }

        private void UpdateProduct()
        {
            throw new NotImplementedException();
        }

        private void UpdateStock()
        {
            throw new NotImplementedException();
        }

        private void ProduceST()
        {
            throw new NotImplementedException();
        }

        private void FindProduct()
        {
            throw new NotImplementedException();
        }

        private void AddProduct()
        {
            
            throw new NotImplementedException();
        }

        //The menu display method
        private MenuI Menu()
        {
            //Menu Entries and Descriptions
            menuOptions.Add(MenuI.A, "Add a Product");
            menuOptions.Add(MenuI.F, "Find a Product");
            menuOptions.Add(MenuI.U, "Update Product Details");
            menuOptions.Add(MenuI.S, "Update Stock Levels for Products");
            menuOptions.Add(MenuI.R, "Produce Stock-take Report");
            menuOptions.Add(MenuI.X, "Exit");

            //Heading
            Console.Title = "Stock Control Alpha on " + Environment.OSVersion;
            Console.Write(Environment.UserName + ", please enter your option here: ");

            //INIT HYPERDRIVE CURSOR JUMP
            int cachedtop = Console.CursorTop;
            int cachedLeft = Console.CursorLeft;
            //PSHHHUUUUUUU~~~~~~~~~~~~~~~~
            Console.SetCursorPosition(0, 19);

            //Print Menu Dictionary
            foreach (KeyValuePair<MenuI, string> menuEntry in menuOptions)
            {
                Console.WriteLine(menuEntry);
            }
            
            //JUMP BACK
            Console.SetCursorPosition(cachedLeft, cachedtop);
            string cursor = Console.ReadKey().KeyChar.ToString().ToUpper();

            //Go forward with the menu selection
            MenuI optionResult;
            Enum.TryParse<MenuI>(cursor, out optionResult);
            
            Console.WriteLine(menuOptions.ContainsKey(optionResult) ? Environment.NewLine + "Fuck yeah america" : Environment.NewLine + "I don't think i can do that, " + Environment.UserName);
            return optionResult;
        }
    }
}
