using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2Claims_Repository
{
    public enum ClaimTypes
    {
        Car = 1,
        Home,
        Theft
    }

    // Plain Old C# Object
    public class Claim
    {
        public int ClaimID { get; set; }
        public ClaimTypes ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfClaim { get; set; }
        public DateTime DateOfIncident { get; set; }
        public bool IsValid { get; set; }

        public Claim() {}

        public Claim(int claimId, ClaimTypes claimType, string description, double claimAmount, DateTime dateOfClaim, DateTime dateOfIncident, bool isValid)
        {
            ClaimID = claimId;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfClaim = dateOfClaim;
            DateOfIncident = dateOfIncident;
            IsValid = isValid;
        }
    }
}
