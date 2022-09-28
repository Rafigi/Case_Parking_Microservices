namespace Case_Parking_Microservices.Models
{
    public class Email
    {
        public string receiver { get; set; } //modtagerens email-adresse
        public string message { get; set; } //beskedens indhold
        public string subject { get; set; } //beskedes titel
        public string html { get; set; } // besked formatteret i html(valgfrit)
    }
}
