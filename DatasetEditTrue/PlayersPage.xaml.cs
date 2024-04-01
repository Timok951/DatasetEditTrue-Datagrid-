using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DatasetEditTrue.GameDataSetTableAdapters;


namespace DatasetEditTrue
{
    /// <summary>
    /// Логика взаимодействия для PlayersPage.xaml
    /// </summary>
    public partial class PlayersPage : Page
    {
        PlayersTableAdapter players = new PlayersTableAdapter();

        public PlayersPage()
        {

            InitializeComponent();
            PlayersGrid.ItemsSource = players.GetData();

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object id = (PlayersGrid.SelectedItem as DataRowView).Row[0];
                players.DeleteQuery(Convert.ToInt32(id));
            }
            catch
            {
                MessageBox.Show("You cannot delete this, because this is attached to another table");
            }
            PlayersGrid.ItemsSource = players.GetData();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            players.InsertQuery(PlrN.Text, Convert.ToInt32(PlrS.Text), Convert.ToInt32(PlrW.Text));
            PlayersGrid.ItemsSource = players.GetData();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            object id = (PlayersGrid.SelectedItem as DataRowView).Row[0];
            players.UpdateQuery(PlrN.Text, Convert.ToInt32(PlrS.Text), Convert.ToInt32(PlrW.Text), Convert.ToInt32(id));
            PlayersGrid.ItemsSource = players.GetData();
        }

        private void PlayersGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PlayersGrid.SelectedItem != null) {
                object id = (PlayersGrid.SelectedItem as DataRowView).Row[0];
                var playersname = players.SelectPlayerName(Convert.ToInt32(id));
                var playersscore = players.SelectPlayerScore(Convert.ToInt32(id));
                var weapontype = players.SelectWeaponId(Convert.ToInt32(id));
                PlrN.Text = Convert.ToString(playersname);
                PlrS.Text = Convert.ToString(playersscore);
                PlrW.Text = Convert.ToString(weapontype);
            }

        }
    }
}
