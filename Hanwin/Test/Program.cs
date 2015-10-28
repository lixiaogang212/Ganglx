using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //string s = Hash("1");
            //string s2 = Hash("1");
            //Console.WriteLine(s);
            //Console.WriteLine(s2);
            //Console.WriteLine(s2==s);
            //List<object> ol = Test();
            //for (int i = 1; i <= 9; i++)
            //{
            //    for (int j = 1; j <= i; j++)
            //    {
            //        Console.Write(i + "*" + j + "=" + (i * j) + "\t");
            //    }
            //    Console.WriteLine();
            //}
            int sum = 0;
            for (int i = 1; i < 101; i++)
            {
                sum += i;
            }
            Console.WriteLine(sum);
            Console.ReadKey();
        }
        public static string Hash(string toHash)
        {
            MD5CryptoServiceProvider crypto = new MD5CryptoServiceProvider();
            byte[] bytes = Encoding.UTF7.GetBytes(toHash);
            bytes = crypto.ComputeHash(bytes);
            StringBuilder sb = new StringBuilder();
            foreach (byte num in bytes)
            {
                sb.AppendFormat("{0:x2}", num);
            }
            return sb.ToString();        //32位
            //return sb.ToString().Substring(8, 16);        //16位
        }
        public static List<Object> Test() {
            List<Object> list = new List<object>();
            for (var i = 0; i < 35;i++ )
                list.Add(new { userlist = "dadasdad", isCheck = "dasdasdasdas" });
            return list;
        }
        //public T GetFirst(Expression<Func<T, bool>> criteria)
        //{
        //    var list = ListTopX(criteria, 1, null);
        //    if (list.Count() > 0)
        //        return list.FirstOrDefault();
        //    return null;
        //}
        //dalSysUser.GetFirst(x => x.Account == model.Account && x.Password == model.Password && x.IsDeleted == false)
        //public virtual IQueryable<T> ListTopX(Expression<Func<T, bool>> criteria, Int64 count, params LinqOrder<T>[] orderCollection)
        //{
        //    IQueryable<T> query = Session.Query<T>();
        //    if (criteria != null)
        //        query = query.Where(criteria);
        //    //添加排序条件
        //    query = AttachOrders(query, orderCollection);
        //    return query.Take((Int32)count);
        //}
    }
}
