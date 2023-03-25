namespace Project_Manager;

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
            TaskStatus.Status = status;
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
                Console.WriteLine("Status: {0}", TaskStatus.Status);
                Console.WriteLine("Team Members:");

                foreach (TeamMember teamMember in TeamMember.TeamMembers)
                {
                    Console.WriteLine("Name: {0}", teamMember.Name);
                    Console.WriteLine("Email: {0}", teamMember.Email);
                    Console.WriteLine("Status: {0}", teamMember.Status);


                }

            }
            
        }

    }