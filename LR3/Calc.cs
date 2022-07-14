using System;
using System.Collections.Generic;
using System.Linq;


namespace LR3
{
    public class Calc
    {
        public double Calculate(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
                throw new ArgumentNullException(nameof(expression), "Введено пустое выражение.");
            Converter converter = new Converter();
            var operands = converter.GetOperands(expression);
            string output = converter.GetExpression(operands); 
            double result = Counting(output); 
            return result; 
        }
        private double Counting(string output)
        {
            if (string.IsNullOrWhiteSpace(output))
                throw new ArgumentNullException(nameof(output), "Введено пустое выражение.");
            char[] operators = new char[] { '*', '/', '+', '=', '-'};
            double result = 0;
            Stack<double> temp = new Stack<double>(); 

            for (int i = 0; i < output.Length; i++) 
            {
               
                if (Char.IsDigit(output[i]))
                {
                    string a = string.Empty;

                    while (!output[i].Equals(' ') && !operators.Any(x => x.Equals(output[i]))) 
                    {
                        a += output[i]; 
                        i++;
                        if (i == output.Length) break;
                    }
                    temp.Push(double.Parse(a)); 
                    i--;
                }
                else if (operators.Any(x => x.Equals(output[i])))
                {
                    
                    double a = temp.Pop();
                    double b = temp.Pop();

                    switch (output[i]) 
                    {
                        case '+': result = b + a; break;
                        case '-': result = b - a; break;
                        case '*': result = b * a; break;
                        case '/': result = b / a; break;
                    }
                    temp.Push(result); 
                }
            }
            return temp.Peek(); 
        }
    }
}
