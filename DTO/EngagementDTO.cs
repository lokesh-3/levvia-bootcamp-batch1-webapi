namespace DTO
{
    public class EngagementDTO
    {
        public int ClientId { get; set; }
        public int CountyId { get; set; }


        public string ClientName { get; set; }
        public string EngagementStartDate { get; set; }
        public string EngagementEndDate { get; set; }

        public List<int> Auditorids { get; set; }
    }
}