namespace Domain.Services.Contracts.Consultant
{
    public class ReadedConsultantContract 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public string AdditionalInformation { get; set; }
    }
}