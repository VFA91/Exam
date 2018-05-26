using RefactoringGeometricalShapes.CommonShapes.Types;
using System;

namespace RefactoringGeometricalShapes.CommonShapes
{
    public enum ShapeType
    {
        Circle,
        Square,
        EquilateralTriangle
    }

    public class ShapeFactory
    {
        public static ShapeBase Create(ShapeType type, double width)
        {
            switch (type)
            {
                case ShapeType.Circle:
                    return new Circle(width);
                case ShapeType.Square:
                    return new Square(width);
                case ShapeType.EquilateralTriangle:
                    return new EquilateralTriangle(width);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}