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

namespace qrblock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Point> TopLeft;
        List<bool> RectColorIsBlack;
        List<Point> WidthHeight;
        public MainWindow()
        {
            InitializeComponent();
            BitmapImage bi = new BitmapImage(new Uri("mctQR.png", UriKind.Relative));
            int stride = bi.PixelWidth * 4;
            int size = bi.PixelHeight * stride;
            byte[] pixels = new byte[size];
            bi.CopyPixels(pixels, stride, 0);
            TopLeft = new List<Point>();
            RectColorIsBlack = new List<bool>();
            WidthHeight = new List<Point>();

            int x, y;
            x = 0;
            y = 0;
            while (y < bi.PixelHeight)
            {
                while (x < bi.PixelWidth)
                {
                    TopLeft.Add(new Point(x, y));
                    int index = y * stride + 4 * x;
                    byte blue = pixels[index];
                    byte green = pixels[index + 1];
                    byte red = pixels[index + 2];
                    byte alpha = pixels[index + 3];
                    if (red < 25 && green < 25 && blue < 25)
                    {
                        RectColorIsBlack.Add(true);

                    }
                    else {
                        RectColorIsBlack.Add(false);
                    }


                    for (int w = x; w < bi.PixelWidth; w++)
                    {
                        index = y * stride + 4 * w;
                        blue = pixels[index];
                        green = pixels[index + 1];
                        red = pixels[index + 2];
                        alpha = pixels[index + 3];
                        if ((red < 25 && green < 25 && blue < 25 && !RectColorIsBlack[RectColorIsBlack.Count-1])||
                            (red > 25 && green > 25 && blue > 25 && RectColorIsBlack[RectColorIsBlack.Count - 1]))
                        {
                            MessageBox.Show(w.ToString());
                        }

                    }
                    //get h

                //add to my list
                
                    
                }
            }
        }
    }
}
