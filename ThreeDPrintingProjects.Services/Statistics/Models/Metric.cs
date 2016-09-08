using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeDPrintingProjects.Services.Statistics.Models
{
    public class Metric<T>
    {
        public MetricType StatType { get; set; }
        public T Data { get; set; }
    }
}
