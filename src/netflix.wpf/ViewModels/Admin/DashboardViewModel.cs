using netflix.wpf.View.Admin.Template;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.wpf.VỉewModel.Admin
{
    public class DashboardViewModel : BaseViewModel
    {
        private PlotModel modelP2;
        public PlotModel Model2
        {
            get { return modelP2; }
            set { modelP2 = value; }
        }
        private PlotModel modelP1;
        public PlotModel Model1
        {
            get { return modelP1; }
            set { modelP1 = value; }
        }
        public DashboardViewModel()
        {
            initModel1();
            initModel2();
        }

        private void initModel1()
        {
            modelP1 = new PlotModel();
            modelP1.LegendTitle = "Legend";
            modelP1.LegendOrientation = LegendOrientation.Horizontal;
            modelP1.LegendPlacement = LegendPlacement.Outside;
            modelP1.LegendPosition = LegendPosition.TopRight;
            modelP1.LegendBackground = OxyColor.FromAColor(200, OxyColors.White);
            modelP1.LegendBorder = OxyColors.Black;
            var dateAxis = new DateTimeAxis() { MajorGridlineStyle = LineStyle.Solid, MinorGridlineStyle = LineStyle.Dot, IntervalLength = 80, Position = AxisPosition.Bottom };
            modelP1.Axes.Add(dateAxis);
            var valueAxis = new LinearAxis() { MajorGridlineStyle = LineStyle.Solid, MinorGridlineStyle = LineStyle.Dot, Title = "Value", Position = AxisPosition.Left };
            modelP1.Axes.Add(valueAxis);

        }
        private void initModel2()
        {
            modelP2 = new PlotModel { Title = "Doanh thu theo ngày" };

            dynamic seriesP2 = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.8, AngleSpan = 360, StartAngle = 0 };

            seriesP2.Slices.Add(new PieSlice("Viễn tưởng", 1030) { IsExploded = false, Fill = OxyColors.PaleVioletRed });
            seriesP2.Slices.Add(new PieSlice("Americas", 929) { IsExploded = true });
            seriesP2.Slices.Add(new PieSlice("Asia", 4157) { IsExploded = true });
            seriesP2.Slices.Add(new PieSlice("Europe", 739) { IsExploded = true });
            seriesP2.Slices.Add(new PieSlice("Oceania", 35) { IsExploded = true });

            modelP2.Series.Add(seriesP2);
        }
    }
}
