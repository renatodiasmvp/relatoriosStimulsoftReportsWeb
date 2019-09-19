using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;

namespace RelatoriosStimulsoftReports.Controllers
{
    public class EditorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetReport()
        {
            StiReport report = new StiReport();

            report.Load(StiNetCoreHelper.MapPath(this, "Reports/relatorio_teste.mrt"));

            return StiNetCoreDesigner.GetReportResult(this, report);
        }

        public IActionResult PreviewReport()
        {
            StiReport report = StiNetCoreDesigner.GetActionReportObject(this);

            return StiNetCoreDesigner.PreviewReportResult(this, report);
        }

        public IActionResult DesignerEvent()
        {
            return StiNetCoreDesigner.DesignerEventResult(this);
        }
    }
}