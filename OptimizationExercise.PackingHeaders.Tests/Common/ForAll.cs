using OptimizationExercise.PackingHeaders.ArrayImpl;
using OptimizationExercise.PackingHeaders.Common;
using OptimizationExercise.PackingHeaders.DictionaryImpl;
using OptimizationExercise.PackingHeaders.FieldsImpl;
using OptimizationExercise.PackingHeaders.PackedImpl;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace OptimizationExercise.PackingHeaders.Tests.Common
{
    internal static class ForAll
    {
        private static readonly Type[] AllTypes = typeof(ForAll).Assembly.GetTypes();
        private static readonly ConcurrentDictionary<(string File, string Member, string Hint), Delegate[]> Cache = new ConcurrentDictionary<(string File, string Member, string Hint), Delegate[]>();

        private static readonly Type[][] TypeParams =
            new[]
            {
                new[]{typeof(DictionaryHeaders), typeof(Dictionary<HeaderNames, string>.KeyCollection.Enumerator)},
                new[]{typeof(FieldHeaders_V1), typeof(FieldHeaders_V1.Enumerator)},
                new[]{typeof(FieldHeaders_V2), typeof(FieldHeaders_V2.Enumerator)},
                new[]{typeof(ArrayHeaders_V1), typeof(ArrayHeaders_V1.Enumerator)},
                new[]{typeof(ArrayHeaders_V2), typeof(ArrayHeaders_V2.Enumerator)},
                new[]{typeof(PackedHeaders_V1), typeof(PackedHeaders_V1.Enumerator)},
                new[]{typeof(PackedHeaders_V2), typeof(PackedHeaders_V2.Enumerator)},
                new[]{typeof(PackedHeaders_V3), typeof(PackedHeaders_V3.Enumerator)},
                new[]{typeof(PackedHeaders_V4), typeof(PackedHeaders_V4.Enumerator)},
            };

        internal static void RunForAll(
            Func<string> hintDel,
            [CallerFilePath] string? file = null,
            [CallerMemberName] string? member = null
        )
        {
            file = file ?? throw new ArgumentNullException(nameof(file));
            member = member ?? throw new ArgumentNullException(nameof(member));
            var hint = hintDel();

            RunForAll(Array.Empty<object>(), file, member, hint);
        }

        internal static void RunForAll(
            Func<string> hintDel,
            object p0,
            [CallerFilePath] string? file = null,
            [CallerMemberName] string? member = null
        )
        {
            file = file ?? throw new ArgumentNullException(nameof(file));
            member = member ?? throw new ArgumentNullException(nameof(member));
            var hint = hintDel();

            RunForAll(new object[] { p0 }, file, member, hint);
        }

        private static void RunForAll(object[] ps, string file, string member, string hint)
        {
            var dels = FindRunMethodFor(file, member, hint);
            foreach (var del in dels)
            {
                del.DynamicInvoke(ps);
            }

            static Delegate[] FindRunMethodFor(string file, string member, string hint)
            {
                if (Cache.TryGetValue((file, member, hint), out var built))
                {
                    return built;
                }

                var className = Path.GetFileNameWithoutExtension(file);
                var type = AllTypes.Where(x => x.Name == className).SingleOrDefault();
                if (type == null)
                {
                    throw new InvalidOperationException($"Couldn't find class for file [{file}]");
                }

                var runMtd =
                    type
                        .GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
                        .Where(x => x.Name.Contains(member) && x.Name.Contains(hint) && x.IsGenericMethodDefinition && x.GetGenericArguments().Length == 2)
                        .SingleOrDefault();
                if (runMtd == null)
                {
                    throw new InvalidOperationException($"Couldn't find static local method corresponding to [{member}] in type [{type.FullName}]");
                }

                var ret = new Delegate[TypeParams.Length];
                for (var i = 0; i < ret.Length; i++)
                {
                    var bound = runMtd.MakeGenericMethod(TypeParams[i]);

                    var delType = GetDelegateType(runMtd);

                    ret[i] = Delegate.CreateDelegate(delType, bound);
                }

                Cache[(file, member, hint)] = ret;

                return ret;

                static Type GetDelegateType(MethodInfo mtd)
                {
                    var ps = mtd.GetParameters();
                    switch (ps.Length)
                    {
                        case 0: return typeof(Action);
                        case 1: return typeof(Action<>).MakeGenericType(ps[0].ParameterType);
                        case 2: return typeof(Action<>).MakeGenericType(ps[0].ParameterType, ps[1].ParameterType);
                        case 3: return typeof(Action<>).MakeGenericType(ps[0].ParameterType, ps[1].ParameterType, ps[2].ParameterType);
                        default: throw new NotImplementedException();
                    }
                }
            }
        }
    }
}
