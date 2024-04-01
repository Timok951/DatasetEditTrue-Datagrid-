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
    /// Логика взаимодействия для WeaponsPage.xaml
    /// </summary>
    public partial class WeaponsPage : Page
    {
        WeaponTableAdapter weapons = new WeaponTableAdapter();

        public WeaponsPage()
        {
            InitializeComponent();
            WeaponsGrid.ItemsSource = weapons.GetData();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            object id = (WeaponsGrid.SelectedItem as DataRowView).Row[0];
            weapons.UpdateQuery(WpnN.Text, Convert.ToInt32(WpnD.Text), Convert.ToInt32(WpnT.Text), Convert.ToInt32(id));
            WeaponsGrid.ItemsSource = weapons.GetData();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object id = (WeaponsGrid.SelectedItem as DataRowView).Row[0];
                weapons.DeleteQuery(Convert.ToInt32(id));
            }
            catch {
                MessageBox.Show("You cannot delete this, because this is attached to another table");
            }
            WeaponsGrid.ItemsSource = weapons.GetData();


        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            weapons.InsertQuery(WpnN.Text, Convert.ToInt32(WpnD.Text), Convert.ToInt32(WpnT.Text) );
            WeaponsGrid.ItemsSource = weapons.GetData();

        }

        private void WeaponsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (WeaponsGrid.SelectedItem != null)
            {
                object id = (WeaponsGrid.SelectedItem as DataRowView).Row[0];
                var waponname = weapons.SelectWeaponName(Convert.ToInt32(id));
                var weapondamage = weapons.SelectIdWeaponDamage(Convert.ToInt32(id));
                var weapontype = weapons.SelectIdWeaponType(Convert.ToInt32(id));
                WpnN.Text = Convert.ToString(waponname);
                WpnD.Text = Convert.ToString(weapondamage);
                WpnT.Text = Convert.ToString(weapontype);
            }


        }
    }
}
