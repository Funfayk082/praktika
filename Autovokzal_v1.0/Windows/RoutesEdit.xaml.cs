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
using System.Windows.Shapes;
using Autovokzal_v1._0.Models;

namespace Autovokzal_v1._0.Windows
{
    /// <summary>
    /// Логика взаимодействия для RoutesEdit.xaml
    /// </summary>
    public partial class RoutesEdit : Window
    {
        public Route Route { get; set; }
        public RoutesEdit(Route route)
        {
            InitializeComponent();
            Route = route;
            DataContext = Route;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
