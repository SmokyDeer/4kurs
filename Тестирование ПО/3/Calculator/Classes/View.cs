using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calculator.Classes
{
    public class View :  Window, ICalculatorView
    {
        public void displayError(string message)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).LbInfo.Content = message;
                }
            }
            
        }

        public string getFirstArgumentAsString()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    return (window as MainWindow).TbA.Text;
                }
            }
            return "";
        }

        public string getSecondArgumentAsString()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    return (window as MainWindow).TbB.Text;
                }
            }
            return "";
        }

        public void printResult(double result)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).LbResult.Content = result.ToString();
                }
            }
            displayError("");
            
        }
    }
}
