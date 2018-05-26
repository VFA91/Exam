using RefactoringGeometricalShapes.Resources;

namespace RefactoringGeometricalShapes.CommonShapes.Types
{
    public abstract class ShapeBase
    {
        protected readonly double _width;

        public ShapeBase(double width)
        {
            _width = width;
        }

        public abstract double GetPerimeter();
        public abstract double GetArea();

        public string GetLine(int numberShapes, double areaTotal, double totalPerimeter)
        {
            if (numberShapes > 0)
                return $"{numberShapes} {TranslateShape(numberShapes)}{GetPrintArea(areaTotal)} {GetPrintPerimeter(totalPerimeter)}<br/>";

            return string.Empty;
        }

        protected abstract string TranslateShape(int numberShapes);

        public static string GetPrintArea(double areaTotal) => $" {Common.Area} {areaTotal.ToString("#.##")}";
        public static string GetPrintPerimeter(double totalPerimeter) => $"{Common.Perimeter} {totalPerimeter.ToString("#.##")}";
        public static string GetPrintNumber(int totalNumber) => $"{totalNumber} {Common.shapes} ";
    }
}