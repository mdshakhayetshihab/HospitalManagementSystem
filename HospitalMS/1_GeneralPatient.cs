class GeneralPatient:Patient,IInsurable
{
 private string _symptoms;
 public string Symptoms
 {
 get{return _symptoms;}
 private set
 {
    if(value==null)
    throw new InvalidPatientDataException(Symptoms,value?? "null");
    _symptoms=value;
 }
 }
 private string _InsuranceId;
 public string InsuranceId
 {
 get{return _InsuranceId;}
 private set
 {
 if(string.IsNullOrWhiteSpace(value))
 throw new ArgumentException("Insurance cannot be empty");
 _InsuranceId=value;
 }
 }
 public GeneralPatient(string name,int id,string symptoms,string I_Id ) : base(name, id)
 {
 Symptoms=symptoms;
 InsuranceId=I_Id;
 }
 public override void Diagnose()
 {
 Console.WriteLine($"[Diagnose] Patient #{patientId} {patientName} general checkup | symptoms: {Symptoms}");
 }
 public override void Treat()
 {
 Console.WriteLine($"[Treat] prescribing medicine & rest for {patientName}");
 SetBillAmount(800);
 }
 public void ProcessInsurableClaim()
 {
      try
      {
         if(new Random().Next(0,4)==0)
         throw new Exception("Database connection timeout");
         Console.WriteLine($"[Insurance] claim processed for {patientName}");
      }
      catch(Exception ex)
      {
         throw new InsuranceClaimRejectedException($"Claim failed for {patientName} due to system error",ex);
      }
 }
 public string GetInsuranceDetails()
 {
 return $"provider: National Health | ID: {InsuranceId} | status:Active";
 }
}