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
        public MainWindow()
        {
            InitializeComponent();

        }

        public void onDivideClicked(object sender, RoutedEventArgs e)
        {
            double a = Convert.ToDouble(_view.getFirstArgumentAsString());
            double b = Convert.ToDouble(_view.getSecondArgumentAsString());

            _view.printResult(_calculator.divide(a, b));
        }

        public void onMinusClicked(object sender, RoutedEventArgs e)
        {
            double a = Convert.ToDouble(_view.getFirstArgumentAsString());
            double b = Convert.ToDouble(_view.getSecondArgumentAsString());

            _view.printResult(_calculator.subtract(a, b));
        }

        public void onMultiplyClicked(object sender, RoutedEventArgs e)
        {
            double a = Convert.ToDouble(_view.getFirstArgumentAsString());
            double b = Convert.ToDouble(_view.getSecondArgumentAsString());

            _view.printResult(_calculator.multiply(a, b));
        }

        public void onPlusClicked(object sender, RoutedEventArgs e)
        {
            double a = Convert.ToDouble(_view.getFirstArgumentAsString());
            double b = Convert.ToDouble(_view.getSecondArgumentAsString());

            _view.printResult(_calculator.sum(a, b));
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,]");
            e.Handled = regex.IsMatch(e.Text);
        }


    }
}
