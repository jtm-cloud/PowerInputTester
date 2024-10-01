using CommonHelpers.GuardClauses;
using System;

namespace PowerInputTester.UI.ViewModels.Base
{
    public abstract class ObjectCalculationBase
    {
        public object Difference(object minuend, object subtrahend, Type valueType)
        {
            GuardClause.NullReference(minuend, "minuend");
            GuardClause.NullReference(subtrahend, "subtrahend");
            GuardClause.NullReference(valueType, "valueType");

            if (valueType == typeof(decimal))
            {
                decimal unboxedMinuend = (decimal)Convert.ChangeType(minuend, typeof(decimal));
                decimal unboxedSubtrahend = (decimal)Convert.ChangeType(subtrahend, typeof(decimal));
                return unboxedMinuend - unboxedSubtrahend;
            }
            else if (valueType == typeof(double))
            {
                double unboxedMinuend = (double)Convert.ChangeType(minuend, typeof(double));
                double unboxedSubtrahend = (double)Convert.ChangeType(subtrahend, typeof(double));
                return unboxedMinuend - unboxedSubtrahend;
            }
            else if (valueType == typeof(float))
            {
                float unboxedMinuend = (float)Convert.ChangeType(minuend, typeof(float));
                float unboxedSubtrahend = (float)Convert.ChangeType(subtrahend, typeof(float));
                return unboxedMinuend - unboxedSubtrahend;
            }
            else if (valueType == typeof(int))
            {
                int unboxedMinuend = (int)Convert.ChangeType(minuend, typeof(int));
                int unboxedSubtrahend = (int)Convert.ChangeType(subtrahend, typeof(int));
                return unboxedMinuend - unboxedSubtrahend;
            }
            else if (valueType == typeof(long))
            {
                long unboxedMinuend = (long)Convert.ChangeType(minuend, typeof(long));
                long unboxedSubtrahend = (long)Convert.ChangeType(subtrahend, typeof(long));
                return unboxedMinuend - unboxedSubtrahend;
            }
            else
            {
                throw new NullReferenceException("Unable to resolve object calculation type.");
            }
        }

        public object Sum(object addend1, object addend2, Type valueType)
        {
            GuardClause.NullReference(addend1, "addend1");
            GuardClause.NullReference(addend2, "addend2");
            GuardClause.NullReference(valueType, "valueType");

            if (valueType == typeof(decimal))
            {
                decimal unboxedAddend1 = (decimal)Convert.ChangeType(addend1, typeof(decimal));
                decimal unboxedAddend2 = (decimal)Convert.ChangeType(addend2, typeof(decimal));
                return unboxedAddend1 + unboxedAddend2;
            }
            else if (valueType == typeof(double))
            {
                double unboxedAddend1 = (double)Convert.ChangeType(addend1, typeof(double));
                double unboxedAddend2 = (double)Convert.ChangeType(addend2, typeof(double));
                return unboxedAddend1 + unboxedAddend2;
            }
            else if (valueType == typeof(float))
            {
                float unboxedAddend1 = (float)Convert.ChangeType(addend1, typeof(float));
                float unboxedAddend2 = (float)Convert.ChangeType(addend2, typeof(float));
                return unboxedAddend1 + unboxedAddend2;
            }
            else if (valueType == typeof(int))
            {
                int unboxedAddend1 = (int)Convert.ChangeType(addend1, typeof(int));
                int unboxedAddend2 = (int)Convert.ChangeType(addend2, typeof(int));
                return unboxedAddend1 + unboxedAddend2;
            }
            else if (valueType == typeof(long))
            {
                long unboxedAddend1 = (long)Convert.ChangeType(addend1, typeof(long));
                long unboxedAddend2 = (long)Convert.ChangeType(addend2, typeof(long));
                return unboxedAddend1 + unboxedAddend2;
            }
            else
            {
                throw new NullReferenceException("Unable to resolve object calculation type.");
            }
        }
    }
}
