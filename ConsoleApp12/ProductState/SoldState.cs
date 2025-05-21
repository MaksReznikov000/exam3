namespace ConsoleApp12.ProductState;

public class SoldState : IProductState
{
    public void RaisePrice(Product p)
    {
        throw new Exception("товар продан, невозможно изменить");
    }

    public void SetUp(Product p)
    {
        throw new Exception("товар продан, невозможно изменить");
    }

    public void SetOff(Product p)
    {
        throw new Exception("товар продан, невозможно изменить");
    }

    public void GiveToTheWinner(Product p)
    {
        throw new Exception("товар продан, невозможно изменить");
    }
}