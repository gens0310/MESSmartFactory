using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using MESFactoryDAC;

namespace WinMSFactory
{
    public class ExcelUtil
    {
        public static void ListToExcel<T>(string[] ColumnsList, List<T> dataList) // string[] Columns
        {
            DataTable dt = SqlHelper.ConvertToDataTable<T>(dataList);
            ExcelSettings(ColumnsList, dt);
        }

        public static void DataTableToExcel(string[] ColumnsList, DataTable dt)
        {
            ExcelSettings(ColumnsList, dt);
        }

        private static void ExcelSettings(string[] ColumnsList, DataTable dt)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            dialog.Filter = "Excel 파일(*.xlsx)|*.xlsx";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Excel.Application xlApp = new Excel.Application();
                    Excel.Workbook xlWorkbook = xlApp.Workbooks.Add();
                    Excel.Worksheet xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.Add();
                    xlApp.Visible = true;

                    for (int i = 1; i <= dt.Columns.Count; i++)
                        xlWorksheet.Cells[1, i] = ColumnsList[i - 1].ToString();

                    for (int i = 2; i <= dt.Rows.Count + 1; i++)
                    {
                        for (int j = 1; j <= dt.Columns.Count; j++)
                            xlWorksheet.Cells[i, j] = dt.Rows[i - 2][j - 1].ToString();
                    }

                    xlWorkbook.SaveAs(dialog.FileName);
                    xlWorkbook.Close(true);
                    xlApp.Quit();

                    MessageBox.Show("엑셀이 생성되었습니다.");
                }
                catch
                {
                    MessageBox.Show("오류가 발생하였습니다. 다시 시도하여 주세요");
                }
            }
        }


    }
}
