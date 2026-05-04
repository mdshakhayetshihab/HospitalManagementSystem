using System;
using Medicare;
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
        catch(InvalidPatientDataException ex)
        {
            Console.WriteLine($"[Rejected] Field: {ex.Fieldname},Value:{ex.InvalidValue}");
        }
        catch(MedicareException ex)
        {
            Console.WriteLine($"[Hospital Error] {ex.Message}");
        }
        catch(Exception ex)
        {
            Console.WriteLine($"[System Error] invalid data: {ex.Message}");
        }
        //Patient 2:Invalid
        try
        {
            var p2=new EmergencyPatient("",102,"Cardiac arrest");
            admitted.Add(p2);
        }
        catch(InvalidPatientDataException ex)
        {
            Console.WriteLine($"[Rejected] Missing field: {ex.Fieldname}, Value:{ex.InvalidValue}");
        }
        catch(MedicareException ex)
        {
           Console.WriteLine($"[Hospital Error] {ex.Message}"); 
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        //Patient 3:valid
        try
        {
            var p3=new SurgeryPatient("Fatema",103,"Appendectomy","Dr.Khan","INS-S-003");
            admitted.Add(p3);
            Console.WriteLine($"[OK] Admitted :{p3.patientName} (ID: {p3.patientId})");
        }
        catch (InvalidPatientDataException ex)
        {
            Console.WriteLine($"[Rejected] Field {ex.Fieldname}, Value: {ex.InvalidValue}");
        }
        catch(MedicareException ex)
        {
            Console.WriteLine($"[Hospital Error] {ex.Message}");
        }
        catch(Exception ex)
        {
            Console.WriteLine($"[System Error] {ex.Message}");
        }
        //Patient 04:Invalid -negative ID
        try
        {
            var p4=new PediatricPatient("Ayan",-5,"MRS.Nusrat","INS-P-004");
            admitted.Add(p4);
        }
        catch(InvalidPatientDataException ex)
        {
            Console.WriteLine($"[Rejected] Field: {ex.Fieldname}, Value: {ex.InvalidValue}");
        }
        catch(MedicareException ex)
        {
            Console.WriteLine($"[Hospital Error] {ex.Message}");
        }
        catch(Exception ex)
        {
            Console.WriteLine($"[System Error {ex.Message}]");
        }
        Console.WriteLine($"\nTotal admitted: {admitted.Count} out of 4 attempted.");
        Console.WriteLine("\n======== Treatment Reports========");
        Console.WriteLine();
        admitted.Add(null);
        foreach(Patient p in admitted)
        {
            try
            {
                if(p==null)
                throw new NullReferenceException("Patient reference is null");
                p.GenerateReport();
            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine($"[Error] Null patient fount: {ex.Message}");
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
                catch(InsuranceClaimRejectedException ex)
                {
                    Console.WriteLine($"[Claim Denied] {ex.Message}");
                    Console.WriteLine($"Insurance: {ex.InsuranceId} | Amount: BDT {ex.ClaimAmount:N0}");
                    Console.WriteLine($"Reason: {ex.Reason}");
                    if(ex.InnerException!=null)
                    Console.WriteLine($" Root Cause: {ex.InnerException.Message}");
                }
                catch(MedicareException ex)
                {
                    Console.WriteLine($"[Hospital Error] {ex.Message}");
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"[System Error] {ex.Message}");
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
                catch(BedUnavailableException ex)
                {
                    Console.WriteLine($"[Transper Denied] {ex.Message}");
                    Console.WriteLine($" Department: {ex.Department}");
                    Console.WriteLine($" Occupancy: {ex.CurrentOccupancy}/{ex.Capacity}");
                    Console.WriteLine($" Action: {p.patientName} placed on waiting list.");
                }
                catch(MedicareException ex)
                {
                    Console.WriteLine($"[Transper Error] {ex.Message}");
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"[System Error] {ex.Message}");
                }
            }
        }
    }
}