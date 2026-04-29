using Medicare;

public class InvalidPatientDataException : MedicareException
{
 public string Fieldname {get;}
 public object InvalidValue{get;}
 public InvalidPatientDataException(string fieldName,object invalidValue):base($"Invalid value for '{fieldName}' : '{invalidValue}'")
 {
   Fieldname=fieldName;
   InvalidValue=invalidValue;
 }
 public InvalidPatientDataException(string message,Exception inner):base(message,inner){}
}
