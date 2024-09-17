namespace aubh.ecashier.Models

{
    public class InventoryItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int SKU { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        public int Tax { get; set; }
        public int Notification { get; set; }
        public string Description { get; set; }
        public bool AnyPrice { get; set; }

    }
}
