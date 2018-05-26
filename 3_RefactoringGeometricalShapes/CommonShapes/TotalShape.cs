using RefactoringGeometricalShapes.CommonShapes.Types;
using System.Collections.Generic;
using System.Linq;

namespace RefactoringGeometricalShapes.CommonShapes
{
    public class TotalShape<T> where T : ShapeBase
    {
        private readonly IEnumerable<T> _shapes;
        public int Number { get; private set; }
        public double Area { get; private set; }
        public double Perimeter { get; private set; }

        public TotalShape(IEnumerable<T> shapes)
        {
            _shapes = shapes;
            Number = shapes.Count();
            Area = shapes.Sum(x => x.GetArea());
            Perimeter = shapes.Sum(x => x.GetPerimeter());
        }

        public string GetLine() => _shapes.FirstOrDefault()?.GetLine(Number, Area, Perimeter);
    }
}