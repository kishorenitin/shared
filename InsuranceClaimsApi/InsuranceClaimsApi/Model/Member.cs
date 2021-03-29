using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceClaimsApi.Model
{
    public class Member
    {
        public int MemberID { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        private List<Claim> _claims;

        public List<Claim> Claims
        {
            get
            {
                if (_claims == null)
                {
                    _claims = new List<Claim>();
                }
                return _claims;
            }
            set { _claims = value; }
        }
    }
}
