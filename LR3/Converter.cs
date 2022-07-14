using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LR3
{
    public class Converter
    {
        private char[] operators = new char[] { '*', '/', '+', '=', '-' };
        private int[] numbers = new int[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        
        static private byte GetPriority(char s)
        {
            switch (s)
            {
                case '(': return 0;
                case ')': return 1;
                case '+': return 2;
                case '-': return 3;
                case '*': return 4;
                case '/': return 4;
                default: return 5;
            }
        }      
        public List<string> GetOperands(string line)
        {
            if (string.IsNullOrEmpty(line))
                throw new ArgumentNullException(nameof(line), "Ввведено пустое выражение.");

            var retData = new List<string>();
            var oper = new StringBuilder();

            for (int i = 0; i < line.Length; i++)
            {
                if (operators.Any(x => x.Equals(line[i])))
                {
                    retData.Add(oper.ToString());
                    retData.Add(line[i].ToString());
                    oper.Clear();
                }
                else
                    oper.Append(line[i]);

                if (i == line.Length - 1)
                    retData.Add(oper.ToString());
            }

            return retData;
        }       
        public IDictionary<string, double> ConvertToDictionary(List<string> lines)
        {
            if (lines == null)
                throw new ArgumentNullException(nameof(lines), "Ввведено пустое выражение.");

            var dic = new Dictionary<string, double>();

            foreach (var line in lines)
                if (line.Contains("="))
                    dic.Add(line.Split('=')[0].Trim(), Convert.ToDouble(line.Split('=')[1].Replace(";", string.Empty).Trim()));

            return dic;
        } 
        public string ReplaceLine(string line, IDictionary<string, double> dic)
        {
            if (string.IsNullOrWhiteSpace(line))
                throw new ArgumentNullException(nameof(line), "Ввведено пустое выражение.");

            if (dic == null)
                throw new ArgumentNullException(nameof(dic), "Словарь переменных пуст.");

            foreach (var kvp in dic)
                line = line.Replace(kvp.Key, kvp.Value.ToString());

            return line.Replace(";", string.Empty);
        }
        public string GetExpression(List<string> sequence)
        {
            if (sequence == null)
                throw new ArgumentNullException(nameof(sequence), "Ввведено пустое выражение.");
            string result = string.Empty; 
            Stack<char> operStack = new Stack<char>(); 
            string output = string.Empty;
            output = string.Join("", sequence);
            char[] charArr = output.ToCharArray();
            for (int i = 0; i < output.Length; i++) 
            { 
                if (charArr[i].Equals(" "))
                    continue;  
                if (numbers.Any(x => x.Equals(charArr[i]))) 
                {
                   
                    while (!charArr[i].Equals(" ") && !operators.Any(x => x.Equals(charArr[i])))
                    {
                        result += charArr[i]; 
                        i++; 

                        if (i == charArr.Length) break; 
                    }
                }               
                if (i < output.Length)
                {
                    if (operators.Any(x => x.Equals(charArr[i])))
                    {
                        if (operStack.Count > 0) 
                            if (GetPriority(charArr[i]) <= GetPriority(operStack.Peek())) 
                                result += operStack.Pop().ToString() + " "; 
                        operStack.Push(char.Parse(output[i].ToString())); 

                    }
                }
            }          
            while (operStack.Count > 0)
                result += operStack.Pop() + " ";
            return result; 
        }
    }
}
