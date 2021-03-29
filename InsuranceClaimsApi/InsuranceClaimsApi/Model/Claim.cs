using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InsuranceClaimsApi.Model
{
    public class Claim
    {
        [JsonIgnore]
        public int MemberID { get; set; }
        public DateTime ClaimDate { get; set; }
        public double ClaimAmount { get; set; }
    }
}
