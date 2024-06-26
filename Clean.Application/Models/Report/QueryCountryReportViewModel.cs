namespace Clean.Application.Models.Report
{
    public class QueryCountryReportViewModel
    {
        public IEnumerable<QueryCountryDetailViewModel> QueryCountryDetails { get; set; }
    }

    public class QueryCountryDetailViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedDate { get; set; }
        public DateTime ActiveDate { get; set; }
    }
}
