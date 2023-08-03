using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Dynamic;
using System.Reflection;

namespace KLO128.Tests
{
    public static class Assertion
    {
        public static int FloatDecimalsToCheck { get; set; }

        internal static bool IsEnumerable(this Type type)
        {
            return typeof(IEnumerable).IsAssignableFrom(type) && type != typeof(string);
        }

        public static bool AssertObj(object? expected, object? actual, List<PropertyInfo?>? aggregates, string? functionDescription = null, int recLevel = 0)
        {
            if (expected == null || actual == null)
            {
                if (expected == null && actual != null || expected != null && actual == null)
                {
                    AssertObjFail(expected, actual, null, functionDescription);
                }

                return true;
            }

            var expectedType = expected.GetType();

            if (actual.GetType() != typeof(ExpandoObject))
            {
                Assert.AreEqual(expectedType, actual.GetType());
            }

            if (expectedType.IsEnumerable())
            {
                return AssertCollections(expected, actual, aggregates, null, functionDescription, recLevel);
            }

            var props = expected.GetType().GetProperties();

            foreach (var prop in props)
            {
                Type underlyingType;
                if (Nullable.GetUnderlyingType(prop.PropertyType) is Type type)
                {
                    underlyingType = type;
                }
                else
                {
                    underlyingType = prop.PropertyType;
                }

                if (underlyingType.IsEnumerable())
                {
                    if (!AssertCollections(PropGetValue(expected, prop), PropGetValue(actual, prop), aggregates, prop, functionDescription, recLevel))
                    {
                        return false;
                    }
                }
                else if (!underlyingType.IsValueType && !typeof(IComparable).IsAssignableFrom(underlyingType) && underlyingType != typeof(string))
                {
                    if (!(aggregates?.Any(x => x?.PropertyType == prop.PropertyType && x?.Name == prop.Name) ?? false))
                    {
                        continue;
                    }

                    if (!AssertObj(PropGetValue(expected, prop), PropGetValue(actual, prop), aggregates, functionDescription, recLevel + 1))
                    {
                        return false;
                    }
                }
                else if (prop.Name != "LastChange" && prop.Name != "RegistrationDate")
                {
                    var val2 = PropGetValue(actual, prop);

                    if (PropGetValue(expected, prop) is object val1)
                    {
                        if (val1 is IComparable comparable)
                        {
                            if (!AssertComparables(comparable, val2, expected, actual, prop, functionDescription))
                            {
                                return false;
                            }
                        }
                        else if (!val1.Equals(val2))
                        {
                            AssertObjFail(expected, actual, prop, functionDescription);
                            return false;
                        }
                    }
                    else if (val2 != null)
                    {
                        AssertObjFail(expected, actual, prop, functionDescription);
                        return false;
                    }
                }
            }

            return true;
        }

        private static object? PropGetValue(object invoker, PropertyInfo prop)
        {
            if (invoker is IDictionary<string, object?> expando)
            {
                expando.TryGetValue(prop.Name, out var ret);

                return ret;
            }
            else
            {
                return prop.GetValue(invoker);
            }
        }

        private static bool AssertCollections(object? expected, object? actual, List<PropertyInfo?>? aggregates, PropertyInfo? currProperty, string? functionDescription, int recLevel)
        {
            if (currProperty != null && aggregates != null && !aggregates.Any(x => x?.PropertyType == currProperty.PropertyType && x?.Name == currProperty.Name) && recLevel > 0 && (actual is not ICollection collectionTmp || collectionTmp.Count == 0))
            {
                return true;
            }

            if (expected is not IEnumerable collection || actual is not IEnumerable collection2)
            {
                AssertObjFail(expected, actual, currProperty, functionDescription);
                return false;
            }

            var enumerator = collection.GetEnumerator();
            var enumerator2 = collection2.GetEnumerator();
            var i = 0;

            while (enumerator.MoveNext() && enumerator2.MoveNext())
            {
                if (!AssertObj(enumerator.Current, enumerator2.Current, aggregates, functionDescription, recLevel + 1))
                {
                    return false;
                }

                i++;
            }

            var enumeratorNext = enumerator.MoveNext();
            var enumerator2Next = enumerator2.MoveNext();

            if (enumeratorNext || enumerator2Next)
            {
                if (enumeratorNext)
                {
                    Assert.Fail($"Collection counts are not the same... expected less than {i}.");
                }
                else
                {
                    Assert.Fail($"Collection counts are not the same... expected {i}, got more.");
                }

                return false;
            }

            return true;
        }

        private static bool AssertComparables(IComparable comparable, object? val2, object? expected, object? actual, PropertyInfo? currProperty, string? functionDescription)
        {
            if (val2 == null)
            {
                AssertObjFail(comparable, val2, currProperty, functionDescription);
                return false;
            }

            if ((comparable is float || comparable is double || comparable is decimal) && (val2 is float || val2 is double || val2 is decimal || val2 is int || val2 is long || val2 is uint || val2 is ulong))
            {
                var float1 = FloatDecimalsToCheck == 0 ? Math.Floor((double)Convert.ChangeType(comparable, typeof(double))) : Math.Round((double)Convert.ChangeType(comparable, typeof(double)), FloatDecimalsToCheck);
                var float2 = FloatDecimalsToCheck == 0 ? Math.Floor((double)Convert.ChangeType(val2, typeof(double))) : Math.Round((double)Convert.ChangeType(val2, typeof(double)), FloatDecimalsToCheck);

                if (float1.CompareTo(float2) != 0)
                {
                    AssertObjFail(float1, float2, currProperty, functionDescription);
                    return false;
                }
            }
            else if (comparable.CompareTo(Convert.ChangeType(val2, comparable.GetType())) != 0)
            {
                AssertObjFail(comparable, val2, currProperty, functionDescription);
                return false;
            }

            return true;
        }

        public static void AssertStrings(string? expected, string? actual, string? functionDescription = null)
        {
            //fake version for GitHub
            if (!string.Equals(expected?.Trim(), actual?.Trim(), StringComparison.InvariantCultureIgnoreCase))
            {
                AssertFail($"Expected string is not the same as given");
            }

            //if (AssertStringsInner(expected, actual, functionDescription) is string error)
            //{
            //    AssertFail(error);
            //}
        }

        private static void AssertObjFail(object? expected, object? actual, PropertyInfo? property, string? functionDescription)
        {
            AssertFail($"{functionDescription} Failure: Objects are not the same, property: {property?.DeclaringType?.Name ?? "n.a."}, expected: {expected ?? "NULL"}, got: {actual ?? "NULL"}");
        }

        private static void AssertFail(string message)
        {
            Assert.Fail(message);
        }

        private class SortContext
        {
            public object Context { get; set; } = null!;

            public bool Sorted { get; set; }
        }
    }
}
