using System;
class SurgeryPatient : Patient,IInsurable,Itransferable,IBillable
{
 private string _surgeryType;
 private string _SurgeonName;
 private string _InsuranceId;
 public string surgeryType{
 get{return _surgeryType;}
 private set
 {
 if(string.IsNullOrWhiteSpace(value))
 throw new InvalidPatientDataException("Surgery type",value ?? "null");
 _surgeryType=value;
 }
 }
 public string SurgeonName
 {
 get{return _SurgeonName;}
 private set
 {
 if(string.IsNullOrWhiteSpace(value))
 throw new InvalidPatientDataException("Surgron name",value?? "null");
 _SurgeonName=value;
 }
 }
 public string InsuranceId
 {
 get{return _InsuranceId;}
 private set
 {
 if(string.IsNullOrWhiteSpace(value))
 throw new ArgumentException("Insurance id cannot be empty");
 _InsuranceId=value;
 }
 }
 public double percentage;
 public SurgeryPatient(string name,int id,string sType,String sNAme,string I_Id):base (name,id)
 {
 surgeryType=sType;
 SurgeonName=sNAme;
 InsuranceId=I_Id;
 }
 public override void Diagnose()
 {
 Console.WriteLine($"[Diagnose] patient #{patientId} {patientName} :pre-surgical assesment for {surgeryType}");
 }
 public override void Treat()
 {
 Console.WriteLine($"Preparing OT ->Anesthesia->{SurgeonName}->performing{surgeryType}");
 SetBillAmount(25000);
 }
 public void ProcessInsurableClaim()
 {
    if(Billamount<=0)
    throw new InvalidOperationException($"Cannot process insurance for {patientName}: treatment has not been completed yet.");
 Console.WriteLine($"[Insurance] processing claim for {patientName}");
 Console.WriteLine($" Insurance Id: {InsuranceId} | calim Amount: BDT {Billamount:N0}");
 }
 public string GetInsuranceDetails()
 {
 return $"provider: MediShield | ID: {InsuranceId} | status:Active";
 }
 public void TransferTo(string department)
 {
   Random rng=new Random();
   if(rng.Next(0,3)==0)
   throw new BedUnavailableException(department,20,20);
 Console.WriteLine($"[Transper] post -op : Moving {patientName} from ER to {department}");
 }
 public double CalculateBill()
 {
 return Billamount;
 }
 public void ApplyDiscount(double percentage)
 {
 //Billamount=Billamount-Billamount*(percentage/100);
 SetBillAmount(Billamount-Billamount*(percentage/100));
 }
}