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

namespace Wpf_grafik_41
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Chizish_Click(object sender,RoutedEventArgs e)
        {
            GraphCanvas.Children.Clear();
            Koordinata_chiz(GraphCanvas);
        }

        private void Koordinata_chiz(Canvas kanvas)
        {
            double Width = kanvas.ActualWidth; 
            double Height=kanvas.ActualHeight;
            double markazX=Width/2;
            Double markazY=Height/2;
            //X o'qini chizish
            Line Xoqi = new Line
            {
                X1 = 0, Y1 = markazY,
                X2 = Width, Y2 = markazY,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
            };
            kanvas.Children.Add(Xoqi);
            //Y o'qini chizish
            Line Yoqi = new Line
            {
                X1 = markazX,
                Y1 = 0,
                X2 = markazX,
                Y2 = Height,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
            };
            kanvas.Children.Add(Yoqi);

            //chiziqchalarni chizish
            double step=Width/20;

            for(double x=markazX+step;x<Width;x+=step)
                Chizma_chiz(kanvas,x,markazY-5,x,markazY+5);
            for (double x = markazX - step; x>0; x -= step)
                Chizma_chiz(kanvas, x, markazY - 5, x, markazY + 5);

            for (double y = markazY + step; y <Height; y += step)
                Chizma_chiz(kanvas, markazX-5, y , markazX+5, y);
            for (double y = markazY - step;y > 0; y -= step)
                Chizma_chiz(kanvas, markazX - 5, y, markazX + 5, y);
            //

        }

        public void Chizma_chiz(Canvas kanvas, double x1,double y1, double x2, double y2)
        {
            Line chiziq = new Line
            {
                X1 = x1,
                Y1 = y1,
                X2 = x2,
                Y2 = y2,
                Stroke = Brushes.Black,
                StrokeThickness = 0.5,
            };
            kanvas.Children.Add(chiziq);
        }
    }
}
