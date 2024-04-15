namespace WebApiSample.DTO;

public class GetProductByIdResponseDto
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public decimal? UnitPrice { get; set; }
    public int? UnitsInStock { get; set; }

    public string QuantityPerUnit { get; set; }
}
