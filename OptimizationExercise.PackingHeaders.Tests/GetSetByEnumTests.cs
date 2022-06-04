using OptimizationExercise.PackingHeaders.Common;
using OptimizationExercise.PackingHeaders.Tests.Common;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Xunit;

namespace OptimizationExercise.PackingHeaders.Tests
{
    public class GetSetByEnumTests
    {
        [Fact]
        public void Empty()
        {
            ForAll.RunForAll(static () => nameof(RunTest));

            static void RunTest<T, V>()
                where T : IHeadersStructure<T, V>
                where V : struct, IEnumerator<HeaderNames>
            {
                var store = T.CreateEmpty();

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
                where T: IHeadersStructure<T, V>
                where V: struct, IEnumerator<HeaderNames>
            {
                foreach(var name in Enum.GetValues<HeaderNames>())
                {
                    var val = name.ToString();

                    var store = T.CreateEmpty();
                    Assert.False(store.TryGetValue(name, out _));

                    store.Set(name, val);

                    Assert.True(store.TryGetValue(name, out string? read));
                    Assert.Same(val, read);
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
                for(var iter = 0; iter < 5_000; iter++)
                {
                    var available = allHeaders.ToList();
                    var toUseBuilder = ImmutableList.CreateBuilder<HeaderNames>();
                    while(toUseBuilder.Count < numToSet)
                    {
                        var ix = rand.Next(available.Count);
                        toUseBuilder.Add(available[ix]);
                        available.RemoveAt(ix);
                    }

                    var toUse = toUseBuilder.ToImmutable();

                    ForAll.RunForAll(static () => nameof(RunTest), toUse);
                }
            }

            static void RunTest<T, V>(ImmutableList<HeaderNames> toSet)
                where T : IHeadersStructure<T, V>
                where V : struct, IEnumerator<HeaderNames>
            {
                var store = T.CreateEmpty();

                for(var i = 0; i < toSet.Count; i++)
                {
                    store.Set(toSet[i], toSet[i].ToString());
                    for(var j = 0; j <= i; j++)
                    {
                        Assert.True(store.TryGetValue(toSet[j], out string? value));
                        Assert.Equal(toSet[j].ToString(), value);
                    }
                }
            }
        }

        [Fact]
        public void ExplodesAfterMax()
        {
            var tooMany = Enum.GetValues<HeaderNames>().Take(Constants.MaximumSetHeaders + 1).ToImmutableArray();

            ForAll.RunForAll(static () => nameof(RunTest), tooMany);

            static void RunTest<T, V>(ImmutableArray<HeaderNames> toSet)
                where T : IHeadersStructure<T, V>
                where V : struct, IEnumerator<HeaderNames>
            {
                var store = T.CreateEmpty();
                for (var i = 0; i < toSet.Length - 1; i++)
                {
                    store.Set(toSet[i], toSet[i].ToString());
                }

                Assert.Throws<InvalidOperationException>(() => store.Set(toSet[^1], "Should explode"));
            }
        }

        [Fact]
        public void ExplodesWhenSetTwice()
        {
            ForAll.RunForAll(static () => nameof(RunTest));

            static void RunTest<T, V>()
                where T : IHeadersStructure<T, V>
                where V : struct, IEnumerator<HeaderNames>
            {
                foreach (var name in Enum.GetValues<HeaderNames>())
                {
                    var store = T.CreateEmpty();

                    store.Set(name, name.ToString());

                    Assert.Throws<ArgumentException>(() => store.Set(name, "2"));
                }
            }
        }
    }
}