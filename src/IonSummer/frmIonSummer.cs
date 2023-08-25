using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using OxyPlot.Annotations;
using MathNet.Numerics;
using System.Configuration;
using iTextSharp.text;
using iTextSharp.text.pdf;
using IonSummer.Models;
using Newtonsoft.Json;
using System.Text;
using MathNet.Numerics.LinearAlgebra;

namespace IonSummer
{
    public partial class frmIonSummer : Form
    {

        DataTable dataTable = new DataTable();
        DataTable ISList = new DataTable();
        public List<string> viewID = new List<string>();
        public bool ViewAndExport = false;
        public Dictionary<string, double> CustomConcentration = new Dictionary<string, double>();
        public frmIonSummer()
        {
            InitializeComponent();
        }
        private double CalculateSlopeThroughZero(double[] xValues, double[] yValues)
        {
            double sumXY = 0;
            double sumX2 = 0;
            for (int i = 0; i < xValues.Length; i++)
            {
                sumXY += xValues[i] * yValues[i];
                sumX2 += xValues[i] * xValues[i];
            }
            return sumXY / sumX2;
        }
        public void LoadDatafromText(string filepath)
        {
            string filePath = filepath;

            var dataTableAll = new DataTable();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string[] headers = reader.ReadLine().Split('\t');
                foreach (string header in headers)
                {
                    dataTableAll.Columns.Add(header);
                }

                while (!reader.EndOfStream)
                {
                    string[] rows = reader.ReadLine().Split('\t');
                    DataRow dataRow = dataTableAll.NewRow();

                    for (int i = 0; i < headers.Length; i++)
                    {
                        if (headers[i] == "Actual Concentration")
                        {
                            decimal ActualConcentration = 0;
                            decimal.TryParse(rows[i], out ActualConcentration);
                            dataRow[i] = ActualConcentration;//rows[i];
                        }
                        else if (headers[i] == "Area")
                        {
                            decimal Area = 0;
                            decimal.TryParse(rows[i], out Area);
                            dataRow[i] = Area;
                        }
                        else
                        {
                            dataRow[i] = rows[i];
                        }

                    }

                    dataTableAll.Rows.Add(dataRow);
                }

                var AvgdataTable = dataTableAll.AsEnumerable().GroupBy(g => new
                {
                    SampleName = g["Sample Name"].ToString(),
                    SampleType = g["Sample Type"].ToString(),
                    ComponentName = g["Component Name"].ToString(),
                    ComponentType = g["Component Type"].ToString(),
                    ActualConcentration = Convert.ToDecimal(g["Actual Concentration"].ToString()),
                    Used = g["Used"].ToString(),
                    ISName = g["IS Name"].ToString()
                }).Select(s => new
                {
                    s.Key.SampleType,
                    s.Key.SampleName,
                    s.Key.ComponentName,
                    s.Key.ComponentType,
                    s.Key.ActualConcentration,
                    s.Key.Used,
                    s.Key.ISName,
                    Area = s.Average(a => Convert.ToDecimal(a["Area"].ToString())),
                    AcquisitionDateTime = s.Max(a => Convert.ToDateTime(a["Acquisition Date & Time"].ToString()))
                }).ToList();

                dataTable = new DataTable();
                dataTable.Columns.Add("Sample Name");
                dataTable.Columns.Add("Sample Type");
                dataTable.Columns.Add("Acquisition Date & Time");
                dataTable.Columns.Add("Component Name");
                dataTable.Columns.Add("Component Type");
                dataTable.Columns.Add("Actual Concentration");
                dataTable.Columns.Add("Area");
                dataTable.Columns.Add("Used");
                dataTable.Columns.Add("IS Name");

                foreach (var item in AvgdataTable)
                {
                    dataTable.Rows.Add(item.SampleName, item.SampleType, item.AcquisitionDateTime, item.ComponentName, item.ComponentType, item.ActualConcentration, item.Area, item.Used, item.ISName);
                }

                //cmbISName.DataSource = dataTable.AsEnumerable().Where(w => w["Component Type"].ToString() == "Internal Standards")
                //    .Select(s => s["Component Name"].ToString()).Distinct().OrderBy(o => o)
                //    .Union(new List<string>() { "(No IS)" }).ToList();

                cmbISName.DataSource = new List<string>() { "(No IS)" };

                //dataTable = dataTableAll;
            }
        }
        public PlotModel OxyPlot_Linear(double[] XX, double[] YY, double[] XXall, double[] YYall, ref string equation, bool ForExport, ref string actual_equation, ref string actual_RSquared)
        {
            var linearRegression = Fit.Line(XX, YY);

            // Print the slope and intercept of the linear regression

            double rsquared = GoodnessOfFit.RSquared(XX.Select(x1 => linearRegression.Item1 + linearRegression.Item2 * x1), YY);

            if (!ForExport)
            {
                txtEquation.Text = string.Format("y = {0:F6}*x + {1:F6}\rRSquared = {2:F6}", linearRegression.Item2, linearRegression.Item1, rsquared);
            }
            else
            {
                actual_equation = $"y = {linearRegression.Item2.ToString("F6")}*x + {linearRegression.Item1.ToString("F6")}";
                actual_RSquared = rsquared.ToString("F6");
                equation = string.Format("y = {0:F6}*x + {1:F6}     RSquared = {2:F6}", linearRegression.Item2, linearRegression.Item1, rsquared);
            }

            double slope = linearRegression.Item2;
            double intercept = linearRegression.Item1;

            var plotModel = new PlotModel
            {
                Title = "Linear"
            };

            // Create the X and Y axes
            var xAxis = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Concentration",
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot
            };
            plotModel.Axes.Add(xAxis);

