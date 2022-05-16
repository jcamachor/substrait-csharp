namespace substrait.type
{
    public interface IType : ITypeExpression, IParameterizedType, INullableType
	{
		public static readonly TypeCreator REQUIRED = TypeCreator.REQUIRED;
		public static readonly TypeCreator NULLABLE = TypeCreator.NULLABLE;

		public static TypeCreator withNullability(bool nullable)
		{
			return nullable ? TypeCreator.NULLABLE : TypeCreator.REQUIRED;
        }

        R accept<R, E>(ITypeVisitor<R, E> typeVisitor) where E : Exception;

        public class Bool : IType
        {
            public Bool(bool nullable)
            {
                Nullable = nullable;
            }

            public bool Nullable { get; }

            public R accept<R, E>(ITypeVisitor<R, E> typeVisitor) where E : Exception
            {
            	return typeVisitor.visit(this);
            }
        }
    }

}

