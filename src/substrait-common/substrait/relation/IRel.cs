using System.Collections.Generic;
using substrait.type;

namespace substrait.relation
{
    public interface IRel
    {
        Remap OutputMap { get; }

        IType.Struct getRecordType();

        List<IRel> Inputs { get; }

        //<O, E extends Exception> O accept(RelVisitor<O, E> visitor) throws E;
    }

    public abstract class Remap
    {
        public abstract List<int> indices();

        public IType.Struct remap(IType.Struct initial)
        {
            List<IType> types = initial.fields();
            return TypeCreator.of(initial.nullable()).struct(indices().stream().map(i -> types.get(i)));
        }

        public static Remap of(Iterable<Integer> fields)
        {
            return ImmutableRemap.builder().addAllIndices(fields).build();
        }

        public static Remap offset(int start, int length)
        {
            return of(IntStream.range(start, start + length).mapToObj(i->i).toList());
        }
    }
}