            var yAxis = new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "Area",
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot
            };
            plotModel.Axes.Add(yAxis);

            // Create the scatter series
            var scatterSeries = new ScatterSeries
            {
                MarkerType = MarkerType.Square,
                MarkerSize = 5,
                MarkerStroke = OxyColors.Black,
                MarkerFill = OxyColors.Red
            };


            var scatterSeries1 = new ScatterSeries
            {
                MarkerType = MarkerType.Square,
                MarkerSize = 5,
                MarkerStroke = OxyColors.Black,
                MarkerFill = OxyColors.LightGreen
            };


            var series = new LineSeries()
            {
                Color = OxyColors.Blue,
                StrokeThickness = 2
            };
            series.Points.Add(new DataPoint(XX.Min(), intercept + slope * XX.Min()));
            series.Points.Add(new DataPoint(XX.Max(), intercept + slope * XX.Max()));

            // Add the data points to the scatter series

            if (chkNonAverage.Checked)
            {
                double[,] data2 = new double[XXall.Length, 2];
                for (int i = 0; i < XXall.Length; i++)
                {
                    data2[i, 0] = XXall[i];
                    data2[i, 1] = YYall[i];
                }

                for (int i = 0; i < data2.GetLength(0); i++)
                {
                    scatterSeries.Points.Add(new ScatterPoint(data2[i, 0], data2[i, 1]));
                }

                plotModel.Series.Add(scatterSeries);
            }

            double[,] data = new double[XX.Length, 2];
            for (int i = 0; i < XX.Length; i++)
            {
                data[i, 0] = XX[i];
                data[i, 1] = YY[i];
            }

            for (int i = 0; i < data.GetLength(0); i++)
            {
                scatterSeries1.Points.Add(new ScatterPoint(data[i, 0], data[i, 1]));
            }


            //scatterSeries1.LabelFormatString = "{1:0.###}";

            plotModel.Series.Add(series);
            //// Add the scatter series to the plot model
            plotModel.Series.Add(scatterSeries1);

            return plotModel;
        }
        public PlotModel OxyPlot_Linear_Through_Zero(double[] XX, double[] YY, double[] XXall, double[] YYall, ref string equation, bool ForExport, ref string actual_equation, ref string actual_RSquared)
        {
            var slope = Fit.LineThroughOrigin(XX, YY);

            //double[] predictedY = new double[YY.Length];
            //for (int i = 0; i < YY.Length; i++)
            //{
            //    predictedY[i] = linearRegression * XX[i];
            //}

            //double rsquared = GoodnessOfFit.RSquared(YY, predictedY);

            double SSres = 0.0;
            double SStot = 0.0;
            for (int i = 0; i < XX.Length; i++)
            {
                double yFit = XX[i] * slope;
                SSres += Math.Pow(YY[i] - yFit, 2);
                SStot += Math.Pow(YY[i] - YY.Average(), 2);
            }

            double rsquared = 1 - SSres / SStot;

            if (!ForExport)
            {
                txtEquation.Text = string.Format("y = {0:F6}*x\rRSquared= {1:F6}", slope, rsquared);
            }
            else
            {
                actual_equation = $"y = {slope.ToString("F6")}*x";
                actual_RSquared = rsquared.ToString("F6");
                equation = string.Format("y = {0:F6}*x     RSquared= {1:F6}", slope, rsquared);
            }

            // Generate a plot model and set the plot title
            var plotModel = new PlotModel { Title = "Linear Through Zero" };

            // Add a linear axis for the x-axis
            var xAxis = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Concentration",
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot
            };
            plotModel.Axes.Add(xAxis);

            // Add a linear axis for the y-axis
            var yAxis = new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "Area",
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot
            };
            plotModel.Axes.Add(yAxis);

            if (chkNonAverage.Checked)
            {
                // Create a scatter series for the observed data
                var scatterSeries = new ScatterSeries
                {
                    MarkerType = MarkerType.Square,
                    MarkerSize = 5,
                    MarkerStroke = OxyColors.Black,
                    MarkerFill = OxyColors.Red
                };

                for (int i = 0; i < XXall.Length; i++)
                {
                    scatterSeries.Points.Add(new ScatterPoint(XXall[i], YYall[i]));
                }

                plotModel.Series.Add(scatterSeries);
            }

            // Create a scatter series for the observed data
            var scatterSeries1 = new ScatterSeries
            {
                MarkerType = MarkerType.Square,
                MarkerSize = 5,
                MarkerStroke = OxyColors.Black,
                MarkerFill = OxyColors.LightGreen
            };

            for (int i = 0; i < XX.Length; i++)
            {
                scatterSeries1.Points.Add(new ScatterPoint(XX[i], YY[i]));
            }

            // Create a line series for the line through the origin
            var lineSeries = new LineSeries()
            {
                Color = OxyColors.Blue,
                StrokeThickness = 2
            };

            lineSeries.Points.Add(new DataPoint(0, 0));
            lineSeries.Points.Add(new DataPoint(XX.Max(), XX.Max() * slope));

            // Add the scatter and line series to the plot model
            plotModel.Series.Add(lineSeries);
            plotModel.Series.Add(scatterSeries1);

            return plotModel;
        }
        public PlotModel OxyPlot_Quadratic(double[] XX, double[] YY, double[] XXall, double[] YYall, ref string equation, bool ForExport, ref string actual_equation, ref string actual_RSquared, ref double actual_a, ref double actual_b, ref double actual_c)
        {
            int degree = 2;
            var coefficients = Fit.Polynomial(XX, YY, degree);
            double aA = coefficients[2];
            double bB = coefficients[1];
            double cC = coefficients[0];

            // Predict the Y values using the fitted model
            double[] yPredicted = null;

            if (chk1x.Checked)
            {
                double[] xValues = XX;
                double[] yValues = YY;
                double[] w = new double[xValues.Length];

                for (int i = 0; i < xValues.Length; i++)
                {
                    w[i] = 1.0 / xValues[i];
                }

                double[,] D = new double[xValues.Length, 3];
                for (int i = 0; i < xValues.Length; i++)
                {
                    D[i, 0] = 1;
                    D[i, 1] = xValues[i];
                    D[i, 2] = Math.Pow(xValues[i], 2);
                }

                double[,] W = new double[xValues.Length, xValues.Length];
                for (int i = 0; i < xValues.Length; i++)
                {
                    for (int j = i; j < xValues.Length; j++)
                    {
                        if (j == i)
                        {
                            W[i, j] = w[i];
                        }
                        else
                        {
                            W[i, j] = 0;
                        }
                    }
                }

                Matrix<double> DMatrix = Matrix<double>.Build.DenseOfArray(D);
                Matrix<double> WMatrix = Matrix<double>.Build.DenseOfArray(W);

                Matrix<double> A = DMatrix.TransposeThisAndMultiply(WMatrix).Multiply(DMatrix);
                Vector<double> yVector = Vector<double>.Build.DenseOfArray(yValues);

                Vector<double> coefficients_new = A.Inverse() * DMatrix.TransposeThisAndMultiply(WMatrix) * yVector;

                aA = coefficients_new[2];
                bB = coefficients_new[1];
                cC = coefficients_new[0];

                List<double> new_coefficients = new List<double>();
                new_coefficients.Add(cC);
                new_coefficients.Add(bB);
                new_coefficients.Add(aA);

                yPredicted = XX.Select(x1 => EvaluatePolynomial(new_coefficients.ToArray(), x1)).ToArray();


            }
            else if (chk1xsquare.Checked)
            {
                double[] xValues = XX;
                double[] yValues = YY;
                double[] w = new double[xValues.Length];

                for (int i = 0; i < xValues.Length; i++)
                {
                    w[i] = 1.0 / Math.Pow(xValues[i], 2);
                }

                double[,] D = new double[xValues.Length, 3];
                for (int i = 0; i < xValues.Length; i++)
                {
                    D[i, 0] = 1;
                    D[i, 1] = xValues[i];
                    D[i, 2] = Math.Pow(xValues[i], 2);
                }

                double[,] W = new double[xValues.Length, xValues.Length];
                for (int i = 0; i < xValues.Length; i++)
                {
                    for (int j = i; j < xValues.Length; j++)
                    {
                        if (j == i)
                        {
                            W[i, j] = w[i];
                        }
                        else
                        {
                            W[i, j] = 0;
                        }
                    }
                }

                Matrix<double> DMatrix = Matrix<double>.Build.DenseOfArray(D);
                Matrix<double> WMatrix = Matrix<double>.Build.DenseOfArray(W);

                Matrix<double> A = DMatrix.TransposeThisAndMultiply(WMatrix).Multiply(DMatrix);
                Vector<double> yVector = Vector<double>.Build.DenseOfArray(yValues);

                Vector<double> coefficients_new = A.Inverse() * DMatrix.TransposeThisAndMultiply(WMatrix) * yVector;

                aA = coefficients_new[2];
                bB = coefficients_new[1];
                cC = coefficients_new[0];

                List<double> new_coefficients = new List<double>();
                new_coefficients.Add(cC);
                new_coefficients.Add(bB);
                new_coefficients.Add(aA);

                yPredicted = XX.Select(x1 => EvaluatePolynomial(new_coefficients.ToArray(), x1)).ToArray();
            }
            else
            {
                yPredicted = XX.Select(x1 => EvaluatePolynomial(coefficients, x1)).ToArray();
            }

            actual_a = aA;
            actual_b = bB;
            actual_c = cC;

            // Calculate the R-squared value using the predicted and actual Y values
            double rsquared = GoodnessOfFit.RSquared(yPredicted, YY);


            if (!ForExport)
            {
                txtEquation.Text = string.Format("y = {0:F6}*x^2 + {1:F6}*x + {2:F6}\rRSquared= {3:F6}", aA, bB, cC, rsquared);
                if (chk1x.Checked)
                {
                    txtEquation.Text += "\r(weighting: 1/x)";
                }
                else if (chk1xsquare.Checked)
                {
                    txtEquation.Text += "\r(weighting: 1/x^2)";
                }
            }
            else
            {
                actual_equation = $"y = {aA.ToString("F6")}*x^2 + {bB.ToString("F6")}*x + {cC.ToString("F6")}";
                actual_RSquared = rsquared.ToString("F4");
                equation = string.Format("y = {0:F6}*x^2 + {1:F6}*x + {2:F6}     RSquared= {3:F6}", aA, bB, cC, rsquared);
                if (chk1x.Checked)
                {
                    equation += "     (weighting: 1/x)";
                }
                else if (chk1xsquare.Checked)
                {
                    equation += "     (weighting: 1/x^2)";
                }
            }

            var plotModel = new PlotModel
            {
                Title = "Quadratic"
            };

            // Create the X and Y axes
            var xAxis = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Concentration",
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot
            };
            plotModel.Axes.Add(xAxis);

            var yAxis = new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "Area",
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot
            };
            plotModel.Axes.Add(yAxis);

            // Create the scatter series
            var scatterSeries = new ScatterSeries
            {
                //MarkerType = MarkerType.Circle,
                MarkerType = MarkerType.Square,
                MarkerSize = 5,
                MarkerStroke = OxyColors.Black,
                MarkerFill = OxyColors.Red
            };

            var scatterSeries1 = new ScatterSeries
            {
                //MarkerType = MarkerType.Circle,
                MarkerType = MarkerType.Square,
                MarkerSize = 5,
                MarkerStroke = OxyColors.Black,
                MarkerFill = OxyColors.LightGreen
            };


            // Add the data points to the scatter series
            double[,] data = new double[XX.Length, 2];
            for (int i = 0; i < XX.Length; i++)
            {
                data[i, 0] = XX[i];
                data[i, 1] = YY[i];
            }

            if (chkNonAverage.Checked)
            {
                double[,] data2 = new double[XXall.Length, 2];
                for (int i = 0; i < XXall.Length; i++)
                {
                    data2[i, 0] = XXall[i];
                    data2[i, 1] = YYall[i];
                }

                for (int i = 0; i < data2.GetLength(0); i++)
                {
                    scatterSeries.Points.Add(new ScatterPoint(data2[i, 0], data2[i, 1]));
                }

                plotModel.Series.Add(scatterSeries);
            }

            for (int i = 0; i < data.GetLength(0); i++)
            {
                scatterSeries1.Points.Add(new ScatterPoint(data[i, 0], data[i, 1]));
            }


            // Create the line series for the quadratic equation
            var lineSeries = new LineSeries();
            lineSeries.Color = OxyColors.Blue;

            // Generate points for the quadratic equation using the same x values as the scatter series
            for (int i = 0; i < XX.Length; i++)
            {
                double yVal = EvaluatePolynomial(coefficients, XX[i]);
                lineSeries.Points.Add(new DataPoint(XX[i], yVal));
            }

            // Add the line series to the plot
            plotModel.Series.Add(lineSeries);

            // Add the scatter series to the plot model
            plotModel.Series.Add(scatterSeries1);

            return plotModel;
        }
        static double EvaluatePolynomial(double[] coefficients, double x)
        {
            double result = 0;
            for (int i = 0; i < coefficients.Length; i++)
            {
                result += coefficients[i] * Math.Pow(x, i);
            }
            return result;
        }
        private void saveFormToPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteTemp();

            string DefaultPath = ConfigurationManager.AppSettings["DefaultPDFFolder"].ToString();
            if (string.IsNullOrWhiteSpace(DefaultPath))
            {
                MessageBox.Show("Please select PDF default Path");
                return;
            }
            DefaultPath = Path.Combine(DefaultPath, DateTime.Now.ToString("MM-dd-yy hh_mm_ss"));
            StringBuilder csvData = new StringBuilder();
            string FilePath = Path.Combine("Temp", Guid.NewGuid().ToString());
            List<string> ScreensPaths = new List<string>();
            Form frmParent = this;

            int viewRecords = 0;

            foreach (Form frmChild in Application.OpenForms)
            {
                if (frmChild != frmParent)
                {
                    viewRecords++;
                }
            }

            if (viewRecords == 0)
            {
                //MessageBox.Show("Please select records to export");
                //return;

                var selectedItems = GetCheckedItems();//chkCName.CheckedItems.Cast<dynamic>().Select(x => x.ComponentName.ToString());

                if (selectedItems.Count() == 0)
                {
                    MessageBox.Show("Please select component.");
                    return;
                }

                int sCount = selectedItems.Count();//chkCName.CheckedItems.Count;
                CloseChildForms();
                DeleteTempGraphs();
                ViewNonStandardData(string.Join("', '", selectedItems), false, (eRegressionType)cmbRegT.SelectedIndex, true);
            }

         

            Document document = new Document();
            document.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
            document.SetMargins(5, 5, 5, 5);


            using (var stream = new FileStream($"{FilePath}.pdf", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                PdfWriter.GetInstance(document, stream);
                document.Open();
                foreach (var ScreensPath in ScreensPaths)
                {
                    using (var imageStream = new FileStream($"{ScreensPath}.png", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        var image = iTextSharp.text.Image.GetInstance(imageStream);
                        float maxWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
                        float maxHeight = document.PageSize.Height - document.TopMargin - document.BottomMargin;
                        if (image.Height > maxHeight || image.Width > maxWidth)
                            image.ScaleToFit(maxWidth, maxHeight);
                        document.Add(image);
                    }
                }

                iTextSharp.text.Font fontH = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD);

                iTextSharp.text.Font fontR = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL);

              
                string q = "\"";
                csvData.AppendLine($"{q}Equation Type{q},{q}Equation{q},{q}R Squared Value{q},{q}Acquisition Date & Time{q},{q}Sample Type{q},{q}Sample Name{q},{q}Component Name{q},{q}Actual Concentration{q},{q}Calculated Concentration{q},{q}Area{q}");

                foreach (Form frmChild in Application.OpenForms)
                {
                    if (frmChild != frmParent)
                    {
                        DataGridView dataGridView1 = null;
                        string FormTitle = "";
                        string GraphFileName = "";
                        foreach (System.Windows.Forms.Control control in frmChild.Controls)
                        {
                            if (frmChild is frmReverseCalculation)
                            {
                                FormTitle = frmChild.Text;
                                GraphFileName = ((frmReverseCalculation)frmChild).GraphFileName;

                                if (control is DataGridView)
                                {
                                    dataGridView1 = (DataGridView)control;
                                }
                            }
                        }

                        if (dataGridView1 != null)
                        {

                            PdfPTable pdfTable = new PdfPTable(6);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;


                            pdfTable.AddCell(new PdfPCell(new Phrase(" "))
                            {
                                Colspan = 6,//dataGridView1.Columns.Count,
                                BorderColor = iTextSharp.text.Color.WHITE
                            });

                            using (var imageStream = new FileStream(GraphFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                            {
                                var image = iTextSharp.text.Image.GetInstance(imageStream);
                                float maxWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
                                float maxHeight = document.PageSize.Height - document.TopMargin - document.BottomMargin;
                                if (image.Height > maxHeight || image.Width > maxWidth)
                                    image.ScaleToFit(maxWidth, maxHeight);
                                pdfTable.AddCell(new PdfPCell(image)
                                {
                                    Colspan = 6,//dataGridView1.Columns.Count,
                                    BorderColor = iTextSharp.text.Color.WHITE
                                });
                            }

                            var e_cell = new PdfPCell(new Phrase(FormTitle, fontH));
                            e_cell.Colspan = 6;//dataGridView1.Columns.Count;
                            pdfTable.AddCell(e_cell);

                            foreach (DataGridViewColumn column in dataGridView1.Columns)
                            {
                                if (column.Index <= 5)
                                {
                                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, fontH));
                                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                                    cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                                    pdfTable.AddCell(cell);
                                }
                            }


                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                string ConcentrationTitle = (row.Cells["h_EquationType"].Value.ToString() == "Quadratic") ? "CalculatedConcentration_Positive" : "CalculatedConcentration";
                                csvData.AppendLine($"{q}{row.Cells["h_EquationType"].Value}{q},{q}{row.Cells["h_Equation"].Value}{q},{q}{row.Cells["h_RSquared"].Value}{q},{q}{row.Cells["AcquisitionDateTime"].Value}{q},{q}{row.Cells["SampleType"].Value}{q},{q}{row.Cells["SampleName"].Value}{q},{q}{row.Cells["ComponentName"].Value}{q},{q}{row.Cells["h_ActualConcentration"].Value}{q},{q}{row.Cells[ConcentrationTitle].Value}{q},{q}{row.Cells["Area"].Value}{q}");
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    if (cell.ColumnIndex <= 5)
                                    {
                                        PdfPCell pdfcell = new PdfPCell(new Phrase(cell.Value.ToString(), fontR));
                                        pdfcell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                                        pdfTable.AddCell(pdfcell);
                                    }
                                }
                            }

                            document.Add(pdfTable);
                        }
                    }
                }

                document.Close();
            }

            CloseChildForms();

            File.WriteAllText(DefaultPath + ".csv", csvData.ToString());

            MessageBox.Show("PDF generated successfully.");

            File.Move(FilePath + ".pdf", DefaultPath + ".pdf");

            if (Convert.ToBoolean(ConfigurationManager.AppSettings["OpenPDFExport"].ToString()))
                System.Diagnostics.Process.Start(DefaultPath + ".pdf");

        }
        private void importDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string DefaultFolder = ConfigurationManager.AppSettings["DefaultFolder"].ToString();
            if (Directory.Exists(DefaultFolder))
            {
                openFileDialog1.InitialDirectory = DefaultFolder;
            }
            else
            {
                openFileDialog1.InitialDirectory = "C:\\";
            }
            openFileDialog1.Filter = "Text|*.txt";
            DialogResult res = openFileDialog1.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                chkCustom.Checked = false;
                string fname = openFileDialog1.FileName;
                try
                {
                    LoadDatafromText(fname);
                    cmbRegT.SelectedIndex = 0;

                    var distinctValues = dataTable.AsEnumerable().Where(w => w["Component Type"].ToString() != "Internal Standards")
                                .Select(row => new
                                {
                                    ComponentName = row.Field<string>("Component Name"),
                                })
                                .Distinct().ToArray();

                    //chkCName.DataSource = distinctValues;
                    //chkCName.DisplayMember = "ComponentName";

                    dgvComponents.DataSource = distinctValues;

                    for (int i = 0; i < dgvComponents.Rows.Count; i++)
                    {
                        //dgvComponents.Rows[i].Cells["cmbISName"].Value = dataTable.AsEnumerable()
                        //    .Where(w => w["Component Name"].ToString() == dgvComponents.Rows[i].Cells["gvtxtComponentName"].Value.ToString())
                        //    .Select(s => s["IS Name"]).FirstOrDefault();

                        dgvComponents.Rows[i].Cells["cmbISName"].Value = "(No IS)";
                    }

                    btnCalculate.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to read the file, Error: " + ex.Message);
                }
            }
        }
        private void addToListToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void ViewNonStandardData(string selectedItems, bool SaveData, eRegressionType regressionType, bool ForExport)
        {

            //GetEquation
            DataView dv1 = new DataView(dataTable);

            dv1.RowFilter = "[Component Name] IN ('" + selectedItems + "') AND [Sample Type] = 'Standard'";

            var dtCNames = dv1.ToTable(true, "Component Name");

            if (dtCNames.Rows.Count == 0)
            {
                MessageBox.Show("Select component(s) not found in the data loaded");
                return;
            }


            var selectedISNames = GetCheckedISNames();

            List<double> cons = new List<double>();
            List<double> areas = new List<double>();

            List<double> consAll = new List<double>();
            List<double> areasAll = new List<double>();

            int sCount1 = dtCNames.Rows.Count;
            int sCount = dtCNames.Rows.Count;

            //Temporary disabled, column also hide
            //string ComponentForConcentration = GetActualConcentrationComponent();

            for (int i = 0; i < dv1.Count; i += sCount1)
            {

                double parsetotalConsInside = 0;
                double parsetotalAreaInside = 0;

                double totalConsInside = 0;
                double totalAreaInside = 0;

                string ISCons = "";
                string ISArea = "";

                double ISparsetotalCons = 0;
                double ISparsetotalArea = 0;

                for (int j = 0; j < sCount1; j++)
                {
                    DataRowView r = dv1[i + j];

                    string SelectedISName = selectedISNames[r["Component Name"].ToString()];

                    double.TryParse(r["Actual Concentration"].ToString(), out parsetotalConsInside);


                    if (SelectedISName != "(No IS)")
                    {
                        ISCons = dataTable.AsEnumerable()
                        .Where(w => w["Component Name"].ToString() == SelectedISName && w["Sample Name"].ToString() == r["Sample Name"].ToString() && w["Sample Type"].ToString() == "Standard")
                        .Select(s => s["Actual Concentration"].ToString()).FirstOrDefault();

                        double.TryParse(ISCons, out ISparsetotalCons);

                        totalConsInside = parsetotalConsInside / ISparsetotalCons;
                    }
                    else
                    {
                        totalConsInside = parsetotalConsInside;
                    }

                    //Temporary disabled, column also hide
                    //if (!chkCustom.Checked)
                    //{
                    //    double.TryParse(r["Actual Concentration"].ToString(), out parsetotalConsInside);
                    //    if (ComponentForConcentration == "")
                    //    {
                    //        totalConsInside = parsetotalConsInside;
                    //    }
                    //    else if (r["Component Name"].ToString() == ComponentForConcentration)
                    //    {
                    //        totalConsInside = parsetotalConsInside;
                    //    }
                    //}

                    double.TryParse(r["Area"].ToString(), out parsetotalAreaInside);

                    if (SelectedISName != "(No IS)")
                    {
                        ISArea = dataTable.AsEnumerable()
                        .Where(w => w["Component Name"].ToString() == SelectedISName && w["Sample Name"].ToString() == r["Sample Name"].ToString() && w["Sample Type"].ToString() == "Standard")
                        .Select(s => s["Area"].ToString()).FirstOrDefault();

                        double.TryParse(ISArea, out ISparsetotalArea);

                        totalAreaInside = totalAreaInside + (parsetotalAreaInside / ISparsetotalArea);
                    }
                    else
                    {
                        totalAreaInside = totalAreaInside + parsetotalAreaInside;
                    }
                }

                if (chkCustom.Checked)
                {
                    if (CustomConcentration.ContainsKey(dv1[i]["Sample Name"].ToString()))
                    {
                        totalConsInside = CustomConcentration[dv1[i]["Sample Name"].ToString()];
                    }
                    else
                    {
                        totalConsInside = 0;
                    }
                }

                areas.Add(totalAreaInside);
                cons.Add(totalConsInside);

            }

            for (int i = 0; i < dv1.Count; i++)
            {

                double parsetotalConsInsideAll = 0;
                double parsetotalAreaInsideAll = 0;

                DataRowView r = dv1[i];

                double.TryParse(r["Actual Concentration"].ToString(), out parsetotalConsInsideAll);
                double.TryParse(r["Area"].ToString(), out parsetotalAreaInsideAll);

                areasAll.Add(parsetotalAreaInsideAll * 2);
                consAll.Add(parsetotalConsInsideAll);
            }

            string equation = "";

            double linear_b = 0;
            double linear_m = 0;

            double linear_zero_a = 0;

            double quadratic_a = 0;
            double quadratic_b = 0;
            double quadratic_c = 0;

            string actual_equation = "";
            string actual_RSquared = "";

            string RegressionTypeName = regressionType.ToString().Replace("_", " ");

            string GraphFileName = Path.Combine("TempGraphs", Guid.NewGuid().ToString() + ".png");

            PlotModel plotModel = null;

            if (regressionType == eRegressionType.Linear)
            {
                var linearRegression = Fit.Line(cons.ToArray(), areas.ToArray());

                linear_m = linearRegression.Item2;
                linear_b = linearRegression.Item1;

                //equation = string.Format("y = {0:F3}*x + {1:F3}", linearRegression.Item2, linearRegression.Item1);

                plotModel = OxyPlot_Linear(cons.ToArray(), areas.ToArray(), consAll.ToArray(), areasAll.ToArray(), ref equation, true, ref actual_equation, ref actual_RSquared);

                var pngExporter = new OxyPlot.WindowsForms.PngExporter { Width = 1400, Height = 850 };
                pngExporter.ExportToBitmap(plotModel).Save(GraphFileName);

            }
            else if (regressionType == eRegressionType.Linear_Through_Zero)
            {
                var linearRegression = Fit.LineThroughOrigin(cons.ToArray(), areas.ToArray());

                linear_zero_a = linearRegression;

              
                plotModel = OxyPlot_Linear_Through_Zero(cons.ToArray(), areas.ToArray(), consAll.ToArray(), areasAll.ToArray(), ref equation, true, ref actual_equation, ref actual_RSquared);

                var pngExporter = new OxyPlot.WindowsForms.PngExporter { Width = 1400, Height = 850 };
                pngExporter.ExportToBitmap(plotModel).Save(GraphFileName);

            }
            else if (regressionType == eRegressionType.Quadratic)
            {
                
                plotModel = OxyPlot_Quadratic(cons.ToArray(), areas.ToArray(), consAll.ToArray(), areasAll.ToArray(), ref equation, true, ref actual_equation, ref actual_RSquared, ref quadratic_a, ref quadratic_b, ref quadratic_c);

                var pngExporter = new OxyPlot.WindowsForms.PngExporter { Width = 1400, Height = 850 };
                pngExporter.ExportToBitmap(plotModel).Save(GraphFileName);
            }
            //GetEquation

            DataView dv = new DataView(dataTable);

            dv.RowFilter = "[Component Name] IN ('" + selectedItems + "')"; //AND [Sample Type] <> 'Standard'";

            List<ReverseCalculationModel> lstData = new List<ReverseCalculationModel>();

            for (int i = 0; i < dv.Count; i += sCount)
            {
                bool UsedFound = false;
                for (int j = 0; j < sCount; j++)
                {
                    DataRowView r = dv[i + j];
                    bool Used = Convert.ToBoolean(r["Used"].ToString());
                    if (Used)
                    {
                        UsedFound = true;
                        break;
                    }
                }

                if (UsedFound)
                {
                    ReverseCalculationModel reverseCalculationModel = new ReverseCalculationModel();
                    for (int j = 0; j < sCount; j++)
                    {
                        DataRowView r = dv[i + j];

                        bool Used = Convert.ToBoolean(r["Used"].ToString());
                        reverseCalculationModel.SampleName = r["Sample Name"].ToString();

                        //if (!string.IsNullOrWhiteSpace(reverseCalculationModel.SampleType))
                        //    reverseCalculationModel.SampleType += ",";
                        reverseCalculationModel.SampleType = r["Sample Type"].ToString();

                        if (reverseCalculationModel.SampleType == "Standard")
                        {
                            string SelectedISName = selectedISNames[r["Component Name"].ToString()];

                            //if (chkCustom.Checked)
                            //{
                            //    if (CustomConcentration.ContainsKey(reverseCalculationModel.SampleName))
                            //    {
                            //        reverseCalculationModel.ActualConcentration = CustomConcentration[reverseCalculationModel.SampleName];
                            //    }
                            //}
                            //else
                            //{

                            double parsetotalConsInside;
                            double.TryParse(r["Actual Concentration"].ToString(), out parsetotalConsInside);

                            if (SelectedISName != "(No IS)")
                            {
                                string ISCons = "";
                                double ISparsetotalCons = 0;

                                ISCons = dataTable.AsEnumerable()
                                .Where(w => w["Component Name"].ToString() == SelectedISName && w["Sample Name"].ToString() == r["Sample Name"].ToString() && w["Sample Type"].ToString() == "Standard")
                                .Select(s => s["Actual Concentration"].ToString()).FirstOrDefault();

                                double.TryParse(ISCons, out ISparsetotalCons);

                                reverseCalculationModel.ActualConcentration = parsetotalConsInside / ISparsetotalCons;
                            }
                            else
                            {
                                reverseCalculationModel.ActualConcentration = parsetotalConsInside;
                            }



                            //Temporary disabled, column also hide
                            //if (ComponentForConcentration == "")
                            //{
                            //    reverseCalculationModel.ActualConcentration = parsetotalConsInside;
                            //}
                            //else if (r["Component Name"].ToString() == ComponentForConcentration)
                            //{
                            //    reverseCalculationModel.ActualConcentration = parsetotalConsInside;
                            //}
                            //}

                            double parsetotalArea;
                            double.TryParse(r["Area"].ToString(), out parsetotalArea);

                            if (SelectedISName != "(No IS)")
                            {
                                string ISArea = "";
                                double ISparsetotalArea = 0;

                                ISArea = dataTable.AsEnumerable()
                            .Where(w => w["Component Name"].ToString() == SelectedISName && w["Sample Name"].ToString() == r["Sample Name"].ToString() && w["Sample Type"].ToString() == "Standard")
                            .Select(s => s["Area"].ToString()).FirstOrDefault();

                                double.TryParse(ISArea, out ISparsetotalArea);

                                reverseCalculationModel.Area += (Used) ? (parsetotalArea / ISparsetotalArea) : 0;
                            }
                            else
                            {
                                reverseCalculationModel.Area += (Used) ? parsetotalArea : 0;
                            }
                        }
                        else
                        {
                            double parsetotalArea;
                            double.TryParse(r["Area"].ToString(), out parsetotalArea);

                            reverseCalculationModel.Area += (Used) ? parsetotalArea : 0;

                        }

                        reverseCalculationModel.AcquisitionDateTime = Convert.ToDateTime(r["Acquisition Date & Time"].ToString());

                        if (!string.IsNullOrWhiteSpace(reverseCalculationModel.ComponentName))
                            reverseCalculationModel.ComponentName += ",";

                        reverseCalculationModel.ComponentName += r["Component Name"].ToString();
                    }

                    if (regressionType == eRegressionType.Linear)
                    {
                        reverseCalculationModel.CalculatedConcentration = Math.Round(getLinearEquationValue(reverseCalculationModel.Area, linear_b, linear_m), 4);
                    }
                    else if (regressionType == eRegressionType.Linear_Through_Zero)
                    {
                        reverseCalculationModel.CalculatedConcentration = Math.Round(getLinear_Zero_EquationValue(reverseCalculationModel.Area, linear_zero_a), 4);
                    }
                    else if (regressionType == eRegressionType.Quadratic)
                    {
                        double[] result = getQuadraticEquationValue(reverseCalculationModel.Area, quadratic_a, quadratic_b, quadratic_c);
                        reverseCalculationModel.CalculatedConcentration = 0;
                        reverseCalculationModel.CalculatedConcentration_Positive = Math.Round(result[0], 4);
                        reverseCalculationModel.CalculatedConcentration_Negative = Math.Round(result[1], 4);

                    }

                    reverseCalculationModel.Area = Math.Round(reverseCalculationModel.Area, 4);

                    lstData.Add(reverseCalculationModel);
                }
            }

            bool dataSaved = false;
            if (SaveData)
            {
                dataSaved = SaveList(lstData);
                if (!dataSaved)
                {
                    MessageBox.Show("An error occurred while saving, Please try again later or contact admin.");
                    return;
                }
            }

            frmReverseCalculation frmReverseCalculation = new frmReverseCalculation();
            frmReverseCalculation.Text = $"{RegressionTypeName} ({equation})";
            frmReverseCalculation.GraphFileName = GraphFileName;
            if (regressionType == eRegressionType.Linear || regressionType == eRegressionType.Linear_Through_Zero)
            {
                frmReverseCalculation.lstData = lstData.Select(s => new ReverseCalculationLinearModel
                {
                    SampleName = s.SampleName,
                    SampleType = s.SampleType,
                    AcquisitionDateTime = s.AcquisitionDateTime,
                    ComponentName = s.ComponentName,
                    CalculatedConcentration = s.CalculatedConcentration,
                    Area = s.Area,
                    h_Equation = actual_equation,
                    h_RSquared = actual_RSquared,
                    h_EquationType = RegressionTypeName,
                    h_ActualConcentration = (s.ActualConcentration == 0) ? "" : s.ActualConcentration.ToString()
                }).ToList();
            }
            else if (regressionType == eRegressionType.Quadratic)
            {
                frmReverseCalculation.lstData = lstData.Select(s => new ReverseCalculationPolinomialModel
                {
                    SampleName = s.SampleName,
                    SampleType = s.SampleType,
                    AcquisitionDateTime = s.AcquisitionDateTime,
                    ComponentName = s.ComponentName,
                    CalculatedConcentration_Positive = s.CalculatedConcentration_Positive,
                    // CalculatedConcentration_Negative = s.CalculatedConcentration_Negative,
                    Area = s.Area,
                    h_Equation = actual_equation,
                    h_RSquared = actual_RSquared,
                    h_EquationType = RegressionTypeName,
                    h_ActualConcentration = (s.ActualConcentration == 0) ? "" : s.ActualConcentration.ToString()
                }).ToList();
            }

            frmReverseCalculation.hideform = ForExport;
            frmReverseCalculation.Show();

        }
        private bool SaveList(List<ReverseCalculationModel> lstData)
        {
            List<ReverseCalculationMasterModel> lstMasterData = null;
            if (File.Exists("dbIonSummer.json"))
            {
                lstMasterData = JsonConvert.DeserializeObject<List<ReverseCalculationMasterModel>>(File.ReadAllText("dbIonSummer.json"));
            }
            else
            {
                lstMasterData = new List<ReverseCalculationMasterModel>();
            }

            lstMasterData.Add(new ReverseCalculationMasterModel
            {
                CreatedOn = DateTime.Now,
                ID = Guid.NewGuid().ToString(),
                //lstData = lstData
                Components = string.Join(",", lstData.Select(s => s.ComponentName).Distinct().ToArray()),
                RegressionType = (eRegressionType)cmbRegT.SelectedIndex
            });

            File.WriteAllText("dbIonSummer.json", JsonConvert.SerializeObject(lstMasterData));

            return true;
        }
        private double getLinearEquationValue(double y, double b, double m)
        {
            //y = mx+b 
            //x = (y-b)/m

            double x = (y - b) / m;

            return x;
        }
        private double getLinear_Zero_EquationValue(double y, double a)
        {
            double x = y / a;

            return x;
        }
        private double[] getQuadraticEquationValue(double y, double a, double b, double c)
        {
            double discriminant = Math.Pow(b, 2) - 4 * a * (c - y);
            double root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            double root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);

            return new double[] { root1, root2 };

        }
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedItems = GetCheckedItems();//chkCName.CheckedItems.Cast<dynamic>().Select(x => x.ComponentName.ToString());

                if (selectedItems.Count() == 0)
                {
                    MessageBox.Show("Please select component.");
                    return;
                }

                var selectedISNames = GetCheckedISNames();


                DataView dv = new DataView(dataTable);

                dv.RowFilter = "[Component Name] IN ('" + string.Join("', '", selectedItems) + "') AND [Sample Type] = 'Standard'";

                List<double> cons = new List<double>();
                List<double> areas = new List<double>();

                List<double> consAll = new List<double>();
                List<double> areasAll = new List<double>();


                int sCount = selectedItems.Count();//chkCName.CheckedItems.Count;

                //Temporary disabled, column also hide
                //string ComponentForConcentration = GetActualConcentrationComponent();

                for (int i = 0; i < dv.Count; i += sCount)
                {

                    double parsetotalConsInside = 0;
                    double parsetotalAreaInside = 0;

                    double totalConsInside = 0;
                    double totalAreaInside = 0;

                    string ISCons = "";
                    string ISArea = "";

                    double ISparsetotalCons = 0;
                    double ISparsetotalArea = 0;


                    for (int j = 0; j < sCount; j++)
                    {
                        DataRowView r = dv[i + j];

                        string SelectedISName = selectedISNames[r["Component Name"].ToString()];

                        double.TryParse(r["Actual Concentration"].ToString(), out parsetotalConsInside);


                        if (SelectedISName != "(No IS)")
                        {
                            ISCons = dataTable.AsEnumerable()
                            .Where(w => w["Component Name"].ToString() == SelectedISName && w["Sample Name"].ToString() == r["Sample Name"].ToString() && w["Sample Type"].ToString() == "Standard")
                            .Select(s => s["Actual Concentration"].ToString()).FirstOrDefault();

                            double.TryParse(ISCons, out ISparsetotalCons);

                            totalConsInside = parsetotalConsInside / ISparsetotalCons;
                        }
                        else
                        {
                            totalConsInside = parsetotalConsInside;
                        }



                        //Temporary disabled, column also hide
                        //if (!chkCustom.Checked)
                        //{
                        //    double.TryParse(r["Actual Concentration"].ToString(), out parsetotalConsInside);
                        //    if (ComponentForConcentration == "")
                        //    {
                        //        totalConsInside = parsetotalConsInside;
                        //    }
                        //    else if (r["Component Name"].ToString() == ComponentForConcentration)
                        //    {
                        //        totalConsInside = parsetotalConsInside;
                        //    }
                        //}

                        double.TryParse(r["Area"].ToString(), out parsetotalAreaInside);


                        if (SelectedISName != "(No IS)")
                        {
                            ISArea = dataTable.AsEnumerable()
                            .Where(w => w["Component Name"].ToString() == SelectedISName && w["Sample Name"].ToString() == r["Sample Name"].ToString() && w["Sample Type"].ToString() == "Standard")
                            .Select(s => s["Area"].ToString()).FirstOrDefault();

                            double.TryParse(ISArea, out ISparsetotalArea);

                            totalAreaInside = totalAreaInside + (parsetotalAreaInside / ISparsetotalArea);
                        }
                        else
                        {
                            totalAreaInside = totalAreaInside + parsetotalAreaInside;
                        }

                    }

                    if (chkCustom.Checked)
                    {
                        if (CustomConcentration.ContainsKey(dv[i]["Sample Name"].ToString()))
                        {
                            totalConsInside = CustomConcentration[dv[i]["Sample Name"].ToString()];
                        }
                        else
                        {
                            totalConsInside = 0;
                        }
                    }

                    areas.Add(totalAreaInside);
                    cons.Add(totalConsInside);

                }

                for (int i = 0; i < dv.Count; i++)
                {

                    double parsetotalConsInsideAll = 0;
                    double parsetotalAreaInsideAll = 0;

                    DataRowView r = dv[i];

                    double.TryParse(r["Actual Concentration"].ToString(), out parsetotalConsInsideAll);
                    double.TryParse(r["Area"].ToString(), out parsetotalAreaInsideAll);

                    areasAll.Add(parsetotalAreaInsideAll * 2);
                    consAll.Add(parsetotalConsInsideAll);
                }


                if (cons.Count == 0 || areas.Count == 0)
                {
                    MessageBox.Show("Data is not complete to plot on graph.");
                    return;
                }

                eRegressionType regressionType = (eRegressionType)cmbRegT.SelectedIndex;

                string equation = "";

                string actual_equation = "";
                string actual_RSquared = "";
                double actual_a = 0;
                double actual_b = 0;
                double actual_c = 0;
                if (regressionType == eRegressionType.Linear)
                {
                    var plotModel = OxyPlot_Linear(cons.ToArray(), areas.ToArray(), consAll.ToArray(), areasAll.ToArray(), ref equation, false, ref actual_equation, ref actual_RSquared);

                    // Create the plot view and add it to the form
                    var plotView = new OxyPlot.WindowsForms.PlotView
                    {
                        Dock = DockStyle.Fill,
                        Model = plotModel
                    };
                    grp2.Controls.Clear();
                    grp2.Controls.Add(plotView);

                }
                else if (regressionType == eRegressionType.Linear_Through_Zero)
                {
                    var plotModel = OxyPlot_Linear_Through_Zero(cons.ToArray(), areas.ToArray(), consAll.ToArray(), areasAll.ToArray(), ref equation, false, ref actual_equation, ref actual_RSquared);

                    //// Create the plot view and add it to the form
                    var plotView = new OxyPlot.WindowsForms.PlotView
                    {
                        Dock = DockStyle.Fill,
                        Model = plotModel
                    };
                    grp2.Controls.Clear();
                    grp2.Controls.Add(plotView);
                }
                //else if (cmbRegT.SelectedIndex == 2)
                //{
                //    OxyPlot3(cons.ToArray(), areas.ToArray());
                //}
                else if (regressionType == eRegressionType.Quadratic)
                {
                    var plotModel = OxyPlot_Quadratic(cons.ToArray(), areas.ToArray(), consAll.ToArray(), areasAll.ToArray(), ref equation, false, ref actual_equation, ref actual_RSquared, ref actual_a, ref actual_b, ref actual_c);

                    // Create the plot view and add it to the form
                    var plotView = new OxyPlot.WindowsForms.PlotView
                    {
                        Dock = DockStyle.Fill,
                        Model = plotModel
                    };
                    grp2.Controls.Clear();
                    grp2.Controls.Add(plotView);
                }
                //else if (cmbRegT.SelectedIndex == 3)
                //{
                //    OxyPlot5(cons.ToArray(), areas.ToArray(), consAll.ToArray(), areasAll.ToArray());
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred, Error Details: " + ex.Message);
            }
        }
        private void CloseChildForms()
        {
            List<Form> openForms = new List<Form>();

            foreach (Form f in Application.OpenForms)
                openForms.Add(f);

            foreach (Form f in openForms)
            {
                if (f.Name != "frmIonSummer")
                    f.Close();
            }
        }

        private void DeleteTempGraphs()
        {
            if (!Directory.Exists("TempGraphs"))
            {
                Directory.CreateDirectory("TempGraphs");
            }
            else
            {

                foreach (var file in Directory.GetFiles("TempGraphs"))
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch { }
                }

            }
        }

        private void DeleteTemp()
        {
            if (!Directory.Exists("Temp"))
            {
                Directory.CreateDirectory("Temp");
            }
            else
            {

                foreach (var file in Directory.GetFiles("Temp"))
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch { }
                }

            }
        }

        private void setDefaultFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDefaultPath frmDefaultPath = new frmDefaultPath();
            frmDefaultPath.ShowDialog();
        }

        private void viewHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists("dbIonSummer.json"))
            {
                List<ReverseCalculationMasterModel> lstMasterData = JsonConvert.DeserializeObject<List<ReverseCalculationMasterModel>>(File.ReadAllText("dbIonSummer.json"));

                var HistoryData = lstMasterData.Select(s => new { s.ID, RegressionType = s.RegressionType.ToString().Replace("_", " "), Components = s.Components, s.CreatedOn }).ToList();

                frmComponentHistory frmComponentHistory = new frmComponentHistory();
                frmComponentHistory.lstData = HistoryData;
                if (frmComponentHistory.ShowDialog(this) == DialogResult.OK)
                {
                    CloseChildForms();
                    DeleteTempGraphs();
                    if (dataTable.Rows.Count > 0)
                    {
                        foreach (var id in viewID)
                        {
                            string components = string.Join(",", HistoryData.Where(w => w.ID == id).Select(s => s.Components).ToArray());
                            eRegressionType regressionType = (eRegressionType)lstMasterData.Where(w => w.ID == id).Select(s => s.RegressionType).FirstOrDefault();
                            ViewNonStandardData(components.Replace(",", "','"), false, regressionType, ViewAndExport);
                        }

                        if (ViewAndExport)
                        {
                            saveFormToPDFToolStripMenuItem_Click(null, null);

                            //CloseChildForms();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please load data to calculate concentration.");
                    }
                }
            }
            else
            {
                MessageBox.Show("No history data found.");
            }
        }

        private void saveSelectedComponentToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var selectedItems = GetCheckedItems();//chkCName.CheckedItems.Cast<dynamic>().Select(x => x.ComponentName.ToString());

            if (selectedItems.Count() == 0)
            {
                MessageBox.Show("Please select component.");
                return;
            }

            int sCount = selectedItems.Count();//chkCName.CheckedItems.Count;
            CloseChildForms();
            DeleteTempGraphs();
            ViewNonStandardData(string.Join("', '", selectedItems), true, (eRegressionType)cmbRegT.SelectedIndex, false);
        }

        private void setPDFDefaultFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPDFDefaultPath frmDefaultPath = new frmPDFDefaultPath();
            frmDefaultPath.ShowDialog();
        }

        private void dgvComponents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvComponents.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvComponents_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Whatever index is your checkbox column
            var radio_columnIndex = 0;
            var component_columnIndex = 1;
            if (e.ColumnIndex == radio_columnIndex)
            {
                // If the user checked this box, then uncheck all the other rows
                var isChecked = (bool)dgvComponents.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (isChecked)
                {
                    foreach (DataGridViewRow row in dgvComponents.Rows)
                    {
                        if (row.Index != e.RowIndex)
                        {
                            row.Cells[radio_columnIndex].Value = !isChecked;
                        }
                    }
                }
            }
            else if (e.ColumnIndex == component_columnIndex)
            {
                var isChecked = (bool)dgvComponents.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                if (!isChecked)
                {
                    dgvComponents.Rows[e.RowIndex].Cells[radio_columnIndex].Style = new DataGridViewCellStyle()
                    {
                        BackColor = System.Drawing.Color.Silver
                    };
                    dgvComponents.Rows[e.RowIndex].Cells[radio_columnIndex].ReadOnly = true;
                    dgvComponents.Rows[e.RowIndex].Cells[radio_columnIndex].Value = false;
                }
                else
                {
                    dgvComponents.Rows[e.RowIndex].Cells[radio_columnIndex].Style = new DataGridViewCellStyle()
                    {
                        BackColor = System.Drawing.Color.White
                    };
                    dgvComponents.Rows[e.RowIndex].Cells[radio_columnIndex].ReadOnly = false;
                }

            }
        }

        private List<string> GetCheckedItems()
        {
            List<string> lstComponents = new List<string>();
            foreach (DataGridViewRow dRow in dgvComponents.Rows)
            {
                if (Convert.ToBoolean(dRow.Cells["gvchkCName"].EditedFormattedValue) == true)
                {
                    lstComponents.Add(dRow.Cells["gvtxtComponentName"].Value.ToString());
                }
            }

            return lstComponents;
        }

        private Dictionary<string, string> GetCheckedISNames()
        {
            Dictionary<string, string> lstComponents = new Dictionary<string, string>();
            foreach (DataGridViewRow dRow in dgvComponents.Rows)
            {
                if (Convert.ToBoolean(dRow.Cells["gvchkCName"].EditedFormattedValue) == true)
                {
                    lstComponents.Add(dRow.Cells["gvtxtComponentName"].Value.ToString(), dRow.Cells["cmbISName"].Value.ToString());
                }
            }

            return lstComponents;
        }

        private string GetActualConcentrationComponent()
        {
            string Component = "";
            foreach (DataGridViewRow dRow in dgvComponents.Rows)
            {
                if (Convert.ToBoolean(dRow.Cells[0].EditedFormattedValue) == true)
                {
                    Component = dRow.Cells[2].Value.ToString();
                    break;
                }
            }
            return Component;
        }

        private void chkCustom_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCustom.Checked)
            {
                var selectedItems = GetCheckedItems();
                if (selectedItems.Count() == 0)
                {
                    MessageBox.Show("Please select component.");
                    chkCustom.Checked = false;
                    return;
                }

                frmCustomConcentrations frmCustomConcentrations = new frmCustomConcentrations();
                frmCustomConcentrations.dgvCustomConcentration.Rows.Clear();
                CustomConcentration = new Dictionary<string, double>();

                var distinctValues = dataTable.AsEnumerable().Where(w => selectedItems.Contains(w["Component Name"].ToString()) && w["Sample Type"].ToString() == "Standard")
                            .Select(row => new
                            {
                                SampleName = row.Field<string>("Sample Name"),
                            })
                            .Distinct().ToList();

                foreach (var Item in distinctValues)
                {
                    frmCustomConcentrations.dgvCustomConcentration.Rows.Add(Item.SampleName, "0.00");
                }

                if (frmCustomConcentrations.ShowDialog() == DialogResult.OK)
                {
                    foreach (DataGridViewRow dRow in frmCustomConcentrations.dgvCustomConcentration.Rows)
                    {
                        CustomConcentration.Add(dRow.Cells[0].Value.ToString(), Convert.ToDouble(dRow.Cells[1].Value));
                    }
                }
            }
        }

        private void chk1x_CheckedChanged(object sender, EventArgs e)
        {
            if (chk1x.Checked)
            {
                chk1xsquare.Checked = false;
            }
        }

        private void chk1xsquare_CheckedChanged(object sender, EventArgs e)
        {
            if (chk1xsquare.Checked)
            {
                chk1x.Checked = false;
            }
        }

        private void cmbRegT_SelectedIndexChanged(object sender, EventArgs e)
        {
            chk1x.Checked = false;
            chk1xsquare.Checked = false;

            eRegressionType regressionType = (eRegressionType)cmbRegT.SelectedIndex;

            if (regressionType==eRegressionType.Quadratic)
            {
                chk1x.Visible = true;
                chk1xsquare.Visible = true;
            }
            else
            {
                chk1x.Visible = false;
                chk1xsquare.Visible = false;
            }
        }
    }
}
