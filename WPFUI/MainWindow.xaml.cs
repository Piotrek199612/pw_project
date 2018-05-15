using System.Collections.Generic;
using System.Windows;
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
