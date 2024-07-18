var retangle1 = new Retangle(5,10);
var calculor = new ShapesMeasurementsCalculator();

Console.WriteLine("Width is " + retangle1.Width);
Console.WriteLine("Height is " + retangle1.Height);
Console.WriteLine("Area is " + calculor.CalculateRetangleArea(retangle1));
Console.WriteLine("Circumference is " + calculor.CalculateRetangleCircumference(retangle1));

var retangle2 = new Retangle(2, 3);

Console.WriteLine("Width is " + retangle2.Width);
Console.WriteLine("Height is " + retangle2.Height);
Console.WriteLine("Area is " + calculor.CalculateRetangleArea(retangle2));
Console.WriteLine("Circumference is " + calculor.CalculateRetangleCircumference(retangle2));

Console.ReadKey();

class Retangle
{
    public int Width = 3; 
    public int Height = 4;

    public Retangle(int width, int height)
    {
        Width = width;
        Height = height;
    }

}
class ShapesMeasurementsCalculator
{

    public int CalculateRetangleArea(Retangle retangle) => retangle.Width * retangle.Height;

    public int CalculateRetangleCircumference(Retangle retangle) => 2 * (retangle.Width + retangle.Height);
}

public class Triangle
{
    private int _base;
    private int _height;

    public Triangle(int @base, int height)
    {
        _base = @base;
        _height = height;
    }

    public int CalculateArea() => (_base * _height) / 2;

    public string AsString() => $"Base is {_base}, height is {_height}";

}

