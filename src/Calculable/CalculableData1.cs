namespace Test.Calculable
{
    public class CalculableData1
    {
        private readonly Context context;

        public string Property1 {
            get
            {
                return this.context.GetOrCalculate<string>(PropertyEnum.DB_PROPERTY1);
            }
        }

        public DateTime Property2 {
            get
            {
                return this.context.GetOrCalculate<DateTime>(PropertyEnum.DB_PROPERTY2);
            }
        }

        public CalculableData1(Context context)
        {
            this.context = context;
        }
    }
}