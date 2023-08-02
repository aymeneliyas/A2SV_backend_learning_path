using System;

namespace Shape
{
    public class Program {
        public static void Main(string[] args)
        {
            Shape s = new Shape();
            Traingle t = new Traingle(4, 4);
            Rectangle r = new Rectangle(4, 4);
            Circle c = new Circle(4);
            double value;
            printShapeArea(t);
            printShapeArea(r);
            printShapeArea(c);
        }

        public static void printShapeArea(Shape s)
        {

            Console.WriteLine("the area of the {0} is {1}", s.Name, s.CalculateArea());


        }

    }




    public class Shape
    {
        public string Name;

        public virtual double CalculateArea()
        {
            return 0;
        }
    }

    public class Rectangle : Shape
    {
        private double width;
        private double height;
        private Rectangle(double width, double height)
        {
            this.Name = "Rectangle";
            this.width = width;
            this.height = height;

        }

        public override double CalculateArea()
        {
            return width * height;
        }

    }

    public class Traingle : Shape
    {
        private doubl Base;
        private double height;

        private Traingle(double Base, double height)
        {
            this.Name = "Traingle";
            this.Base = Base;
            this.height = height;
        }

        public override double CalculateArea()
        {
            return Base * height * 0.5;
        }

    }

    public class Circle : Shape
    {
        private double radius;
        public Circle(double radius)
        {
            this.Name = "circle";
            this.radius = radius;
        }

        public override double CalculateArea()
        {
            return radius * radius * Math.PI;
        }
    }

}
