using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using CsvHelper;
using InsuranceClaimsApi.Model;
using Microsoft.AspNetCore.Hosting;

namespace InsuranceClaimsApi.BusinessService
{
    public class InsuranceClaimService
    {
        private IWebHostEnvironment HostingEnvironment;
        private string MemberFilePath => Path.Combine(HostingEnvironment.ContentRootPath,"Data\\Member.csv");
        private string ClaimFilePath => Path.Combine(HostingEnvironment.ContentRootPath, "Data\\Claim.csv");
        public InsuranceClaimService(IWebHostEnvironment environment)
        {
            HostingEnvironment = environment;
        }
        private Member GetMember(int memberId)
        {
            Member member = new Member();
            using (var reader = new StreamReader(MemberFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                member = csv.GetRecords<Member>().FirstOrDefault(p => p.MemberID == memberId);
            }
            return member;
        }

        public List<Member> GetMemberClaimsByDate(DateTime date)
        {
            List<Member> members = new List<Member>();
            using (var reader = new StreamReader(ClaimFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var claims = csv.GetRecords<Claim>().Where(p => p.ClaimDate.Date == date.Date).GroupBy(p => p.MemberID);
                foreach (var item in claims)
                {
                    Member m = GetMember(item.Key);
                    m.Claims = item.ToList();
                    members.Add(m);
                }
            }
            return members;
        }
    }
}
