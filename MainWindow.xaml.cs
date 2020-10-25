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
using InteractiveDataDisplay.WPF;
using Microsoft.Maps.MapControl.WPF;

namespace ControlCenter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            double[] x = new double[200];
            for (int i = 0; i < x.Length; i++)
                x[i] = 3.1415 * i / (x.Length - 1);

            for (int i = 0; i < 25; i++)
            {
                var lg = new LineGraph();
                lines.Children.Add(lg);
                lg.Stroke = new SolidColorBrush(Color.FromArgb(255, 0, (byte)(i * 10), 0));
                lg.Description = String.Format("Data series {0}", i + 1);
                lg.StrokeThickness = 2;
                lg.Plot(x, x.Select(v => Math.Sin(v + i / 10.0)).ToArray());
            }
            addNewlabel();
        }
        private void OnClickButtonPlanning(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Кнопка была нажата!");
        }

        private void OnClickButtonGraphics(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Кнопка была нажата!");
        }

        private void addNewlabel()
        {
            MapPolyline polyline = new MapPolyline();
            polyline.Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Blue);
            polyline.StrokeThickness = 5;
            polyline.Opacity = 0.7;
            polyline.Locations = new LocationCollection() {
                new Location(58.010259, 56.234195)};

            RocketLocationMap.Children.Add(polyline);
        }
    }

    public class VisibilityToCheckedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((Visibility)value) == Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((bool)value) ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
