using System;
class PediatricPatient : Patient,IInsurable
{
 private string _gInsuranceId;
 private string _GurdianName;
 public string gInsuranceId
 {
 get{return _gInsuranceId;}
 private set
 {
 if(string.IsNullOrWhiteSpace(value))
 throw new InvalidPatientDataException("Gurdian name",value?? "null");
 _gInsuranceId=value;
 }
 }
 public string GurdianName
 {
 get{return _GurdianName;}
 private set
 {
 if(string.IsNullOrWhiteSpace(value))
 throw new InvalidPatientDataException("Gurdian name",value??"null");
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
    if(Billamount<0)
 Console.WriteLine($"[Insurance] processing claim for {patientName}");
 Console.WriteLine($" Insurance Id: {gInsuranceId} | calim Amount: BDT {Billamount}");
 }
 public string GetInsuranceDetails()
 {
 return $"provider: childcarePlan | ID: {gInsuranceId} | status:Active";
 }
}