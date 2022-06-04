using BenchmarkDotNet.Attributes;
using OptimizationExercise.PackingHeaders.ArrayImpl;
using OptimizationExercise.PackingHeaders.Benchmarks.Helpers;
using OptimizationExercise.PackingHeaders.Common;
using OptimizationExercise.PackingHeaders.DictionaryImpl;
using OptimizationExercise.PackingHeaders.FieldsImpl;
using OptimizationExercise.PackingHeaders.PackedImpl;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace OptimizationExercise.PackingHeaders.Benchmarks.SetBenchmarks
{
    [MemoryDiagnoser]
    public class SetDirectlyByNameBenchmark : ImplBenchmarkBase
    {
        public record Parameters(string Order, int NumHeaders)
        {
            public override string ToString()
            => $"{NumHeaders:00}, {Order}";
        }

        // have to pump up iterations until benchmarkdotnet stops complaining
        private const int Iterations = 1_000;

        [ParamsSource(nameof(GetOrderAndCount))]
        public Parameters OrderAndCount { get; set; } = new Parameters("", int.MaxValue);

        public static IEnumerable<int> NumHeadersSet => Enumerable.Range(1, Constants.MaximumSetHeaders);

        private (HeaderNames Header, string Value)[] ToSet = Array.Empty<(HeaderNames Header, string Value)>();

        [GlobalSetup]
        public override void GlobalSetup()
        {
            var chosen = Data.ChooseNumberFrom(Data.AllHeaders, OrderAndCount.NumHeaders).ToImmutableArray();
            var withValues = chosen.Select(t => (Header: t, Value: t + "_value")).ToImmutableArray();

            switch (OrderAndCount.Order)
            {
                case "Ordered": ToSet = withValues.OrderBy(static x => x.Header).ToArray(); break;
                case "Random": ToSet = Data.Shuffle(withValues).ToArray(); break;
                case "Reversed": ToSet = withValues.OrderByDescending(static x => x.Header).ToArray(); break;
                default: throw new InvalidOperationException();
            }
        }

        [Benchmark]
        public override void Dictionary()
        => RunBenchmark<DictionaryHeaders, Dictionary<HeaderNames, string>.KeyCollection.Enumerator>();

        [Benchmark]
        public override void Fields_V1()
        => RunBenchmark<FieldHeaders_V1, FieldHeaders_V1.Enumerator>();

        [Benchmark]
        public override void Fields_V2()
        => RunBenchmark<FieldHeaders_V2, FieldHeaders_V2.Enumerator>();

        [Benchmark]
        public override void Arrays_V1()
        => RunBenchmark<ArrayHeaders_V1, ArrayHeaders_V1.Enumerator>();

        [Benchmark]
        public override void Arrays_V2()
        => RunBenchmark<ArrayHeaders_V2, ArrayHeaders_V2.Enumerator>();

        [Benchmark]
        public override void Packed_V1()
        => RunBenchmark<PackedHeaders_V1, PackedHeaders_V1.Enumerator>();

        [Benchmark]
        public override void Packed_V2()
        => RunBenchmark<PackedHeaders_V2, PackedHeaders_V2.Enumerator>();

        [Benchmark]
        public override void Packed_V3()
        => RunBenchmark<PackedHeaders_V3, PackedHeaders_V3.Enumerator>();

        [Benchmark]
        public override void Packed_V4()
        => RunBenchmark<PackedHeaders_V4, PackedHeaders_V4.Enumerator>();

        private void RunBenchmark<T, V>()
            where T : IHeadersStructure<T, V>
            where V : struct, IEnumerator<HeaderNames>
        {
            for (var iter = 0; iter < Iterations; iter++)
            {
                var headers = T.CreateEmpty();
                foreach (var kv in ToSet)
                {
                    var header = kv.Header;
                    var value = kv.Value;
                    switch (header)
                    {
                        case HeaderNames.Aardvark: headers.Aardvark = value; break;
                        case HeaderNames.Albatross: headers.Albatross = value; break;
                        case HeaderNames.Alligator: headers.Alligator = value; break;
                        case HeaderNames.Anteater: headers.Anteater = value; break;
                        case HeaderNames.Antelope: headers.Antelope = value; break;
                        case HeaderNames.Bat: headers.Bat = value; break;
                        case HeaderNames.Beaver: headers.Beaver = value; break;
                        case HeaderNames.Bee: headers.Bee = value; break;
                        case HeaderNames.Beetle: headers.Beetle = value; break;
                        case HeaderNames.Binturong: headers.Binturong = value; break;
                        case HeaderNames.Bird: headers.Bird = value; break;
                        case HeaderNames.Boar: headers.Boar = value; break;
                        case HeaderNames.Buffalo: headers.Buffalo = value; break;
                        case HeaderNames.Butterfly: headers.Butterfly = value; break;
                        case HeaderNames.Camel: headers.Camel = value; break;
                        case HeaderNames.Capybara: headers.Capybara = value; break;
                        case HeaderNames.Caracal: headers.Caracal = value; break;
                        case HeaderNames.Cat: headers.Cat = value; break;
                        case HeaderNames.Cattle: headers.Cattle = value; break;
                        case HeaderNames.Chamois: headers.Chamois = value; break;
                        case HeaderNames.Chicken: headers.Chicken = value; break;
                        case HeaderNames.Chimpanzee: headers.Chimpanzee = value; break;
                        case HeaderNames.Chinchilla: headers.Chinchilla = value; break;
                        case HeaderNames.Coati: headers.Coati = value; break;
                        case HeaderNames.Cockroach: headers.Cockroach = value; break;
                        case HeaderNames.Cormorant: headers.Cormorant = value; break;
                        case HeaderNames.Cow: headers.Cow = value; break;
                        case HeaderNames.Crab: headers.Crab = value; break;
                        case HeaderNames.Crocodile: headers.Crocodile = value; break;
                        case HeaderNames.Cuckoo: headers.Cuckoo = value; break;
                        case HeaderNames.Curlew: headers.Curlew = value; break;
                        case HeaderNames.Deer: headers.Deer = value; break;
                        case HeaderNames.Dhole: headers.Dhole = value; break;
                        case HeaderNames.Dinosaur: headers.Dinosaur = value; break;
                        case HeaderNames.Dog: headers.Dog = value; break;
                        case HeaderNames.Dogfish: headers.Dogfish = value; break;
                        case HeaderNames.Dolphin: headers.Dolphin = value; break;
                        case HeaderNames.Donkey: headers.Donkey = value; break;
                        case HeaderNames.Dragonfly: headers.Dragonfly = value; break;
                        case HeaderNames.Duck: headers.Duck = value; break;
                        case HeaderNames.Dugong: headers.Dugong = value; break;
                        case HeaderNames.Eland: headers.Eland = value; break;
                        case HeaderNames.Elephant: headers.Elephant = value; break;
                        case HeaderNames.Elk: headers.Elk = value; break;
                        case HeaderNames.Emu: headers.Emu = value; break;
                        case HeaderNames.Falcon: headers.Falcon = value; break;
                        case HeaderNames.Ferret: headers.Ferret = value; break;
                        case HeaderNames.Fish: headers.Fish = value; break;
                        case HeaderNames.Fossa: headers.Fossa = value; break;
                        case HeaderNames.Fox: headers.Fox = value; break;
                        case HeaderNames.Frog: headers.Frog = value; break;
                        case HeaderNames.Gaur: headers.Gaur = value; break;
                        case HeaderNames.Gazelle: headers.Gazelle = value; break;
                        case HeaderNames.Gecko: headers.Gecko = value; break;
                        case HeaderNames.Genet: headers.Genet = value; break;
                        case HeaderNames.Gerbil: headers.Gerbil = value; break;
                        case HeaderNames.Gnat: headers.Gnat = value; break;
                        case HeaderNames.Gnu: headers.Gnu = value; break;
                        case HeaderNames.Goat: headers.Goat = value; break;
                        case HeaderNames.Goldfinch: headers.Goldfinch = value; break;
                        case HeaderNames.Goosander: headers.Goosander = value; break;
                        case HeaderNames.Gorilla: headers.Gorilla = value; break;
                        case HeaderNames.Goshawk: headers.Goshawk = value; break;
                        case HeaderNames.Grasshopper: headers.Grasshopper = value; break;
                        case HeaderNames.Grouse: headers.Grouse = value; break;
                        case HeaderNames.Guanaco: headers.Guanaco = value; break;
                        case HeaderNames.Gull: headers.Gull = value; break;
                        case HeaderNames.Hamster: headers.Hamster = value; break;
                        case HeaderNames.Hare: headers.Hare = value; break;
                        case HeaderNames.Hawk: headers.Hawk = value; break;
                        case HeaderNames.Hedgehog: headers.Hedgehog = value; break;
                        case HeaderNames.Heron: headers.Heron = value; break;
                        case HeaderNames.Herring: headers.Herring = value; break;
                        case HeaderNames.Hoatzin: headers.Hoatzin = value; break;
                        case HeaderNames.Hoopoe: headers.Hoopoe = value; break;
                        case HeaderNames.Hornet: headers.Hornet = value; break;
                        case HeaderNames.Horse: headers.Horse = value; break;
                        case HeaderNames.Hummingbird: headers.Hummingbird = value; break;
                        case HeaderNames.Hyena: headers.Hyena = value; break;
                        case HeaderNames.Ibis: headers.Ibis = value; break;
                        case HeaderNames.Iguana: headers.Iguana = value; break;
                        case HeaderNames.Jackal: headers.Jackal = value; break;
                        case HeaderNames.Jaguar: headers.Jaguar = value; break;
                        case HeaderNames.Jay: headers.Jay = value; break;
                        case HeaderNames.Kingbird: headers.Kingbird = value; break;
                        case HeaderNames.Kingfisher: headers.Kingfisher = value; break;
                        case HeaderNames.Kinkajou: headers.Kinkajou = value; break;
                        case HeaderNames.Kodkod: headers.Kodkod = value; break;
                        case HeaderNames.Kookaburra: headers.Kookaburra = value; break;
                        case HeaderNames.Kowari: headers.Kowari = value; break;
                        case HeaderNames.Langur: headers.Langur = value; break;
                        case HeaderNames.Lapwing: headers.Lapwing = value; break;
                        case HeaderNames.Lark: headers.Lark = value; break;
                        case HeaderNames.Lechwe: headers.Lechwe = value; break;
                        case HeaderNames.Lemur: headers.Lemur = value; break;
                        case HeaderNames.Lizard: headers.Lizard = value; break;
                        case HeaderNames.Llama: headers.Llama = value; break;
                        case HeaderNames.Locust: headers.Locust = value; break;
                        case HeaderNames.Lyrebird: headers.Lyrebird = value; break;
                        case HeaderNames.Macaque: headers.Macaque = value; break;
                        case HeaderNames.Macaw: headers.Macaw = value; break;
                        case HeaderNames.Mallard: headers.Mallard = value; break;
                        case HeaderNames.Mammoth: headers.Mammoth = value; break;
                        case HeaderNames.Manatee: headers.Manatee = value; break;
                        case HeaderNames.Mandrill: headers.Mandrill = value; break;
                        case HeaderNames.Marmoset: headers.Marmoset = value; break;
                        case HeaderNames.Marmot: headers.Marmot = value; break;
                        case HeaderNames.Meerkat: headers.Meerkat = value; break;
                        case HeaderNames.Mink: headers.Mink = value; break;
                        case HeaderNames.Mongoose: headers.Mongoose = value; break;
                        case HeaderNames.Monkey: headers.Monkey = value; break;
                        case HeaderNames.Moose: headers.Moose = value; break;
                        case HeaderNames.Mouse: headers.Mouse = value; break;
                        case HeaderNames.Myna: headers.Myna = value; break;
                        case HeaderNames.Narwhal: headers.Narwhal = value; break;
                        case HeaderNames.Newt: headers.Newt = value; break;
                        case HeaderNames.Nightingale: headers.Nightingale = value; break;
                        case HeaderNames.Nilgai: headers.Nilgai = value; break;
                        case HeaderNames.Ocelot: headers.Ocelot = value; break;
                        case HeaderNames.Octopus: headers.Octopus = value; break;
                        case HeaderNames.Okapi: headers.Okapi = value; break;
                        case HeaderNames.Olingo: headers.Olingo = value; break;
                        case HeaderNames.Opossum: headers.Opossum = value; break;
                        case HeaderNames.Ostrich: headers.Ostrich = value; break;
                        case HeaderNames.Owl: headers.Owl = value; break;
                        case HeaderNames.Ox: headers.Ox = value; break;
                        case HeaderNames.Oyster: headers.Oyster = value; break;
                        case HeaderNames.Panda: headers.Panda = value; break;
                        case HeaderNames.Panther: headers.Panther = value; break;
                        case HeaderNames.Peafowl: headers.Peafowl = value; break;
                        case HeaderNames.Pelican: headers.Pelican = value; break;
                        case HeaderNames.Penguin: headers.Penguin = value; break;
                        case HeaderNames.Pheasant: headers.Pheasant = value; break;
                        case HeaderNames.Pig: headers.Pig = value; break;
                        case HeaderNames.Pigeon: headers.Pigeon = value; break;
                        case HeaderNames.Pika: headers.Pika = value; break;
                        case HeaderNames.Pony: headers.Pony = value; break;
                        case HeaderNames.Porpoise: headers.Porpoise = value; break;
                        case HeaderNames.Pug: headers.Pug = value; break;
                        case HeaderNames.Quail: headers.Quail = value; break;
                        case HeaderNames.Quetzal: headers.Quetzal = value; break;
                        case HeaderNames.Rabbit: headers.Rabbit = value; break;
                        case HeaderNames.Raccoon: headers.Raccoon = value; break;
                        case HeaderNames.Ram: headers.Ram = value; break;
                        case HeaderNames.Rat: headers.Rat = value; break;
                        case HeaderNames.Reindeer: headers.Reindeer = value; break;
                        case HeaderNames.Rhea: headers.Rhea = value; break;
                        case HeaderNames.Rhinoceros: headers.Rhinoceros = value; break;
                        case HeaderNames.Rook: headers.Rook = value; break;
                        case HeaderNames.Salamander: headers.Salamander = value; break;
                        case HeaderNames.Sandpiper: headers.Sandpiper = value; break;
                        case HeaderNames.Sardine: headers.Sardine = value; break;
                        case HeaderNames.Sassaby: headers.Sassaby = value; break;
                        case HeaderNames.Seahorse: headers.Seahorse = value; break;
                        case HeaderNames.Seal: headers.Seal = value; break;
                        case HeaderNames.Serval: headers.Serval = value; break;
                        case HeaderNames.Sheep: headers.Sheep = value; break;
                        case HeaderNames.Shrike: headers.Shrike = value; break;
                        case HeaderNames.Siamang: headers.Siamang = value; break;
                        case HeaderNames.Skink: headers.Skink = value; break;
                        case HeaderNames.Skipper: headers.Skipper = value; break;
                        case HeaderNames.Skunk: headers.Skunk = value; break;
                        case HeaderNames.Sloth: headers.Sloth = value; break;
                        case HeaderNames.Snake: headers.Snake = value; break;
                        case HeaderNames.Spider: headers.Spider = value; break;
                        case HeaderNames.Spoonbill: headers.Spoonbill = value; break;
                        case HeaderNames.Squid: headers.Squid = value; break;
                        case HeaderNames.Squirrel: headers.Squirrel = value; break;
                        case HeaderNames.Starfish: headers.Starfish = value; break;
                        case HeaderNames.Tamarin: headers.Tamarin = value; break;
                        case HeaderNames.Tapir: headers.Tapir = value; break;
                        case HeaderNames.Tarsier: headers.Tarsier = value; break;
                        case HeaderNames.Termite: headers.Termite = value; break;
                        case HeaderNames.Tiger: headers.Tiger = value; break;
                        case HeaderNames.Toad: headers.Toad = value; break;
                        case HeaderNames.Toucan: headers.Toucan = value; break;
                        case HeaderNames.Turaco: headers.Turaco = value; break;
                        case HeaderNames.Turtle: headers.Turtle = value; break;
                        case HeaderNames.Viper: headers.Viper = value; break;
                        case HeaderNames.Vulture: headers.Vulture = value; break;
                        case HeaderNames.Wallaby: headers.Wallaby = value; break;
                        case HeaderNames.Wasp: headers.Wasp = value; break;
                        case HeaderNames.Wildebeest: headers.Wildebeest = value; break;
                        case HeaderNames.Wobbegong: headers.Wobbegong = value; break;
                        case HeaderNames.Wolf: headers.Wolf = value; break;
                        case HeaderNames.Wolverine: headers.Wolverine = value; break;
                        case HeaderNames.Wombat: headers.Wombat = value; break;
                        case HeaderNames.Woodpecker: headers.Woodpecker = value; break;
                        case HeaderNames.Worm: headers.Worm = value; break;
                        case HeaderNames.Wren: headers.Wren = value; break;
                        case HeaderNames.Yak: headers.Yak = value; break;
                        case HeaderNames.Zebra: headers.Zebra = value; break;
                        default: throw new InvalidOperationException();
                    }
                }
            }
        }

        public static IEnumerable<Parameters> GetOrderAndCount()
        {
            foreach (var count in Enumerable.Range(0, Constants.MaximumSetHeaders + 1))
            {
                if ((count % 2) != 0)
                {
                    continue;
                }

                foreach (var order in new[] { "Ordered", "Random", "Reversed" })
                {
                    if (count == 0 && order != "InOrder")
                    {
                        continue;
                    }

                    if ((count == 1 || count == 2) && order == "Random")
                    {
                        continue;
                    }

                    yield return new Parameters(order, count);
                }
            }
        }
    }
}
