using RobotGame;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace JocRobot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int NFILES = 3, NCOLUMNES = 3;
        Tauler joc;
        int moviments = 0;
        Stopwatch rellotge = new Stopwatch();
        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            joc = new Tauler(NFILES, NCOLUMNES);
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
            rellotge.Start();
            InitializeComponent();
            grdTaulell.Children.Add(joc);
            grdTaulell.Background = Brushes.CadetBlue;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            
            joc.posicioRobot();
            ActualitzaTextBlockNMoviments(tbNMoviments, "Moviments Luffy: ", comptador);
            if (joc.jocAcabat())
            {
                
                rellotge.Stop();
                timer.Stop();
                Window finestra = new wndFinal();
                finestra.Show();

            }
            TimeSpan tempsJoc = rellotge.Elapsed;
            ActualitzaTextBlockTemps(tbTempsCronometrat, tempsJoc, "Temps de joc:");
        }
        private void ActualitzaTextBlockNMoviments(TextBlock tb, string titol, int comptador)
        {
            tb.Text = String.Format(titol + "{0}", comptador);
        }
        private void ActualitzaTextBlockTemps(TextBlock tb, TimeSpan temps, string titol)
        {
            tb.Text = String.Format(titol + " {0:00}:{1:00}:{2:00}", temps.Hours, temps.Minutes, temps.Seconds);
        }


    }
}
