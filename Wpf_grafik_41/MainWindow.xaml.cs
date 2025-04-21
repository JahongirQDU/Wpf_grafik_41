using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NCalc;

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
            this.SizeChanged += Chizish_Click;
        }
        private void Chizish_Click(object sender,RoutedEventArgs e)
        {
            GraphCanvas.Children.Clear();
            Koordinata_chiz(GraphCanvas, Convert.ToDouble(ulcham.Text));
            Funksiya_grafigi(GraphCanvas, FunksiyaMatni.Text,Convert.ToDouble( ulcham.Text));
        }

        private void Koordinata_chiz(Canvas kanvas,double ulcham)
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
            double step=Width/ulcham;

            for(double x=markazX+step;x<Width;x+=step)
                Chizma_chiz(kanvas,x,markazY-5,x,markazY+5);
            for (double x = markazX - step; x>0; x -= step)
                Chizma_chiz(kanvas, x, markazY - 5, x, markazY + 5);

            for (double y = markazY + step; y <Height; y += step)
                Chizma_chiz(kanvas, markazX-5, y , markazX+5, y);
            for (double y = markazY - step;y > 0; y -= step)
                Chizma_chiz(kanvas, markazX - 5, y, markazX + 5, y);
            Chizma_chiz(kanvas, markazX - 10, 5, markazX, 0);
            Chizma_chiz(kanvas, markazX + 10, 5, markazX, 0);
            Chizma_chiz(kanvas, Width-5 , markazY-10, Width, markazY);
            Chizma_chiz(kanvas, Width - 5, markazY + 10, Width, markazY);
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

        public void Funksiya_grafigi(Canvas kanvas, String Formula ,double ulcham)
        {
            double Width = kanvas.ActualWidth;
            double Height = kanvas.ActualHeight;
            double markazX = Width / 2;
            Double markazY = Height / 2;
            double step = Width / ulcham;

            Polyline polyline = new Polyline
            {
                Stroke = Brushes.Red,
                StrokeThickness = 2
            };

            for (double x = (-1)*ulcham/2; x <= ulcham / 2; x += 0.1)
            {
                var ifoda = new NCalc.Expression(Formula);//y=formula//y=Cos(x)
                ifoda.Parameters["x"] = x;
                double y = Convert.ToDouble(ifoda.Evaluate());
                Point a = new Point(markazX + x * step, markazY - y * step);
                polyline.Points.Add(a);
                //double ekranX = markazX + x * step;
                //double ekranY = markazY - y * step;

                //polyline.Points.Add(new Point(ekranX, ekranY));
            }

            kanvas.Children.Add(polyline);



        }
    }
}
