using OptimizationExercise.PackingHeaders.Common;
using OptimizationExercise.PackingHeaders.Tests.Common;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Xunit;

namespace OptimizationExercise.PackingHeaders.Tests
{
    public class EnumeratorTests
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
                var read = ImmutableList.CreateBuilder<HeaderNames>();
                foreach (var item in store)
                {
                    read.Add(item);
                }

                Assert.Empty(read.ToImmutable());
            }
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(Constants.MaximumSetHeaders / 2)]
        [InlineData(Constants.MaximumSetHeaders - 1)]
        [InlineData(Constants.MaximumSetHeaders)]
        public void Basic(int numHeaders)
        {
            var rand = new Random(2022_06_04);

            var all = Enum.GetValues<HeaderNames>().ToImmutableList();
            for (var i = 0; i < 1_000; i++)
            {
                var available = all.ToList();
                var builder = ImmutableList.CreateBuilder<HeaderNames>();
                for (var j = 0; j < numHeaders; j++)
                {
                    var ix = rand.Next(available.Count);
                    builder.Add(available[ix]);
                    available.RemoveAt(ix);
                }

                var use = builder.ToImmutable();
                ForAll.RunForAll(static () => nameof(RunTest), use);
            }

            static void RunTest<T, V>(ImmutableList<HeaderNames> headers)
                where T : IHeadersStructure<T, V>
                where V : struct, IEnumerator<HeaderNames>
            {
                var store = T.CreateEmpty();
                var alreadySet = new HashSet<HeaderNames>();
                foreach (var name in headers)
                {
                    store.Set(name, name + "_" + name);
                    alreadySet.Add(name);

                    var readItems = new HashSet<HeaderNames>();
                    foreach (var readName in store)
                    {
                        Assert.Contains(readName, headers);
                        Assert.True(readItems.Add(readName));
                    }

                    Assert.Equal(alreadySet.Count, readItems.Count);
                }
            }
        }
    }
}
