namespace RefactoringGeometricalShapes.CommonShapes.Types
{
    public class Square : ShapeBase
    {
        private const int SIDE = 4;

        public Square(double width) : base(width) { }

        public override double GetArea() => _width * _width;

        public override double GetPerimeter() => SIDE * _width;

        protected override string TranslateShape(int numberShapes)
        {
            return numberShapes == 1 ? Resources.Common.Square : Resources.Common.Squares;
        }
    }
}