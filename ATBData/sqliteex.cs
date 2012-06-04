using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

//расширения для SQLite:
//
//сам SQLite не хочет сравнивать слова с рускими буквами, поэтому при помощи расширений
//подменяются функции lower и upper которые используют системные функции приведения к
//регистру и, в итоге, позволяют работать поиску по строкам:
//
//  select * from table where name like '%мама%'               - НЕ РАБОТАЕТ
//  select * from table where lower(name) like lower('%мама%') - РАБОТАЕТ
namespace ATB.Data
{

    [SQLiteFunction(Name = "lower", Arguments = 1, FuncType = FunctionType.Scalar)]
    internal class LoverFunction : SQLiteFunction
    {
        public override object Invoke(object[] args)
        {
            if (args == null || args.Length < 1 || args[0] == null) return null;
            return ((string)args[0]).ToLower();
        }
    }

    [SQLiteFunction(Name = "upper", Arguments = 1, FuncType = FunctionType.Scalar)]
    internal class UpperFunction : SQLiteFunction
    {
        public override object Invoke(object[] args)
        {
            if (args == null || args.Length < 1 || args[0] == null) return null;
            return ((string)args[0]).ToUpper();
        }
    }

}
