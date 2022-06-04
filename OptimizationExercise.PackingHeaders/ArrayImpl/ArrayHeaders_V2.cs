using OptimizationExercise.PackingHeaders.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace OptimizationExercise.PackingHeaders.ArrayImpl
{
    /// <summary>
    /// Stores headers by shoving values into a list, and then recording the index of those values into
    /// an array where the indexes of the array correspond to the values of HeaderNames.
    /// </summary>
    public sealed class ArrayHeaders_V2 : IHeadersStructure<ArrayHeaders_V2, ArrayHeaders_V2.Enumerator>
    {
        /// <summary>
        /// Enumerates an ArrayHeaders.
        /// 
        /// Key trick is scanning the array, but we can go 8 bytes at a time MOST of the time
        /// and terminate early if we're fully saturated.
        /// </summary>
        public struct Enumerator : IEnumerator<HeaderNames>
        {
            public HeaderNames Current { get; private set; }

            object IEnumerator.Current
            => Current;

            private readonly byte[] valueIndexes;
            private byte yieldedCount;
            private byte startIndex;

            internal Enumerator(byte[] valueIndexes)
            {
                Current = default;
                this.valueIndexes = valueIndexes;
                startIndex = 0;
                yieldedCount = 0;
            }

            public bool MoveNext()
            {
                if (yieldedCount == Constants.MaximumSetHeaders || startIndex == Constants.HeaderNamesCount)
                {
                    return false;
                }

                Span<byte> remainingBytes = valueIndexes.AsSpan().Slice(startIndex);
                var remaining = remainingBytes.Length;
                var longs = remaining / sizeof(ulong);

                byte byteOffset;

                // go 8 bytes at a time
                Span<ulong> remainingLongs = MemoryMarshal.Cast<byte, ulong>(remainingBytes.Slice(0, longs * sizeof(ulong)));
                for (var i = 0; i < remainingLongs.Length; i++)
                {
                    var firstNonZeroByte = Helpers.TrailingZeroByteCount_Intrinsics(remainingLongs[i]);
                    if (firstNonZeroByte != sizeof(ulong))
                    {
                        byteOffset = (byte)((i * sizeof(ulong)) + firstNonZeroByte);
                        goto gotHit;
                    }
                }

                remaining -= sizeof(ulong) * longs;

                // handle the trailing int, if there is one
                var hasInt = remaining >= sizeof(uint);
                if (hasInt)
                {
                    var remainingInt = MemoryMarshal.Cast<byte, uint>(remainingBytes.Slice(longs * sizeof(ulong), sizeof(uint)))[0];
                    var firstNonZeroByte = Helpers.TrailingZeroByteCount_Intrinsics(remainingInt);
                    if (firstNonZeroByte != sizeof(uint))
                    {
                        byteOffset = (byte)((longs * sizeof(ulong)) + firstNonZeroByte);
                        goto gotHit;
                    }

                    remaining -= sizeof(uint);
                }

                // handling the trailing short, if there is one
                var hasShort = remaining >= sizeof(ushort);
                if (hasShort)
                {
                    var remainingShort = MemoryMarshal.Cast<byte, ushort>(remainingBytes.Slice(longs * sizeof(ulong) + (hasInt ? sizeof(uint) : 0), sizeof(ushort)))[0];
                    var firstNonZeroByte = Helpers.TrailingZeroByteCount_Intrinsics(remainingShort);
                    if (firstNonZeroByte != sizeof(ushort))
                    {
                        byteOffset = (byte)((longs * sizeof(ulong)) + (hasInt ? sizeof(uint) : 0) + firstNonZeroByte);
                        goto gotHit;
                    }

                    remaining -= sizeof(ushort);
                }

                // handle the last byte, if there is one
                if (remaining != 0)
                {
                    var remainingByte = remainingBytes[^1];
                    if (remainingByte != 0)
                    {
                        byteOffset = (byte)(remainingBytes.Length - 1);
                        goto gotHit;
                    }
                }

                startIndex = Constants.HeaderNamesCount;
                return false;

            // all the hits end up here
            gotHit:
                var currentHeaderOffset = (byte)(startIndex + byteOffset);

                Current = (HeaderNames)currentHeaderOffset;
                startIndex = (byte)(currentHeaderOffset + 1);
                yieldedCount++;

                return true;
            }

            public void Reset()
            {
                throw new NotSupportedException();
            }

            public void Dispose() { }
        }

        private readonly byte[] valueIndexes;
        private readonly List<string?> values;

        #region direct access by name
        public string? Aardvark { get => GetOrDefault(HeaderNames.Aardvark); set => SetNull(HeaderNames.Aardvark, value); }
        public string? Albatross { get => GetOrDefault(HeaderNames.Albatross); set => SetNull(HeaderNames.Albatross, value); }
        public string? Alligator { get => GetOrDefault(HeaderNames.Alligator); set => SetNull(HeaderNames.Alligator, value); }
        public string? Anteater { get => GetOrDefault(HeaderNames.Anteater); set => SetNull(HeaderNames.Anteater, value); }
        public string? Antelope { get => GetOrDefault(HeaderNames.Antelope); set => SetNull(HeaderNames.Antelope, value); }
        public string? Bat { get => GetOrDefault(HeaderNames.Bat); set => SetNull(HeaderNames.Bat, value); }
        public string? Beaver { get => GetOrDefault(HeaderNames.Beaver); set => SetNull(HeaderNames.Beaver, value); }
        public string? Bee { get => GetOrDefault(HeaderNames.Bee); set => SetNull(HeaderNames.Bee, value); }
        public string? Beetle { get => GetOrDefault(HeaderNames.Beetle); set => SetNull(HeaderNames.Beetle, value); }
        public string? Binturong { get => GetOrDefault(HeaderNames.Binturong); set => SetNull(HeaderNames.Binturong, value); }
        public string? Bird { get => GetOrDefault(HeaderNames.Bird); set => SetNull(HeaderNames.Bird, value); }
        public string? Boar { get => GetOrDefault(HeaderNames.Boar); set => SetNull(HeaderNames.Boar, value); }
        public string? Buffalo { get => GetOrDefault(HeaderNames.Buffalo); set => SetNull(HeaderNames.Buffalo, value); }
        public string? Butterfly { get => GetOrDefault(HeaderNames.Butterfly); set => SetNull(HeaderNames.Butterfly, value); }
        public string? Camel { get => GetOrDefault(HeaderNames.Camel); set => SetNull(HeaderNames.Camel, value); }
        public string? Capybara { get => GetOrDefault(HeaderNames.Capybara); set => SetNull(HeaderNames.Capybara, value); }
        public string? Caracal { get => GetOrDefault(HeaderNames.Caracal); set => SetNull(HeaderNames.Caracal, value); }
        public string? Cat { get => GetOrDefault(HeaderNames.Cat); set => SetNull(HeaderNames.Cat, value); }
        public string? Cattle { get => GetOrDefault(HeaderNames.Cattle); set => SetNull(HeaderNames.Cattle, value); }
        public string? Chamois { get => GetOrDefault(HeaderNames.Chamois); set => SetNull(HeaderNames.Chamois, value); }
        public string? Chicken { get => GetOrDefault(HeaderNames.Chicken); set => SetNull(HeaderNames.Chicken, value); }
        public string? Chimpanzee { get => GetOrDefault(HeaderNames.Chimpanzee); set => SetNull(HeaderNames.Chimpanzee, value); }
        public string? Chinchilla { get => GetOrDefault(HeaderNames.Chinchilla); set => SetNull(HeaderNames.Chinchilla, value); }
        public string? Coati { get => GetOrDefault(HeaderNames.Coati); set => SetNull(HeaderNames.Coati, value); }
        public string? Cockroach { get => GetOrDefault(HeaderNames.Cockroach); set => SetNull(HeaderNames.Cockroach, value); }
        public string? Cormorant { get => GetOrDefault(HeaderNames.Cormorant); set => SetNull(HeaderNames.Cormorant, value); }
        public string? Cow { get => GetOrDefault(HeaderNames.Cow); set => SetNull(HeaderNames.Cow, value); }
        public string? Crab { get => GetOrDefault(HeaderNames.Crab); set => SetNull(HeaderNames.Crab, value); }
        public string? Crocodile { get => GetOrDefault(HeaderNames.Crocodile); set => SetNull(HeaderNames.Crocodile, value); }
        public string? Cuckoo { get => GetOrDefault(HeaderNames.Cuckoo); set => SetNull(HeaderNames.Cuckoo, value); }
        public string? Curlew { get => GetOrDefault(HeaderNames.Curlew); set => SetNull(HeaderNames.Curlew, value); }
        public string? Deer { get => GetOrDefault(HeaderNames.Deer); set => SetNull(HeaderNames.Deer, value); }
        public string? Dhole { get => GetOrDefault(HeaderNames.Dhole); set => SetNull(HeaderNames.Dhole, value); }
        public string? Dinosaur { get => GetOrDefault(HeaderNames.Dinosaur); set => SetNull(HeaderNames.Dinosaur, value); }
        public string? Dog { get => GetOrDefault(HeaderNames.Dog); set => SetNull(HeaderNames.Dog, value); }
        public string? Dogfish { get => GetOrDefault(HeaderNames.Dogfish); set => SetNull(HeaderNames.Dogfish, value); }
        public string? Dolphin { get => GetOrDefault(HeaderNames.Dolphin); set => SetNull(HeaderNames.Dolphin, value); }
        public string? Donkey { get => GetOrDefault(HeaderNames.Donkey); set => SetNull(HeaderNames.Donkey, value); }
        public string? Dragonfly { get => GetOrDefault(HeaderNames.Dragonfly); set => SetNull(HeaderNames.Dragonfly, value); }
        public string? Duck { get => GetOrDefault(HeaderNames.Duck); set => SetNull(HeaderNames.Duck, value); }
        public string? Dugong { get => GetOrDefault(HeaderNames.Dugong); set => SetNull(HeaderNames.Dugong, value); }
        public string? Eland { get => GetOrDefault(HeaderNames.Eland); set => SetNull(HeaderNames.Eland, value); }
        public string? Elephant { get => GetOrDefault(HeaderNames.Elephant); set => SetNull(HeaderNames.Elephant, value); }
        public string? Elk { get => GetOrDefault(HeaderNames.Elk); set => SetNull(HeaderNames.Elk, value); }
        public string? Emu { get => GetOrDefault(HeaderNames.Emu); set => SetNull(HeaderNames.Emu, value); }
        public string? Falcon { get => GetOrDefault(HeaderNames.Falcon); set => SetNull(HeaderNames.Falcon, value); }
        public string? Ferret { get => GetOrDefault(HeaderNames.Ferret); set => SetNull(HeaderNames.Ferret, value); }
        public string? Fish { get => GetOrDefault(HeaderNames.Fish); set => SetNull(HeaderNames.Fish, value); }
        public string? Fossa { get => GetOrDefault(HeaderNames.Fossa); set => SetNull(HeaderNames.Fossa, value); }
        public string? Fox { get => GetOrDefault(HeaderNames.Fox); set => SetNull(HeaderNames.Fox, value); }
        public string? Frog { get => GetOrDefault(HeaderNames.Frog); set => SetNull(HeaderNames.Frog, value); }
        public string? Gaur { get => GetOrDefault(HeaderNames.Gaur); set => SetNull(HeaderNames.Gaur, value); }
        public string? Gazelle { get => GetOrDefault(HeaderNames.Gazelle); set => SetNull(HeaderNames.Gazelle, value); }
        public string? Gecko { get => GetOrDefault(HeaderNames.Gecko); set => SetNull(HeaderNames.Gecko, value); }
        public string? Genet { get => GetOrDefault(HeaderNames.Genet); set => SetNull(HeaderNames.Genet, value); }
        public string? Gerbil { get => GetOrDefault(HeaderNames.Gerbil); set => SetNull(HeaderNames.Gerbil, value); }
        public string? Gnat { get => GetOrDefault(HeaderNames.Gnat); set => SetNull(HeaderNames.Gnat, value); }
        public string? Gnu { get => GetOrDefault(HeaderNames.Gnu); set => SetNull(HeaderNames.Gnu, value); }
        public string? Goat { get => GetOrDefault(HeaderNames.Goat); set => SetNull(HeaderNames.Goat, value); }
        public string? Goldfinch { get => GetOrDefault(HeaderNames.Goldfinch); set => SetNull(HeaderNames.Goldfinch, value); }
        public string? Goosander { get => GetOrDefault(HeaderNames.Goosander); set => SetNull(HeaderNames.Goosander, value); }
        public string? Gorilla { get => GetOrDefault(HeaderNames.Gorilla); set => SetNull(HeaderNames.Gorilla, value); }
        public string? Goshawk { get => GetOrDefault(HeaderNames.Goshawk); set => SetNull(HeaderNames.Goshawk, value); }
        public string? Grasshopper { get => GetOrDefault(HeaderNames.Grasshopper); set => SetNull(HeaderNames.Grasshopper, value); }
        public string? Grouse { get => GetOrDefault(HeaderNames.Grouse); set => SetNull(HeaderNames.Grouse, value); }
        public string? Guanaco { get => GetOrDefault(HeaderNames.Guanaco); set => SetNull(HeaderNames.Guanaco, value); }
        public string? Gull { get => GetOrDefault(HeaderNames.Gull); set => SetNull(HeaderNames.Gull, value); }
        public string? Hamster { get => GetOrDefault(HeaderNames.Hamster); set => SetNull(HeaderNames.Hamster, value); }
        public string? Hare { get => GetOrDefault(HeaderNames.Hare); set => SetNull(HeaderNames.Hare, value); }
        public string? Hawk { get => GetOrDefault(HeaderNames.Hawk); set => SetNull(HeaderNames.Hawk, value); }
        public string? Hedgehog { get => GetOrDefault(HeaderNames.Hedgehog); set => SetNull(HeaderNames.Hedgehog, value); }
        public string? Heron { get => GetOrDefault(HeaderNames.Heron); set => SetNull(HeaderNames.Heron, value); }
        public string? Herring { get => GetOrDefault(HeaderNames.Herring); set => SetNull(HeaderNames.Herring, value); }
        public string? Hoatzin { get => GetOrDefault(HeaderNames.Hoatzin); set => SetNull(HeaderNames.Hoatzin, value); }
        public string? Hoopoe { get => GetOrDefault(HeaderNames.Hoopoe); set => SetNull(HeaderNames.Hoopoe, value); }
        public string? Hornet { get => GetOrDefault(HeaderNames.Hornet); set => SetNull(HeaderNames.Hornet, value); }
        public string? Horse { get => GetOrDefault(HeaderNames.Horse); set => SetNull(HeaderNames.Horse, value); }
        public string? Hummingbird { get => GetOrDefault(HeaderNames.Hummingbird); set => SetNull(HeaderNames.Hummingbird, value); }
        public string? Hyena { get => GetOrDefault(HeaderNames.Hyena); set => SetNull(HeaderNames.Hyena, value); }
        public string? Ibis { get => GetOrDefault(HeaderNames.Ibis); set => SetNull(HeaderNames.Ibis, value); }
        public string? Iguana { get => GetOrDefault(HeaderNames.Iguana); set => SetNull(HeaderNames.Iguana, value); }
        public string? Jackal { get => GetOrDefault(HeaderNames.Jackal); set => SetNull(HeaderNames.Jackal, value); }
        public string? Jaguar { get => GetOrDefault(HeaderNames.Jaguar); set => SetNull(HeaderNames.Jaguar, value); }
        public string? Jay { get => GetOrDefault(HeaderNames.Jay); set => SetNull(HeaderNames.Jay, value); }
        public string? Kingbird { get => GetOrDefault(HeaderNames.Kingbird); set => SetNull(HeaderNames.Kingbird, value); }
        public string? Kingfisher { get => GetOrDefault(HeaderNames.Kingfisher); set => SetNull(HeaderNames.Kingfisher, value); }
        public string? Kinkajou { get => GetOrDefault(HeaderNames.Kinkajou); set => SetNull(HeaderNames.Kinkajou, value); }
        public string? Kodkod { get => GetOrDefault(HeaderNames.Kodkod); set => SetNull(HeaderNames.Kodkod, value); }
        public string? Kookaburra { get => GetOrDefault(HeaderNames.Kookaburra); set => SetNull(HeaderNames.Kookaburra, value); }
        public string? Kowari { get => GetOrDefault(HeaderNames.Kowari); set => SetNull(HeaderNames.Kowari, value); }
        public string? Langur { get => GetOrDefault(HeaderNames.Langur); set => SetNull(HeaderNames.Langur, value); }
        public string? Lapwing { get => GetOrDefault(HeaderNames.Lapwing); set => SetNull(HeaderNames.Lapwing, value); }
        public string? Lark { get => GetOrDefault(HeaderNames.Lark); set => SetNull(HeaderNames.Lark, value); }
        public string? Lechwe { get => GetOrDefault(HeaderNames.Lechwe); set => SetNull(HeaderNames.Lechwe, value); }
        public string? Lemur { get => GetOrDefault(HeaderNames.Lemur); set => SetNull(HeaderNames.Lemur, value); }
        public string? Lizard { get => GetOrDefault(HeaderNames.Lizard); set => SetNull(HeaderNames.Lizard, value); }
        public string? Llama { get => GetOrDefault(HeaderNames.Llama); set => SetNull(HeaderNames.Llama, value); }
        public string? Locust { get => GetOrDefault(HeaderNames.Locust); set => SetNull(HeaderNames.Locust, value); }
        public string? Lyrebird { get => GetOrDefault(HeaderNames.Lyrebird); set => SetNull(HeaderNames.Lyrebird, value); }
        public string? Macaque { get => GetOrDefault(HeaderNames.Macaque); set => SetNull(HeaderNames.Macaque, value); }
        public string? Macaw { get => GetOrDefault(HeaderNames.Macaw); set => SetNull(HeaderNames.Macaw, value); }
        public string? Mallard { get => GetOrDefault(HeaderNames.Mallard); set => SetNull(HeaderNames.Mallard, value); }
        public string? Mammoth { get => GetOrDefault(HeaderNames.Mammoth); set => SetNull(HeaderNames.Mammoth, value); }
        public string? Manatee { get => GetOrDefault(HeaderNames.Manatee); set => SetNull(HeaderNames.Manatee, value); }
        public string? Mandrill { get => GetOrDefault(HeaderNames.Mandrill); set => SetNull(HeaderNames.Mandrill, value); }
        public string? Marmoset { get => GetOrDefault(HeaderNames.Marmoset); set => SetNull(HeaderNames.Marmoset, value); }
        public string? Marmot { get => GetOrDefault(HeaderNames.Marmot); set => SetNull(HeaderNames.Marmot, value); }
        public string? Meerkat { get => GetOrDefault(HeaderNames.Meerkat); set => SetNull(HeaderNames.Meerkat, value); }
        public string? Mink { get => GetOrDefault(HeaderNames.Mink); set => SetNull(HeaderNames.Mink, value); }
        public string? Mongoose { get => GetOrDefault(HeaderNames.Mongoose); set => SetNull(HeaderNames.Mongoose, value); }
        public string? Monkey { get => GetOrDefault(HeaderNames.Monkey); set => SetNull(HeaderNames.Monkey, value); }
        public string? Moose { get => GetOrDefault(HeaderNames.Moose); set => SetNull(HeaderNames.Moose, value); }
        public string? Mouse { get => GetOrDefault(HeaderNames.Mouse); set => SetNull(HeaderNames.Mouse, value); }
        public string? Myna { get => GetOrDefault(HeaderNames.Myna); set => SetNull(HeaderNames.Myna, value); }
        public string? Narwhal { get => GetOrDefault(HeaderNames.Narwhal); set => SetNull(HeaderNames.Narwhal, value); }
        public string? Newt { get => GetOrDefault(HeaderNames.Newt); set => SetNull(HeaderNames.Newt, value); }
        public string? Nightingale { get => GetOrDefault(HeaderNames.Nightingale); set => SetNull(HeaderNames.Nightingale, value); }
        public string? Nilgai { get => GetOrDefault(HeaderNames.Nilgai); set => SetNull(HeaderNames.Nilgai, value); }
        public string? Ocelot { get => GetOrDefault(HeaderNames.Ocelot); set => SetNull(HeaderNames.Ocelot, value); }
        public string? Octopus { get => GetOrDefault(HeaderNames.Octopus); set => SetNull(HeaderNames.Octopus, value); }
        public string? Okapi { get => GetOrDefault(HeaderNames.Okapi); set => SetNull(HeaderNames.Okapi, value); }
        public string? Olingo { get => GetOrDefault(HeaderNames.Olingo); set => SetNull(HeaderNames.Olingo, value); }
        public string? Opossum { get => GetOrDefault(HeaderNames.Opossum); set => SetNull(HeaderNames.Opossum, value); }
        public string? Ostrich { get => GetOrDefault(HeaderNames.Ostrich); set => SetNull(HeaderNames.Ostrich, value); }
        public string? Owl { get => GetOrDefault(HeaderNames.Owl); set => SetNull(HeaderNames.Owl, value); }
        public string? Ox { get => GetOrDefault(HeaderNames.Ox); set => SetNull(HeaderNames.Ox, value); }
        public string? Oyster { get => GetOrDefault(HeaderNames.Oyster); set => SetNull(HeaderNames.Oyster, value); }
        public string? Panda { get => GetOrDefault(HeaderNames.Panda); set => SetNull(HeaderNames.Panda, value); }
        public string? Panther { get => GetOrDefault(HeaderNames.Panther); set => SetNull(HeaderNames.Panther, value); }
        public string? Peafowl { get => GetOrDefault(HeaderNames.Peafowl); set => SetNull(HeaderNames.Peafowl, value); }
        public string? Pelican { get => GetOrDefault(HeaderNames.Pelican); set => SetNull(HeaderNames.Pelican, value); }
        public string? Penguin { get => GetOrDefault(HeaderNames.Penguin); set => SetNull(HeaderNames.Penguin, value); }
        public string? Pheasant { get => GetOrDefault(HeaderNames.Pheasant); set => SetNull(HeaderNames.Pheasant, value); }
        public string? Pig { get => GetOrDefault(HeaderNames.Pig); set => SetNull(HeaderNames.Pig, value); }
        public string? Pigeon { get => GetOrDefault(HeaderNames.Pigeon); set => SetNull(HeaderNames.Pigeon, value); }
        public string? Pika { get => GetOrDefault(HeaderNames.Pika); set => SetNull(HeaderNames.Pika, value); }
        public string? Pony { get => GetOrDefault(HeaderNames.Pony); set => SetNull(HeaderNames.Pony, value); }
        public string? Porpoise { get => GetOrDefault(HeaderNames.Porpoise); set => SetNull(HeaderNames.Porpoise, value); }
        public string? Pug { get => GetOrDefault(HeaderNames.Pug); set => SetNull(HeaderNames.Pug, value); }
        public string? Quail { get => GetOrDefault(HeaderNames.Quail); set => SetNull(HeaderNames.Quail, value); }
        public string? Quetzal { get => GetOrDefault(HeaderNames.Quetzal); set => SetNull(HeaderNames.Quetzal, value); }
        public string? Rabbit { get => GetOrDefault(HeaderNames.Rabbit); set => SetNull(HeaderNames.Rabbit, value); }
        public string? Raccoon { get => GetOrDefault(HeaderNames.Raccoon); set => SetNull(HeaderNames.Raccoon, value); }
        public string? Ram { get => GetOrDefault(HeaderNames.Ram); set => SetNull(HeaderNames.Ram, value); }
        public string? Rat { get => GetOrDefault(HeaderNames.Rat); set => SetNull(HeaderNames.Rat, value); }
        public string? Reindeer { get => GetOrDefault(HeaderNames.Reindeer); set => SetNull(HeaderNames.Reindeer, value); }
        public string? Rhea { get => GetOrDefault(HeaderNames.Rhea); set => SetNull(HeaderNames.Rhea, value); }
        public string? Rhinoceros { get => GetOrDefault(HeaderNames.Rhinoceros); set => SetNull(HeaderNames.Rhinoceros, value); }
        public string? Rook { get => GetOrDefault(HeaderNames.Rook); set => SetNull(HeaderNames.Rook, value); }
        public string? Salamander { get => GetOrDefault(HeaderNames.Salamander); set => SetNull(HeaderNames.Salamander, value); }
        public string? Sandpiper { get => GetOrDefault(HeaderNames.Sandpiper); set => SetNull(HeaderNames.Sandpiper, value); }
        public string? Sardine { get => GetOrDefault(HeaderNames.Sardine); set => SetNull(HeaderNames.Sardine, value); }
        public string? Sassaby { get => GetOrDefault(HeaderNames.Sassaby); set => SetNull(HeaderNames.Sassaby, value); }
        public string? Seahorse { get => GetOrDefault(HeaderNames.Seahorse); set => SetNull(HeaderNames.Seahorse, value); }
        public string? Seal { get => GetOrDefault(HeaderNames.Seal); set => SetNull(HeaderNames.Seal, value); }
        public string? Serval { get => GetOrDefault(HeaderNames.Serval); set => SetNull(HeaderNames.Serval, value); }
        public string? Sheep { get => GetOrDefault(HeaderNames.Sheep); set => SetNull(HeaderNames.Sheep, value); }
        public string? Shrike { get => GetOrDefault(HeaderNames.Shrike); set => SetNull(HeaderNames.Shrike, value); }
        public string? Siamang { get => GetOrDefault(HeaderNames.Siamang); set => SetNull(HeaderNames.Siamang, value); }
        public string? Skink { get => GetOrDefault(HeaderNames.Skink); set => SetNull(HeaderNames.Skink, value); }
        public string? Skipper { get => GetOrDefault(HeaderNames.Skipper); set => SetNull(HeaderNames.Skipper, value); }
        public string? Skunk { get => GetOrDefault(HeaderNames.Skunk); set => SetNull(HeaderNames.Skunk, value); }
        public string? Sloth { get => GetOrDefault(HeaderNames.Sloth); set => SetNull(HeaderNames.Sloth, value); }
        public string? Snake { get => GetOrDefault(HeaderNames.Snake); set => SetNull(HeaderNames.Snake, value); }
        public string? Spider { get => GetOrDefault(HeaderNames.Spider); set => SetNull(HeaderNames.Spider, value); }
        public string? Spoonbill { get => GetOrDefault(HeaderNames.Spoonbill); set => SetNull(HeaderNames.Spoonbill, value); }
        public string? Squid { get => GetOrDefault(HeaderNames.Squid); set => SetNull(HeaderNames.Squid, value); }
        public string? Squirrel { get => GetOrDefault(HeaderNames.Squirrel); set => SetNull(HeaderNames.Squirrel, value); }
        public string? Starfish { get => GetOrDefault(HeaderNames.Starfish); set => SetNull(HeaderNames.Starfish, value); }
        public string? Tamarin { get => GetOrDefault(HeaderNames.Tamarin); set => SetNull(HeaderNames.Tamarin, value); }
        public string? Tapir { get => GetOrDefault(HeaderNames.Tapir); set => SetNull(HeaderNames.Tapir, value); }
        public string? Tarsier { get => GetOrDefault(HeaderNames.Tarsier); set => SetNull(HeaderNames.Tarsier, value); }
        public string? Termite { get => GetOrDefault(HeaderNames.Termite); set => SetNull(HeaderNames.Termite, value); }
        public string? Tiger { get => GetOrDefault(HeaderNames.Tiger); set => SetNull(HeaderNames.Tiger, value); }
        public string? Toad { get => GetOrDefault(HeaderNames.Toad); set => SetNull(HeaderNames.Toad, value); }
        public string? Toucan { get => GetOrDefault(HeaderNames.Toucan); set => SetNull(HeaderNames.Toucan, value); }
        public string? Turaco { get => GetOrDefault(HeaderNames.Turaco); set => SetNull(HeaderNames.Turaco, value); }
        public string? Turtle { get => GetOrDefault(HeaderNames.Turtle); set => SetNull(HeaderNames.Turtle, value); }
        public string? Viper { get => GetOrDefault(HeaderNames.Viper); set => SetNull(HeaderNames.Viper, value); }
        public string? Vulture { get => GetOrDefault(HeaderNames.Vulture); set => SetNull(HeaderNames.Vulture, value); }
        public string? Wallaby { get => GetOrDefault(HeaderNames.Wallaby); set => SetNull(HeaderNames.Wallaby, value); }
        public string? Wasp { get => GetOrDefault(HeaderNames.Wasp); set => SetNull(HeaderNames.Wasp, value); }
        public string? Wildebeest { get => GetOrDefault(HeaderNames.Wildebeest); set => SetNull(HeaderNames.Wildebeest, value); }
        public string? Wobbegong { get => GetOrDefault(HeaderNames.Wobbegong); set => SetNull(HeaderNames.Wobbegong, value); }
        public string? Wolf { get => GetOrDefault(HeaderNames.Wolf); set => SetNull(HeaderNames.Wolf, value); }
        public string? Wolverine { get => GetOrDefault(HeaderNames.Wolverine); set => SetNull(HeaderNames.Wolverine, value); }
        public string? Wombat { get => GetOrDefault(HeaderNames.Wombat); set => SetNull(HeaderNames.Wombat, value); }
        public string? Woodpecker { get => GetOrDefault(HeaderNames.Woodpecker); set => SetNull(HeaderNames.Woodpecker, value); }
        public string? Worm { get => GetOrDefault(HeaderNames.Worm); set => SetNull(HeaderNames.Worm, value); }
        public string? Wren { get => GetOrDefault(HeaderNames.Wren); set => SetNull(HeaderNames.Wren, value); }
        public string? Yak { get => GetOrDefault(HeaderNames.Yak); set => SetNull(HeaderNames.Yak, value); }
        public string? Zebra { get => GetOrDefault(HeaderNames.Zebra); set => SetNull(HeaderNames.Zebra, value); }
        #endregion

        private ArrayHeaders_V2()
        {
            valueIndexes = new byte[Constants.HeaderNamesCount];

            // start with a null value, so all valueIndexes default point to a null
            values = new List<string?>();
            values.Add(null);
        }

        // this should always just be a pass through
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public void Set(HeaderNames header, string value)
        => SetImpl(header, value);

        public bool TryGetValue(HeaderNames header, [NotNullWhen(returnValue: true)] out string? value)
        {
            value = values[valueIndexes[(byte)header]];
            return value != null;
        }

        public Enumerator GetEnumerator()
        => new Enumerator(valueIndexes);

        public static ArrayHeaders_V2 CreateEmpty()
        => new ArrayHeaders_V2();

        public static ArrayHeaders_V2 CreateFromDictionary(Dictionary<HeaderNames, string> headers)
        {
            if (headers.Count > Constants.MaximumSetHeaders)
            {
                throw new ArgumentException(nameof(headers));
            }

            var ret = new ArrayHeaders_V2();
            byte nextIx = 1;
            foreach (var kv in headers)
            {
                ret.values.Add(kv.Value);
                ret.valueIndexes[(byte)kv.Key] = nextIx;
                nextIx++;
            }

            return ret;
        }

        // this backs all property impls and we want it to be inlined
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        private void SetNull(HeaderNames header, string? value)
        {
            value = value ?? throw new ArgumentNullException(nameof(value));

            SetImpl(header, value);
        }

        // there's a little too much here for us to want to inline this (unless the JIT disagrees)
        private void SetImpl(HeaderNames header, string value)
        {
            if (values.Count == (Constants.MaximumSetHeaders + 1))  // +1 here because we store an extra null
            {
                throw new InvalidOperationException();
            }

            var headerIx = (byte)header;

            var valueIx = (byte)values.Count;
            values.Add(value);

            if (valueIndexes[headerIx] != 0)
            {
                throw new ArgumentException();
            }

            valueIndexes[headerIx] = valueIx;
        }

        // we want each property access to devolve to basically two array lookups, so inline aggressively
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        private string? GetOrDefault(HeaderNames header)
        => values[valueIndexes[(byte)header]];
    }
}
