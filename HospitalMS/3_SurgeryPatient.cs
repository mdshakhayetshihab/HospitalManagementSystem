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
 throw new ArgumentException("Surgery type cannot be empty");
 _surgeryType=value;
 }
 }
 public string SurgeonName
 {
 get{return _SurgeonName;}
 private set
 {
 if(string.IsNullOrWhiteSpace(value))
 throw new ArgumentException("Surgeon name cannot be empty");
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
 Console.WriteLine($"[Diagnose] patient #{patientId} {patientName} :pre-surgical assesment for Appendectomy");
 }
 public override void Treat()
 {
 Console.WriteLine($"Preparing OT ->Anesthesia->{SurgeonName}->performing{surgeryType}");
 SetBillAmount(25000);
 }
 public void ProcessInsurableClaim()
 {
 Console.WriteLine($"[Insurance] processing claim for {patientName}");
 Console.WriteLine($" Insurance Id: {InsuranceId} | calim Amount: BDT {Billamount}");
 }
 public string GetInsuranceDetails()
 {
 return $"provider: MediShield | ID: {InsuranceId} | status:Active";
 }
 public void TransferTo(string department)
 {
 Console.WriteLine($"[Transper] post -op : Moving {patientName} from ER to {department}");
 }
 public double CalculateBill()
 {
 return Billamount;
 }
 public void ApplyDiscount(double percentage)
 {
 Billamount=Billamount-Billamount*(percentage/100);
 }
}