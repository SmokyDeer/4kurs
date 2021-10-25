using Calculator.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ICalculatorPresenter
    {
        private Calc _calculator = new Calc();
        private View _view = new View();
        
        private delegate double ToCalculate(double a, double b);
        ToCalculate toCalculate;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void onDivideClicked(object sender, RoutedEventArgs e)
        {
            toCalculate = _calculator.divide;
            ToCallCalc();
        }

        public void onMinusClicked(object sender, RoutedEventArgs e)
        {
            toCalculate = _calculator.subtract;
            ToCallCalc();
        }

        public void onMultiplyClicked(object sender, RoutedEventArgs e)
        {
            toCalculate = _calculator.multiply;
            ToCallCalc();
        }

        public void onPlusClicked(object sender, RoutedEventArgs e)
        {
            toCalculate = _calculator.sum;
            ToCallCalc();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void ToCallCalc()
        {
            (double, double) aa = GetInputValues();

            try
            {
                _view.printResult(toCalculate(aa.Item1, aa.Item2));
            }
            catch(Exception e)
            {
                _view.displayError(e.Message);
            }
        }

        private (double,double) GetInputValues()
        {
            double a;
            double b;


            var resA = Double.TryParse(_view.getFirstArgumentAsString(), out a);
            var resB = Double.TryParse(_view.getSecondArgumentAsString(), out b);

            Trace.WriteLine(resA + " " + resB + " " + a + " " + b);
            if (!(resA && resB))
            {
                a = double.NaN;
                b = double.NaN;
            }

            return (a, b);
        }


    }
}
