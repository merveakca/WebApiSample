namespace WebApiSample.DTO;

public class GetAllProductsResponseDto
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public decimal? UnitPrice { get; set; }
    public int? UnitsInStock { get; set; }
}
