namespace api_opportunities.Models.Opportunities;

public record OpportunityDto(
    Guid Id,
    string Title,
    string Desc,
    string Type,
    string Link,
    double Money,
    string Status,
    string DateChanged);
