using netflix.Medias;
using netflix.Orders;
using netflix.wpf.VỉewModel;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.wpf.ViewModels.Admin
{
    public class StatViewModel: BaseViewModel
    {
        private PlotModel viewChartModel;
        public PlotModel ViewChartModel
        {
            get { return viewChartModel; }
            set { viewChartModel = value; }
        }
        private MediaStat mediaStat;
        private OrderStat orderStat;
        public OrderStat OrderStat
        {
            get => orderStat;
            set
            {
                orderStat = value;
                OnPropertyChanged();
            }
        }
        private string increasePercent;
        public string IncreasePercent
        {
            get => increasePercent;
            set
            {
                increasePercent = value;
                OnPropertyChanged();
            }
        }
        private void initViewChartModel()
        {
            ViewChartModel = new PlotModel { Title = "Những video có lượt xem cao nhất" };
            dynamic seriesP2 = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.8, AngleSpan = 360, StartAngle = 0 };
            MediaStat.MediaViews.ForEach(i =>
            {
                seriesP2.Slices.Add(new PieSlice(i.Media.Name, i.ViewCount) { IsExploded = true });
            });
            ViewChartModel.Series.Add(seriesP2);

        }
        private PlotModel profChartModel;
        public PlotModel ProfChartModel
        {
            get { return profChartModel; }
            set { profChartModel = value; }
        }
        public MediaStat MediaStat
        {
            get => mediaStat;
            set
            {
                mediaStat = value;
                OnPropertyChanged();
            }
        }
        private void getInitData()
        {
            MediaStat = this.getData<MediaStat>("/api/services/app/Action/GetMediaStat");
            var ad = MediaStat.ToDayView - MediaStat.YesterdayView;
            var iss = ad < 0 ? "↓" : "↑";
            IncreasePercent = "(" + iss + ad.ToString()+")";
            initViewChartModel();
            initModel1();
        }
        private void initModel1()
        {
            OrderStat = this.getData<OrderStat>("/api/services/app/Order/GetOrderStat");

            profChartModel = new PlotModel();
            profChartModel.LegendTitle = "Biểu đồ doanh thu";
            profChartModel.LegendOrientation = LegendOrientation.Horizontal;
            profChartModel.LegendPlacement = LegendPlacement.Outside;
            profChartModel.LegendPosition = LegendPosition.TopRight;
            profChartModel.LegendBackground = OxyColor.FromAColor(200, OxyColors.White);
            profChartModel.LegendBorder = OxyColors.Black;

            var dateAxis = new DateTimeAxis() { MajorGridlineStyle = LineStyle.Solid, MinorGridlineStyle = LineStyle.Dot, IntervalLength = 80, Position = AxisPosition.Bottom };
            profChartModel.Axes.Add(dateAxis);
            var valueAxis = new LinearAxis() { MajorGridlineStyle = LineStyle.Solid, MinorGridlineStyle = LineStyle.Dot, Title = "Value", Position = AxisPosition.Left };
            profChartModel.Axes.Add(valueAxis);

            var seriesP2 = new LineSeries();
            OrderStat.OrderAndProfs.ForEach(i =>
            {
                seriesP2.Points.Add(new DataPoint(DateTimeAxis.ToDouble(i.Date), i.Prof));
            });

            profChartModel.Series.Add(seriesP2);

        }
        public StatViewModel()
        {
            MediaStat = new MediaStat();
            getInitData();
        }
    }
}
