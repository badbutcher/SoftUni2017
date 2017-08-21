using NUnit.Framework;

[TestFixture]
public class TestClass
{
    private MissionController mc;
    private IArmy army;
    private IWareHouse wereHouse;

    [SetUp]
    public void TestInit()
    {
        this.mc = new MissionController(army, wereHouse);
    }

    [Test]
    public void AddEasyMission()
    {
        IMission mission = new Easy(25);

        mc.Missions.Enqueue(mission);

        Assert.AreEqual(1, mc.Missions.Count);
    }

    [Test]
    public void AddMediumMission()
    {
        IMission mission = new Medium(55);

        mc.Missions.Enqueue(mission);

        Assert.AreEqual(1, mc.Missions.Count);
    }

    [Test]
    public void AddHardMission()
    {
        IMission mission = new Hard(85);

        mc.Missions.Enqueue(mission);

        Assert.AreEqual(1, mc.Missions.Count);
    }

    [Test]
    public void AddMissions()
    {
        IMission mission1 = new Hard(3);
        IMission mission2 = new Medium(4);
        IMission mission3 = new Easy(5);
        IMission mission4 = new Easy(6);

        mc.Missions.Enqueue(mission1);
        mc.Missions.Enqueue(mission2);
        mc.Missions.Enqueue(mission3);
        mc.Missions.Enqueue(mission4);

        Assert.AreEqual(4, mc.Missions.Count);
    }
}