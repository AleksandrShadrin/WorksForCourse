namespace AA.Calculator.Services
{
    public interface IMapper<TSource, TDestination>
    {
        public TDestination Map(TSource entity);
    }
}
