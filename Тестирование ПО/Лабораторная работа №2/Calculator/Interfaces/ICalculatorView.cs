using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    interface ICalculatorView
    {
        /**
        * Отображает результат вычисления
        */
        void printResult(double result);

        /**
         * Показывает ошибку, например деление на 0, пустые аргументы и прочее
         */
        void displayError(String message);

        /**
         * Возвращает значение, введенное в поле первого аргументы
         */
        String getFirstArgumentAsString();

        /**
         * Возвращает значение, введенное в поле второго аргументы
         */
        String getSecondArgumentAsString();
    }
}
