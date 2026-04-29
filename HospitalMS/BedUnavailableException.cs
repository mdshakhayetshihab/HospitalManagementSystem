using Medicare;

public class BedUnavailableException : MedicareException
{
    public string Department{get;}
    public int CurrentOccupancy{get;}
    public int Capacity{get;}
    public BedUnavailableException(string department,int occupancy,int capacity):base($"No beds in {department}:{occupancy}/{capacity} occupied")
    {
        Department=department;
        CurrentOccupancy=occupancy;
        Capacity=capacity;
    }
    public BedUnavailableException(string message,Exception inner):base(message,inner){}
}