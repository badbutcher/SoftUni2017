public abstract class Mission : IMission
{
    protected Mission(double enduranceRequired/*, double scoreToComplete*/)
    {
        this.EnduranceRequired = enduranceRequired;
        //this.ScoreToComplete = scoreToComplete;
    }

    public string Name { get; private set; }

    public double EnduranceRequired { get; private set; }

    public double ScoreToComplete { get; private set; }

    public double WearLevelDecrement { get; private set; }
}