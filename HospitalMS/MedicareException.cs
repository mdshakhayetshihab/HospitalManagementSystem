namespace Medicare
{
    public class MedicareException : Exception
    {
        public MedicareException():base("A Medicare+ system error occured."){}
        public MedicareException(string message):base(message){}
        public MedicareException(string message,Exception innerException):base(message,innerException){}
    }
}