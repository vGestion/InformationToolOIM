using System.Data;
using ClosedXML.Excel;
using InformationToolOIM2.Models;
using OIMInformationTool2.Models;

namespace OIMInformationTool2.Utils

{
    public class ExcelManager
    {
        public DataSet readExcelSheet(String path_file_xls)
        {
            var wbook = new XLWorkbook(path_file_xls);
            var workSheet = wbook.Worksheet(3);

            //Create a new DataTable.
            DataTable dt = new DataTable();

            //Loop through the Worksheet rows.
            bool firstRow = true;
            foreach (IXLRow row in workSheet.Rows())
            {
                //Use the first row to add columns to DataTable.
                if (firstRow)
                {
                    foreach (IXLCell cell in row.Cells())
                    {
                        dt.Columns.Add(cell.Value.ToString());
                    }
                    firstRow = false;
                }
                else
                {
                    //Add rows to DataTable.
                    dt.Rows.Add();
                    int i = 0;
                    foreach (IXLCell cell in row.Cells())
                    {
                        dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString();
                        i++;
                    }
                }

            }

            DataSet data = new DataSet();
            data.Tables.Add(dt);

            return data;
        }
        public void saveExcelFile(List<AreaOim> areasP, String fileName)
        {
            
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sheet1");


                worksheet.Range(1, 1, 1, 3).Merge().Value = "Áreas Programáticas";

                worksheet.Cell(2, 1).Value = "Recuperado el " + System.DateTime.Now.ToString();

                worksheet.Cell(3, 1).Value = "ID";
                worksheet.Cell(3, 2).Value = "Descripción";
            
                worksheet.Cell(3, 1).Style.Fill.SetBackgroundColor(XLColor.FromHtml("#0033A0"));
                worksheet.Cell(3, 2).Style.Fill.SetBackgroundColor(XLColor.FromHtml("#0033A0"));

                worksheet.Cell(3, 1).Style.Font.SetFontColor(XLColor.White);
                worksheet.Cell(3, 2).Style.Font.SetFontColor(XLColor.White);



                int j = 4;

                areasP.ForEach(x =>
                {
                    worksheet.Cell(j, 1).Value = x.IdAreaOim.ToString();
                    worksheet.Cell(j, 2).Value = x.Descripcion;
                    j++;
                });
                workbook.SaveAs(fileName);

            }
        }
        public void saveExcelFile(List<Nominal> nominal, String fileName)
        {

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sheet1");


                worksheet.Range(1, 1, 1, 16).Merge().Value = "Registro nominal";

                worksheet.Cell(2, 1).Value = "Recuperado el " + System.DateTime.Now.ToString();

                worksheet.Cell(3, 1).Value = "ID";
                worksheet.Cell(3, 2).Value = "Fecha de asistencia";
                worksheet.Cell(3, 3).Value = "Edad";
                worksheet.Cell(3, 4).Value = "Discapacidad";
                worksheet.Cell(3, 5).Value = "Monto";
                worksheet.Cell(3, 6).Value = "Fecha de registro";
                worksheet.Cell(3, 7).Value = "Indicador";
                worksheet.Cell(3, 8).Value = "Sexo";
                worksheet.Cell(3, 9).Value = "Nacionalidad";
                worksheet.Cell(3, 10).Value = "Cantón";
                worksheet.Cell(3, 11).Value = "Provincia";
                worksheet.Cell(3, 12).Value = "Parentesco";
                worksheet.Cell(3, 13).Value = "Criterio de Movilidad";
                worksheet.Cell(3, 14).Value = "Periodo";
                worksheet.Cell(3, 15).Value = "Usuario";
                worksheet.Cell(3, 16).Value = "Genero";

                worksheet.Range(3, 1, 3, 17).Style.Fill.SetBackgroundColor(XLColor.FromHtml("#0033A0"));
                worksheet.Range(3, 1, 3, 17).Style.Font.SetFontColor(XLColor.White);

                int j = 4;

                nominal.ForEach(x =>
                {
                    worksheet.Cell(j, 1).Value = x.IdNominal;
                    worksheet.Cell(j, 2).Value = x.FechaAsistencia;
                    worksheet.Cell(j, 3).Value = x.Edad;
                    worksheet.Cell(j, 4).Value = x.Discapacidad;
                    worksheet.Cell(j, 5).Value = x.Monto;
                    worksheet.Cell(j, 6).Value = x.FechaRegistro;
                    worksheet.Cell(j, 7).Value = x.Indicador.Descripcion;
                    worksheet.Cell(j, 8).Value = x.Sexo.Descripcion;
                    worksheet.Cell(j, 9).Value = x.Nacionalidad.Descripcion;
                    worksheet.Cell(j, 10).Value = x.CantonId;
                    worksheet.Cell(j, 11).Value = x.ProvinciaId;
                    worksheet.Cell(j, 12).Value = x.Parentezco.Descripcion;
                    worksheet.Cell(j, 13).Value = x.CriterioMovi.Descripcion;
                    worksheet.Cell(j, 14).Value = x.Periodo.Descripcion;
                    worksheet.Cell(j, 15).Value = x.Usuario.Nombre;
                    worksheet.Cell(j, 16).Value = x.Genero.Descripcion;

                    j++;
                });
                workbook.SaveAs(fileName);
            }
        }
        public void saveExcelFile(List<Canton> lista, String fileName)
        {

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sheet1");


                worksheet.Range(1, 1, 1, 5).Merge().Value = "Cantones";

                worksheet.Cell(2, 1).Value = "Recuperado el " + System.DateTime.Now.ToString();

                worksheet.Cell(3, 1).Value = "ID";
                worksheet.Cell(3, 2).Value = "Cantón";
                worksheet.Cell(3, 3).Value = "Provincia";
                worksheet.Cell(3, 4).Value = "Latitud";
                worksheet.Cell(3, 5).Value = "Longitud";

                worksheet.Range(3, 1, 3, 5).Style.Fill.SetBackgroundColor(XLColor.FromHtml("#0033A0"));
                worksheet.Range(3, 1, 3, 5).Style.Font.SetFontColor(XLColor.White);

                int j = 4;

                lista.ForEach(x =>
                {
                    worksheet.Cell(j, 1).Value = x.IdCanton;
                    worksheet.Cell(j, 2).Value = x.Descripcion;
                    worksheet.Cell(j, 3).Value = x.Provincia.Descripcion;
                    worksheet.Cell(j, 4).Value = x.Latitud;
                    worksheet.Cell(j, 5).Value = x.Longitud;
                    j++;
                });
                workbook.SaveAs(fileName);
            }
        }
        public void saveExcelFile(List<CriterioMovi> lista, String fileName)
        {

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sheet1");


                worksheet.Range(1, 1, 1, 2).Merge().Value = "Criterios de Movilidad";

                worksheet.Cell(2, 1).Value = "Recuperado el " + System.DateTime.Now.ToString();

                worksheet.Cell(3, 1).Value = "ID";
                worksheet.Cell(3, 2).Value = "Descripción";

                worksheet.Range(3, 1, 3, 2).Style.Fill.SetBackgroundColor(XLColor.FromHtml("#0033A0"));
                worksheet.Range(3, 1, 3, 2).Style.Font.SetFontColor(XLColor.White);

                int j = 4;

                lista.ForEach(x =>
                {
                    worksheet.Cell(j, 1).Value = x.IdCriterioMovi;
                    worksheet.Cell(j, 2).Value = x.Descripcion;
                    j++;
                });
                workbook.SaveAs(fileName);
            }
        }
        public void saveExcelFile(List<Fondo> lista, String fileName)
        {

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sheet1");


                worksheet.Range(1, 1, 1, 4).Merge().Value = "Fondos";

                worksheet.Cell(2, 1).Value = "Recuperado el " + System.DateTime.Now.ToString();

                worksheet.Cell(3, 1).Value = "ID";
                worksheet.Cell(3, 2).Value = "Descripción";
                worksheet.Cell(3, 3).Value = "Fecha de inicio";
                worksheet.Cell(3, 4).Value = "Fecha de fin";

                worksheet.Range(3, 1, 3, 4).Style.Fill.SetBackgroundColor(XLColor.FromHtml("#0033A0"));
                worksheet.Range(3, 1, 3, 4).Style.Font.SetFontColor(XLColor.White);

                int j = 4;

                lista.ForEach(x =>
                {
                    worksheet.Cell(j, 1).Value = x.IdFondo;
                    worksheet.Cell(j, 2).Value = x.Descripcion;
                    worksheet.Cell(j, 3).Value = x.FechaInicio;
                    worksheet.Cell(j, 4).Value = x.FechaFin;
                    j++;
                });
                workbook.SaveAs(fileName);
            }
        }
        public void saveExcelFile(List<Genero> lista, String fileName)
        {

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sheet1");


                worksheet.Range(1, 1, 1, 2).Merge().Value = "Géneros";

                worksheet.Cell(2, 1).Value = "Recuperado el " + System.DateTime.Now.ToString();

                worksheet.Cell(3, 1).Value = "ID";
                worksheet.Cell(3, 2).Value = "Descripción";

                worksheet.Range(3, 1, 3, 2).Style.Fill.SetBackgroundColor(XLColor.FromHtml("#0033A0"));
                worksheet.Range(3, 1, 3, 2).Style.Font.SetFontColor(XLColor.White);

                int j = 4;

                lista.ForEach(x =>
                {
                    worksheet.Cell(j, 1).Value = x.IdGenero;
                    worksheet.Cell(j, 2).Value = x.Descripcion;
                    j++;
                });
                workbook.SaveAs(fileName);
            }
        }
        public void saveExcelFile(List<Implementador> lista, String fileName)
        {

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sheet1");


                worksheet.Range(1, 1, 1, 2).Merge().Value = "Implementadores";

                worksheet.Cell(2, 1).Value = "Recuperado el " + System.DateTime.Now.ToString();

                worksheet.Cell(3, 1).Value = "ID";
                worksheet.Cell(3, 2).Value = "Descripción";

                worksheet.Range(3, 1, 3, 2).Style.Fill.SetBackgroundColor(XLColor.FromHtml("#0033A0"));
                worksheet.Range(3, 1, 3, 2).Style.Font.SetFontColor(XLColor.White);

                int j = 4;

                lista.ForEach(x =>
                {
                    worksheet.Cell(j, 1).Value = x.IdImplementador;
                    worksheet.Cell(j, 2).Value = x.Descripcion;
                    j++;
                });
                workbook.SaveAs(fileName);
            }
        }
        public void saveExcelFile(List<Indicador> lista, String fileName)
        {

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sheet1");


                worksheet.Range(1, 1, 1, 8).Merge().Value = "Indicadores";

                worksheet.Cell(2, 1).Value = "Recuperado el " + System.DateTime.Now.ToString();

                worksheet.Cell(3, 1).Value = "ID";
                worksheet.Cell(3, 2).Value = "Descripción";
                worksheet.Cell(3, 3).Value = "Fondo";
                worksheet.Cell(3, 4).Value = "Meta";
                worksheet.Cell(3, 5).Value = "Output";
                worksheet.Cell(3, 6).Value = "Estado actual del indicador";
                worksheet.Cell(3, 7).Value = "Implementador";
                worksheet.Cell(3, 8).Value = "Periodicidad";

                worksheet.Range(3, 1, 3, 8).Style.Fill.SetBackgroundColor(XLColor.FromHtml("#0033A0"));
                worksheet.Range(3, 1, 3, 8).Style.Font.SetFontColor(XLColor.White);

                int j = 4;

                lista.ForEach(x =>
                {
                    worksheet.Cell(j, 1).Value = x.IdIndicador;
                    worksheet.Cell(j, 2).Value = x.Descripcion;
                    worksheet.Cell(j, 3).Value = x.Fondo.Descripcion; 
                    worksheet.Cell(j, 4).Value = x.Meta;
                    worksheet.Cell(j, 5).Value = x.Output.Descripcion;
                    worksheet.Cell(j, 6).Value = x.NumeroTotal;
                    worksheet.Cell(j, 7).Value = x.Implementador.Descripcion;
                    worksheet.Cell(j, 8).Value = x.Periodicidad.Descripcion;
                    j++;
                });
                workbook.SaveAs(fileName);
            }
        }
        public void saveExcelFile(List<Nacionalidad> lista, String fileName)
        {

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sheet1");


                worksheet.Range(1, 1, 1, 8).Merge().Value = "Nacionalidades";

                worksheet.Cell(2, 1).Value = "Recuperado el " + System.DateTime.Now.ToString();

                worksheet.Cell(3, 1).Value = "ID";
                worksheet.Cell(3, 2).Value = "Descripción";
                worksheet.Range(3, 1, 3, 2).Style.Fill.SetBackgroundColor(XLColor.FromHtml("#0033A0"));
                worksheet.Range(3, 1, 3, 2).Style.Font.SetFontColor(XLColor.White);

                int j = 4;

                lista.ForEach(x =>
                {
                    worksheet.Cell(j, 1).Value = x.IdNacionalidad;
                    worksheet.Cell(j, 2).Value = x.Descripcion;
                    j++;
                });
                workbook.SaveAs(fileName);
            }
        }
        public void saveExcelFile(List<Objetivo> lista, String fileName)
        {

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sheet1");


                worksheet.Range(1, 1, 1, 2).Merge().Value = "Objetivos";

                worksheet.Cell(2, 1).Value = "Recuperado el " + System.DateTime.Now.ToString();

                worksheet.Cell(3, 1).Value = "ID";
                worksheet.Cell(3, 2).Value = "Descripción";

                worksheet.Range(3, 1, 3, 2).Style.Fill.SetBackgroundColor(XLColor.FromHtml("#0033A0"));
                worksheet.Range(3, 1, 3, 2).Style.Font.SetFontColor(XLColor.White);

                int j = 4;

                lista.ForEach(x =>
                {
                    worksheet.Cell(j, 1).Value = x.IdObjetivo;
                    worksheet.Cell(j, 2).Value = x.Descripcion;
                    j++;
                });
                workbook.SaveAs(fileName);
            }
        }
        public void saveExcelFile(List<Outcome> lista, String fileName)
        {

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sheet1");


                worksheet.Range(1, 1, 1, 5).Merge().Value = "Outcomes";

                worksheet.Cell(2, 1).Value = "Recuperado el " + System.DateTime.Now.ToString();

                worksheet.Cell(3, 1).Value = "ID";
                worksheet.Cell(3, 2).Value = "Descripción";
                worksheet.Cell(3, 3).Value = "Área programática";
                worksheet.Cell(3, 4).Value = "Sector";
                worksheet.Cell(3, 5).Value = "Objetivo";

                worksheet.Range(3, 1, 3, 5).Style.Fill.SetBackgroundColor(XLColor.FromHtml("#0033A0"));
                worksheet.Range(3, 1, 3, 5).Style.Font.SetFontColor(XLColor.White);

                int j = 4;

                lista.ForEach(x =>
                {
                    worksheet.Cell(j, 1).Value = x.IdOutcome;
                    worksheet.Cell(j, 2).Value = x.Descripcion;
                    worksheet.Cell(j, 3).Value = x.AreaOim.Descripcion;
                    worksheet.Cell(j, 4).Value = x.Sector.Descripcion;
                    worksheet.Cell(j, 5).Value = x.Objetivo.Descripcion;
                    j++;
                });
                workbook.SaveAs(fileName);
            }
        }
        public void saveExcelFile(List<Output> lista, String fileName)
        {

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sheet1");


                worksheet.Range(1, 1, 1, 3).Merge().Value = "Output";

                worksheet.Cell(2, 1).Value = "Recuperado el " + System.DateTime.Now.ToString();

                worksheet.Cell(3, 1).Value = "ID";
                worksheet.Cell(3, 2).Value = "Descripción";
                worksheet.Cell(3, 3).Value = "Outcome";

                worksheet.Range(3, 1, 3, 3).Style.Fill.SetBackgroundColor(XLColor.FromHtml("#0033A0"));
                worksheet.Range(3, 1, 3, 3).Style.Font.SetFontColor(XLColor.White);

                int j = 4;

                lista.ForEach(x =>
                {
                    worksheet.Cell(j, 1).Value = x.IdOutput;
                    worksheet.Cell(j, 2).Value = x.Descripcion;
                    worksheet.Cell(j, 3).Value = x.Outcome.Descripcion;
                    j++;
                });
                workbook.SaveAs(fileName);
            }
        }
        public void saveExcelFile(List<Parentezco> lista, String fileName)
        {

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sheet1");


                worksheet.Range(1, 1, 1, 2).Merge().Value = "Parentezco";

                worksheet.Cell(2, 1).Value = "Recuperado el " + System.DateTime.Now.ToString();

                worksheet.Cell(3, 1).Value = "ID";
                worksheet.Cell(3, 2).Value = "Descripción";

                worksheet.Range(3, 1, 3, 2).Style.Fill.SetBackgroundColor(XLColor.FromHtml("#0033A0"));
                worksheet.Range(3, 1, 3, 2).Style.Font.SetFontColor(XLColor.White);

                int j = 4;

                lista.ForEach(x =>
                {
                    worksheet.Cell(j, 1).Value = x.IdParentezco;
                    worksheet.Cell(j, 2).Value = x.Descripcion;
                    j++;
                });
                workbook.SaveAs(fileName);
            }
        }
        public void saveExcelFile(List<Periodicidad> lista, String fileName)
        {

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sheet1");


                worksheet.Range(1, 1, 1, 2).Merge().Value = "Periodicidad";

                worksheet.Cell(2, 1).Value = "Recuperado el " + System.DateTime.Now.ToString();

                worksheet.Cell(3, 1).Value = "ID";
                worksheet.Cell(3, 2).Value = "Descripción";

                worksheet.Range(3, 1, 3, 2).Style.Fill.SetBackgroundColor(XLColor.FromHtml("#0033A0"));
                worksheet.Range(3, 1, 3, 2).Style.Font.SetFontColor(XLColor.White);

                int j = 4;

                lista.ForEach(x =>
                {
                    worksheet.Cell(j, 1).Value = x.IdPeriodo;
                    worksheet.Cell(j, 2).Value = x.Descripcion;
                    j++;
                });
                workbook.SaveAs(fileName);
            }
        }
        public void saveExcelFile(List<Periodo> lista, String fileName)
        {

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sheet1");


                worksheet.Range(1, 1, 1, 4).Merge().Value = "Periodo";

                worksheet.Cell(2, 1).Value = "Recuperado el " + System.DateTime.Now.ToString();

                worksheet.Cell(3, 1).Value = "ID";
                worksheet.Cell(3, 2).Value = "Descripción";
                worksheet.Cell(3, 3).Value = "Fecha de inicio";
                worksheet.Cell(3, 4).Value = "Fecha de fin";

                worksheet.Range(3, 1, 3, 4).Style.Fill.SetBackgroundColor(XLColor.FromHtml("#0033A0"));
                worksheet.Range(3, 1, 3, 4).Style.Font.SetFontColor(XLColor.White);

                int j = 4;

                lista.ForEach(x =>
                {
                    worksheet.Cell(j, 1).Value = x.IdPeriodo;
                    worksheet.Cell(j, 2).Value = x.Descripcion;
                    worksheet.Cell(j, 3).Value = x.FechaInicio;
                    worksheet.Cell(j, 4).Value = x.FechaFin;
                    j++;
                });
                workbook.SaveAs(fileName);
            }
        }
        public void saveExcelFile(List<Provincium> lista, String fileName)
        {

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sheet1");


                worksheet.Range(1, 1, 1, 2).Merge().Value = "Provincias";

                worksheet.Cell(2, 1).Value = "Recuperado el " + System.DateTime.Now.ToString();

                worksheet.Cell(3, 1).Value = "ID";
                worksheet.Cell(3, 2).Value = "Descripción";

                worksheet.Range(3, 1, 3, 2).Style.Fill.SetBackgroundColor(XLColor.FromHtml("#0033A0"));
                worksheet.Range(3, 1, 3, 2).Style.Font.SetFontColor(XLColor.White);

                int j = 4;

                lista.ForEach(x =>
                {
                    worksheet.Cell(j, 1).Value = x.IdProvincia;
                    worksheet.Cell(j, 2).Value = x.Descripcion;
                    j++;
                });
                workbook.SaveAs(fileName);
            }
        }
        public void saveExcelFile(List<Rol> lista, String fileName)
        {

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sheet1");


                worksheet.Range(1, 1, 1, 2).Merge().Value = "Roles";

                worksheet.Cell(2, 1).Value = "Recuperado el " + System.DateTime.Now.ToString();

                worksheet.Cell(3, 1).Value = "ID";
                worksheet.Cell(3, 2).Value = "Descripción";

                worksheet.Range(3, 1, 3, 2).Style.Fill.SetBackgroundColor(XLColor.FromHtml("#0033A0"));
                worksheet.Range(3, 1, 3, 2).Style.Font.SetFontColor(XLColor.White);

                int j = 4;

                lista.ForEach(x =>
                {
                    worksheet.Cell(j, 1).Value = x.IdRol;
                    worksheet.Cell(j, 2).Value = x.Descripcion;
                    j++;
                });
                workbook.SaveAs(fileName);
            }
        }
        public void saveExcelFile(List<Sector> lista, String fileName)
        {

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sheet1");


                worksheet.Range(1, 1, 1, 2).Merge().Value = "Sectores";

                worksheet.Cell(2, 1).Value = "Recuperado el " + System.DateTime.Now.ToString();

                worksheet.Cell(3, 1).Value = "ID";
                worksheet.Cell(3, 2).Value = "Descripción";

                worksheet.Range(3, 1, 3, 2).Style.Fill.SetBackgroundColor(XLColor.FromHtml("#0033A0"));
                worksheet.Range(3, 1, 3, 2).Style.Font.SetFontColor(XLColor.White);

                int j = 4;

                lista.ForEach(x =>
                {
                    worksheet.Cell(j, 1).Value = x.IdSector;
                    worksheet.Cell(j, 2).Value = x.Descripcion;
                    j++;
                });
                workbook.SaveAs(fileName);
            }
        }
        public void saveExcelFile(List<Usuario> lista, String fileName)
        {

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sheet1");


                worksheet.Range(1, 1, 1, 5).Merge().Value = "Sectores";

                worksheet.Cell(2, 1).Value = "Recuperado el " + System.DateTime.Now.ToString();

                worksheet.Cell(3, 1).Value = "ID";
                worksheet.Cell(3, 2).Value = "Nombre";
                worksheet.Cell(3, 3).Value = "Correo";
                worksheet.Cell(3, 4).Value = "Rol";
                worksheet.Cell(3, 5).Value = "Activo";

                worksheet.Range(3, 1, 3, 5).Style.Fill.SetBackgroundColor(XLColor.FromHtml("#0033A0"));
                worksheet.Range(3, 1, 3, 5).Style.Font.SetFontColor(XLColor.White);

                int j = 4;

                lista.ForEach(x =>
                {
                    worksheet.Cell(j, 1).Value = x.IdUsuario;
                    worksheet.Cell(j, 2).Value = x.Nombre;
                    worksheet.Cell(j, 2).Value = x.Correo;
                    worksheet.Cell(j, 2).Value = x.Rol.Descripcion;
                    worksheet.Cell(j, 2).Value = x.Activo.ToString();
                    j++;
                });
                workbook.SaveAs(fileName);
            }
        }
    }
}