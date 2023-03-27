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
                    Console.WriteLine("Task_Satus:NotStarted, InProgress, Completed");
                    string Task_Status = Console.ReadLine();

                    Project project = new Project();
                    project.CreateProject(projectName, projectDescription, projectStartDate, projectEndDate,
                        projectBudget);

                    Task task1 = new Task();
                    task1.CreateTask(taskName, taskDescription, taskStartDate, taskEndDate, taskBudget);
                    project.AddTask(task1);

                    TeamMember teamMember1 = new TeamMember();
                    teamMember1.CreateTeamMember(teamMemberName, teamMemberEmail);
                    TeamMember.AddTeamMember(teamMember1);
                    Console.WriteLine("If you want to exit pres 0 if not press 1");
                    statement = Console.ReadLine();
                    project.GenerateReport();
                    
                }
            }
           
        }

    }
}