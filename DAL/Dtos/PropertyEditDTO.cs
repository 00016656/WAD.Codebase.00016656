﻿namespace WAD.Codebase._00016656.Dtos
{
    public class PropertyEditDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public double SquareFeet { get; set; }
        public string PropertyType { get; set; }
        public DateTime ListedDate { get; set; }
    }
}
