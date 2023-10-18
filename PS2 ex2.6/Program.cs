// ********** 6 **********

double eps = 0.0001, sum = 0; int count = 0;
static long Factorial(int f)
{
    long s = 1;
    for (int i = 1; i < f + 1; i++) s *= i;
    return s;
}
double BinomKoef(double sum)
{
    int n = 0;
    while (Math.Abs(sum - Math.PI) > eps)
    {
        sum += ((50 * n) - 6d) / (Math.Pow(2, n) * (Factorial(3 * n)/(Factorial(n)*Factorial((3*n)-n))));
        //Console.WriteLine($"{((50 * n) - 6d)} / {(Math.Pow(2, n) * (Factorial(3 * n) / (Factorial(n) * Factorial((3 * n) - n))))} = {sum}");
        n++;
        count++;
    }
    return sum;
}
Console.WriteLine($"При формуле через биномиальные коэффициенты и epsilon = {eps} значение: {BinomKoef(sum)} при {count} циклах");