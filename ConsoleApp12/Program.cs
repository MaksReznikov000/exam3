namespace ConsoleApp12;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            ShowProducts();
            ChooseProduct();
        }
    }

    static void ShowProducts()
    {
        Product[] products = FileWorker.GetProducts();
        Console.WriteLine("\u2116    | Продукт");
        foreach (var p in products)
        {
            Console.WriteLine($"{p.Id}    | {p.Name}");
        }
    }

    static void ChooseProduct()
    {
        try
        {
            Console.WriteLine("Введи id продукта");
            int id = Convert.ToInt32(Console.ReadLine());
            Product product = null;
            foreach (var p in FileWorker.GetProducts())
            {
                if (p.Id == id)
                {
                    product = p;
                }
            }
            if (product != null)
            {
                Console.WriteLine($"Id| Название | Цена | Состояние | Почетный код");
                Console.WriteLine($"{product.Id} | {product.Name} | {product.Price} | {product.State} | {product.Honorary_code}");
                Console.WriteLine("1 - Выставить на аукцион\n2 - Поднять цену\n3 - Выдать победителю\n4 - Снять с торгов\n5 - выйти из программы");
                string userAnswer = Console.ReadLine();
                switch (userAnswer)
                {
                    case "1":
                        product.SetUp();
                        break;
                    case "2":
                        product.RaisePrice();
                        break;
                    case "3":
                        product.GiveToTheWinner();
                        break;
                    case "4":
                        product.SetOff();
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("неизвестная команда");
                        ChooseProduct();
                        break;
                }
                FileWorker.OverrideFile();
            }
            else
            {
                Console.WriteLine("Неверный id");
                ChooseProduct();
            }
        }
        catch (Exception e)
        {
            ShowProducts();
            Console.WriteLine(e.Message);
            ChooseProduct();
        }
    }
}