﻿namespace EfCore.Application.Contract.Product
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public string Category { get; set; }
        public bool IsRemoved { get; set; }
        public string CreationDate { get; set; }

    }
}