using System;

namespace RefactoringGeometricalShapes.CommonShapes.Types
{
    public class Circle : ShapeBase
    {
        public Circle(double width) : base(width) { }

        public override double GetArea() => Math.PI * (_width / 2) * (_width / 2);

        public override double GetPerimeter() => Math.PI * _width;

        protected override string TranslateShape(int numberShapes)
        {
            return numberShapes == 1 ? Resources.Common.Circle : Resources.Common.Circles;
        }
    }
}