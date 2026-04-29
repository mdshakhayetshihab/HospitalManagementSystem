using System;
abstract class Patient
{
private string _patientName;
private int _patientId;
public DateTime AdmissionDate {get;}
public string patientName
 {
 get{return _patientName;}
 set
 {
   if(string.IsNullOrWhiteSpace(value))
   throw new InvalidPatientDataException("PatientName",value?? "null");
 _patientName=value.Trim();
 }
 }
//public double setBillamount{get;protected set;}
public Patient(string s,int PatientId)
{
patientName=s;
if(PatientId<=0)
throw new InvalidPatientDataException("PatientId",patientId);
_patientId=PatientId;
AdmissionDate=DateTime.Now;
}
public int patientId
 {
 get{return _patientId;}
 }
 public double Billamount{get;protected set;}
 protected void SetBillAmount(double amount)
 {
 if(amount<0)
 throw new InvalidPatientDataException("BillAmount",amount);
 Billamount=amount;
 }
//public DateTime AdmissionDate {get;}
public abstract void Diagnose();
public abstract void Treat();
public void GenerateReport()
{
Diagnose();
Treat();
Console.WriteLine($"[Bill] Parient : {patientName} (ID:{patientId})");
Console.WriteLine($"Admitted: {AdmissionDate:yyyy-MM-dd HH:mm}");
Console.WriteLine($" Total:BDT{Billamount:N0}");
}
}