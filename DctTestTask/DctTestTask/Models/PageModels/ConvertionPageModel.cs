namespace DctTestTask.Models.PageModels;

public class ConvertionPageModel
{
    public string Name { get; set; }
    
    public decimal PriceUsd { get; set; }

    public override string ToString()
    {
        return Name;
    }
}