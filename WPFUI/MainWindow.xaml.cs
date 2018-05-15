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
using Sturmer.AircraftCompany.Interfaces;

namespace Sturmer.AircraftCompany.WPFUI
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<IPlane> Planes
        {
            set;
            get;
        }

        public List<IProducer> Producers
        {
            set;
            get;
        }

        public MainWindow()
        {
            IBL bl = new BL.BL(Properties.Settings.Default.LibraryName);
            Planes = bl.GetAllPlanes();
            Producers = bl.GetAllProducers();
            InitializeComponent();
        }
    }
}
