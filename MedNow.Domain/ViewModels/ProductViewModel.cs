using System;

namespace MedNow.Domain.ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal? Price { get; set; }

        public decimal? PromotionalPrice { get; set; }

        public string ImagePath { get; set; }

        public string Description { get; set; }

        public decimal? TotalValue { get; set; }

        public int? Quantity { get; set; }
    }
}
