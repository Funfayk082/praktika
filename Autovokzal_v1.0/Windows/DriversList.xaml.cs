using Autovokzal_v1._0.Models;
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
using System.Windows.Shapes;

namespace Autovokzal_v1._0.Windows
{
    public partial class DriversList : Window
    {
        ApplicationContext db = new ApplicationContext();
        public DriversList()
        {
            InitializeComponent();

            Loaded += DriverList_Loaded;
        }

        private void DriverList_Loaded(object sender, RoutedEventArgs e)
        {
            db.Database.EnsureCreated();
            db.Drivers.Load();
            DataContext = db.Drivers.Local.ToObservableCollection();
        }

        private void Add_Click_1(object sender, RoutedEventArgs e)
        {
            DriverEdit driverEdit = new DriverEdit(new Driver());
            if (driverEdit.ShowDialog() == true)
            {
                Driver driver = driverEdit.Driver;
                db.Drivers.Add(driver);
                db.SaveChanges();
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Driver? driver = driverlList.SelectedItem as Driver;
            if (driver is null) return;

            DriverEdit driverEdit = new DriverEdit(new Driver
            {
                Id = driver.Id,
                DriveLicense = driver.DriveLicense,
                DriverLicGetter = driver.DriverLicGetter,
                KatTS = driver.KatTS,
                GetDate = driver.GetDate,
                LastDate = driver.LastDate,
            });

            if (driverEdit.ShowDialog() == true)
            {
                driver = db.Drivers.Find(driverEdit.Driver.Id);
                if (driver != null)
                {
                    driver.DriveLicense = driverEdit.Driver.DriveLicense;
                    driver.DriverLicGetter = driverEdit.Driver.DriverLicGetter;
                    driver.KatTS = driverEdit.Driver.KatTS;
                    driver.GetDate = driverEdit.Driver.GetDate;
                    driver.LastDate = driverEdit.Driver.LastDate;
                    db.SaveChanges();
                    driverlList.Items.Refresh();
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Driver? driver = driverlList.SelectedItem as Driver;
            if (driver is null) return;
            db.Drivers.Remove(driver);
            db.SaveChanges();
        }
    }
}
