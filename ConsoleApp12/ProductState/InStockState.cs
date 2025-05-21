namespace ConsoleApp12.ProductState;

public class InStockState : IProductState
{
    public void RaisePrice(Product p)
    {
        throw new Exception("товар на складе, невозможно поднять цену");
    }

    public void SetUp(Product p)
    {
        Console.WriteLine("Товар успешно выставлен на торги");
        p.State = "for_sale";
        p.StateObj = new ForSaleState();
    }

    public void SetOff(Product p)
    {
        throw new Exception("товар на складе, невозможно снять с торгов");
    }

    public void GiveToTheWinner(Product p)
    {
        throw new Exception("товар на складе, невозможно отдать победителю");
    }
}