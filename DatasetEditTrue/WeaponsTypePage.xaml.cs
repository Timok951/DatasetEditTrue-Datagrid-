using DatasetEditTrue.GameDataSetTableAdapters;
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

namespace DatasetEditTrue
{
    /// <summary>
    /// Логика взаимодействия для WeaponsTypePage.xaml
    /// </summary>
    public partial class WeaponsTypePage : Page
    {
        WeaponTypeTableAdapter weponstype = new WeaponTypeTableAdapter();

        public WeaponsTypePage()
        {
            InitializeComponent();
            WeaponsTypeGrid.ItemsSource = weponstype.GetData();
            
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object id = (WeaponsTypeGrid.SelectedItem as DataRowView).Row[0];
                weponstype.DeleteQuery(Convert.ToInt32(id));
            }
            catch
            {
                MessageBox.Show("You cannot delete this, because this is attached to another table");
            }
            WeaponsTypeGrid.ItemsSource = weponstype.GetData();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            weponstype.InsertQuery(WpnT.Text, Convert.ToInt32(DmgB.Text));
            WeaponsTypeGrid.ItemsSource = weponstype.GetData();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            object id = (WeaponsTypeGrid.SelectedItem as DataRowView).Row[0];
            weponstype.UpdateQuery(WpnT.Text, Convert.ToInt32(DmgB.Text), Convert.ToInt32(id));
            WeaponsTypeGrid.ItemsSource = weponstype.GetData();

        }

        private void WeaponsTypeGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (WeaponsTypeGrid.SelectedItem != null)
            {
                object id = (WeaponsTypeGrid.SelectedItem as DataRowView).Row[0];
                var waponttypetext = weponstype.SelectWeaponTypeName(Convert.ToInt32(id));
                var wapontypedamagebonus = weponstype.SelectWeaponBonus(Convert.ToInt32(id));
                DmgB.Text = Convert.ToString(wapontypedamagebonus);
                WpnT.Text = Convert.ToString(waponttypetext);
            }
    
        }
    }
}
