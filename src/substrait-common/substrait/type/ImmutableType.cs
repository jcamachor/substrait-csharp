using BuilderGenerator;

namespace substrait.type
{
	public class ImmutableType
	{
		private ImmutableType()
		{
		}

	}

    [BuilderFor(typeof(IType.Bool))]
	public partial class ImmutableBool
	{
	}
}

