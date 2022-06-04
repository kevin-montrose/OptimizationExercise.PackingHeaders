using OptimizationExercise.PackingHeaders.Common;
using OptimizationExercise.PackingHeaders.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace OptimizationExercise.PackingHeaders.Tests
{
    public class FromDictionaryTests
    {
        [Fact]
        public void Empty()
        {
            var dict = new Dictionary<HeaderNames, string>();

            ForAll.RunForAll(static () => nameof(RunTest), dict);

            static void RunTest<T, V>(Dictionary<HeaderNames, string> dict)
                where T : IHeadersStructure<T, V>
                where V : struct, IEnumerator<HeaderNames>
            {
                var store = T.CreateFromDictionary(dict);

                foreach (var name in Enum.GetValues<HeaderNames>())
                {
                    Assert.False(store.TryGetValue(name, out _));
                }
            }
        }

        [Fact]
        public void SingleHeader()
        {
            ForAll.RunForAll(static () => nameof(RunTest));

            static void RunTest<T, V>()
                where T : IHeadersStructure<T, V>
                where V : struct, IEnumerator<HeaderNames>
            {
                foreach (var name in Enum.GetValues<HeaderNames>())
                {
                    var dict = new Dictionary<HeaderNames, string>();
                    var value = name.ToString();

                    dict[name] = value;

                    var x = T.CreateFromDictionary(dict);

                    Assert.True(x.TryGetValue(name, out var read));
                    Assert.Same(value, read);
                }
            }
        }

        [Fact]
        public void SeveralHeaders()
        {
            var rand = new Random(2022_06_03);
            var allHeaders = Enum.GetValues<HeaderNames>();

            for (var numToSet = 1; numToSet <= Constants.MaximumSetHeaders; numToSet++)
            {
                for (var iter = 0; iter < 5_000; iter++)
                {
                    var available = allHeaders.ToList();
                    var toUse = new Dictionary<HeaderNames, string>();
                    while (toUse.Count < numToSet)
                    {
                        var ix = rand.Next(available.Count);
                        toUse.Add(available[ix], toUse.Count.ToString());
                        available.RemoveAt(ix);
                    }

                    ForAll.RunForAll(static () => nameof(RunTest), toUse);

                }
            }

            static void RunTest<T, V>(Dictionary<HeaderNames, string> toSet)
                where T : IHeadersStructure<T, V>
                where V : struct, IEnumerator<HeaderNames>
            {
                var store = T.CreateFromDictionary(toSet);

                foreach (var kv in toSet)
                {
                    Assert.True(store.TryGetValue(kv.Key, out var value));
                    Assert.Same(kv.Value, value);
                }
            }
        }

        [Fact]
        public void ExplodeAfterMax()
        {
            var tooMany = Enum.GetValues<HeaderNames>().Take(Constants.MaximumSetHeaders + 1).ToDictionary(t => t, _ => Guid.NewGuid().ToString());

            ForAll.RunForAll(static () => nameof(RunTest), tooMany);

            static void RunTest<T, V>(Dictionary<HeaderNames, string> dict)
                where T : IHeadersStructure<T, V>
                where V : struct, IEnumerator<HeaderNames>
            {
                Assert.Throws<ArgumentException>(() => T.CreateFromDictionary(dict));
            }
        }
    }
}
