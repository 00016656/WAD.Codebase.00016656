namespace WAD.Codebase._00016656.Dtos
{
    public class CreatePropertyDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public double SquareFeet { get; set; }
        public string PropertyType { get; set; }
        public int UserId { get; set; } // Link to the user creating the property
    }
}
