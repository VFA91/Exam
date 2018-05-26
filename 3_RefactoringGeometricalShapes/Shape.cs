using System;
using System.Collections.Generic;

namespace RefactoringGeometricalShapes
{
    public class Shape
    {
        //TODO add more shapes if needed
        public const int SQUARE = 1;
        public const int CIRCLE = 2;
        public const int EQUILATERAL_TRIANGLE = 3;
        public static int EN = 1;
        /**
       * The shape's width is readonly.
       */
        private readonly double width;
        public int type = -1;

        /**
       * Constructs a new Shape with the specified width
       */

        public Shape(int type, double width)
        {
            this.type = type;
            this.width = width;
        }

        /**
       * This method generates a HTML string used to be displayed for a web page
       * The generated string depends on the language of the user
       */

        public static String generateHtml(List<Shape> shapes, int userLanguage)
        {
            String returnString = "";

            // test list is empty
            if (shapes.Count == 0)
            {
                if (userLanguage == EN)
                {
                    returnString = "<h1>Empty list of shapes!</h1>";
                }
                else
                {
                    // default is spanish
                    returnString = "<h1>Lista de figuras vacía!</h1>";
                }
            }
            else
            {
                //we have shapes
                //header
                if (userLanguage == EN)
                {
                    returnString += "<h1>Shapes report</h1><br/>";
                }
                else
                {
                    // default is spanish
                    returnString += "<h1>Reporte de figuras</h1><br/>";
                }

                int numberSquares = 0;
                int numberCircles = 0;
                int numberTriangles = 0;

                double areaSquares = 0;
                double areaCircles = 0;
                double areaTriangles = 0;

                double perimeterSquares = 0;
                double perimeterCircles = 0;
                double perimeterTriangles = 0;

                //compute numbers
                for (int i = 0; i < shapes.Count; i++)
                {
                    if (shapes[i].type == SQUARE)
                    {
                        numberSquares++;
                        areaSquares += shapes[i].getArea();
                        perimeterSquares += shapes[i].getPerimeter();
                    }
                    if (shapes[i].type == CIRCLE)
                    {
                        numberCircles++;
                        areaCircles += shapes[i].getArea();
                        perimeterCircles += shapes[i].getPerimeter();
                    }
                    if (shapes[i].type == EQUILATERAL_TRIANGLE)
                    {
                        numberTriangles++;
                        areaTriangles += shapes[i].getArea();
                        perimeterTriangles += shapes[i].getPerimeter();
                    }
                }

                //let`s print this
                returnString += getLine(numberSquares, areaSquares, perimeterSquares, SQUARE, userLanguage);
                returnString += getLine(numberCircles, areaCircles, perimeterCircles, CIRCLE, userLanguage);
                returnString += getLine(numberTriangles, areaTriangles, perimeterTriangles, EQUILATERAL_TRIANGLE, userLanguage);

                //footer
                returnString += "TOTAL:<br/>";
                returnString += (numberCircles + numberSquares + numberTriangles) + " " +
                                (userLanguage == EN ? "shapes" : "figuras") + " ";
                returnString += (userLanguage == EN ? "Perimeter " : "Perímetro ") +
                                (perimeterCircles + perimeterSquares + perimeterTriangles).ToString("#.##") + " ";
                returnString += (userLanguage == EN ? "Area " : "Área ") +
                                (areaCircles + areaSquares + areaTriangles).ToString("#.##");
            }


            return returnString;
        }

        public double getWidth()
        {
            return width;
        }

        public double getArea()
        {
            switch (type)
            {
                case SQUARE:
                    return width * width;
                case CIRCLE:
                    return Math.PI * (width / 2) * (width / 2);
                case EQUILATERAL_TRIANGLE:
                    return (Math.Sqrt(3) / 4) * width * width;
            }
            throw new SystemException("Can`t compute area of unknown shape");
        }

        public double getPerimeter()
        {
            switch (type)
            {
                case SQUARE:
                    return 4 * width;
                case CIRCLE:
                    return Math.PI * width;
                case EQUILATERAL_TRIANGLE:
                    return 3 * width;
            }
            throw new SystemException("Can`t compute area of unknown shape");
        }

        private static String getLine(int numberShapes, double area, double perimeter, int type, int userLanguage)
        {
            if (numberShapes > 0)
            {
                if (userLanguage == EN)
                {
                    return numberShapes + " " + translateShape(type, numberShapes, userLanguage) + " Area " + area.ToString("#.##") +
                           " Perimeter " + perimeter.ToString("#.##") + "<br/>";
                }
                return numberShapes + " " + translateShape(type, numberShapes, userLanguage) + " Área " + area.ToString("#.##") +
                       " Perímetro " + perimeter.ToString("#.##") + "<br/>";
            }
            return "";
        }

        private static String translateShape(int type, int numberShapes, int userLanguage)
        {
            switch (type)
            {
                case SQUARE:
                    if (userLanguage == EN)
                    {
                        return numberShapes == 1 ? "Square" : "Squares";
                    }
                    else
                    {
                        return numberShapes == 1 ? "Cuadrado" : "Cuadrados";
                    }
                case CIRCLE:
                    if (userLanguage == EN)
                    {
                        return numberShapes == 1 ? "Circle" : "Circles";
                    }
                    else
                    {
                        return numberShapes == 1 ? "Círculo" : "Círculos";
                    }
                case EQUILATERAL_TRIANGLE:
                    if (userLanguage == EN)
                    {
                        return numberShapes == 1 ? "Triangle" : "Triangles";
                    }
                    else
                    {
                        return numberShapes == 1 ? "Triángulo" : "Triángulos";
                    }
            }
            return "";
        }
    }
}