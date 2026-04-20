namespace PROG7311_ST10443399_POE.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client? Client { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; } = "Draft"; // Draft/Active/Expired/On Hold
        public string ServiceLevel { get; set; } = string.Empty;
        public string? SignedAgreementPath { get; set; } // PDF Path
    }
}
