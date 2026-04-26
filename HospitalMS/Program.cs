using System;
using System.Runtime.InteropServices.Marshalling;
class EntryPoint
{
    static void Main()
    {
        Console.WriteLine("========Admitting Patients========");
        Console.WriteLine();
        List<Patient> admitted=new List<Patient>();
        //Patient 1:valid
        try
        {
            var p1=new GeneralPatient("Rahim",101,"Fever,Cough","INS-G-001");
            admitted.Add(p1);
            Console.WriteLine($"[OK] Admitted:{p1.patientName} (ID: {p1.patientId})");
        }
        catch(ArgumentNullException ex)
        {
            Console.WriteLine($"[Rejected] Missing required field: {ex.ParamName}");
        }
        catch(ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"[Rejected] Value out of range: {ex.Message}");
        }
        catch(ArgumentException ex)
        {
            Console.WriteLine($"[Rejected invalid data: {ex.Message}]");
        }
        //Patient 2:Invalid
        try
        {
            var p2=new EmergencyPatient("",102,"Cardiac arrest");
            admitted.Add(p2);
        }
        catch(ArgumentNullException ex)
        {
            Console.WriteLine($"[Rejected] Missing field: {ex.ParamName}");
        }
        catch(ArgumentException ex)
        {
           Console.WriteLine($"[Rejected] {ex.Message}"); 
        }
        //Patient 3:valid
        try
        {
            var p3=new SurgeryPatient("Fatema",103,"Appendectomy","Dr.Khan","INS-S-003");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"[Rejected] {ex.Message}");
        }
    }
}