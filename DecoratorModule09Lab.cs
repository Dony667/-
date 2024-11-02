using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module08Practice
{
    internal class Program
    {
        public interface IReport
        {
            string Generate();
        }

        public class SalesReport : IReport
        {
            public string Generate()
            {
                return "SalesReport";
            }

        }
        public class UserReport : IReport
        {
            public string Generate()
            {
                return "UserReport";
            }

        }

        public abstract class ReposrtDecorator : IReport
        {
            private IReport report;

            protected ReposrtDecorator(IReport report)
            {
                this.report = report;
            }
            public virtual string Generate()
            {
                return report.Generate();
            }
        }

        public class DateFilterDecorator : ReposrtDecorator
        {
            private DateTime startDate;
            private DateTime endDate;

            public DateFilterDecorator(IReport report, 
                DateTime startDate,
                DateTime endDate) :base(report)
            {
                this.startDate = startDate;
                this.endDate = endDate;
            }

            public override string Generate()
            {
                var data = base.Generate();
                return "Filter from " + startDate + "" + data;
            }
        }



        static void Main(string[] args)
        {
            IReport report = new SalesReport();
            report = new DateFilterDecorator(report, DateTime.Now.AddYears(-1), DateTime.Now);
            report = new DateFilterDecorator(report, DateTime.Now.AddYears(2), DateTime.Now);
        }
    }
}
