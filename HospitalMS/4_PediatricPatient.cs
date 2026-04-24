using System;
class PediatricPatient : Patient,IInsurable
{
 private string _gInsuranceId;
 public string _GurdianName;
 public string gInsuranceId
 {
 get{return _gInsuranceId;}
 private set
 {
 if(string.IsNullOrWhiteSpace(value))
 throw new ArgumentException("gurdian insurance id cannot be empty");
 _gInsuranceId=value;
 }
 }
 public string GurdianName
 {
 get{return _GurdianName;}
 private set
 {
 if(string.IsNullOrWhiteSpace(value))
 throw new ArgumentException("Gurdian name cannot be empty");
 _GurdianName=value;
 }
 }
 public PediatricPatient(string name,int id,string gurdianName,string insuranceId) : base(name,
id)
 {
 GurdianName=gurdianName;
 gInsuranceId=insuranceId;
 }
 public override void Diagnose()
 {
 Console.WriteLine($"{patientName} (child) is being diagnosed.{GurdianName} is present for comfort.");
 }
 public override void Treat()
 {
 Console.WriteLine($"{patientName} is treated with pediatric-safemedicine and abravery sticker");
 SetBillAmount(1200);
 }
 public void ProcessInsurableClaim()
 {
 Console.WriteLine($"[Insurance] processing claim for {GurdianName}");
 Console.WriteLine($" Insurance Id: {gInsuranceId} | calim Amount: BDT {Billamount}");
 }
 public string GetInsuranceDetails()
 {
 return $"provider: childcarePlan | ID: {gInsuranceId} | status:Active";
 }
}