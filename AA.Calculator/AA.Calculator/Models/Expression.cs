namespace AA.Calculator.Models
{
    public class Expression
    {
        public float OperandL { get; set; }
        public float OperandR { get; set; }
        public Operator Operator { get; set; }
        public override string ToString()
        {
            return $"{OperandL} {(char)Operator} {OperandR}";
        }
    }
}
