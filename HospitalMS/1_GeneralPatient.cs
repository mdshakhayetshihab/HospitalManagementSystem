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
 Console.WriteLine($"[Insurance] processing claim for {patientName}");
 Console.WriteLine($" Insurance Id: {InsuranceId} | calim Amount: BDT {Billamount}");
 }
 public string GetInsuranceDetails()
 {
 return $"provider: National Health | ID: {InsuranceId} | status:Active";
 }
}