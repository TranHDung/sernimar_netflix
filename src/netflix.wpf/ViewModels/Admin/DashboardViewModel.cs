using netflix.Medias;
using netflix.Orders;
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
        private PlotModel viewChartModel;
        public PlotModel ViewChartModel
        {
            get { return viewChartModel; }
            set { viewChartModel = value; }
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
            var orderStat = this.getData<OrderStat>("/api/services/app/Order/GetOrderStat");

            modelP1 = new PlotModel();
            modelP1.LegendTitle = "Biểu đồ doanh thu";
            modelP1.LegendOrientation = LegendOrientation.Horizontal;
            modelP1.LegendPlacement = LegendPlacement.Outside;
            modelP1.LegendPosition = LegendPosition.TopRight;
            modelP1.LegendBackground = OxyColor.FromAColor(200, OxyColors.White);
            modelP1.LegendBorder = OxyColors.Black;

            var dateAxis = new DateTimeAxis() { MajorGridlineStyle = LineStyle.Solid, MinorGridlineStyle = LineStyle.Dot, IntervalLength = 80, Position = AxisPosition.Bottom };
            modelP1.Axes.Add(dateAxis);
            var valueAxis = new LinearAxis() { MajorGridlineStyle = LineStyle.Solid, MinorGridlineStyle = LineStyle.Dot, Title = "Value", Position = AxisPosition.Left };
            modelP1.Axes.Add(valueAxis);

            var seriesP2 = new LineSeries();
            orderStat.OrderAndProfs.ForEach(i =>
            {
                seriesP2.Points.Add(new DataPoint(DateTimeAxis.ToDouble(i.Date), i.Prof));
            });

            modelP1.Series.Add(seriesP2);

        }
        private void initModel2()
        {
            var mediaStat = this.getData<MediaStat>("/api/services/app/Action/GetMediaStat"); ViewChartModel = new PlotModel { Title = "Những video có lượt xem cao nhất" };
            dynamic seriesP2 = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.8, AngleSpan = 360, StartAngle = 0 };
            mediaStat.MediaViews.ForEach(i =>
            {
                seriesP2.Slices.Add(new PieSlice(i.Media.Name, i.ViewCount) { IsExploded = true });
            });
            ViewChartModel.Series.Add(seriesP2);
        }
    }
}
