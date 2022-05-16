namespace substrait.type
{
	public interface ITypeExpression
	{
        class RequiredTypeExpressionVisitorException : Exception { }

		R accept<R, E>(ITypeVisitor<R, E> typeVisitor) where E : Exception;

		//public static ITypeExpressionCreator withNullability(boolean nullable)
		//{
		//	return nullable ? TypeExpressionCreator.NULLABLE : TypeExpressionCreator.REQUIRED;
		//}

	}
}

