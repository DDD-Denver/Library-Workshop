using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryFineManager
{
    public class FinesCalculator
    {
        double finePerDay = 0.25;

        public int GracePeriodInDays
        {
            get { return 2; }
        }

        public double CalculateFine(DateTime dueDate, DateTime dateToCalculateFine)
        {
            double fine = 0;
            double daysOverdue = (dateToCalculateFine - dueDate).Days;

            if (daysOverdue > GracePeriodInDays)
            {
                fine = daysOverdue * finePerDay;
            }
            return fine;
        }
    }
}
