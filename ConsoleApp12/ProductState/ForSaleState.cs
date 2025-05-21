namespace ConsoleApp12.ProductState;

public class ForSaleState : IProductState
{
    private int GetPrice()
    {
        try
        {
            Console.WriteLine("Введите цену, на которую хотите поднять товар");
            int num = Convert.ToInt32(Console.ReadLine());
            if (num < 0)
                throw new FormatException();
            return num;
        }
        catch (FormatException)
        {
            Console.WriteLine("Неверное значение, попробуйте снова");
            return GetPrice();
        }
    }
    public void RaisePrice(Product p)
    {
        int num = GetPrice();
        p.Price += num;
        Console.WriteLine("Цена успешно повышена");
    }

    public void SetUp(Product p)
    {
        throw new Exception("Уже на торгах");
    }

    public void SetOff(Product p)
    {
        Console.WriteLine("Товар успешно снят с торгов");
        p.State = "in_stock";
        p.StateObj = new InStockState();
    }

    public void GiveToTheWinner(Product p)
    {
        if (p.Price > 0)
        {
            Console.WriteLine("Продукт успешно продан");
            if (p.Price >= 1000)
                p.Honorary_code = Generator.CalculateMD5Hash("Gold-" + p.Id);
            else if(p.Price >= 500)
                p.Honorary_code = Generator.CalculateMD5Hash("Silver-" + p.Id);
            else
                p.Honorary_code = Generator.CalculateMD5Hash("Bronze-" + p.Id);
            p.State = "sold";
            p.StateObj = new SoldState();
        }
        else
        {
            throw new Exception("Нельзя отдавать товар бесплатно");
        }
    }
}