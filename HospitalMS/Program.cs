using System;
using System.Linq.Expressions;
//using BuildingAHospitalManagementSystem;
class EntryPoint
{
 static void Main()
 {
 Patient[] patients=new Patient[]
 {
 new GeneralPatient("Rahim",101,"Fever,Cough","INS-G-001"),
 new EmergencyPatient("Karim",102,"Cardiac Arrest"),
 new SurgeryPatient("Fatema",103,"Appendectomy","Dr.Khan","INS-S-003"),
 new PediatricPatient("Ayan",104,"MD Alam","INS-P-004"),
 new GeneralPatient("Test",99,"Flu","INS-001")
 };
 //Patient p1=new Patient("Test",99);
 //Patient p2=new GeneralPatient("Test",99,"Flu","INS-001");
 foreach(Patient p in patients)
 {
 p.GenerateReport();
 }
 Console.WriteLine("========Insurance claim processing=========");
 Console.WriteLine();
 foreach(Patient p in patients)
 {
 if( p is IInsurable insuredPatient)
 {
 Console.WriteLine(insuredPatient.GetInsuranceDetails());
 insuredPatient.ProcessInsurableClaim();
 Console.WriteLine();
 }
 }
 Console.WriteLine("========Patient Transpers ==========");
 Console.WriteLine();
 foreach(Patient p in patients)
 {
 if(p is Itransferable transperable)
 {
 transperable.TransferTo("ICU");
 }
 }
 Patient sp=new SurgeryPatient("Fatema",103,"Appendectomy","Dr.Khan","INS-S-003");
 sp.Treat();
 if(sp is IBillable billable)
 {
 Console.WriteLine($"The bill before discount is {billable.CalculateBill()}");
 billable.ApplyDiscount(10);
 Console.WriteLine($"After discount the bill is {billable.CalculateBill()}");
 }
 static void ProcessAllInsurance(Patient[] patients)
 {
 foreach(Patient p in patients)
 {
 if(p is IInsurable insuredPatient)
 {
 Console.WriteLine(insuredPatient.GetInsuranceDetails());
 insuredPatient.ProcessInsurableClaim();
 Console.WriteLine();
 }
 }
 }
 ProcessAllInsurance(patients);
 Console.WriteLine("=====Encapsulation tests=====");
 Console.WriteLine();
 //test-01:Empty name should throw
 try
 {
 var bad1=new GeneralPatient("",201,"Fever","INS-001");
 }
 catch(ArgumentException ex)
 {
 Console.WriteLine($"[validation] Rejected:{ex.Message}");
 }
 //Test 2: Negative ID (should throw)
 try
 {
 var bad2=new GeneralPatient("Test",-5,"Fever","INS-001");
 }
 catch(ArgumentException ex)
 {
 Console.WriteLine($"[validation] Rejected: {ex.Message}");
 }
 //Test 3: Empty symptoms (should throw)
 try
 {
 var bad3=new GeneralPatient("Test",201,"","Ins-001");
 }
 catch(ArgumentException ex)
 {
 Console.WriteLine($"[validation] Rejected: {ex.Message}");
 }
 Patient p__=new GeneralPatient("Rahim",101,"Fever","INS-001");
 //p__.patientId=999;//error CS0200: Property or indexer 'Patient.patientId' cannot be assignedto -- it is read only
 //p__.Billamount=-500;//error CS0272: The property or indexer 'Patient.Billamount' cannot be used in this context because the set accessor is inaccessible
 //p__.AdmissionDate=..;// error CS0200: Property or indexer 'Patient.AdmissionDate' cannot be assigned to -- it is read only
 Console.WriteLine($"Patient:{p__.patientName},ID: {p__.patientId}, Bill: {p__.Billamount}");
}
}