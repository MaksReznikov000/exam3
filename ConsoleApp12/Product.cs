using System.Text.Json.Serialization;
using ConsoleApp12.ProductState;

namespace ConsoleApp12;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public string Honorary_code { get; set; }
    public string State { get; set; }
    [JsonIgnore]
    public IProductState StateObj { get; set; }
    
    public Product() {}

    public Product(int id, string name, int price)
    {
        Id = id;
        Name = name;
        Price = price;
        Honorary_code = "";
        State = "in_stock";
        StateObj = new InStockState();
    }

    public void FillState()
    {
        if (State == "in_stock")
            StateObj = new InStockState();
        else if (State == "for_sale")
            StateObj = new ForSaleState();
        else
            StateObj = new SoldState();
    }

    public void RaisePrice() => StateObj.RaisePrice(this);
    public void SetUp() => StateObj.SetUp(this);
    public void SetOff() => StateObj.SetOff(this);
    public void GiveToTheWinner() => StateObj.GiveToTheWinner(this);
}