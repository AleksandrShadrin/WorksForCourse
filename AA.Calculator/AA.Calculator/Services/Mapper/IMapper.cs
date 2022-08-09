namespace AA.Calculator.Services.Mapper
{
    public interface IMapper<TSource, TDestination>
    {
        public TDestination Map(TSource entity);
    }
}
