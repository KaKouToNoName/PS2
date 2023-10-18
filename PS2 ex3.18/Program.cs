// ************ 18 ***********

double dx, sum, a = 0.5, b = 2.5;
Console.WriteLine($"Примерное значение интеграла: 0.57285");
double f(double x) { return Math.Pow(Math.Log(2 * Math.Sin(x)), 2); }

double RectangleLeft(double a, double b, int n)
{
    dx = 1 * ((b - a) / n);
    sum = 0;
    for (int i = 0; i < n - 1; i++) sum += f(a + i * dx);
    return sum * dx;
}
Console.WriteLine($"По формуле левых треугольников: {RectangleLeft(a, b, 1000)}");
double RectangleRight(double a, double b, int n)
{
    dx = 1 * ((b - a) / n);
    sum = 0;
    for (int i = 1; i < n; i++) sum += f(a + i * dx);
    return sum * dx;
}
Console.WriteLine($"По формуле правых треугольников: {RectangleRight(a, b, 1000)}");
double Trapezoid(double a, double b, int n)
{
    dx = 1 * ((b - a) / n);
    sum = 0.5 * (f(a) + f(b));
    for (int i = 1; i < n; i++) sum += f(a + i * dx);
    return sum * dx;
}
Console.WriteLine($"По формуле трапеции: {Trapezoid(a, b, 1000)}");
double Simpson(double a, double b, int n)
{
    if (n % 2 == 0) n += 1;
    dx = 1 * ((b - a) / n);
    sum = (f(a) + 4 * f(a + dx) + f(b));
    for (int i = 1; i < n / 2; i++) sum += 2 * f(a + (2 * i) * dx) + 4 * f(a + (2 * i + 1) * dx);
    return sum * dx / 3;
}
Console.WriteLine($"По формуле Симпсона: {Simpson(a, b, 1000)}");

double MonteCarlo(double a, double b, int n)
{
    double total = 0, yMax = 0, x, funct;
    int i = 0;
    do
    {
        x = GetRandomNumber(a, b);
        funct = Math.Abs(f(x));
        if (yMax > funct)
        {
            total += funct;
            i++;
        }
        else
        {
            yMax = funct * 2;
            i = 0;
        }
    } while (i < n);
    return (b - a) * total / n;
}
static double GetRandomNumber(double minimum, double maximum)
{
    Random random = new Random();
    return random.NextDouble() * (maximum - minimum) + minimum;
}
Console.WriteLine($"По формуле Монте-Карло: {MonteCarlo(a, b, 1000000)}");