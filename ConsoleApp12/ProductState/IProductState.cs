namespace ConsoleApp12.ProductState;

public interface IProductState
{
    void RaisePrice(Product p);
    void SetUp(Product p);
    void SetOff(Product p);
    void GiveToTheWinner(Product p);
}