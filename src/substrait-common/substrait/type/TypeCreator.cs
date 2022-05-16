using System;
namespace substrait.type
{
	public class TypeCreator
	{
        public static readonly TypeCreator REQUIRED = new TypeCreator(false);
        public static readonly TypeCreator NULLABLE = new TypeCreator(true);

        protected readonly bool nullable;
        public readonly IType BOOLEAN;
        public readonly IType I8;
        public readonly IType I16;
        public readonly IType I32;
        public readonly IType I64;
        public readonly IType FP32;
        public readonly IType FP64;
        public readonly IType STRING;
        public readonly IType BINARY;
        public readonly IType TIMESTAMP;
        public readonly IType TIMESTAMP_TZ;
        public readonly IType DATE;
        public readonly IType TIME;
        public readonly IType INTERVAL_DAY;
        public readonly IType INTERVAL_YEAR;
        public readonly IType UUID;


        protected TypeCreator(bool nullable)
        {
            this.nullable = nullable;
            BOOLEAN = new IType.Bool(nullable);
            //I8 = IType.I8.builder().nullable(nullable).build();
            //I16 = IType.I16.builder().nullable(nullable).build();
            //I32 = IType.I32.builder().nullable(nullable).build();
            //I64 = IType.I64.builder().nullable(nullable).build();
            //FP32 = IType.FP32.builder().nullable(nullable).build();
            //FP64 = IType.FP64.builder().nullable(nullable).build();
            //STRING = IType.Str.builder().nullable(nullable).build();
            //BINARY = IType.Binary.builder().nullable(nullable).build();
            //TIMESTAMP = IType.Timestamp.builder().nullable(nullable).build();
            //TIMESTAMP_TZ = IType.TimestampTZ.builder().nullable(nullable).build();
            //DATE = IType.Date.builder().nullable(nullable).build();
            //TIME = IType.Time.builder().nullable(nullable).build();
            //INTERVAL_DAY = IType.IntervalDay.builder().nullable(nullable).build();
            //INTERVAL_YEAR = IType.IntervalYear.builder().nullable(nullable).build();
            //UUID = IType.UUID.builder().nullable(nullable).build();
        }

        public IType fixedChar(int len)
        {
            return IType.FixedChar.builder().nullable(nullable).length(len).build();
        }

        public sealed IType varChar(int len)
        {
            return IType.VarChar.builder().nullable(nullable).length(len).build();
        }

        public sealed IType fixedBinary(int len)
        {
            return IType.FixedBinary.builder().nullable(nullable).length(len).build();
        }

        public sealed IType decimal (int precision, int scale) {
            return IType.Decimal.builder().nullable(nullable).precision(precision).scale(scale).build();
        }

        public sealed IType.Struct struct(Type...types) {
            return IType.Struct.builder().nullable(nullable).addFields(types).build();
        }

        public IType.Struct struct(Iterable <? extends IType > ITypes) {
            return IType.Struct.builder().nullable(nullable).addAllFields(types).build();
        }

        public IType.Struct struct(Stream <? extends IType > ITypes) {
            return IType.Struct.builder()
                .nullable(nullable)
                .addAllFields(types.collect(Collectors.toList()))
                .build();
        }

        public IType list(Type IType)
        {
            return IType.ListType.builder().nullable(nullable).elementType(type).build();
        }

        public IType map(Type key, IType value)
        {
            return IType.Map.builder().nullable(nullable).key(key).value(value).build();
        }

        public static TypeCreator of(boolean nullability)
        {
            return nullability ? NULLABLE : REQUIRED;
        }
	}
}

