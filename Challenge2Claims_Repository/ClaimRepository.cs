using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2Claims_Repository
{
    public class ClaimRepository
    {
        public Queue<Claim> _queueOfClaims = new Queue<Claim>();

        // Create
        public void AddClaimToQueue(Claim newClaim)
        {
            _queueOfClaims.Enqueue(newClaim);
        }

        // Read
        public Queue<Claim> GetClaims()
        {
            return _queueOfClaims;
        }

        // Helper
        public Claim GetClaimById(int claimId)
        {
            foreach (Claim claim in _queueOfClaims)
            {
                if (claim.ClaimID == claimId)
                {
                    return claim;
                }
            }

            return null;
        }
    }
}
