using System;
using System.Numerics;
using System.Reflection;
using System.Threading.Tasks;

namespace DesafioPorter.Helpers
{
    public class Calculator
    {
        public long SumArray(int[] numbers)
        {
            long sum = 0;

            //Two easy ways that work better, but not optimal yet

            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    sum += numbers[i];
            //}

            //foreach (int number in numbers)
            //{
            //    sum += number;
            //}

            //Trying to optimize:

            //var isOdd = numbers.Length % 2 != 0;

            //for (int i = 0; i < numbers.Length; i += 2)
            //{
            //    sum += isOdd && i + 1 >= numbers.Length 
            //        ? numbers[i] 
            //        : numbers[i] + numbers[i + 1];
            //}

            //Optimised, at least 2 times faster for big arrays:

            if(numbers != null && numbers.Length > 0) 
            { 
                int index = 0;
                for (int i = 0; i < numbers.Length; index = i += 5)
                {
                    if (index + 4 >= numbers.Length)
                    {
                        break;
                    }
                    sum += numbers[i] + numbers[i + 1] + numbers[i + 2] + numbers[i + 3] + numbers[i + 4];
                }

                for (int i = index; i < numbers.Length; i++)
                {
                    sum += numbers[i];
                }
            } 

            return sum;
        }


        public double EvaluateEquation(string expression)
        {
            expression = expression.Replace(" ","");

            while (expression.Contains('(') && expression.Contains(')'))
            {
                expression = ResolveInnermostParentheses(expression);
            }

            var values = new Stack<double>();
            var operators = new Stack<char>();

            for (int i = 0; i < expression.Length; i++)
            {
                char currentChar = expression[i];

                if (currentChar == '-' && (i == 0 || (i > 2 || IsOperator(expression[i - 1]))))
                {
                    continue;
                }

                if (char.IsDigit(currentChar))
                {
                    string number = "";
                    if (i > 0 && expression[i - 1] == '-' && (i == 1 || (i > 3 || IsOperator(expression[i - 2]))))
                    {
                        number = "-";
                    }
                    
                    while (i < expression.Length && (char.IsDigit(expression[i]) || expression[i] == '.' || expression[i] == ','))
                    {
                        number += expression[i];
                        i++;
                    }
                    i--;

                    values.Push(double.Parse(number));
                }
                else if (IsOperator(currentChar))
                {
                    while (operators.Count > 0 && HasPrecedence(currentChar, operators.Peek()))
                    {
                        double val2 = values.Pop();
                        double val1 = values.Pop();
                        char op = operators.Pop();
                        double res = PerformOperation(val1, val2, op);
                        values.Push(res);
                    }
                    operators.Push(currentChar);
                }
            }

            while (operators.Count > 0)
            {
                double val2 = values.Pop();
                double val1 = values.Pop();
                char op = operators.Pop();
                double res = PerformOperation(val1, val2, op);
                values.Push(res);
            }

            return values.Pop();
        }

        private string ResolveInnermostParentheses(string expression)
        {
            int startIndex = expression.LastIndexOf('(');
            if (startIndex == -1)
            {
                return string.Empty;
            }

            int endIndex = expression.IndexOf(')', startIndex);
            if (endIndex == -1)
            {
                throw new ArgumentException("Equação inválida: parênteses desbalanceados.");
            }

            var result = expression.Substring(startIndex + 1, endIndex - startIndex - 1);
            var value = EvaluateEquation(result);

            return expression.Remove(startIndex, endIndex - startIndex + 1).Insert(startIndex, value.ToString()); ;
        }

        private bool IsOperator(char c)
        {
            return (c == '+' || c == '-' || c == '*' || c == '/');
        }

        static bool HasPrecedence(char operation1, char operation2)
        {
            if ((operation1 == '*' || operation1 == '/') && (operation2 == '+' || operation2 == '-'))
                return false;
            else
                return true;
        }

        private double PerformOperation(double value1, double value2, char operation)
        {
            switch (operation)
            {
                case '+':
                    return value1 + value2;
                case '-':
                    return value1 - value2;
                case '*':
                    return value1 * value2;
                case '/':
                    if(value2 == 0)
                    {
                        throw new ArgumentException("Ocorreu uma divizão por zero.");
                    }
                    return value1 / value2;
                default:
                    throw new ArgumentException("Operador inválido.");
            }
        }

    }
}
