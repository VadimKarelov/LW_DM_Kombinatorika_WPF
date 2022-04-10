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

namespace LW_DM_Kombinatorika_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //#D7FBE8 green
        //#CD4A4C red

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Compute(object sender, EventArgs e)
        {
            if (IsDataCorrect())
            {
                if (rb_Permutation.IsChecked == true && rb_NoRepetition.IsChecked == true)
                {
                    long res = CombinatoricsFormulas.PermutationNoRepetition(int.Parse(tb_n.Text), out string solution);
                    tb_Formula.Text = CombinatoricsFormulas.Formula_PermutationNoRepetition;
                    tb_Solution.Text = solution;
                    tb_Answer.Text = res.ToString();
                }
                else if (rb_Permutation.IsChecked == true && rb_Repetition.IsChecked == true)
                {
                    long res = CombinatoricsFormulas.PermutationRepetition(tb_n.Text.Split(' ').Select(long.Parse).ToArray(), out string solution);
                    tb_Formula.Text = CombinatoricsFormulas.Formula_PermutationRepetition;
                    tb_Solution.Text = solution;
                    tb_Answer.Text = res.ToString();
                }
            }
        }

        private bool IsDataCorrect()
        {
            bool res = true;

            if (!(rb_Permutation.IsChecked == true || rb_Accommodation.IsChecked == true || rb_Combination.IsChecked == true))
            {
                res = false;
            }
            if (!(rb_Repetition.IsChecked == true || rb_NoRepetition.IsChecked == true))
            {
                res = false;
            }

            // m
            if (long.TryParse(tb_m.Text, out long t1) && t1 > 0)
            {
                tb_m.Background = new SolidColorBrush(Color.FromRgb(215, 251, 232));
            }
            else
            {
                tb_m.Background = new SolidColorBrush(Color.FromRgb(205, 74, 76));
                res = false;
            }

            // n
            if (rb_Permutation.IsChecked == true && rb_Repetition.IsChecked == true)
            {
                try
                {
                    long[] t3 = tb_n.Text.Split(' ').Select(long.Parse).ToArray();
                    tb_n.Background = new SolidColorBrush(Color.FromRgb(215, 251, 232));
                }
                catch
                {
                    tb_n.Background = new SolidColorBrush(Color.FromRgb(205, 74, 76));
                    res = false;
                }
                tb_Formula.Text = "Введите все значения n в поле n, разделяя их пробелами";
            }
            else
            {
                if (long.TryParse(tb_n.Text, out long t2) && t2 > 0)
                {
                    tb_n.Background = new SolidColorBrush(Color.FromRgb(215, 251, 232));
                }
                else
                {
                    tb_n.Background = new SolidColorBrush(Color.FromRgb(205, 74, 76));
                    res = false;
                }
            }

            if (!res)
                tb_Answer.Text = "";

            return res;
        }
    }
}
