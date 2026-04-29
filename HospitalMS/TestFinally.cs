using System;
class FinallyReturn
{
   public static int TestFinallyReturn()
    {
        int result=0;
        try
        {
            result=1;
        }
        catch(Exception ex)
        {
            result=2;
        }
        finally
        {
            result= 3;
        }
        return result;
    }
}