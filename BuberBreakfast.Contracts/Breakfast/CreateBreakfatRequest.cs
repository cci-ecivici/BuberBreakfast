namespace BuberBreakfast.Contracts.Breakfast;

public record CreateBreakfatRequest(

    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    List<string> Savory,
    List<string> Sweet
);

