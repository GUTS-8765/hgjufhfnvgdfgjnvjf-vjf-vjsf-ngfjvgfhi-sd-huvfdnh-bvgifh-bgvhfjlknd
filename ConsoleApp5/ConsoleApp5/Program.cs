using System;
using System.Diagnostics;
using System.Text;
using CalcDeliveryNs;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Замер склейки ===");
        Console.WriteLine("строк  |  string+=  |  StringBuilder");
        foreach (int n in new[] { 10_000, 20_000, 40_000 })
        {
            var sw1 = Stopwatch.StartNew();
            string s = "";
            for (int i = 0; i < n; i++) s += i.ToString();
            sw1.Stop();

            var sw2 = Stopwatch.StartNew();
            var sb = new StringBuilder();
            for (int i = 0; i < n; i++) sb.Append(i);
            string s2 = sb.ToString();
            sw2.Stop();

            Console.WriteLine($"{n,6} | {sw1.Elapsed.TotalSeconds,8:F3} с | {sw2.Elapsed.TotalSeconds,8:F4} с");
        }

        Console.WriteLine();
        Console.WriteLine("=== Проверки CalcDelivery (новый тариф) ===");
        Check("вес 3  (скидки нет)", 250, CalcDelivery.Calc(3));
        Check("вес 20 (граница, нет)", 550, CalcDelivery.Calc(20));
        Check("вес 25 (скидка 5%)", 665, CalcDelivery.Calc(25));

        Console.WriteLine();
        Console.WriteLine("=== Проверки CalcDeliveryOld (демо регрессии) ===");
        Check("вес 3", 200, CalcDeliveryOld.Calc(3));
        Check("вес 20", 500, CalcDeliveryOld.Calc(20));
        Check("вес 25", 650, CalcDeliveryOld.Calc(25));
    }
    static void Check(string name, int expected, int actual)
        => Console.WriteLine(
            $"{(expected == actual ? "OK  " : "FAIL")} {name}: ожидалось {expected}, получено {actual}");
}