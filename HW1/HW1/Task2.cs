using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    public class UpgradedBank : SimpleBank
    {
        public override void MakeDeposit(double depositAmount)
        {
            base.MakeDeposit(depositAmount);
            _totalSum += 15;
        }
    }
}
