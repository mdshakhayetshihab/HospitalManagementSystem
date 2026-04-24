using System;
using System.Reflection.Metadata.Ecma335;
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
 throw new ArgumentNullException("Patient name cannot be empty or whitespace.");
 _patientName=value.Trim();
 }
 }
public double setBillamount{get;protected set;}
public Patient(string s,int i)
{
patientName=s;
if(i<0)
throw new ArgumentException("Patient Id must be positive");
_patientId=i;
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
 throw new ArgumentException("Bill amount cannot be negative.");
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