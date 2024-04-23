namespace ValorantApp;

public sealed partial class Agents
{
    private IEnumerable<Agent>? _agents;
}

public class Agent 
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Ability? Ability1 {get; set; }
    public Ability? Ability2 {get; set; }
    public Ability? Ability3 {get; set; }
    public Ability? Ultimate {get; set; }
}

public class Ability 
{
    public string? Name { get; set; }
    public string? Description { get; set; }
}