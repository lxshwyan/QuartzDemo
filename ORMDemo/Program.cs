using System;

namespace ORMDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            OrmSql orm = new OrmSql();
            Console.WriteLine(orm.GetAllSelectSQL<Donator>() );
            Console.WriteLine(orm.GetSelectSQLByID<Donator>(new Donator() {  Id=1}) );
        }
    }
}
