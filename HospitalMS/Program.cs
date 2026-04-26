using System;
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
            Console.WriteLine($"[Rejected] invalid data: {ex.Message}");
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
            admitted.Add(p3);
            Console.WriteLine($"[OK] Admitted :{p3.patientName} (ID: {p3.patientId})");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"[Rejected] {ex.Message}");
        }
        //Patient 04:Invalid -negative ID
        try
        {
            var p4=new PediatricPatient("Ayan",-5,"MRS.Nusrat","INS-P-004");
            admitted.Add(p4);
        }
        catch(ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"[Rejected] out of range {ex.ParamName} = {ex.ActualValue}");
        }
        catch(ArgumentException ex)
        {
            Console.WriteLine($"[Rejected] {ex.Message}");
        }
        Console.WriteLine($"\nTotal admitted: {admitted.Count} out of 4 attempted.");
        Console.WriteLine("\n======== Treatment Reports========");
        Console.WriteLine();
        foreach(Patient p in admitted)
        {
            try
            {
                p.GenerateReport();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"[Error] Failed to generate report:{ex.Message}");
            }
            Console.WriteLine();
        }
        Console.WriteLine("========Insurance Claims========");
        Console.WriteLine();
        foreach(Patient p in admitted)
        {
            if(p is IInsurable Insured)
            {
                bool started=false;
                try
                {
                    Console.WriteLine($"[Claim] Starting claim for {p.patientName}");
                    started=true;
                    Console.WriteLine(Insured.GetInsuranceDetails());
                    Insured.ProcessInsurableClaim();
                    Console.WriteLine($"[Claim] completed successfully.");
                }
                catch(InvalidOperationException ex)
                {
                    Console.WriteLine($"[Claim failed] {ex.Message}");
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"[Claim Error] Unexpected: {ex.Message}");
                }
                finally
                {
                    if(started)
                    Console.WriteLine($"[Log] Claim attempt for {p.patientName} recorded.");
                    Console.WriteLine();
                }
            }
        }
        Console.WriteLine("======== Patient Transpers ========");
        Console.WriteLine();
        foreach(Patient p in admitted)
        {
            if(p is Itransferable transperable)
            {
                try
                {
                    transperable.TransferTo("ICU");
                }
                catch(InvalidOperationException ex)
                {
                    Console.WriteLine($"[Transper Failed] {ex.Message}");
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"[Transper Error] {ex.Message}");
                }
            }
        }
    }
}