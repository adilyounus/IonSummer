using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IonSummer.Models
{
    public enum eRegressionType
    {
        Linear = 0,
        Linear_Through_Zero = 1,
        Quadratic = 2
    }
    public class ReverseCalculationMasterModel
    {
        public string ID { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Components { get; set; }
        public eRegressionType RegressionType { get; set; }
        //public List<ReverseCalculationModel> lstData { get; set; }
    }
    public class ReverseCalculationModel
    {
        public string SampleName { get; set; }
        public string SampleType { get; set; }
        public DateTime AcquisitionDateTime { get; set; }
        public string ComponentName { get; set; }
        public double CalculatedConcentration { get; set; }
        public double CalculatedConcentration_Positive { get; set; }
        public double CalculatedConcentration_Negative { get; set; }
        public double Area { get; set; }
        public double ActualConcentration { get; set; }
    }

    public class ReverseCalculationLinearModel
    {
        [DisplayName("Sample Name")]
        public string SampleName { get; set; }
        [DisplayName("Sample Type")]
        public string SampleType { get; set; }
        [DisplayName("Acquisition Date/Time")]
        public DateTime AcquisitionDateTime { get; set; }
        [DisplayName("Component Name")]
        public string ComponentName { get; set; }
        [DisplayName("Calculated Concentration")]
        public double CalculatedConcentration { get; set; }
        [DisplayName("Area")]
        public double Area { get; set; }

        public string h_Equation { get; set; }
        public string h_EquationType { get; set; }
        public string h_RSquared { get; set; }
        public string h_ActualConcentration { get; set; }
    }
    public class ReverseCalculationPolinomialModel
    {
        [DisplayName("Sample Name")]
        public string SampleName { get; set; }
        [DisplayName("Sample Type")]
        public string SampleType { get; set; }
        [DisplayName("Acquisition Date/Time")]
        public DateTime AcquisitionDateTime { get; set; }
        [DisplayName("Component Name")]
        public string ComponentName { get; set; }
        [DisplayName("Calculated Concentration +")]
        public double CalculatedConcentration_Positive { get; set; }
        //[DisplayName("Calculated Concentration -")]
        //public double CalculatedConcentration_Negative { get; set; }
        [DisplayName("Area")]
        public double Area { get; set; }

        public string h_Equation { get; set; }
        public string h_EquationType { get; set; }
        public string h_RSquared { get; set; }
        public string h_ActualConcentration { get; set; }

    }
}
