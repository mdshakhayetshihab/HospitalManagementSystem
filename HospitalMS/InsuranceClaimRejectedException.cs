using Medicare;

public class InsuranceClaimRejectedException : MedicareException
{
    public string InsuranceId{get;}
    public string Reason{get;}
    public double ClaimAmount{get;}
    public InsuranceClaimRejectedException(string insuranceId,double claimAmount,string reason):base($"Claim rejected for {insuranceId}: {reason}")
    {
        InsuranceId=insuranceId;
        Reason=reason;
        ClaimAmount=claimAmount;
    }
    public InsuranceClaimRejectedException(string message,Exception inner):base(message,inner){}
}