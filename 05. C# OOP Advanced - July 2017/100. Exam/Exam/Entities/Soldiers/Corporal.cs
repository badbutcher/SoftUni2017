using System.Collections.Generic;

public class Corporal : Soldier
{
    private const double OverallSkillMiltiplier = 2.5;

    private readonly List<string> weaponsAllowed = new List<string>
        {
            "Gun",
            "AutomaticMachine",
            "MachineGun",
            "Helmet",
            "Knife",
        };

    public Corporal(string name, int age, double experience, double endurance)
            : base(name, age, experience, endurance)
    {
        this.OverallSkill = OverallSkillMiltiplier * (age + experience);
    }

    public override IReadOnlyList<string> WeaponsAllowed => this.weaponsAllowed;
}