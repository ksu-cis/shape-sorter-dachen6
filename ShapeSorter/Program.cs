using System;
using System.Collections.Generic;
using System.Linq;

namespace ShapeSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fun With Shapes!");
            Console.WriteLine("_______________________");

            List<IShape> shapes = new List<IShape>()
            {
                new Circle(4),
            new Rectangle(3.2, 5.9),
            new Square(3),
            new Square(10),
            new Rectangle(2, 3),
            new Circle(2),
            new Rectangle(10, 10),
            new Circle(8)
        };
        
    
       
            foreach(IShape shape in shapes)
                {
                Console.WriteLine($"Shape with area{shape.Area}");
                }
            Console.WriteLine("_______________________");



            IEnumerable<IShape> filteredShapes = shapes.Where(ShapeSorter => ShapeSorter.Area > 50);
             Console.WriteLine("Shapes with area greater than 50");
            foreach(IShape shape in filteredShapes)
                {
                Console.WriteLine($"Shape with area {shape.Area }");
                }
            Console.WriteLine("_______________________");





                IEnumerable<Circle> circles = shapes.OfType<Circle>();
            foreach(Circle circle in circles)
            {
                Console.WriteLine($"Circle with redius{circle.Radius} and area{circle.Area}");
            }
            Console.WriteLine("_______________________");


            IEnumerable<Circle> FileteredCircles = circles.Where(circle => circle.Area < 70);
            Console.WriteLine("Circle with area less than 70");
            foreach(Circle circle in FileteredCircles)
            {
                Console.WriteLine($"Circle with redius{circle.Radius} and area{circle.Area}");
            }

            Console.WriteLine("Combined example");
            foreach(Circle circle in shapes.OfType<Circle>().Where(c=>c.Radius>3.5))
            {
                Console.WriteLine($"Circle with radius {circle.Radius} and area {circle.Area}");

            }
            Console.WriteLine("_______________________");




            Console.WriteLine("Group by type");
            var groupedShapes = shapes.GroupBy(shape => shape.GetType());
            foreach(var group in groupedShapes)
            {
                Console.WriteLine($"Shape of type{group.Key}");
                foreach(IShape shape in group)
                {
                    Console.WriteLine($"Shape of area {shape.Area}");
                }
            }
            Console.WriteLine("_______________________");





            var groupedByArea = shapes.GroupBy(shape => shape.Area % 2 == 0);

            foreach(var group in groupedByArea)
            {
                Console.WriteLine(group.Key ? "even area" : "Odd Areas");
                foreach(IShape shape in group)
                {
                    Console.WriteLine($"Shape with area {shape.Area}");
                }
            }
            Console.WriteLine("_______________________");




            var maximunArea = shapes.Max(shape => shape.Area);

            Console.WriteLine($"Maximun Area is {maximunArea}");
            Console.WriteLine("_______________________");

            var totalArea = shapes.Sum(shape => shape.Area);
            Console.WriteLine($"Totle Area is {totalArea}");



            Console.ReadKey();
        }
    }
}
