using System.Collections.Generic;
using NUnit.Framework;

namespace RefactoringGeometricalShapes
{
  [TestFixture]
  public class ShapeTest
  {

    [Test]
    public void testReportForEmptyListOfShapes()
    {
      Assert.AreEqual("<h1>Lista de figuras vacía!</h1>", Shape.generateHtml(new List<Shape>(), 0));
    }

    [Test]
    public void testReportForEmptyListOfShapesAndEnglishLanguage()
    {
      Assert.AreEqual("<h1>Empty list of shapes!</h1>", Shape.generateHtml(new List<Shape>(), 1));
    }

    [Test]
    public void testReportForOneSquare()
    {
      List<Shape> shapes = new List<Shape>();
      shapes.Add(new Shape(Shape.SQUARE, 1));
      Assert.AreEqual("<h1>Reporte de figuras</h1><br/>1 Cuadrado Área 1 Perímetro 4<br/>TOTAL:<br/>1 figuras Perímetro 4 Área 1", Shape.generateHtml(shapes, 0));
    }           

    [Test]
    public void testReportForMoreShapesAndEnglishLanguage()
    {
      List<Shape> shapes = new List<Shape>();
      shapes.Add(new Shape(Shape.CIRCLE, 1));
      shapes.Add(new Shape(Shape.SQUARE, 1));
      shapes.Add(new Shape(Shape.EQUILATERAL_TRIANGLE, 2));
      shapes.Add(new Shape(Shape.SQUARE, 2));
      shapes.Add(new Shape(Shape.SQUARE, 3));
      shapes.Add(new Shape(Shape.CIRCLE, 2));
      Assert.AreEqual("<h1>Shapes report</h1><br/>3 Squares Area 14 Perimeter 24<br/>2 Circles Area 3,93 Perimeter 9,42<br/>1 Triangle Area 1,73 Perimeter 6<br/>TOTAL:<br/>6 shapes Perimeter 39,42 Area 19,66", Shape.generateHtml(shapes, 1));
    }
  }
}
