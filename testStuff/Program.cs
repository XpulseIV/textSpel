// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

static double Lerp(double a, double b, double t)
{
    return (a * (1.0f - t)) + (b * t);
}

const double stepSize = 1F / 5F;
double t = 0;

for (int i = 5 - 1; i >= 0; i--)
{
    double result = Lerp(0, 100, t);
    t += stepSize;

    Console.WriteLine(result);
}