using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DrawingApp
{
    public partial class MainWindow : Window
    {
        private Polyline _currentPolyline;
        private SolidColorBrush _currentBrush = new SolidColorBrush(Colors.Black);
        private double _currentThickness = 2;
        private double _currentOpacity = 1.0;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void DrawingCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {              
                _currentPolyline = new Polyline
                {
                    Stroke = _currentBrush,
                    StrokeThickness = _currentThickness,
                    StrokeLineJoin = PenLineJoin.Round
                };
                _currentPolyline.Opacity = _currentOpacity;
                _currentPolyline.Points.Add(e.GetPosition(DrawingCanvas));
                DrawingCanvas.Children.Add(_currentPolyline);
            }
        }
        private void DrawingCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && _currentPolyline != null)
            {
                _currentPolyline.Points.Add(e.GetPosition(DrawingCanvas));
            }
        }
        private void DrawingCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _currentPolyline = null;
        }
        private void ThicknessSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _currentThickness = ThicknessSlider.Value;
        }
        private void OpacitySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _currentOpacity = OpacitySlider.Value;
        }
        private void ColorBox_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Background is SolidColorBrush brush)
            {
                _currentBrush = new SolidColorBrush(brush.Color);
            }
        }
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            DrawingCanvas.Children.Clear();
        }
    }
}
