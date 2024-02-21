using System;

class Program
{
    static void Main(string[] args)
    {

        List<Shape> elements = new List<Shape>();

        Square cuadrado = new Square("Blue",2);
        elements.Add(cuadrado);

        Rectangle rectangulo = new Rectangle("yellow", 6, 8);
        elements.Add(rectangulo);

        Circle circulo = new Circle("red", 6);
        elements.Add(circulo);

        foreach(Shape element in elements){
            
            string color = element.GetColor();
            double area = element.GetArea();

            Console.WriteLine($"Your shape is {color} and has a {area} total area.");
        }
        


    }
}