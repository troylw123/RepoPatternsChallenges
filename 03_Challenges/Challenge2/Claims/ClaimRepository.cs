namespace Claims;
public class ClaimRepository
{
    protected readonly List<ClaimData> _claimDataList = new List<ClaimData>();

    public bool AddClaimToList(ClaimData claim)
    {
        int initialCount = _claimDataList.Count;
        _claimDataList.Add(claim);
        bool wasAdded = (_claimDataList.Count > initialCount) ? true : false;
        return wasAdded;
    }

    public List<ClaimData> DisplayClaims()
    {
        return _claimDataList;
    }

    public ClaimData GetClaimByID(int claimID)
    {
        return _claimDataList.Find(i => i.ClaimID == claimID);

        // foreach (ClaimData claim in _claimDataList)
        // {
        //     if (claim.ClaimID == claimID)
        //     {
        //         return claim;
        //     }
        // }
        // return null;
    }
}