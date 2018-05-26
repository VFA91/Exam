using RefactoringGeometricalShapes.CommonShapes.Types;
using RefactoringGeometricalShapes.Resources;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace RefactoringGeometricalShapes.CommonShapes
{
    public class Shapes
    {
        private readonly List<ShapeBase> _shapes;
        private int _totalNumber = 0;
        private double _totalPerimeter = 0;
        private double _totalArea = 0;

        public Shapes(List<ShapeBase> shapes, Language userLanguage)
        {
            _shapes = shapes;

            if (userLanguage == Language.EN)
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en");
            else if (userLanguage == Language.SP)
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("es");
        }

        public string GenerateHtml()
        {
            if (_shapes.Count == 0)
                return Common.EmptyList;

            StringBuilder result = new StringBuilder(Common.ShapesReport);

            result.Append(GetLine<Square>())
                .Append(GetLine<Circle>())
                .Append(GetLine<EquilateralTriangle>())
                .Append(PrintTotal());

            return result.ToString();
        }

        private string GetLine<T>()
            where T : ShapeBase
        {
            IEnumerable<T> type = _shapes.Where(x => x.GetType() == typeof(T)).Cast<T>();
            var resultType = new TotalShape<T>(type);

            _totalArea += resultType.Area;
            _totalPerimeter += resultType.Perimeter;
            _totalNumber += resultType.Number;

            return resultType.GetLine();
        }

        private StringBuilder PrintTotal()
        {
            StringBuilder printTotal = new StringBuilder();
            printTotal.Append("TOTAL:<br/>");
            printTotal.Append(ShapeBase.GetPrintNumber(_totalNumber));
            printTotal.Append(ShapeBase.GetPrintPerimeter(_totalPerimeter));
            printTotal.Append(ShapeBase.GetPrintArea(_totalArea));

            return printTotal;
        }
    }
}