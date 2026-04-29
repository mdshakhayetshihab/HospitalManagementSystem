using System;
class EmergencyPatient : Patient,Itransferable
{
 private string _EmergencyType;
 public string EmergencyType
 {
 get{return _EmergencyType;}
 private set
 {
 if(string.IsNullOrWhiteSpace(value))
 throw new InvalidPatientDataException("Emergency Type",value?? "null");
 _EmergencyType=value;
 }
 }
 public EmergencyPatient(string name,int id,string E_Type):base(name,id)
 {
 EmergencyType=E_Type;
 }
 public override void Diagnose()
 {
 Console.WriteLine($"[Diagnose] patient #{patientId} {patientName}:Urgent triage | Emergency:{EmergencyType}");
 }
 public override void Treat()
 {
 Console.WriteLine($"Rushing to ER->IV drip->Calling specialist");
 SetBillAmount(4000);
 }
 public void TransferTo(string department)
 {
    Random rng=new Random();
    if(rng.Next(0,3)==0)
    throw new BedUnavailableException(department,20,20);
 Console.WriteLine($"[Transper] Urgent : Moving {patientName} to {department}");
 }
}