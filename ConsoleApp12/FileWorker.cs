using System.Text.Json;

namespace ConsoleApp12;

public static class FileWorker
{
    public static Product[]? Products { get; private set; }
    private static string _path = "../../../data.json";
    
    public static Product[]? GetProducts()
    {
        try
        {
            if (Products == null || Products.Length == 0)
            {
                if (!File.Exists(_path))
                {
                    File.WriteAllText(_path, "[]");
                }
                string json = File.ReadAllText(_path);
                if (json == "")
                {
                    json = "[]";
                }
                Products = JsonSerializer.Deserialize<Product[]>(json);
                if (Products.Length == 0)
                {
                    GenerateProducts();
                    OverrideFile();
                }
                foreach (Product? p in Products)
                    p.FillState();
            }
            return Products;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Products = new Product[0];
            return GetProducts();
        }
    }

    public static void OverrideFile()
    {
        try
        {
            File.WriteAllText(_path, JsonSerializer.Serialize(Products));
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    private static void GenerateProducts()
    {
        try
        {
            Console.WriteLine("Сколько продуктов вы хотите сгенерировать?");
            int count = Convert.ToInt32(Console.ReadLine());
            string[] names = {"iphone", "car", "apple" };
            Products = new Product[count];
            for (int i = 0; i < count; i++)
            {
                Products[i] = new Product(i, names[new Random().Next(0,3)], new Random().Next(100, 1001));
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            GetProducts();
        }
    }
}