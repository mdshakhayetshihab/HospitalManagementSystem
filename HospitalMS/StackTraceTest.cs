class StackTraceTest
{
    static void CreatePatientWithBadID()
    {
        int badID=-5;
        if(badID<0)
        throw new ArgumentOutOfRangeException(nameof(badID),badID,"Patient ID must be a positive number.");
    }
    static void InnerMethod_PreserveTrace()
    {
        try
        {
            CreatePatientWithBadID();
        }
        catch (ArgumentOutOfRangeException)
        {
            throw;
        }
    }
    static void InnerMethod_ResetTrace()
    {
        try
        {
            CreatePatientWithBadID();
        }
        catch(ArgumentOutOfRangeException ex)
        {
            throw ex;
        }
    }
    public static void RunTest()
    {
        Console.WriteLine("========Test-01:Throw; ========");
        try
        {
            InnerMethod_PreserveTrace();
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"{ex.Message}");
            Console.WriteLine(ex.StackTrace);
        }
        Console.WriteLine("========Test-02: Throw ex; ========");
        try
        {
            InnerMethod_ResetTrace();
        }
        catch(ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
        }
    }
}