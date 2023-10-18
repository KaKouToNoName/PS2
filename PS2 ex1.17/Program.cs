
// ********** 17 **********
double eps = 0.2, G = 0.915965594177, dif = 1, sum = 0, SigmaSum = 0, count=0;
ulong Factorial(int f) 
{
    ulong s = 1;
    for (uint i = 1; i < f+1; i++) s *= i;
    return s;
}
double Sum(int n)
{
    SigmaSum += Math.Pow(Factorial(n), 2) / ((Factorial(2 * n) * Math.Pow(((2 * n) + 1), 2)));
    return SigmaSum;
}
double KatalanConst(double eps, double G, double dif, double sum)
{
    var Del = 3 / 8d; var Pi = (Math.PI / 8); var Log = (Math.Log(Math.Sqrt(3) + 2)); int n = 1;
    while (Math.Abs(dif) > eps)
    {
        sum = (Pi * Log) + (Del * Sum(n));
        dif = sum - G;
        n++;
        count++;
    }
    return sum;
}
Console.WriteLine($"Сумма ряда с точностью epsilon = {eps} равна {KatalanConst(eps, G, dif, sum)} на {count} шаге");

