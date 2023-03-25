namespace Project_Manager;

public class Task
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double Budget { get; set; }
    
    
   
    public void CreateTask(string name, string description, DateTime startDate, DateTime endDate, double budget)
    {
        Name = name;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
        Budget = budget;
    }
    
    

}