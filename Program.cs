using System;

namespace PointAndRectangle
{
    class Point
    {
        // fields : 
        public double x;
        public double y; 
        public Point(double x, double y) //constructor 1 : 
        {
            this.x = x;
            this.y = y;
        }
        public Point() // constructor 2 :
        {
          
        }
        public double DistanceFromOrigin() // formula is : d = √((x2 – x1)² + (y2 – y1)²), since the origin's x and y equals to 0 : 
        {
            double distance = Math.Sqrt((x * x) + (y * y));
            return distance;
        }
        public void DisplayPoint() // to show the point info : 
        {
            Console.WriteLine("x = " + x + ", y = " + y);
        }
    }
    class Rectangle
    {
        //fields : 
        public double length;
        public double width;
        public Point topRight;
        public Rectangle(double length, double width, Point topRight)   //constructor 1 :
        {
            this.length = length;
            this.width = width;
            this.topRight = topRight;
        }
        public Rectangle() //constructor 2 : 
        {
            
        }
        public void setLength(double l) // given length must be greater than 0 : (using set/get)
        {
            if (l < 0)
                Console.WriteLine("ERROR : Length must be greater than 0!");
            else
                length = l;
        }
        public double getLength()
        {
            return length;
        }
        public void setWidth(double w) // given width must be greater than 0 : (using set/get)
        {
            if (w < 0)
                Console.WriteLine("ERROR : Width must be greater than 0!");
            else
                width = w;
        }
        public double getWidth()
        {
            return width;
        }
        public double perimeter() // calculating perimeter : 
        {
            return 2 * (length + width);
        }
        public double area() //calculating area : 
        {
            return length * width;
        }
        public bool isInside(Point point) // if a point is inside the rectangle : 
        {
            if (point.x > (topRight.x - length) && point.x < topRight.x && point.y > topRight.y - width && point.y < topRight.y) // if the range of the point.x is between the maximum x of our rectangle and minimum x of our rectangle and the range of point.y is between the maximum and minimum of the y of our rectangle.
                return true;
            else
                return false;
        }
        public bool isOverlap(Rectangle rectangle )
        {
            if (rectangle.topRight.x < topRight.x - length || topRight.x < rectangle.topRight.x - rectangle.length) //if the ccurrent rectangle is on the left side of the input rectangle or on the right side of it
                return false;
            else if (rectangle.topRight.y - rectangle.width > topRight.y || rectangle.topRight.y < topRight.y - width) // if the current rectangle is above the input rectangle or below it .
                return false;
            return true;
        }
        public void rectangleDisplay()
        {
            Console.WriteLine(" Length =  " + length + " , width =  " + width );
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Point point1 = new Point();
                Point topRight = new Point();
                Rectangle rectangle = new Rectangle();
                int operation = 0;
                Console.WriteLine("Welcome!");
                Console.WriteLine("Enter any number to see the menue ! ");
                int menu = Convert.ToInt32(Console.ReadLine());
                do
                {
                    Console.WriteLine("**NOTE : FOR OPTION 7 & 8 YOU HAVE TO MAKE A RECTANGLE FIRST.**");
                    Console.WriteLine("\n 1.Make a point : " + "\n 2. Find out the point's distance from the origin : " +
                        "\n 3. Print point's information : " +
                        "\n 4. Make a rectangle : " + "\n 5. Rectangle's Perimeter : " + "\n 6. Rectangle's area : " + "\n 7. Find out a point is indside your rectangle : " +
                        "\n 8. Find out 2 rectangles overlap or not : " + "\n 9. Print rectangle information : "+"\n 0. Exit ");
                    Console.WriteLine("Choose Your Operation :  ");
                    operation = Convert.ToInt32(Console.ReadLine());
                    switch(operation)
                    {
                        case 1:
                            Console.WriteLine("Enter x : ");
                            double x = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Enter y : ");
                            double y = Convert.ToDouble(Console.ReadLine());
                            point1.x = x;
                            point1.y = y;
                            break;
                        case 2:
                            Console.WriteLine("The distance between point and origin is : ");
                            Console.WriteLine(point1.DistanceFromOrigin());
                            break;
                        case 3:
                            Console.WriteLine("Point Information : ");
                            point1.DisplayPoint();
                            break;
                        case 4:
                            Console.WriteLine("Enter Length : ");
                            double length1 = Convert.ToDouble(Console.ReadLine());
                            rectangle.setLength(length1);
                            Console.WriteLine("Enter width : ");
                            double width1 = Convert.ToDouble(Console.ReadLine());
                            rectangle.setWidth(width1);
                            Console.WriteLine("Enter the top-right-point : for example (x,y) : ");
                            double toprx = Convert.ToDouble(Console.ReadLine());
                            double topry = Convert.ToDouble(Console.ReadLine());
                            Point topright1 = new Point(toprx,topry);
                            rectangle.length = length1;
                            rectangle.width = width1;
                            rectangle.topRight = topright1;
                            break;
                        case 5:
                            Console.WriteLine("Perimeter : ");
                            Console.WriteLine(rectangle.perimeter());
                            break;
                        case 6:
                            Console.WriteLine("Area : ");
                            Console.WriteLine(rectangle.area());
                            break;
                        case 7:
                            Console.WriteLine("*if you have not make a point yet or you want to make a new point *\n Enter new. \n Else Enter curr. **Note : If you have not made a rectangle !!**");
                            string answer = Console.ReadLine();
                            if (answer == "new")
                            {
                                Point point2 = new Point();
                                Console.WriteLine("Enter x : ");
                                double x2 = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine("Enter y : ");
                                double y2 = Convert.ToDouble(Console.ReadLine());
                                point2.x = x2;
                                point2.y = y2;
                                Console.WriteLine(rectangle.isInside(point2));
                            }
                            else
                            {
                                Console.WriteLine(rectangle.isInside(point1));
                            }
                            break;
                        case 8:
                            Console.WriteLine("Make a new rectangle : ");
                            Rectangle rectangle2 = new Rectangle();
                            Console.WriteLine("Enter Length : ");
                            double length2 = Convert.ToDouble(Console.ReadLine());
                            rectangle.setLength(length2);
                            Console.WriteLine("Enter width : ");
                            double width2 = Convert.ToDouble(Console.ReadLine());
                            rectangle.setWidth(width2);
                            Console.WriteLine("Enter the top-right-point : for example (x,y) : ");
                            double toprx2 = Convert.ToDouble(Console.ReadLine());
                            double topry2 = Convert.ToDouble(Console.ReadLine());
                            Point topRight2 = new Point();
                            topRight2.x = toprx2;
                            topRight2.y = topry2;
                            rectangle2.length = length2;
                            rectangle2.width = width2;
                            rectangle2.topRight = topRight2;
                            Console.WriteLine("Your current rectangle and your new rectangle oerlap? : ");
                            Console.WriteLine(rectangle.isOverlap(rectangle2));
                            break;
                        case 9:
                            Console.WriteLine("Rectangle info : ");
                            rectangle.rectangleDisplay();
                            break;
                        case 0:
                            Console.WriteLine("Exiting program!Bye!!");
                            break;
                    }

                }
                while (operation!=0);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
