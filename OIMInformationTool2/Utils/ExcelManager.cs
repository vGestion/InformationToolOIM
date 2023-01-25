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


                worksheet.Range(1, 1, 1, 3).Merge().Value = "Registro nominal";

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
                    worksheet.Cell(j, 7).Value = x.IndicadorId;
                    worksheet.Cell(j, 8).Value = x.SexoId;
                    worksheet.Cell(j, 9).Value = x.NacionalidadId;
                    worksheet.Cell(j, 10).Value = x.CantonId;
                    worksheet.Cell(j, 11).Value = x.ProvinciaId;
                    worksheet.Cell(j, 12).Value = x.ParentezcoId;
                    worksheet.Cell(j, 13).Value = x.CriterioMoviId;
                    worksheet.Cell(j, 14).Value = x.PeriodoId;
                    worksheet.Cell(j, 15).Value = x.UsuarioId;
                    worksheet.Cell(j, 16).Value = x.GeneroId;

                    j++;
                });
                workbook.SaveAs(fileName);
            }
        }
    }
}