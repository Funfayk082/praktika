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
using Microsoft.EntityFrameworkCore;

namespace Autovokzal_v1._0.Windows
{
    /// <summary>
    /// Логика взаимодействия для RoutesList.xaml
    /// </summary>
    public partial class RoutesList : Window
    {
        ApplicationContext db = new ApplicationContext();
        public RoutesList()
        {
            InitializeComponent();
        }

        private void RouteList_Loaded(object sender, RoutedEventArgs e)
        {
            db.Database.EnsureCreated();
            db.Routes.Load();
            DataContext = db.Routes.Local.ToObservableCollection();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            RoutesEdit routesEdit = new RoutesEdit(new Route());
            if (routesEdit.ShowDialog() == true)
            {
                Route route = routesEdit.Route;
                db.Routes.Add(route);
                db.SaveChanges();
            }
        }
    }
}
