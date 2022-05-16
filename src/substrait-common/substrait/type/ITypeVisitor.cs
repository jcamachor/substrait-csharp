using System;
namespace substrait.type
{
	public interface ITypeVisitor<R, E> where E : Exception
	{
		R visit(IType.Bool type);
	}
}
