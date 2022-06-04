using BenchmarkDotNet.Attributes;
using OptimizationExercise.PackingHeaders.ArrayImpl;
using OptimizationExercise.PackingHeaders.Benchmarks.Helpers;
using OptimizationExercise.PackingHeaders.Common;
using OptimizationExercise.PackingHeaders.DictionaryImpl;
using OptimizationExercise.PackingHeaders.FieldsImpl;
using OptimizationExercise.PackingHeaders.PackedImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace OptimizationExercise.PackingHeaders.Benchmarks.GetBenchmarks
{
    /// <summary>
    /// Benchmarking reading headers by the exposed "names" (ie. properties).
    /// 
    /// Parameterized by the number of headers set, we read the full set of headers.
    /// </summary>
    public class GetDirectlyByNameBenchmark : ImplBenchmarkBase
    {
        // have to pump up iterations until benchmarkdotnet stops complaining
        private const int Iterations = 60_000;

        [ParamsSource(nameof(NumHeadersSet))]
        public int NumHeadersSetParam { get; set; } = int.MaxValue;

        public static IEnumerable<int> NumHeadersSet => Enumerable.Range(0, Constants.MaximumSetHeaders + 1);

        private string?[] StoreInto = Array.Empty<string?>();

        private DictionaryHeaders dict = DictionaryHeaders.CreateEmpty();
        private FieldHeaders_V1 field_v1 = FieldHeaders_V1.CreateEmpty();
        private FieldHeaders_V2 field_v2 = FieldHeaders_V2.CreateEmpty();
        private ArrayHeaders_V1 array_v1 = ArrayHeaders_V1.CreateEmpty();
        private ArrayHeaders_V2 array_v2 = ArrayHeaders_V2.CreateEmpty();
        private PackedHeaders_V1 packed_v1 = PackedHeaders_V1.CreateEmpty();
        private PackedHeaders_V2 packed_v2 = PackedHeaders_V2.CreateEmpty();
        private PackedHeaders_V3 packed_v3 = PackedHeaders_V3.CreateEmpty();
        private PackedHeaders_V4 packed_v4 = PackedHeaders_V4.CreateEmpty();

        [GlobalSetup]
        public override void GlobalSetup()
        {
            var chosenHeaders = Data.PopulateAll(NumHeadersSetParam, ref dict, ref field_v1, ref field_v2, ref array_v1, ref array_v2, ref packed_v1, ref packed_v2, ref packed_v3, ref packed_v4);

            StoreInto = new string[chosenHeaders.Length];
        }

        [Benchmark]
        public override void Dictionary()
        => RunBenchmark<DictionaryHeaders, Dictionary<HeaderNames, string>.KeyCollection.Enumerator>(dict);

        [Benchmark]
        public override void Fields_V1()
        => RunBenchmark<FieldHeaders_V1, FieldHeaders_V1.Enumerator>(field_v1);

        [Benchmark]
        public override void Fields_V2()
        => RunBenchmark<FieldHeaders_V2, FieldHeaders_V2.Enumerator>(field_v2);

        [Benchmark]
        public override void Arrays_V1()
        => RunBenchmark<ArrayHeaders_V1, ArrayHeaders_V1.Enumerator>(array_v1);

        [Benchmark]
        public override void Arrays_V2()
        => RunBenchmark<ArrayHeaders_V2, ArrayHeaders_V2.Enumerator>(array_v2);

        [Benchmark]
        public override void Packed_V1()
        => RunBenchmark<PackedHeaders_V1, PackedHeaders_V1.Enumerator>(packed_v1);

        [Benchmark]
        public override void Packed_V2()
        => RunBenchmark<PackedHeaders_V2, PackedHeaders_V2.Enumerator>(packed_v2);

        [Benchmark]
        public override void Packed_V3()
        => RunBenchmark<PackedHeaders_V3, PackedHeaders_V3.Enumerator>(packed_v3);
        
        [Benchmark]
        public override void Packed_V4()
        => RunBenchmark<PackedHeaders_V4, PackedHeaders_V4.Enumerator>(packed_v4);

        private void RunBenchmark<T, V>(T headers)
            where T : IHeadersStructure<T, V>
            where V : struct, IEnumerator<HeaderNames>
        {
            for (var iter = 0; iter < Iterations; iter++)
            {
                Array.Clear(StoreInto);
                var nextIx = 0;

                StoreIntoNotNull(headers.Aardvark, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Albatross, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Alligator, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Anteater, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Antelope, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Bat, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Beaver, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Bee, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Beetle, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Binturong, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Bird, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Boar, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Buffalo, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Butterfly, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Camel, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Capybara, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Caracal, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Cat, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Cattle, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Chamois, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Chicken, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Chimpanzee, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Chinchilla, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Coati, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Cockroach, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Cormorant, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Cow, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Crab, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Crocodile, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Cuckoo, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Curlew, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Deer, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Dhole, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Dinosaur, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Dog, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Dogfish, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Dolphin, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Donkey, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Dragonfly, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Duck, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Dugong, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Eland, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Elephant, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Elk, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Emu, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Falcon, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Ferret, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Fish, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Fossa, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Fox, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Frog, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Gaur, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Gazelle, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Gecko, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Genet, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Gerbil, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Gnat, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Gnu, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Goat, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Goldfinch, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Goosander, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Gorilla, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Goshawk, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Grasshopper, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Grouse, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Guanaco, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Gull, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Hamster, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Hare, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Hawk, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Hedgehog, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Heron, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Herring, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Hoatzin, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Hoopoe, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Hornet, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Horse, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Hummingbird, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Hyena, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Ibis, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Iguana, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Jackal, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Jaguar, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Jay, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Kingbird, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Kingfisher, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Kinkajou, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Kodkod, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Kookaburra, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Kowari, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Langur, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Lapwing, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Lark, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Lechwe, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Lemur, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Lizard, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Llama, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Locust, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Lyrebird, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Macaque, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Macaw, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Mallard, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Mammoth, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Manatee, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Mandrill, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Marmoset, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Marmot, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Meerkat, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Mink, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Mongoose, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Monkey, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Moose, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Mouse, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Myna, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Narwhal, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Newt, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Nightingale, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Nilgai, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Ocelot, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Octopus, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Okapi, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Olingo, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Opossum, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Ostrich, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Owl, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Ox, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Oyster, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Panda, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Panther, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Peafowl, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Pelican, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Penguin, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Pheasant, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Pig, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Pigeon, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Pika, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Pony, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Porpoise, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Pug, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Quail, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Quetzal, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Rabbit, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Raccoon, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Ram, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Rat, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Reindeer, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Rhea, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Rhinoceros, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Rook, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Salamander, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Sandpiper, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Sardine, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Sassaby, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Seahorse, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Seal, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Serval, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Sheep, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Shrike, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Siamang, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Skink, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Skipper, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Skunk, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Sloth, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Snake, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Spider, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Spoonbill, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Squid, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Squirrel, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Starfish, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Tamarin, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Tapir, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Tarsier, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Termite, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Tiger, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Toad, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Toucan, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Turaco, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Turtle, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Viper, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Vulture, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Wallaby, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Wasp, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Wildebeest, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Wobbegong, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Wolf, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Wolverine, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Wombat, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Woodpecker, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Worm, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Wren, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Yak, ref nextIx, StoreInto);
                StoreIntoNotNull(headers.Zebra, ref nextIx, StoreInto);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            static void StoreIntoNotNull(string? val, ref int nextIx, string?[] into)
            {
                if (val == null)
                {
                    return;
                }

                into[nextIx] = val;
                nextIx++;
            }
        }
    }
}
