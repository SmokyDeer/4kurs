using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calculator
{
    interface ICalculatorPresenter
    {
        /**
   * Вызывается формой в тот момент, когда пользователь нажал на кнопку '+'
   */
        void onPlusClicked(object sender, RoutedEventArgs e);

        /**
         * Вызывается формой в тот момент, когда пользователь нажал на кнопку '-'
         */
        void onMinusClicked(object sender, RoutedEventArgs e);

        /**
         * Вызывается формой в тот момент, когда пользователь нажал на кнопку '/'
         */
        void onDivideClicked(object sender, RoutedEventArgs e);

        /**
         * Вызывается формой в тот момент, когда пользователь нажал на кнопку '*'
         */
        void onMultiplyClicked(object sender, RoutedEventArgs e);
    }
}
