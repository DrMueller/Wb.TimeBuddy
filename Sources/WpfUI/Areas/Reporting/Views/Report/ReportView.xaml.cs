using System.Windows.Controls;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Views.Interfaces;

namespace Mmu.Wb.TimeBuddy.WpfUI.Areas.Reporting.Views.Report
{
    public partial class ReportView : UserControl, IViewMap<ReportViewModel>
    {
        public ReportView()
        {
            InitializeComponent();
        }
    }
}