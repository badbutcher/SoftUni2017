using System;
using System.Text;

public class Engine
{
    private readonly IReader reader;
    private readonly IWriter writer;
    private readonly GameController gameController;

    public Engine(IReader reader, IWriter writer, GameController gameController)
    {
        this.reader = reader;
        this.writer = writer;
        this.gameController = gameController;
    }

    public void Run()
    {
        var input = this.reader.ReadLine();
        var result = new StringBuilder();

        while (!input.Equals("Enough! Pull back!"))
        {
            try
            {
                this.gameController.GiveInputToGameController(input);
            }
            catch (ArgumentException arg)
            {
                result.AppendLine(arg.Message);
            }

            input = this.reader.ReadLine();
        }

        this.gameController.RequestResult();
        this.writer.WriteLine(result.ToString());
    }
}