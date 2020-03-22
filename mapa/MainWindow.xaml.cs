﻿using System;
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

        // массив точек записывать в список  

        public List<MapObject> mapObjects = new List<MapObject>();

        public PointLatLng point = new PointLatLng();
        public MainWindow()
        {
           InitializeComponent();
           initMap();
            radioButCreate.IsChecked = true;
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

        public void createArea(List<PointLatLng> points)
        {
            GMapMarker marker = new GMapPolygon(points)
            {
                Shape = new Path
                {
                    Stroke = Brushes.Black, // стиль обводки
                    Fill = Brushes.Violet, // стиль заливки
                    Opacity = 0.7 // прозрачность
                }
            };
            Map.Markers.Add(marker);
        }

        public void createPath(List<PointLatLng> points)
        {
            GMapMarker marker = new GMapRoute(points)
            {
                Shape = new Path()
                {
                    Stroke = Brushes.DarkBlue, // цвет обводки
                    Fill = Brushes.DarkBlue, // цвет заливки
                    StrokeThickness = 4 // толщина обводки
                }
            };
            Map.Markers.Add(marker);

        }

        private void MapLoaded(object sender, RoutedEventArgs e)
        {
           
        }

     

        

        private void Map_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           
        
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
                
                createArea(areaspots);
                areaspots.Clear();
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
                
                createPath(pathspot);
                pathspot.Clear();
            }


        }

        public List<PointLatLng> areaspots = new List<PointLatLng>();
        public List<PointLatLng> pathspot = new List<PointLatLng>();
        public bool getareagreatagain = false;
        public bool getpathgreatagain = false;


        private void Map_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            System.Windows.MessageBox.Show("double");
        }

        private void Map_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (getareagreatagain)
            {
                point = Map.FromLocalToLatLng((int)e.GetPosition(Map).X, (int)e.GetPosition(Map).Y);
                areaspots.Add(point);
                clickinfoY.Content = point.Lng;
                clickinfoX.Content = point.Lat;

            }
            else
            if (getpathgreatagain)
            {
                point = Map.FromLocalToLatLng((int)e.GetPosition(Map).X, (int)e.GetPosition(Map).Y);
                pathspot.Add(point);
                clickinfoY.Content = point.Lng;
                clickinfoX.Content = point.Lat;
            }
            else
            {
                point = Map.FromLocalToLatLng((int)e.GetPosition(Map).X, (int)e.GetPosition(Map).Y);
                clickinfoY.Content = point.Lng;
                clickinfoX.Content = point.Lat;
            }
        }

        private void createmodecombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (createmodecombo.SelectedIndex == 0) // area
            {
                getareagreatagain = true;
                getpathgreatagain = false;
            }

            if (createmodecombo.SelectedIndex == 1) // point
            {
                getareagreatagain = false;
                getpathgreatagain = false;
            }

            if (createmodecombo.SelectedIndex == 2) // car
            {
                getareagreatagain = false;
                getpathgreatagain = false;
            }

            if (createmodecombo.SelectedIndex == 3) // people
            {
                getareagreatagain = false;
                getpathgreatagain = false;
            }

            if (createmodecombo.SelectedIndex == 4) // path
            {
                getareagreatagain = false;
                getpathgreatagain = true;
            }

        }
    }
    
}




//public ref GMapMarker findRef()
//{
//    return ref new GMapMarker(new PointLatLng());
//}

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

//GMapMarker marker = new GMapMarker(point)
//{
//    Shape = new Image
//    {
//        Width = 32, // ширина маркера
//        Height = 32, // высота маркера
//        ToolTip = "timetime", // всплывающая подсказка
//        Source = new BitmapImage(new Uri("pack://application:,,,/Resources/notMainSpot.png")) // картинка
//    }
//};





//if (Map.Markers.Count == 0)
//{
//    Map.Markers.Add(marker);
//    clickinfoX.Content = point.Lat;
//    clickinfoY.Content = point.Lng;

//}
//else
//{

//    Map.Markers.Add(marker);     // после выхода из метода ссылка обнуляется 
//    clickinfoX.Content = point.Lat;
//    clickinfoY.Content = point.Lng;
//}