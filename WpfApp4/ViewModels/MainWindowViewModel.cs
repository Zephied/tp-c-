using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using WpfApp4.Model;

public class MainWindowViewModel : BaseViewModel
{
    private ObservableCollection<Monster> monsters;
    public ObservableCollection<Monster> Monsters
    {
        get { return monsters; }
        set { monsters = value; OnPropertyChanged(); }
    }

    private Monster selectedMonster;
    public Monster SelectedMonster
    {
        get { return selectedMonster; }
        set { selectedMonster = value; OnPropertyChanged(); }
    }

    public MainWindowViewModel()
    {
        LoadMonsters();
    }

    private void LoadMonsters()
    {
        using (var context = new GameDbContext())
        {
            Monsters = new ObservableCollection<Monster>(context.Monsters.Include(m => m.Spells).ToList());
        }
    }
}
