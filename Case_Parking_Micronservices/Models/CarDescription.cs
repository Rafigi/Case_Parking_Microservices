namespace Case_Parking_Microservices.Models
{
    public class CarDescription
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Variant { get; set; }

        public static CarDescription NONE = new CarDescription();
    }
}
