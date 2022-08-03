using AA.Calculator.CustomExceptions;
using AA.Calculator.Models;

namespace AA.Calculator.Services
{
    public class OperatorsMapper : IMapper<char, Operator>
    {
        public Operator Map(char entity)
        {
            var result = Enum.
                GetValues<Operator>().
                Where(op => Convert.
                        ToChar(op) == entity).
                        FirstOrDefault();

            if (result != 0)
                return result;

            throw new WrongMappingException(entity);
        }
    }


}
