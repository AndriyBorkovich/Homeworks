namespace HW1
{
    public class SimpleBank
    {
        protected double _totalSum;
        public virtual void MakeDeposit(double depositAmount)
        {
            if (depositAmount < 0)
            {
                throw new ArgumentException("Deposit amount can't be less than zero");
            }
            else
            {
                if (depositAmount < 100)
                {
                    _totalSum = depositAmount + (depositAmount * 0.05);
                }
                else if (depositAmount >= 100 && depositAmount <= 200)
                {
                    _totalSum = depositAmount + (depositAmount * 0.07);
                }
                else
                {
                    _totalSum = depositAmount + (depositAmount * 0.1);
                }
            }
        }

        public override string ToString()
        {
            return $"Total amount of money: {_totalSum} UAH";
        }
    }
}
