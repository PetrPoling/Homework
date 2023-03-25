namespace Project_Manager;

public class TeamMember
{
    public string Name { get; set; }
    public string Email { get; set; }
    public TaskStatus Status { get; set; }
    public static List<TeamMember> TeamMembers { get; set; }
    
    static TeamMember()
    { 
        TeamMembers = new List<TeamMember>();
    }
    
    public void CreateTeamMember(string name, string email)
    {
        Name = name;
        Email = email;
    }

    public void ChangeStatus(TaskStatus status)
    {
        Status = status;
    }
    public static void AddTeamMember(TeamMember teamMember)
    {
        TeamMembers.Add(teamMember);
    }

    public void RemoveTeamMember(TeamMember teamMember)
    {
        TeamMembers.Remove(teamMember);
    }
}