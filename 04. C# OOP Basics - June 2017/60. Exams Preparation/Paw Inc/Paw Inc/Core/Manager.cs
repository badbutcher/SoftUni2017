using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Manager
{
    private List<AdoptionCenter> adoptionCenter;
    private List<CleansingCenter> cleansingCenter;
    private List<Animal> adoptedAnimals;
    private List<Animal> cleanedAnimals;

    public Manager()
    {
        this.adoptionCenter = new List<AdoptionCenter>();
        this.cleansingCenter = new List<CleansingCenter>();
        this.adoptedAnimals = new List<Animal>();
        this.cleanedAnimals = new List<Animal>();
    }

    public void RegisterCleansingCenter(string name)
    {
        this.cleansingCenter.Add(new CleansingCenter(name, new List<Animal>()));
    }

    public void RegisterAdoptionCenter(string name)
    {
        this.adoptionCenter.Add(new AdoptionCenter(name, new List<Animal>()));
    }

    public void RegisterDog(string name, int age, int learnedCommands, string adoptionCenterName)
    {
        Center center = this.adoptionCenter.FirstOrDefault(a => a.Name == adoptionCenterName);
        center.StoredAnimals.Add(new Dog(name, age, false, learnedCommands, adoptionCenterName));
    }

    public void RegisterCat(string name, int age, int intelligenceCoefficient, string adoptionCenterName)
    {
        Center center = this.adoptionCenter.FirstOrDefault(a => a.Name == adoptionCenterName);
        center.StoredAnimals.Add(new Cat(name, age, false, intelligenceCoefficient, adoptionCenterName));
    }

    public void SendForCleansing(string adoptionCenterName, string cleansingCenterName)
    {
        Center adoptCenter = this.adoptionCenter.FirstOrDefault(a => a.Name == adoptionCenterName);
        Center cleansCenter = this.cleansingCenter.FirstOrDefault(a => a.Name == cleansingCenterName);

        foreach (var item in adoptCenter.StoredAnimals.Where(a => a.CleansingStatus == false))
        {
            cleansCenter.StoredAnimals.Add(item);
        }

        adoptCenter.StoredAnimals.RemoveAll(a => a.CleansingStatus == false);
    }

    public void Cleanse(string cleansingCenterName)
    {
        Center cleansCenter = this.cleansingCenter.FirstOrDefault(a => a.Name == cleansingCenterName);

        foreach (var item in cleansCenter.StoredAnimals)
        {
            item.CleansingStatus = true;
            Center adoptCenter = this.adoptionCenter.FirstOrDefault(a => a.Name == item.AdoptedAt);
            adoptCenter.StoredAnimals.Add(item);
            this.cleanedAnimals.Add(item);
        }

        cleansCenter.StoredAnimals.RemoveAll(a => a.CleansingStatus == true);
    }

    public void Adopt(string adoptionCenterName)
    {
        Center adoptCenter = this.adoptionCenter.FirstOrDefault(a => a.Name == adoptionCenterName);

        foreach (var item in adoptCenter.StoredAnimals.Where(a => a.CleansingStatus == true))
        {
            this.adoptedAnimals.Add(item);
        }

        adoptCenter.StoredAnimals.RemoveAll(a => a.CleansingStatus == true);
    }

    public string PawPawPawah()
    {
        this.adoptionCenter.Select(a => a.StoredAnimals.Select(c => c.Name).Distinct()).Distinct();

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Paw Incorporative Regular Statistics");
        sb.AppendLine($"Adoption Centers: {this.adoptionCenter.Count()}");
        sb.AppendLine($"Cleansing Centers: {this.cleansingCenter.Count()}");

        if (this.adoptedAnimals.Count != 0)
        {
            sb.AppendLine($"Adopted Animals: {string.Join(", ", this.adoptedAnimals.Select(a => a.Name).OrderBy(b => b))}");
        }
        else
        {
            sb.AppendLine($"Adopted Animals: None");
        }

        if (this.cleanedAnimals.Count != 0)
        {
            sb.AppendLine($"Cleansed Animals: {string.Join(", ", this.cleanedAnimals.Select(a => a.Name).OrderBy(b => b))}");
        }
        else
        {
            sb.AppendLine($"Cleansed Animals: None");
        }

        sb.AppendLine($"Animals Awaiting Adoption: {this.adoptionCenter.Sum(a => a.StoredAnimals.Where(c => c.CleansingStatus == true).Count())}");
        sb.AppendLine($"Animals Awaiting Cleansing: {this.cleansingCenter.Sum(a => a.StoredAnimals.Where(c => c.CleansingStatus == false).Count())}");

        return sb.ToString().Trim();
    }
}