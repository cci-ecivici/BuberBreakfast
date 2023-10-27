using BuberBreakfast.Models;

namespace BuberBreakfast.Services.Breakfasts;

public class breakfastService : IBreakfastService
{
    private static readonly Dictionary<Guid, Breakfast> _breakfast = new ();
    public void CreateBreakfast(Breakfast breakfast)
        {
            _breakfast.Add (breakfast.Id, breakfast);
        }

    public Breakfast CreateBreakfast(Guid id)
    {
        return _breakfast[id];
    }
}