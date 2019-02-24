using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GAMELIFE_REBUILD_LOGIC;
using System.Windows.Threading;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        //хранить в канвас только те элементы которые живы
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        int height=0;
        int width=0;
        root_gamelogic GAME;
        public MainWindow()
        {
            //GAME.randomgeneration();
            InitializeComponent();
            //GAME = root_gamelogic.Create(height, width, 1);
        }
        public void paint_field()
        {
            field.Children.Clear();
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {   //прорисовка игрового поля
                    Rectangle R = new Rectangle();
                    R.Width = field.ActualWidth / (width) - 1;
                    R.Height = field.ActualHeight / (height) - 1;
                    Canvas.SetLeft(R, j * (R.Width+1));//Canvas.Left указывает, на сколько единиц от левой стороны контейнера будет находиться элемент
                    Canvas.SetTop(R, i * (R.Height+1));//Canvas.Top - насколько единиц ниже верхней границы контейнера находится элемент.
                    if (GAME.islive(i, j))
                    {
                        field.Children.Add(R);
                        R.Fill = Brushes.Green;
                    }
                    //else
                    //{
                    //    field.Children.Add(R);
                    //    R.Fill = Brushes.Black;
                    //}
                }
            }
        }
        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            int X = int.Parse(x.Text);
            int Y = int.Parse(y.Text);
            if (X > 0 && X <= 200 && Y > 0 && Y <= 200)
            {
                int Type= int.Parse(type.Text);
                height = X;
                width = Y;
                if (Type == 1 || Type == 2||Type==3)
                {
                    GAME = root_gamelogic.Create(height, width, Type);
                }
                else
                    GAME = root_gamelogic.Create(height, width, 1);
                dispatcherTimer.Stop();
                field.Children.Clear();
                //GAME.time_to_die();
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {   //прорисовка игрового пол
                        Rectangle R = new Rectangle();
                        R.MouseDown += Mouse_Down;
                        R.Width = field.ActualWidth / (width) - 1;
                        R.Height = field.ActualHeight / (height) - 1;
                        R.Fill = Brushes.Black;
                        field.Children.Add(R);
                        Canvas.SetLeft(R, j * (R.Width + 1));//Canvas.Left указывает, на сколько единиц от левой стороны контейнера будет находиться элемент
                        Canvas.SetTop(R, i * (R.Height + 1));//Canvas.Top - насколько единиц ниже верхней границы контейнера находится элемент.
                    }
                }
            }
        }
        public void Mouse_Down(object sender, MouseButtonEventArgs args)
        {
            Rectangle R = sender as Rectangle;
            double j = Canvas.GetLeft(R)/ (R.Width + 1);
            double i = Canvas.GetTop(R)/ (R.Height + 1);
            GAME.press(Convert.ToInt32(i),Convert.ToInt32(j));
            if (R.Fill == Brushes.Black)
                R.Fill = Brushes.Green;
            else
                R.Fill = Brushes.Black;
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            paint_field();
            GAME.nextgeneration();

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (height != 0 && width != 0)
            {
                if (dispatcherTimer.IsEnabled)
                {
                    dispatcherTimer.Stop();
                }
                else
                {
                    dispatcherTimer.Start();
                }
            }
        }
        private void TEMPLATE1(object sender, RoutedEventArgs e)
        {
            if (height > 9 && width > 9)
            {
                GAME.press(4, 5);
                GAME.press(5, 4);
                GAME.press(5, 5);
                GAME.press(5, 6);
                paint_field();
            }
        }
        private void TEMPLATE2(object sender, RoutedEventArgs e)
        {
            if (height > 15 && width > 15)
            {
                GAME.press(1, 3);
                GAME.press(1, 4);
                GAME.press(1, 5);
                GAME.press(1, 9);
                GAME.press(1, 10);
                GAME.press(1, 11);
                GAME.press(4, 1);
                GAME.press(4, 6);
                GAME.press(4, 8);
                GAME.press(4, 13);
                GAME.press(3, 1);
                GAME.press(3, 6);
                GAME.press(3, 8);
                GAME.press(3, 13);
                GAME.press(5, 1);
                GAME.press(5, 6);
                GAME.press(5, 8);
                GAME.press(5, 13);
                GAME.press(6, 3);
                GAME.press(6, 4);
                GAME.press(6, 5);
                GAME.press(6, 9);
                GAME.press(6, 10);
                GAME.press(6, 11);
                GAME.press(8, 3);
                GAME.press(8, 4);
                GAME.press(8, 5);
                GAME.press(8, 9);
                GAME.press(8, 10);
                GAME.press(8, 11);
                GAME.press(9, 1);
                GAME.press(9, 6);
                GAME.press(9, 8);
                GAME.press(9, 13);
                GAME.press(10, 1);
                GAME.press(10, 6);
                GAME.press(10, 8);
                GAME.press(10, 13);
                GAME.press(11, 1);
                GAME.press(11, 6);
                GAME.press(11, 8);
                GAME.press(11, 13);
                GAME.press(13, 3);
                GAME.press(13, 4);
                GAME.press(13, 5);
                GAME.press(13, 9);
                GAME.press(13, 10);
                GAME.press(13, 11);
                paint_field();
            }
        }
        private void TEMPLATE3(object sender, RoutedEventArgs e)
        {
            if (height > 40 && width > 40)
            {
                GAME.press(6,2);
                GAME.press(6, 3);
                GAME.press(7, 2);
                GAME.press(7, 3);
                GAME.press(4, 14);
                GAME.press(4, 15);
                GAME.press(5, 13);
                GAME.press(5, 17);
                GAME.press(6, 12);
                GAME.press(6, 18);
                GAME.press(7, 12);
                GAME.press(7, 18);
                GAME.press(8, 12);
                GAME.press(8, 18);
                GAME.press(9, 13);
                GAME.press(9, 17);
                GAME.press(10, 14);
                GAME.press(10, 15);
                GAME.press(7, 16);
                GAME.press(7, 19);
                GAME.press(4, 22);
                GAME.press(5, 22);
                GAME.press(6, 22);
                GAME.press(4, 23);
                GAME.press(5, 23);
                GAME.press(6, 23);
                GAME.press(3, 24);
                GAME.press(7, 24);
                GAME.press(2, 26);
                GAME.press(3, 26);
                GAME.press(7, 26);
                GAME.press(8, 26);
                GAME.press(4, 36);
                GAME.press(5, 36);
                GAME.press(4, 37);
                GAME.press(5, 37);
                paint_field();
            }
        }
    }
}
