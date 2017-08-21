using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{
    public string Name { get; private set; }

    public int Age { get; private set; }

    public double Experience { get; private set; }

    public double Endurance { get; private set; }

    public double OverallSkill { get; set; }

    public IDictionary<string, IAmmunition> Weapons { get; private set; }

    public abstract IReadOnlyList<string> WeaponsAllowed { get; }

    protected Soldier(string name, int age, double experience, double endurance)
    {
        this.Name = name;
        this.Age = age;
        this.Experience = experience;
        this.Endurance = endurance;
    }

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        bool hasAllEquipment = this.Weapons.Values.Count(weapon => weapon == null) == 0;

        if (!hasAllEquipment)
        {
            return false;
        }

        return this.Weapons.Values.Count(weapon => weapon.WearLevel <= 0) == 0;
    }

    public override string ToString() => string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);

    public void Regenerate()
    {
        throw new System.NotImplementedException();
    }

    public void CompleteMission(IMission mission)
    {
        throw new System.NotImplementedException();
    }

    public bool CanCarryWeaponsTotalWeight(List<Ammunition> missionWeapons)
    {
        double weaponsWeight = this.Weapons.Values.Sum(a => a.Weight);

        if (missionWeapons.Sum(a => a.Weight) < weaponsWeight)
        {
            return true;
        }

        return false;
    }

    private void AmmunitionRevision(double missionWearLevelDecrement)
    {
        IEnumerable<string> keys = this.Weapons.Keys.ToList();
        foreach (string weaponName in keys)
        {
            this.Weapons[weaponName].DecreaseWearLevel(missionWearLevelDecrement);

            if (this.Weapons[weaponName].WearLevel <= 0)
            {
                this.Weapons[weaponName] = null;
            }
        }
    }
}