namespace DotnetAngular.Dtos
{
    public record AddressDto()
    {
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
