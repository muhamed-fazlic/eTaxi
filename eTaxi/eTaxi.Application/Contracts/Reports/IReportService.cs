using eTaxi.Application.DTOs.Reports;


namespace eTaxi.Application.Contracts.Reports
{
    public interface IReportService
    {
        Task<ReportDto> GetReportAsync(ReportSearchDTO search);
    }
}
