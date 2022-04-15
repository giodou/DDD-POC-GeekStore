using System.Text.RegularExpressions;

namespace GeekStore.Core.DomainObjects
{
    public class Validations
    {
        public static void ValidateIfEquals(object objct1, object object2, string message)
        {
            if (!objct1.Equals(object2))
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfDifferent(object objct1, object object2, string message)
        {
            if (objct1.Equals(object2))
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateCharacters(string value, int maximum, string message)
        {
            var length = value.Trim().Length;
            if (length > maximum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateCharacters(string value, int minimum, int maximum, string message)
        {
            var length = value.Trim().Length;
            if (length > maximum || length < minimum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateExpression(string pattern, string value, string message)
        {
            var regex = new Regex(pattern);

            if (!regex.IsMatch(value))
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfEmpty(string value, string message)
        {
            
            if (value == null || value.Trim().Length == 0)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfNull(string value, string message)
        {

            if (value == null)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateMinimumMaximum(double value, double minimum, double maximum, string message)
        {

            if (value < minimum || value > maximum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateMinimumMaximum(float value, float minimum, float maximum, string message)
        {

            if (value < minimum || value > maximum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateMinimumMaximum(int value, int minimum, int maximum, string message)
        {

            if (value < minimum || value > maximum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateMinimumMaximum(long value, long minimum, long maximum, string message)
        {

            if (value < minimum || value > maximum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateMinimumMaximum(decimal value, decimal minimum, decimal maximum, string message)
        {

            if (value < minimum || value > maximum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfSmallerEqualsMinimum(float value, float minimum, string message)
        {

            if (value <= minimum)
            {
                throw new DomainException(message);
            }
        }
        public static void ValidateIfSmallerEqualsMinimum(double value, double minimum, string message)
        {

            if (value <= minimum)
            {
                throw new DomainException(message);
            }
        }
        public static void ValidateIfSmallerEqualsMinimum(decimal value, decimal minimum, string message)
        {

            if (value <= minimum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfSmallerEqualsMinimum(int value, int minimum, string message)
        {

            if (value <= minimum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfSmallerEqualsMinimum(long value, long minimum, string message)
        {

            if (value <= minimum)
            {
                throw new DomainException(message);
            }
        }
        

        public static void ValidateIfBiggerEqualsMaximum(int value, int maximum, string message)
        {

            if (value >= maximum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfBiggerEqualsMaximum(float value, float maximum, string message)
        {

            if (value >= maximum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfBiggerEqualsMaximum(double value, double maximum, string message)
        {

            if (value >= maximum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfBiggerEqualsMaximum(decimal value, decimal maximum, string message)
        {

            if (value >= maximum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfBiggerEqualsMaximum(long value, long maximum, string message)
        {

            if (value >= maximum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfFalse(bool value, string message)
        {
            if (value)
                throw new DomainException(message);
        }

        public static void ValidateIfTrue(bool value, string message)
        {
            if (!value)
                throw new DomainException(message);
        }
    }
}
