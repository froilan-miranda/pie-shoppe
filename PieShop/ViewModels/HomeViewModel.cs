using PieShop.Models;

namespace PieShop.ViewModels;

public class HomeViewModel
{
    public IEnumerable<Pie> PiesOfTheWeek;

    public HomeViewModel(IEnumerable<Pie> piesOfTheWeek)
    {
        PiesOfTheWeek = piesOfTheWeek;
    }
}