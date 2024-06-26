using Clean.Application.Models.Report;
using Dapper;
using MehrSepand.Framework.Dapper;
using System.Data;

namespace Ceal.Dapper
{
    public class PersonDapperService : DapperContext
    {
        public PersonDapperService(IDbConnection connection) : base(connection)
        {
        }


        public async Task<QueryCountryReportViewModel> GetPerson()
        {
            var result = new QueryCountryReportViewModel();

            var sql = @"select * from Person";

            /*
             * 
            #region Filter
            var filters = "";

            filters += $" FROM InsuranceCustomer icustomer" +
                   $" INNER JOIN InsuranceRequest request on  request.Id=icustomer.RequestId" +
                   $" INNER JOIN View_LoanRequest  loanRequest ON  loanRequest.Id=request.LoanRequestId" +
                   $" INNER JOIN View_LoanConfig loanConfig on   loanConfig.LoanType=196" +
                   $" INNER JOIN Project project on project.ProjectCode=request.ProjectId" +
                   $" INNER JOIN Agent agent on agent.AgentCode=request.AgentCode" +
                   $" INNER JOIN  Organization organization on organization.Id = agent.OrganizationId  " +
                   $" where" +
                   $" icustomer.CustomerType=0 " +
                   $" and (request.AttachmentId  is  null  or request.AttachmentId='' OR (request.AttachmentId is not null and request.AttachmentStep < request.Step))" +
                   $" and (request.Step=17 or request.Step=18) and request.IsDisabled <> 1 and " +
                   $" (organization.Disabled  is null or organization.Disabled <> 1)  and (agent.Disabled  is null or agent.Disabled <> 1) and  " +
                   $" (CAST(request.CreateDate AS Date) <> CAST(GETDATE() AS Date) and CAST(request.CreateDate AS Date) <> CAST(DATEADD(day, -1, GETDATE()) AS Date)) ";


            if (!mehrSepandIdentity.Roles.Any(s => s.Contains("InsuranceEngineAdminPanel")))
                filters += $" and  request.BranchCode={mehrSepandIdentity.BranchId} ";

            if (query.OrganizationId != null)
                filters += " and  agent.OrganizationId=" + query.OrganizationId;

            if (!string.IsNullOrEmpty(query.FromDate))
                filters += " and  CONVERT(int,FORMAT(request.CreateDate, 'yyyyMMdd')) >= CONVERT(int,REPLACE('" + query.FromDate + "','-','')) ";

            if (!string.IsNullOrEmpty(query.ToDate))
                filters += " and CONVERT(int,FORMAT(request.CreateDate, 'yyyyMMdd')) <= CONVERT(int,REPLACE('" + query.ToDate + "','-','')) ";

            sql += filters;
            count += filters;
            #endregion

            #region Order
            var order = " Order by request.CreateDate ";
            if (!string.IsNullOrEmpty(query.OrderBy))
                order = " Order by " + query.OrderBy;

            if (!query.IsAsc)
                order += " Desc ";

            sql += order;
            #endregion

            #region Paging
            if (query.PageNumber.HasValue || query.PageSize.HasValue)
            {
                var paging = " OFFSET ((" + query.PageNumber + " ) * " + query.PageSize + ")  ROWS "; //skip
                paging += " FETCH NEXT " + query.PageSize + " ROWS ONLY  ";//take
                sql += paging;
            }
            #endregion
             * */

            Connection.Open();
            var grid = await Connection.QueryMultipleAsync(sql);
            var request = await grid.ReadAsync<QueryCountryReportViewModel>();
            result.QueryCountryDetails = (IEnumerable<QueryCountryDetailViewModel>)request.ToList();
            Connection.Close();
            return result;
        }

    }
}
