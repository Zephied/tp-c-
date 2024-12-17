using System.Windows;
using MyPokemonGame;
using MyPokemonGame.Views;

namespace MyPokemonGame
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private void StartCombat_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as MainWindowViewModel;
            if (viewModel != null && viewModel.SelectedMonster != null)
            {
                var combatView = new CombatView
                {
                    DataContext = new CombatViewModel(viewModel.SelectedMonster)
                };
                combatView.ShowDialog();
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un monstre pour commencer le combat.",
                                "Aucun Monstre Sélectionné", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}