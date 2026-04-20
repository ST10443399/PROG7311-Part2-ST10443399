namespace PROG7311_ST10443399_POE.Models
{
    public class ServiceRequest
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public Contract? Contract { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal CostUSD { get; set; }
        public decimal CostZAR { get; set; }
        public string Status { get; set; } = "Pending";
    }
}
