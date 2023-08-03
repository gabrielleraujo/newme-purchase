namespace Newme.Purchase.Application.Consulting.ConsultingModels
{
    public class ProductConsultingModel : ConsultingModel
    {
        public ProductConsultingModel(
            string name, 
            string description, 
            string category,
            string color, 
            string size)
        {
            Name = name;
            Description = description;
            Category = category;
            Color = color;
            Size = size;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
    }
}