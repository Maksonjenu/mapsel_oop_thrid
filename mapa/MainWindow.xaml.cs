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
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using GMap.NET.MapProviders;
using System.Device.Location;
using System.Windows.Forms;
using mapa.Classes;

namespace mapa
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<MapObject> mapObjects = new List<MapObject>();

        public PointLatLng point = new PointLatLng();
        public MainWindow()
        {
           InitializeComponent();
           initMap();
        }

        public void initMap()
        {
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            Map.MapProvider = OpenStreetMapProvider.Instance;
            Map.MinZoom = 2;
            Map.MaxZoom = 17;
            Map.Zoom = 15;
            Map.Position = new PointLatLng(55.012823, 82.950359);
            Map.MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter;
            Map.CanDragMap = true;
            Map.DragButton = MouseButton.Left;

        }
        
        public void createCarMarker(PointLatLng clickedPoint)
        {
            MapObject mapObject_car = new Car_class(createObjectName.Text,clickedPoint);
            mapObjects.Add(mapObject_car);
            Map.Markers.Add(mapObject_car.GetMarker());
        }

        public void createPeopleMarker(PointLatLng clickedPoint)
        {
            MapObject mapObject_people = new Human_class(createObjectName.Text, clickedPoint);
            mapObjects.Add(mapObject_people);
            Map.Markers.Add(mapObject_people.GetMarker());
        }

        public void createPointMarker(PointLatLng clickedPoint)
        {
            MapObject mapObject_point = new Location_class(createObjectName.Text, clickedPoint);
            mapObjects.Add(mapObject_point);
            Map.Markers.Add(mapObject_point.GetMarker());
        }

        private void MapLoaded(object sender, RoutedEventArgs e)
        {
           
        }

        

        private void Map_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            point = Map.FromLocalToLatLng((int)e.GetPosition(Map).X, (int)e.GetPosition(Map).Y);
            GMapMarker marker = new GMapMarker(point)
            {
                Shape = new Image
                {
                    Width = 32, // ширина маркера
                    Height = 32, // высота маркера
                    ToolTip = "timetime", // всплывающая подсказка
                    Source = new BitmapImage(new Uri("pack://application:,,,/Resources/notMainSpot.png")) // картинка
                }
            };
            ref GMapMarker markerRef = ref marker;
            if (Map.Markers.Count == 0)
            {
                Map.Markers.Add(marker);
                clickinfoX.Content = point.Lat;
                clickinfoY.Content = point.Lng;
            }
            else
            {
                Map.Markers.Remove(markerRef);
                Map.Markers.Add(marker);     // после выхода из метода ссылка обнуляется 
                clickinfoX.Content = point.Lat;
                clickinfoY.Content = point.Lng;
            }
        }


        

        private void radioButCreate_Checked(object sender, RoutedEventArgs e)
        {
            createmodecombo.IsEnabled = true;
            addbuttoncreate.IsEnabled = true;
            resetpointcreate.IsEnabled = true;
        }

        private void radioButSearch_Checked(object sender, RoutedEventArgs e)
        {
            createmodecombo.IsEnabled = false;
            addbuttoncreate.IsEnabled = false;
            resetpointcreate.IsEnabled = false;
        }

        private void addbuttoncreate_Click(object sender, RoutedEventArgs e)
        {
            if (createmodecombo.SelectedIndex == 0) // area
            {
                System.Windows.MessageBox.Show(createmodecombo.SelectedItem.ToString());
            }

            if (createmodecombo.SelectedIndex == 1) // point
            {
                createPointMarker(point);
            }

            if (createmodecombo.SelectedIndex == 2) // car
            {
                createCarMarker(point);
            }

            if (createmodecombo.SelectedIndex == 3) // people
            {
                createPeopleMarker(point);
            }

            if (createmodecombo.SelectedIndex == 4) // path
            {
                System.Windows.MessageBox.Show(createmodecombo.SelectedItem.ToString());
            }
        }

        

        

        private void Map_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            System.Windows.MessageBox.Show("double");
        }
    }
    
}


   



//PointLatLng point = new PointLatLng(55.016511, 82.946152);

//GMapMarker marker = new GMapMarker(point)
//{
//    Shape = new Image
//    {
//        Width = 32, // ширина маркера
//        Height = 32, // высота маркера
//        ToolTip = "Honda CR-V", // всплывающая подсказка
//        Source = new BitmapImage(new Uri("pack://application:,,,/Resources/men.png")) // картинка
//    }
//};
//Map.Markers.Add(marker);