using System;
using System.Data;
using System.Globalization;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography.X509Certificates;

namespace Laba4
{
    public class Owner
    {
        public int ID;
        public string name;
        public string nameOrganiz;
        public Owner(int id, string nm, string nO)
        {
            ID = id;
            name = nm;
            nameOrganiz = nO;
        }
    }

    public class Arra
    {
        public class Date
        {
            public string date;

            public Date (string dt)
            {
                date = dt;
            }
        }

        public Owner owner = new Owner(123, "Danila", "DanilaCorp");
        public Date dt = new Date("12042002");
        public int[] nums;
        public char[] str;

        private Arra() { }

        public Arra(params int[] arr)
        {
            str = null;
            nums = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                nums[i] = arr[i];
            }
        }

        public Arra(params char[] arr)
        {
            nums = null;
            str = new char[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                str[i] = arr[i];
            }
        }

        //public bool CheckSymb(char ch)
        //{
        //    if (str == null)
        //    {
        //        //Console.WriteLine("Class definded as Int array^-^");
        //        return false;
        //    }

        //    foreach (char i in str)
        //    {
        //        if (ch == i) return true;
        //    }

        //    return false;
        //}

        //public bool CheckSymb(int num)
        //{
        //    if (nums == null)
        //    {
        //        //Console.WriteLine("Class definded as Char array^-^");
        //        return false;
        //    }

        //    foreach (int i in nums)
        //    {
        //        if (num == i) return true;
        //    }

        //    return false;
        //}

        //public void DeleteNeg()
        //{
        //    if (nums == null)
        //    {
        //        Console.WriteLine("Class definded as Char array^-^");
        //        return;
        //    }

        //    int counter = 0;
        //    for (int i = 0; i < nums.Length; i++)
        //        if (nums[i] < 0) counter++;

        //    if (counter != 0)
        //    {
        //        int[] buf = new int[nums.Length - counter];

        //        for (int i = 0, j = 0; i < nums.Length; i++)
        //        {
        //            if (nums[i] >= 0)
        //            {
        //                buf[j++] = nums[i];
        //            }
        //        }

        //        nums = buf;
        //    }
        //}

        public override string ToString()
        {
            if (str == null)
            {
                string arr = $"";
                for (int i = 0; i < nums.Length; i++)
                {
                    arr += $"{nums[i]} ";
                }
                return arr;
            }

            if (nums == null)
            {
                string arr = $"";
                for (int i = 0; i < str.Length; i++)
                {
                    arr += $"{str[i]} ";
                }
                return arr;
            }

            return "Exception?";
        }

        //Returns Arra with longest Length
        public static Arra operator *(Arra a1, Arra a2)
        {
            if (a1.nums == null || a2.nums == null)
            {
                Console.WriteLine("Wrong types");
                return null;
            }


            int[] arr;
            if (a1.nums.Length > a2.nums.Length)
            {
                arr = new int[a1.nums.Length];
                for (int i = 0; i < a2.nums.Length; i++)
                    arr[i] = a1.nums[i] * a2.nums[i];
                for (int i = 0; i < a1.nums.Length - a2.nums.Length; i++)
                    arr[i + a2.nums.Length] = 0;
            }
            else
            {
                arr = new int[a2.nums.Length];
                for (int i = 0; i < a1.nums.Length; i++)
                    arr[i] = a1.nums[i] * a2.nums[i];
                for (int i = 0; i < a2.nums.Length - a1.nums.Length; i++)
                    arr[i + a1.nums.Length] = 0;
            }

            Arra a = new Arra(arr);

            return a;
        }

        public static explicit operator int(Arra a)
        {
            if (a.nums != null) return a.nums.Length;
            else return a.str.Length;
        }

        public static bool operator ==(Arra a1, Arra a2)
        {
            if ((a1.nums == null && a2.str == null) || (a1.str == null && a2.nums == null))
            {
                Console.WriteLine("Difirent types");
                return false;
            }

            if (a1.str == null)
            {
                if (a1.nums.Length != a2.nums.Length)
                    return false;
                else
                {
                    for (int i = 0; i < a1.nums.Length; i++)
                    {
                        if (a1.nums[i] != a2.nums[i])
                            return false;
                    }
                    return true;
                }
            }
            else
            {
                if (a1.str.Length != a2.str.Length)
                    return false;
                else
                {
                    for (int i = 0; i < a1.nums.Length; i++)
                    {
                        if (a1.nums[i] != a2.nums[i])
                            return false;
                    }
                    return true;
                }
            }
        }

        public static bool operator !=(Arra a1, Arra a2)
        {
            //Console.WriteLine("!= WIP");
            return !(a1 == a2);
        }

        public static bool operator true(Arra a1)
        {
            foreach (int i in a1.nums)
                if (i < 0) { return false; }
            return true;
        }

        public static bool operator false(Arra a1)
        {
            foreach (int i in a1.nums)
                if (i < 0) { return true; }
            return false;
        }
    }

    static class StaticOperation
    {
        public static int Sum(Arra a)
        {
            if (a.nums == null)
                return 0;
            else
            {
                int min = a.nums[0], max = a.nums[0];
                foreach (int i in a.nums)
                {
                    if (i < min) min = i;
                    if (i > max) max = i;
                }
                return min + max;
            }
        }
        public static int Differ(Arra a)
        {
            if (a.nums == null)
                return 0;
            else
            {
                int min = a.nums[0], max = a.nums[0];
                foreach (int i in a.nums)
                {
                    if (i < min) min = i;
                    if (i > max) max = i;
                }
                return max - min;
            }
        }
        public static int Count(Arra a)
        {
            if (a.nums == null)
                return 0;
            else return a.nums.Length;
        }

        public static bool CheckSymb(this Arra a, char ch)
        {
            if (a.str == null)
            {
                //Console.WriteLine("Class definded as Int array^-^");
                return false;
            }

            foreach (char i in a.str)
            {
                if (ch == i) return true;
            }

            return false;
        }
        public static bool CheckSymb(this Arra a, int num)
        {
            if (a.nums == null)
            {
                //Console.WriteLine("Class definded as Int array^-^");
                return false;
            }

            foreach (char i in a.nums)
            {
                if (num == i) return true;
            }

            return false;
        }
        public static void DeleteNeg(this Arra a)
        {
            if (a.nums == null)
            {
                Console.WriteLine("Class definded as Char array^-^");
                return;
            }

            int counter = 0;
            for (int i = 0; i < a.nums.Length; i++)
                if (a.nums[i] < 0) counter++;

            if (counter != 0)
            {
                int[] buf = new int[a.nums.Length - counter];

                for (int i = 0, j = 0; i < a.nums.Length; i++)
                {
                    if (a.nums[i] >= 0)
                    {
                        buf[j++] = a.nums[i];
                    }
                }

                a.nums = buf;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            char[] ch = new char[] { 'a', 'b', 'c' };
            int[] ar = new int[] { 1, 2, 3 };
            int[] ar1 = new int[] { 1, 2, -3, 4 };
            Arra a1 = new Arra(ar1);
            Arra a2 = new Arra(ar);
            Arra a3 = a1 * a2;
            if (a2)
                Console.WriteLine(true);
            else
                Console.WriteLine(false);
        }
    }
}
