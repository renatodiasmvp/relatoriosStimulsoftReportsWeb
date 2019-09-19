using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;
using RelatoriosStimulsoftReports.Data;
using System.Data;
using System.Data.SqlClient;


namespace RelatoriosStimulsoftReports.Controllers
{
    public class ViewerController : Controller
    {
        bd data = new bd();
        

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult GetReport()
        {
            // Cria o relatório
            StiReport report = new StiReport();
            // Carrega o arquivo de relatório da pasta Reports do projeto
            report.Load(StiNetCoreHelper.MapPath(this, "Reports/relatorio_dados.mrt"));
            // Criar DataSet com o mesmo nome usado no editor de relatórios
            DataSet dataSet = new DataSet("dataSet");
            // Criar DataTable com o mesmo nome usado para o DataSource
            // no editor de relatórios
            DataTable dataTable = new DataTable("Gastos");
            // Instrução sql que retorna os dados 
            // com formatação para Data e Moeda
            string sql = @"select CONVERT(VARCHAR(10),Data,103) as Data
                           ,Area
                           ,FORMAT(VALOR, 'c', 'pt-BR') as Valor
                           from Gastos";
            // Preenchendo o DataTable com os dados
            // trazidos do banco de dados Sql Server
            dataTable = data.retornaDataTable<SqlConnection>(sql);
            // Adicionando o DataTable ao DataSet
            dataSet.Tables.Add(dataTable);
            // Adicionando o DataSet ao relatório
            // Informando nome e alias
            report.RegData("dataSet","dataSet",dataSet);
            // retorna o relatório com dados para o Visualizador
            return StiNetCoreViewer.GetReportResult(this, report);
        }

        public ActionResult ViewerEvent()
        {
            // Retorna o Visualizador de Relatórios
            return StiNetCoreViewer.ViewerEventResult(this);
        }
    }
}