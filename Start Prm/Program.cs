using System;
using Project_Manager;
using TaskStatus = System.Threading.Tasks.TaskStatus;

namespace Project_Manager
{
    public class Program
    {
        static void Main(string[] args)
        {   
            string statement = "1";
            while (statement == "1")
            {
                {
                    Console.WriteLine("Please enter project name");
                    string projectName = Console.ReadLine();
                    Console.WriteLine("Please enter project description");
                    string projectDescription = Console.ReadLine();
                    Console.WriteLine("Please enter project start date in format \"yyyy-MM-dd\"");
                    DateTime projectStartDate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter project end date in format \"yyyy-MM-dd\"");
                    DateTime projectEndDate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter project budget");
                    double projectBudget = double.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter task name");
                    string taskName = Console.ReadLine();
                    Console.WriteLine("Please enter task description");
                    string taskDescription = Console.ReadLine();
                    Console.WriteLine("Please enter task start date in format \"yyyy-MM-dd\"");
                    DateTime taskStartDate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter task end date in format \"yyyy-MM-dd\"");
                    DateTime taskEndDate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter task budget");
                    double taskBudget = double.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter team member name");
                    string teamMemberName = Console.ReadLine();
                    Console.WriteLine("Please enter team member email");
                    string teamMemberEmail = Console.ReadLine();

                    Project project = new Project();
                    project.CreateProject(projectName, projectDescription, projectStartDate, projectEndDate,
                        projectBudget);

                    Task task1 = new Task();
                    task1.CreateTask(taskName, taskDescription, taskStartDate, taskEndDate, taskBudget);
                    project.AddTask(task1);

                    TeamMember teamMember1 = new TeamMember();
                    teamMember1.CreateTeamMember(teamMemberName, teamMemberEmail);
                    task1.AddTeamMember(teamMember1);
                    Console.WriteLine("If you want to exit pres 0 if not press 1");
                    statement = Console.ReadLine();
                    project.GenerateReport();
                    
                }
            }
           
        }

    }
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Budget { get; set; }
        public List<Task> Tasks { get; set; }
        public List<TeamMember> TeamMembers { get; set; }
        public Project()
        {
            Tasks = new List<Task>();
            TeamMembers = new List<TeamMember>();
        }
        public void ChangeProjectDescription(string newDescription)
        {
            this.Description = newDescription;
        }

        public void ChangeProjectStartDate(DateTime newStartDate)
        {
            this.StartDate = newStartDate;
        }

        public void ChangeProjectEndDate(DateTime newEndDate)
        {
            this.EndDate = newEndDate;
        }

        public void ChangeProjectBudget(double newBudget)
        {
            this.Budget = newBudget;
        }
        
        public void ChangeTaskName(Task task, string newName)
        {
            task.Name = newName;
        }

        public void ChangeTaskDescription(Task task, string newDescription)
        {
            task.Description = newDescription;
        }

        public void ChangeTaskStartDate(Task task, DateTime newStartDate)
        {
            task.StartDate = newStartDate;
        }

        public void ChangeTaskEndDate(Task task, DateTime newEndDate)
        {
            task.EndDate = newEndDate;
        }

        public void ChangeTaskBudget(Task task, double newBudget)
        {
            task.Budget = newBudget;
        }

        public void ChangeTeamMemberName(TeamMember teamMember, string newName)
        {
            teamMember.Name = newName;
        }

        public void ChangeTeamMemberEmail(TeamMember teamMember, string newEmail)
        {
            teamMember.Email = newEmail;
        }
        public void CreateProject(string Name, string Description, DateTime StartDate, DateTime EndDate, double Budget)
        {
            this.Name = Name;
            this.Description = Description;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.Budget = Budget;
        }

        public void AddTask(Task task)
        {
            Tasks.Add(task);
        }

        public void RemoveTask(Task task)
        {
            Tasks.Remove(task);
        }

        public void AddTeamMember(TeamMember teamMember)
        {
            TeamMembers.Add(teamMember);
        }

        public void RemoveTeamMember(TeamMember teamMember)
        {
            TeamMembers.Remove(teamMember);
        }

        public void ChangeTaskStatus(Task task, TaskStatus status)
        {
            task.Status = status;
        }

        public void GenerateReport()
        { 
            Console.WriteLine("Project Name: {0}", this.Name);
            Console.WriteLine("Project Description: {0}", this.Description);
            Console.WriteLine("Project Start Date: {0}", this.StartDate);
            Console.WriteLine("Project End Date: {0}", this.EndDate);
            Console.WriteLine("Project Budget: {0}", this.Budget);
            Console.WriteLine("Tasks:");

            foreach (Task task in this.Tasks)
            {
                Console.WriteLine("Name: {0}", task.Name);
                Console.WriteLine("Description: {0}", task.Description);
                Console.WriteLine("Start Date: {0}", task.StartDate);
                Console.WriteLine("End Date: {0}", task.EndDate);
                Console.WriteLine("Budget: {0}", task.Budget);
                Console.WriteLine("Status: {0}", task.Status);
                Console.WriteLine("Team Members:");

                foreach (TeamMember teamMember in task.TeamMembers)
                {
                    Console.WriteLine("Name: {0}", teamMember.Name);
                    Console.WriteLine("Email: {0}", teamMember.Email);
                    Console.WriteLine("Status: {0}", teamMember.Status);


                }

            }
            
        }

    }
    
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Budget { get; set; }
        public TaskStatus Status { get; set; }
        public List<TeamMember> TeamMembers { get; set; }
        public Task()
            { 
                TeamMembers = new List<TeamMember>();
            }
        public void CreateTask(string name, string description, DateTime startDate, DateTime endDate, double budget)
        {
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Budget = budget;
        }

        public void AddTeamMember(TeamMember teamMember)
        {
            TeamMembers.Add(teamMember);
        }

        public void RemoveTeamMember(TeamMember teamMember)
        {
            TeamMembers.Remove(teamMember);
        }

        public void ChangeTaskStatus(TaskStatus status)
        {
            Status = status;
        }

    }
    
    public class TeamMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public TaskStatus Status { get; set; }

        public void CreateTeamMember(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public void ChangeStatus(TaskStatus status)
        {
            Status = status;
        }
    }


    public class TaskStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static TaskStatus NotStarted = new TaskStatus { Id = 1, Name = "Не начато" };
        public static TaskStatus InProgress = new TaskStatus { Id = 2, Name = "В процессе" };
        public static TaskStatus Completed = new TaskStatus { Id = 3, Name = "Завершено" };
    }
    
}