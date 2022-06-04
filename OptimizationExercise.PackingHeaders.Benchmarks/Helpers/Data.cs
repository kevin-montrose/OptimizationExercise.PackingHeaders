using OptimizationExercise.PackingHeaders.ArrayImpl;
using OptimizationExercise.PackingHeaders.Common;
using OptimizationExercise.PackingHeaders.DictionaryImpl;
using OptimizationExercise.PackingHeaders.FieldsImpl;
using OptimizationExercise.PackingHeaders.PackedImpl;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace OptimizationExercise.PackingHeaders.Benchmarks.Helpers
{
    internal static class Data
    {
        internal static readonly ImmutableArray<HeaderNames> AllHeaders = Enum.GetValues<HeaderNames>().OrderBy(static x => x).ToImmutableArray();

        private static Dictionary<HeaderNames, string> GetHeadersToSet(int numHeaders)
        {
            var rand = new Random(2022_06_04);
            var available = AllHeaders.ToList();

            var sb = new StringBuilder();

            var ret = new Dictionary<HeaderNames, string>(numHeaders);
            for (var i = 0; i < numHeaders; i++)
            {
                var ix = rand.Next(available.Count);
                var header = available[ix];
                available.RemoveAt(ix);

                var valLength = rand.Next(50) + 1;
                for (var j = 0; j < valLength; j++)
                {
                    var c = (char)('A' + (rand.Next(26)));
                    c = rand.Next(2) == 1 ? char.ToLowerInvariant(c) : c;

                    sb.Append(c);
                }
                var val = sb.ToString();
                sb.Clear();

                ret.Add(header, val);
            }

            return ret;
        }

        private static T Populate<T, V>(int numSet)
            where T : IHeadersStructure<T, V>
            where V : struct, IEnumerator<HeaderNames>
        => T.CreateFromDictionary(GetHeadersToSet(numSet));

        internal static IEnumerable<T> ChooseNumberFrom<T>(ICollection<T> from, int num)
        {
            if (num < 0 || num > from.Count)
            {
                throw new ArgumentException();
            }

            var rand = new Random(2022_06_04);
            var ixs = Enumerable.Range(0, from.Count).ToList();

            for (var i = 0; i < num; i++)
            {
                var ix = rand.Next(ixs.Count);
                var itemIx = ixs[ix];
                ixs.RemoveAt(ix);

                yield return from.ElementAt(itemIx);
            }
        }

        internal static IEnumerable<T> Shuffle<T>(IEnumerable<T> e)
        {
            var rand = new Random(2022_06_04);

        tryAgain:
            var ret = e.Select(i => (Item: i, Order: rand.Next())).OrderBy(static t => t.Order).Select(static t => t.Item).ToList();

            if (ret.Count > 2 && e.First() is IComparable<T>)
            {
                // make sure we don't return in order (either forward or backwards
                var inOrder = e.OrderBy(static x => x).ToArray();
                var reversed = e.OrderByDescending(static x => x).ToArray();
                if (inOrder.SequenceEqual(ret) || reversed.SequenceEqual(ret))
                {
                    goto tryAgain;
                }
            }

            return ret;
        }

        internal static ImmutableArray<HeaderNames> PopulateAll(
            int numHeaders,
            ref DictionaryHeaders dict,
            ref FieldHeaders_V1 fieldV1,
            ref FieldHeaders_V2 fieldV2,
            ref ArrayHeaders_V1 arrayV1,
            ref ArrayHeaders_V2 arrayV2,
            ref PackedHeaders_V1 packedV1,
            ref PackedHeaders_V2 packedV2,
            ref PackedHeaders_V3 packedV3,
            ref PackedHeaders_V4 packedV4
        )
        {
            dict = Populate<DictionaryHeaders, Dictionary<HeaderNames, string>.KeyCollection.Enumerator>(numHeaders);
            fieldV1 = Populate<FieldHeaders_V1, FieldHeaders_V1.Enumerator>(numHeaders);
            fieldV2 = Populate<FieldHeaders_V2, FieldHeaders_V2.Enumerator>(numHeaders);
            arrayV1 = Populate<ArrayHeaders_V1, ArrayHeaders_V1.Enumerator>(numHeaders);
            arrayV2 = Populate<ArrayHeaders_V2, ArrayHeaders_V2.Enumerator>(numHeaders);
            packedV1 = Populate<PackedHeaders_V1, PackedHeaders_V1.Enumerator>(numHeaders);
            packedV2 = Populate<PackedHeaders_V2, PackedHeaders_V2.Enumerator>(numHeaders);
            packedV3 = Populate<PackedHeaders_V3, PackedHeaders_V3.Enumerator>(numHeaders);
            packedV4 = Populate<PackedHeaders_V4, PackedHeaders_V4.Enumerator>(numHeaders);

            var ret = ImmutableArray.CreateBuilder<HeaderNames>(numHeaders);
            foreach (var x in dict)
            {
                ret.Add(x);
            }

            return ret.ToImmutable();
        }
    }
}
