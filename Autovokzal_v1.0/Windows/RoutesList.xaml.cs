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

        private void RoutesList_Loaded(object sender, RoutedEventArgs e)
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

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Route? route = routesList.SelectedItem as Route;
            if (route is null) return;

            RoutesEdit routesEdit = new RoutesEdit(new Route
            {
                Id = route.Id,
                RouteName = route.RouteName,
                RouteStartDate = route.RouteStartDate,
                RouteEndDate = route.RouteEndDate,
                RouteCode = route.RouteCode,
                Price = route.Price,
                isClosed = route.isClosed,
                WorkingDays = route.WorkingDays,
                isWEW = route.isWEW,
                isFYear = route.isFYear,
            });
            
            if (routesEdit.ShowDialog() == true)
            {
                route = db.Routes.Find(routesEdit.Route.Id);
                if (route != null)
                {
                    route.RouteName = routesEdit.Route.RouteName;
                    route.RouteStartDate = routesEdit.Route.RouteStartDate;
                    route.RouteEndDate = routesEdit.Route.RouteEndDate;
                    route.RouteCode = routesEdit.Route.RouteCode;
                    route.Price = routesEdit.Route.Price;
                    route.isClosed = routesEdit.Route.isClosed;
                    route.WorkingDays = routesEdit.Route.WorkingDays;
                    route.isWEW = routesEdit.Route.isWEW;
                    route.isFYear = routesEdit.Route.isFYear;
                    db.SaveChanges();
                    routesList.Items.Refresh();
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Route? route = routesList.SelectedItem as Route;
            if (route is null) return;
            db.Routes.Remove(route);
            db.SaveChanges();
        }
    }
}
