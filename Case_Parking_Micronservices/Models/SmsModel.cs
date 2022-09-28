namespace Case_Parking_Microservices.Models
{
    /// <summary>
    /// The Properties names need to be in smallcases, because it's used as a JSON object.
    /// </summary>
    public class SmsModel
    {
        public string receiver { get; set; } // number for the reciver
        public int key { get; set; } //Den unikke nøgle som giver dig adgang til at sende til din egen telefon
        public string message { get; set; } //Den besked der skal sendes // The message to be send
    }
}
