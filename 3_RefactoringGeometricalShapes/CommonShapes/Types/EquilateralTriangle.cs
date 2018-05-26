using System;

namespace RefactoringGeometricalShapes.CommonShapes.Types
{
    public class EquilateralTriangle : ShapeBase
    {
        private const int SIDE = 3;

        public EquilateralTriangle(double width) : base(width) { }

        public override double GetArea() => (Math.Sqrt(3) / 4) * _width * _width;

        public override double GetPerimeter() => SIDE * _width;

        protected override string TranslateShape(int numberShapes)
        {
            return numberShapes == 1 ? Resources.Common.Triangle : Resources.Common.Triangles;
        }
    }
}