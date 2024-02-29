using System.ComponentModel.DataAnnotations;

namespace api_opportunities.Models.Opportunities;
public class Opportunity
{
    public enum StatusOpp
    {
        NAplicado,
        Aplicado,
        EntMarcada,
        Aprovado,
        NAprovado
    }
    private DateTime saTime;
    
    
    public Guid Id { get; init; }
    
    [MaxLength(100)]
    public string Title { get; private set; }
    
    [MaxLength(455)]
    public string Desc { get; private set; }
    
    [MaxLength(100)]
    public string Type { get; private set; }
    
    [MaxLength(100)]
    public string Link { get; private set; }
    
    public double Money { get; private set; }
    
    public StatusOpp Status { get; private set; }

    public DateTime DateChanges { get; private set; }
    [MaxLength(100)]
    public string DateChangesString { get; private set; }
    
    public Opportunity()
    {
    }

    public Opportunity(string title, string desc, string type, string link, double money)
    {
        Id = Guid.NewGuid();
        Title = title;
        Desc = desc;
        Type = type;
        Link = link;
        Status = StatusOpp.NAplicado;
        DateChanges = DateTime.UtcNow;
        
        TimeZoneInfo localTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
        saTime = TimeZoneInfo.ConvertTimeFromUtc(DateChanges, localTimeZone);
        DateChangesString = saTime.ToString("dd-MM-yyyy | HH:mm:ss");
        
        Money = money;
    }

    public void ChangeTitle(string newTitle)
    {
        Title = newTitle;
    }
    public void ChangeDescription(string newDesc)
    {
        Desc = newDesc;
    }
    public void ChangeType(string newType)
    {
        Type = newType;
    }
    public void ChangeLink(string newLink)
    {
        Link = newLink;
    }
    public void ChangeMoney(double newMoney)
    {
        Money = newMoney;
    }


    private void updateTime()
    {
        DateChanges = DateTime.UtcNow;
        TimeZoneInfo localTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
        saTime = TimeZoneInfo.ConvertTimeFromUtc(DateChanges, localTimeZone);
        DateChangesString = saTime.ToString("dd-MM-yyyy | HH:mm:ss");
    }
    
    #region ChangeStatus
    public void NAplicado()
    {
        Status = StatusOpp.NAplicado;
        DateChanges = DateTime.UtcNow;
        TimeZoneInfo localTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
        saTime = TimeZoneInfo.ConvertTimeFromUtc(DateChanges, localTimeZone);
        DateChangesString = saTime.ToString("dd-MM-yyyy | HH:mm:ss");
    }

    public void Aplicado()
    {
        Status = StatusOpp.Aplicado;
        DateChanges = DateTime.UtcNow;
        TimeZoneInfo localTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
        saTime = TimeZoneInfo.ConvertTimeFromUtc(DateChanges, localTimeZone);
        DateChangesString = saTime.ToString("dd-MM-yyyy | HH:mm:ss");
    }
    
    public void EntMarcada()
    {
        Status = StatusOpp.EntMarcada;
        DateChanges = DateTime.UtcNow;
        TimeZoneInfo localTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
        saTime = TimeZoneInfo.ConvertTimeFromUtc(DateChanges, localTimeZone);
        DateChangesString = saTime.ToString("dd-MM-yyyy | HH:mm:ss");
    }
    
    public void Aprovado()
    {
        Status = StatusOpp.Aprovado;
        DateChanges = DateTime.UtcNow;
        TimeZoneInfo localTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
        saTime = TimeZoneInfo.ConvertTimeFromUtc(DateChanges, localTimeZone);
        DateChangesString = saTime.ToString("dd-MM-yyyy | HH:mm:ss");
    }
    public void NAprovado()
    {
        Status = StatusOpp.NAprovado;
        DateChanges = DateTime.UtcNow;
        TimeZoneInfo localTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
        saTime = TimeZoneInfo.ConvertTimeFromUtc(DateChanges, localTimeZone);
        DateChangesString = saTime.ToString("dd-MM-yyyy | HH:mm:ss");
    }
    #endregion
    
}
