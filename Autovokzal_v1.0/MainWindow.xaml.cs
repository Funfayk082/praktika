using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

namespace Autovokzal_v1._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int item;
        private void Dep_Choose_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            if (selectedItem == HR)
            {
                item = 1;
            }
            else if (selectedItem == Plane)
            {
                item = 2;
            }
            else if (selectedItem == Prod)
            {
                item = 3;
            }
            else if (selectedItem == Finance)
            {
                item = 4;
            }
        }
        private void Go_Button_Click(object sender, RoutedEventArgs e)
        {
            if (item == 1)
            {
                HR_dep hr_Dep = new HR_dep();
                hr_Dep.Show();
                this.Close();
            }
            else if (item == 2)
            {
                PlaneWindow planeWindow = new PlaneWindow();
                planeWindow.Show();
                this.Close();
            }
            else if (item == 3)
            {
                ProdWindow prodWindow = new ProdWindow();
                prodWindow.Show();
                this.Close();
            }
            else if (item == 4)
            {
                FinanceWindow financeWindow = new FinanceWindow();
                financeWindow.Show();
                this.Close();
            }
        }

    }
}
