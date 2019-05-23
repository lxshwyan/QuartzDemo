using System;
using System.Linq.Expressions;

namespace LambdaTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Expression<Func<int, bool>> func = i => i == 11 && true;
            Console.WriteLine(func.ToString());
            Console.WriteLine(func.ReturnType.ToString());
            Console.WriteLine(func.Body);
            foreach (var item in func.Parameters)
            {
                Console.WriteLine($"Name:{item.Name},Type:{item.Type}");
            }


            ConstantExpression ce1 = Expression.Constant(10);
            Expression<Func<int>> exp1 = Expression.Lambda<Func<int>>(ce1);
            Console.WriteLine(exp1.ToString());
             Console.WriteLine(exp1.Compile().Invoke());


        }
    }
}
