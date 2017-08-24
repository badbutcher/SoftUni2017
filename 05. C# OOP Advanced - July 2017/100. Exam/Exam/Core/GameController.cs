public class GameController
{
    private IArmy army;
    private IWareHouse wearHouse;
    private readonly ISoldierFactory soldiersFactory;
    private readonly IAmmunitionFactory ammunitionFactory;
    private readonly IMissionFactory missionFactory;
    private MissionController missionControllerField;

    public GameController(ISoldierFactory soldiersFactory, IAmmunitionFactory ammunitionFactory, IMissionFactory missionFactory)
    {
        this.soldiersFactory = soldiersFactory;
        this.ammunitionFactory = ammunitionFactory;
        this.missionFactory = missionFactory;
        this.Army = army;
        this.WearHouse = wearHouse;
        this.MissionControllerField = new MissionController(army, wearHouse);
    }

    public IArmy Army
    {
        get { return this.army; }
        set { this.army = value; }
    }

    public IWareHouse WearHouse
    {
        get { return this.wearHouse; }
        set { this.wearHouse = value; }
    }

    public MissionController MissionControllerField
    {
        get { return this.missionControllerField; }
        set { this.missionControllerField = value; }
    }

    public void GiveInputToGameController(string input)
    {
        var data = input.Split();

        if (data[0].Equals("Soldier"))
        {
            string type = data[1];
            string name = data[2];
            int age = int.Parse(data[3]);
            double experience = double.Parse(data[4]);
            double endurance = double.Parse(data[5]);
            ISoldier soldier = this.soldiersFactory.CreateSoldier(type, name, age, experience, endurance);
            this.army.AddSoldier(soldier);

            //switch (type)
            //{
            //    case "Ranker":
            //        var ranker = new Ranker(name, age, experience, endurance);
            //        AddSoldierToArmy(ranker, type);
            //        break;
            //    case "Corporal":
            //        var corporal = new Corporal(name, age, experience, endurance);
            //        AddSoldierToArmy(corporal, type);
            //        break;
            //    case "Special-Force":
            //        var specialForce = new SpecialForce(name, age, experience, endurance);
            //        AddSoldierToArmy(specialForce, type);
            //        break;
            //    case "Regenerate":
            //        SoldierController.TeamRegenerate(army, name);
            //        break;
            //        //case "Vacation":
            //        //    SoldierController.TeamGoesOnVacation(army, name);
            //        //    break;
            //        //case "Bonus":
            //        //    SoldierController.TeamGetBonus(army, name);
            //        //    break;
            //}
        }
        else if (data[0].Equals("WareHouse"))
        {
            string name = data[1];
            int count = int.Parse(data[2]);
            IAmmunition ammunition = this.ammunitionFactory.CreateAmmunition(name);

            //TODO
            //AddAmmunitions(AmmunitionFactory.CreateAmmunition(name));
        }
        else if (data[0].Equals("Mission"))
        {
            string type = data[1];
            int score = int.Parse(data[2]);
            IMission mission = this.missionFactory.CreateMission(type, score);
            //TODO
            //this.MissionControllerField.PerformMission(new Easy());
        }
    }

    public string RequestResult()
    {
        return null;
        //return Output.GiveOutput(army, wearHouse, this.MissionControllerField.MissionQueue.Count);
    }

    //TODO check
    //private void AddAmmunitions(IAmmunition ammunition)
    //{
    //    this.WearHouse.EquipArmy(army);
    //    if (!this.WearHouse.ContainsKey(ammunition.Name))
    //    {
    //        this.WearHouse[ammunition.Name] = new List<Ammunition>();
    //        this.WearHouse[ammunition.Name].Add(ammunition);
    //    }
    //    else
    //    {
    //        this.WearHouse[ammunition.Name][0].Number += ammunition.Number;
    //    }
    //}

    //private void AddSoldierToArmy(Soldier soldier, string type)
    //{
    //    if (!soldier.CheckIfSoldierCanJoinTeam())
    //    {
    //        throw new ArgumentException($"The soldier {soldier.Name} is not skillful enough {type} team");
    //    }

    //    if (!this.Army.ContainsKey(type))
    //    {
    //        this.Army[type] = new List<Soldier>();
    //    }
    //    this.Army[type].Add(soldier);
    //}
}