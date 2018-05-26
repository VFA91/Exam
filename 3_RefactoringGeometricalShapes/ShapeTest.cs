using System.Collections.Generic;
using NUnit.Framework;
using RefactoringGeometricalShapes.CommonShapes;
using RefactoringGeometricalShapes.CommonShapes.Types;

namespace RefactoringGeometricalShapes
{
    [TestFixture]
    public class ShapeTest
    {
        [Test]
        public void testReportForEmptyListOfShapes()
        {
            Shapes shapes = new Shapes(new List<ShapeBase>(), Language.SP);
            Assert.AreEqual("<h1>Lista de figuras vacía!</h1>", shapes.GenerateHtml());
        }

        [Test]
        public void testReportForEmptyListOfShapesAndEnglishLanguage()
        {
            Shapes shapes = new Shapes(new List<ShapeBase>(), Language.EN);
            Assert.AreEqual("<h1>Empty list of shapes!</h1>", shapes.GenerateHtml());
        }

        [Test]
        public void testReportForOneSquare()
        {
            Shapes shapes = new Shapes(new List<ShapeBase>
            {
                ShapeFactory.Create(ShapeType.Square, 1)
            }, Language.SP);
            Assert.AreEqual("<h1>Reporte de figuras</h1><br/>1 Cuadrado Área 1 Perímetro 4<br/>TOTAL:<br/>1 figuras Perímetro 4 Área 1", shapes.GenerateHtml());
        }

        [Test]
        public void testReportForMoreShapesAndEnglishLanguage()
        {
            Shapes shapes = new Shapes(new List<ShapeBase>
            {
                ShapeFactory.Create(ShapeType.Circle, 1),
                ShapeFactory.Create(ShapeType.Square, 1),
                ShapeFactory.Create(ShapeType.EquilateralTriangle, 2),
                ShapeFactory.Create(ShapeType.Square, 2),
                ShapeFactory.Create(ShapeType.Square, 3),
                ShapeFactory.Create(ShapeType.Circle, 2)
            }, Language.EN);
            Assert.AreEqual("<h1>Shapes report</h1><br/>3 Squares Area 14 Perimeter 24<br/>2 Circles Area 3,93 Perimeter 9,42<br/>1 Triangle Area 1,73 Perimeter 6<br/>TOTAL:<br/>6 shapes Perimeter 39,42 Area 19,66", shapes.GenerateHtml());
        }
    }
}
