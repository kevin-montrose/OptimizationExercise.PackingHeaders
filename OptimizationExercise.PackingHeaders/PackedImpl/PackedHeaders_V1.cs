using OptimizationExercise.PackingHeaders.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace OptimizationExercise.PackingHeaders.PackedImpl
{
    public sealed class PackedHeaders_V1 : IHeadersStructure<PackedHeaders_V1, PackedHeaders_V1.Enumerator>
    {
        public struct Enumerator : IEnumerator<HeaderNames>
        {
            private readonly PackedHeaders_V1 outer;

            private byte currentBitfieldIndex;
            private byte nextBitIndex;
            private byte yieldedCount;

            public HeaderNames Current { get; private set; }

            object IEnumerator.Current
            => Current;

            internal Enumerator(PackedHeaders_V1 outer)
            {
                Current = default;
                this.outer = outer;
                currentBitfieldIndex = 0;
                nextBitIndex = 0;
                yieldedCount = 0;
            }

            public bool MoveNext()
            {
                if (yieldedCount == Constants.MaximumSetHeaders)
                {
                    return false;
                }

            tryAgain:
                if (currentBitfieldIndex == 3)
                {
                    return false;
                }

                var bitfield = outer.GetBitfield(currentBitfieldIndex);
                if (bitfield != 0)
                {
                    while (nextBitIndex < 64)
                    {
                        var bitIndexAsMask = (1UL << nextBitIndex);

                        var isSet = (bitfield & bitIndexAsMask) != 0;
                        
                        if (isSet)
                        {
                            Current = (HeaderNames)(nextBitIndex + 64 * currentBitfieldIndex);
                            yieldedCount++;
                            nextBitIndex++;
                            return true;
                        }

                        nextBitIndex++;
                    }
                }

                currentBitfieldIndex++;
                nextBitIndex = 0;
                goto tryAgain;
            }

            public void Reset()
            {
                throw new NotSupportedException();
            }


            public void Dispose() { }
        }

        private PackedBitfield bitfield;
        private PackedData data;

        #region direct access by name

        // going into first bitfield
        public string? Aardvark { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Aardvark) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Aardvark) % 64, value); }
        public string? Albatross { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Albatross) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Albatross) % 64, value); }
        public string? Alligator { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Alligator) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Alligator) % 64, value); }
        public string? Anteater { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Anteater) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Anteater) % 64, value); }
        public string? Antelope { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Antelope) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Antelope) % 64, value); }
        public string? Bat { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Bat) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Bat) % 64, value); }
        public string? Beaver { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Beaver) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Beaver) % 64, value); }
        public string? Bee { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Bee) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Bee) % 64, value); }
        public string? Beetle { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Beetle) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Beetle) % 64, value); }
        public string? Binturong { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Binturong) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Binturong) % 64, value); }
        public string? Bird { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Bird) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Bird) % 64, value); }
        public string? Boar { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Boar) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Boar) % 64, value); }
        public string? Buffalo { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Buffalo) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Buffalo) % 64, value); }
        public string? Butterfly { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Butterfly) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Butterfly) % 64, value); }
        public string? Camel { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Camel) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Camel) % 64, value); }
        public string? Capybara { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Capybara) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Capybara) % 64, value); }
        public string? Caracal { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Caracal) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Caracal) % 64, value); }
        public string? Cat { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Cat) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Cat) % 64, value); }
        public string? Cattle { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Cattle) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Cattle) % 64, value); }
        public string? Chamois { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Chamois) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Chamois) % 64, value); }
        public string? Chicken { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Chicken) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Chicken) % 64, value); }
        public string? Chimpanzee { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Chimpanzee) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Chimpanzee) % 64, value); }
        public string? Chinchilla { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Chinchilla) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Chinchilla) % 64, value); }
        public string? Coati { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Coati) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Coati) % 64, value); }
        public string? Cockroach { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Cockroach) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Cockroach) % 64, value); }
        public string? Cormorant { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Cormorant) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Cormorant) % 64, value); }
        public string? Cow { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Cow) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Cow) % 64, value); }
        public string? Crab { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Crab) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Crab) % 64, value); }
        public string? Crocodile { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Crocodile) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Crocodile) % 64, value); }
        public string? Cuckoo { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Cuckoo) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Cuckoo) % 64, value); }
        public string? Curlew { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Curlew) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Curlew) % 64, value); }
        public string? Deer { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Deer) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Deer) % 64, value); }
        public string? Dhole { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Dhole) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Dhole) % 64, value); }
        public string? Dinosaur { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Dinosaur) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Dinosaur) % 64, value); }
        public string? Dog { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Dog) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Dog) % 64, value); }
        public string? Dogfish { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Dogfish) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Dogfish) % 64, value); }
        public string? Dolphin { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Dolphin) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Dolphin) % 64, value); }
        public string? Donkey { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Donkey) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Donkey) % 64, value); }
        public string? Dragonfly { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Dragonfly) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Dragonfly) % 64, value); }
        public string? Duck { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Duck) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Duck) % 64, value); }
        public string? Dugong { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Dugong) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Dugong) % 64, value); }
        public string? Eland { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Eland) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Eland) % 64, value); }
        public string? Elephant { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Elephant) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Elephant) % 64, value); }
        public string? Elk { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Elk) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Elk) % 64, value); }
        public string? Emu { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Emu) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Emu) % 64, value); }
        public string? Falcon { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Falcon) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Falcon) % 64, value); }
        public string? Ferret { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Ferret) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Ferret) % 64, value); }
        public string? Fish { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Fish) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Fish) % 64, value); }
        public string? Fossa { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Fossa) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Fossa) % 64, value); }
        public string? Fox { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Fox) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Fox) % 64, value); }
        public string? Frog { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Frog) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Frog) % 64, value); }
        public string? Gaur { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Gaur) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Gaur) % 64, value); }
        public string? Gazelle { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Gazelle) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Gazelle) % 64, value); }
        public string? Gecko { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Gecko) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Gecko) % 64, value); }
        public string? Genet { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Genet) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Genet) % 64, value); }
        public string? Gerbil { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Gerbil) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Gerbil) % 64, value); }
        public string? Gnat { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Gnat) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Gnat) % 64, value); }
        public string? Gnu { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Gnu) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Gnu) % 64, value); }
        public string? Goat { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Goat) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Goat) % 64, value); }
        public string? Goldfinch { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Goldfinch) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Goldfinch) % 64, value); }
        public string? Goosander { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Goosander) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Goosander) % 64, value); }
        public string? Gorilla { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Gorilla) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Gorilla) % 64, value); }
        public string? Goshawk { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Goshawk) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Goshawk) % 64, value); }
        public string? Grasshopper { get => GetOrDefault(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Grasshopper) % 64); set => SetNull(ref bitfield.bitfield0, 0, ((byte)HeaderNames.Grasshopper) % 64, value); }

        // going into second bitfield
        public string? Grouse { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Grouse) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Grouse) % 64, value); }
        public string? Guanaco { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Guanaco) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Guanaco) % 64, value); }
        public string? Gull { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Gull) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Gull) % 64, value); }
        public string? Hamster { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Hamster) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Hamster) % 64, value); }
        public string? Hare { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Hare) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Hare) % 64, value); }
        public string? Hawk { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Hawk) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Hawk) % 64, value); }
        public string? Hedgehog { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Hedgehog) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Hedgehog) % 64, value); }
        public string? Heron { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Heron) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Heron) % 64, value); }
        public string? Herring { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Herring) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Herring) % 64, value); }
        public string? Hoatzin { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Hoatzin) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Hoatzin) % 64, value); }
        public string? Hoopoe { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Hoopoe) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Hoopoe) % 64, value); }
        public string? Hornet { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Hornet) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Hornet) % 64, value); }
        public string? Horse { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Horse) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Horse) % 64, value); }
        public string? Hummingbird { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Hummingbird) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Hummingbird) % 64, value); }
        public string? Hyena { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Hyena) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Hyena) % 64, value); }
        public string? Ibis { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Ibis) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Ibis) % 64, value); }
        public string? Iguana { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Iguana) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Iguana) % 64, value); }
        public string? Jackal { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Jackal) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Jackal) % 64, value); }
        public string? Jaguar { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Jaguar) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Jaguar) % 64, value); }
        public string? Jay { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Jay) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Jay) % 64, value); }
        public string? Kingbird { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Kingbird) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Kingbird) % 64, value); }
        public string? Kingfisher { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Kingfisher) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Kingfisher) % 64, value); }
        public string? Kinkajou { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Kinkajou) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Kinkajou) % 64, value); }
        public string? Kodkod { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Kodkod) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Kodkod) % 64, value); }
        public string? Kookaburra { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Kookaburra) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Kookaburra) % 64, value); }
        public string? Kowari { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Kowari) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Kowari) % 64, value); }
        public string? Langur { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Langur) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Langur) % 64, value); }
        public string? Lapwing { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Lapwing) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Lapwing) % 64, value); }
        public string? Lark { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Lark) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Lark) % 64, value); }
        public string? Lechwe { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Lechwe) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Lechwe) % 64, value); }
        public string? Lemur { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Lemur) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Lemur) % 64, value); }
        public string? Lizard { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Lizard) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Lizard) % 64, value); }
        public string? Llama { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Llama) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Llama) % 64, value); }
        public string? Locust { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Locust) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Locust) % 64, value); }
        public string? Lyrebird { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Lyrebird) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Lyrebird) % 64, value); }
        public string? Macaque { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Macaque) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Macaque) % 64, value); }
        public string? Macaw { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Macaw) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Macaw) % 64, value); }
        public string? Mallard { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Mallard) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Mallard) % 64, value); }
        public string? Mammoth { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Mammoth) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Mammoth) % 64, value); }
        public string? Manatee { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Manatee) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Manatee) % 64, value); }
        public string? Mandrill { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Mandrill) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Mandrill) % 64, value); }
        public string? Marmoset { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Marmoset) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Marmoset) % 64, value); }
        public string? Marmot { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Marmot) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Marmot) % 64, value); }
        public string? Meerkat { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Meerkat) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Meerkat) % 64, value); }
        public string? Mink { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Mink) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Mink) % 64, value); }
        public string? Mongoose { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Mongoose) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Mongoose) % 64, value); }
        public string? Monkey { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Monkey) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Monkey) % 64, value); }
        public string? Moose { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Moose) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Moose) % 64, value); }
        public string? Mouse { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Mouse) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Mouse) % 64, value); }
        public string? Myna { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Myna) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Myna) % 64, value); }
        public string? Narwhal { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Narwhal) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Narwhal) % 64, value); }
        public string? Newt { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Newt) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Newt) % 64, value); }
        public string? Nightingale { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Nightingale) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Nightingale) % 64, value); }
        public string? Nilgai { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Nilgai) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Nilgai) % 64, value); }
        public string? Ocelot { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Ocelot) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Ocelot) % 64, value); }
        public string? Octopus { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Octopus) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Octopus) % 64, value); }
        public string? Okapi { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Okapi) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Okapi) % 64, value); }
        public string? Olingo { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Olingo) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Olingo) % 64, value); }
        public string? Opossum { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Opossum) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Opossum) % 64, value); }
        public string? Ostrich { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Ostrich) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Ostrich) % 64, value); }
        public string? Owl { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Owl) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Owl) % 64, value); }
        public string? Ox { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Ox) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Ox) % 64, value); }
        public string? Oyster { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Oyster) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Oyster) % 64, value); }
        public string? Panda { get => GetOrDefault(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Panda) % 64); set => SetNull(ref bitfield.bitfield1, Bitfield0SetBits(), ((byte)HeaderNames.Panda) % 64, value); }

        // going into third bitfield
        public string? Panther { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Panther) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Panther) % 64, value); }
        public string? Peafowl { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Peafowl) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Peafowl) % 64, value); }
        public string? Pelican { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Pelican) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Pelican) % 64, value); }
        public string? Penguin { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Penguin) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Penguin) % 64, value); }
        public string? Pheasant { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Pheasant) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Pheasant) % 64, value); }
        public string? Pig { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Pig) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Pig) % 64, value); }
        public string? Pigeon { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Pigeon) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Pigeon) % 64, value); }
        public string? Pika { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Pika) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Pika) % 64, value); }
        public string? Pony { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Pony) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Pony) % 64, value); }
        public string? Porpoise { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Porpoise) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Porpoise) % 64, value); }
        public string? Pug { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Pug) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Pug) % 64, value); }
        public string? Quail { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Quail) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Quail) % 64, value); }
        public string? Quetzal { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Quetzal) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Quetzal) % 64, value); }
        public string? Rabbit { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Rabbit) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Rabbit) % 64, value); }
        public string? Raccoon { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Raccoon) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Raccoon) % 64, value); }
        public string? Ram { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Ram) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Ram) % 64, value); }
        public string? Rat { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Rat) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Rat) % 64, value); }
        public string? Reindeer { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Reindeer) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Reindeer) % 64, value); }
        public string? Rhea { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Rhea) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Rhea) % 64, value); }
        public string? Rhinoceros { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Rhinoceros) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Rhinoceros) % 64, value); }
        public string? Rook { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Rook) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Rook) % 64, value); }
        public string? Salamander { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Salamander) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Salamander) % 64, value); }
        public string? Sandpiper { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Sandpiper) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Sandpiper) % 64, value); }
        public string? Sardine { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Sardine) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Sardine) % 64, value); }
        public string? Sassaby { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Sassaby) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Sassaby) % 64, value); }
        public string? Seahorse { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Seahorse) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Seahorse) % 64, value); }
        public string? Seal { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Seal) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Seal) % 64, value); }
        public string? Serval { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Serval) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Serval) % 64, value); }
        public string? Sheep { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Sheep) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Sheep) % 64, value); }
        public string? Shrike { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Shrike) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Shrike) % 64, value); }
        public string? Siamang { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Siamang) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Siamang) % 64, value); }
        public string? Skink { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Skink) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Skink) % 64, value); }
        public string? Skipper { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Skipper) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Skipper) % 64, value); }
        public string? Skunk { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Skunk) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Skunk) % 64, value); }
        public string? Sloth { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Sloth) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Sloth) % 64, value); }
        public string? Snake { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Snake) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Snake) % 64, value); }
        public string? Spider { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Spider) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Spider) % 64, value); }
        public string? Spoonbill { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Spoonbill) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Spoonbill) % 64, value); }
        public string? Squid { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Squid) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Squid) % 64, value); }
        public string? Squirrel { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Squirrel) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Squirrel) % 64, value); }
        public string? Starfish { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Starfish) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Starfish) % 64, value); }
        public string? Tamarin { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Tamarin) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Tamarin) % 64, value); }
        public string? Tapir { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Tapir) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Tapir) % 64, value); }
        public string? Tarsier { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Tarsier) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Tarsier) % 64, value); }
        public string? Termite { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Termite) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Termite) % 64, value); }
        public string? Tiger { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Tiger) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Tiger) % 64, value); }
        public string? Toad { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Toad) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Toad) % 64, value); }
        public string? Toucan { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Toucan) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Toucan) % 64, value); }
        public string? Turaco { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Turaco) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Turaco) % 64, value); }
        public string? Turtle { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Turtle) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Turtle) % 64, value); }
        public string? Viper { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Viper) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Viper) % 64, value); }
        public string? Vulture { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Vulture) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Vulture) % 64, value); }
        public string? Wallaby { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Wallaby) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Wallaby) % 64, value); }
        public string? Wasp { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Wasp) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Wasp) % 64, value); }
        public string? Wildebeest { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Wildebeest) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Wildebeest) % 64, value); }
        public string? Wobbegong { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Wobbegong) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Wobbegong) % 64, value); }
        public string? Wolf { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Wolf) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Wolf) % 64, value); }
        public string? Wolverine { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Wolverine) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Wolverine) % 64, value); }
        public string? Wombat { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Wombat) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Wombat) % 64, value); }
        public string? Woodpecker { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Woodpecker) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Woodpecker) % 64, value); }
        public string? Worm { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Worm) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Worm) % 64, value); }
        public string? Wren { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Wren) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Wren) % 64, value); }
        public string? Yak { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Yak) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Yak) % 64, value); }
        public string? Zebra { get => GetOrDefault(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Zebra) % 64); set => SetNull(ref bitfield.bitfield2, Bitfield01SetBits(), ((byte)HeaderNames.Zebra) % 64, value); }
        #endregion

        private PackedHeaders_V1() { }

        public Enumerator GetEnumerator()
        => new Enumerator(this);

        public void Set(HeaderNames name, string value)
        {
            var nameAsByte = (byte)name;

            // figure out which ulong we're going into, and the bit of in that ulong we're going to set
            var bitfieldIndex = Math.DivRem(nameAsByte, 64, out var bitIndex);
            ref ulong bitfield = ref GetBitfield(bitfieldIndex);

            var bitIndexAsMask = (1UL << bitIndex);

            // explode if we've already set that value
            var alreadySet = (bitfield & bitIndexAsMask) != 0;
            if (alreadySet)
            {
                throw new ArgumentException();
            }

            // figure out which _value_ index we're going to stash the value in
            var bitsSetBeforeBitfield = GetBitsSetBeforeBitfield(bitfieldIndex);
            var bitsSetBeforeBitfieldIndex = Helpers.BitsSetBeforeIndex_Naive(bitfield, (byte)bitIndex);

            var valueIndex = bitsSetBeforeBitfieldIndex + bitsSetBeforeBitfield;

            // make space
            if (!TryShiftValuesDownFrom(valueIndex))
            {
                // implies we're full
                throw new InvalidOperationException();
            }

            ref string storeInto = ref GetValueReference(valueIndex);
            storeInto = value;
            bitfield |= bitIndexAsMask;
        }

        public bool TryGetValue(HeaderNames name, [NotNullWhen(returnValue: true)] out string? value)
        {
            var nameAsByte = (byte)name;

            // figure out which ulong we're going to read, and the bit of in that ulong we're going to check
            var bitfieldIndex = Math.DivRem(nameAsByte, 64, out var bitIndex);
            ref ulong bitfield = ref GetBitfield(bitfieldIndex);

            var bitIndexAsMask = (1UL << bitIndex);

            var notSet = (bitfield & bitIndexAsMask) == 0;   // the JIT 
            if (notSet)
            {
                value = null;
                return false;
            }

            // we know we're set, so figure out where it'd be stored
            // figure out which _value_ index we're going to stash the value in
            var bitsSetBeforeBitfield = GetBitsSetBeforeBitfield(bitfieldIndex);
            var bitsSetBeforeBitfieldIndex = Helpers.BitsSetBeforeIndex_Naive(bitfield, (byte)bitIndex);

            var valueIndex = bitsSetBeforeBitfieldIndex + bitsSetBeforeBitfield;

            value = GetValueReference(valueIndex);
            return true;
        }

        public static PackedHeaders_V1 CreateEmpty()
        => new PackedHeaders_V1();

        public static PackedHeaders_V1 CreateFromDictionary(Dictionary<HeaderNames, string> dict)
        {
            if (dict.Count > Constants.MaximumSetHeaders)
            {
                throw new ArgumentException(nameof(dict));
            }

            var ret = new PackedHeaders_V1();
            foreach (var kv in dict)
            {
                ret.SetKnownGood(kv.Key, kv.Value);
            }

            return ret;
        }

        // this only has one call site and it's hot, so hint that we should inline
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SetKnownGood(HeaderNames name, string value)
        {
            var nameAsByte = (byte)name;

            // figure out which ulong we're going into, and the bit of in that ulong we're going to set
            var bitfieldIndex = Math.DivRem(nameAsByte, 64, out var bitIndex);
            ref ulong bitfield = ref GetBitfield(bitfieldIndex);

            var bitIndexAsMask = (1UL << bitIndex);

            // no need to check if there are dupes, we know there aren't

            // figure out which _value_ index we're going to stash the value in
            var bitsSetBeforeBitfield = GetBitsSetBeforeBitfield(bitfieldIndex);
            var bitsSetBeforeBitfieldIndex = Helpers.BitsSetBeforeIndex_Naive(bitfield, (byte)bitIndex);

            var valueIndex = bitsSetBeforeBitfieldIndex + bitsSetBeforeBitfield;

            // make space
            TryShiftValuesDownFrom(valueIndex);

            // no need to bail on too many values, we know we don't have any

            ref string storeInto = ref GetValueReference(valueIndex);
            storeInto = value;
            bitfield |= bitIndexAsMask;
        }

        // this ends up backing all the setters
        // we can pre-calculate some of this stuff so setting by name is a little faster than
        // a normal Set
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]  // this is super hot so optimize, but it's a bit big to inline
        private void SetNull(ref ulong bitfield, byte bitsSetBeforeBitfield, byte bitIndex, string? value)
        {
            value = value ?? throw new ArgumentNullException(value);

            var bitIndexAsMask = (1UL << bitIndex);

            // explode if we've already set that value
            var alreadySet = (bitfield & bitIndexAsMask) != 0;
            if (alreadySet)
            {
                throw new InvalidOperationException();
            }

            // figure out which _value_ index we're going to stash the value in
            var bitsSetBeforeBitfieldIndex = Helpers.BitsSetBeforeIndex_Naive(bitfield, bitIndex);

            var valueIndex = bitsSetBeforeBitfieldIndex + bitsSetBeforeBitfield;

            // make space
            if (!TryShiftValuesDownFrom(valueIndex))
            {
                // implies we're full
                throw new InvalidOperationException();
            }

            ref string storeInto = ref GetValueReference(valueIndex);
            storeInto = value;
            bitfield |= bitIndexAsMask;
        }

        // this ends up backing all the getters
        // we can pre-calculate some of this stuff so reading by name is a little faster than
        // a normal TryGetValue
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]  // this is super hot so optimize, but it's a bit big to inline
        private string? GetOrDefault(ref ulong bitfield, byte bitsSetBeforeBitfield, byte bitIndex)
        {
            var bitIndexAsMask = (1UL << bitIndex);

            var notSet = (bitfield & bitIndexAsMask) == 0;
            if (notSet)
            {
                return null;
            }

            // we know we're set, so figure out where it'd be stored
            // figure out which _value_ index we're going to stash the value in
            var bitsSetBeforeBitfieldIndex = Helpers.BitsSetBeforeIndex_Naive(bitfield, bitIndex);

            var valueIndex = bitsSetBeforeBitfieldIndex + bitsSetBeforeBitfield;

            return GetValueReference(valueIndex);
        }

        private ref string GetValueReference(int index)
        {
            switch (index)
            {
                case 0: return ref data.data0;
                case 1: return ref data.data1;
                case 2: return ref data.data2;
                case 3: return ref data.data3;
                case 4: return ref data.data4;
                case 5: return ref data.data5;
                case 6: return ref data.data6;
                case 7: return ref data.data7;
                case 8: return ref data.data8;
                case 9: return ref data.data9;
                default: throw new InvalidOperationException();
            }
        }

        // this is quite hot, inline this despite it having weird control flow
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool TryShiftValuesDownFrom(int index)
        {
            if (data.data9 != null)
            {
                return false;
            }

            switch (index)
            {
                case 0:
                    data.data9 = data.data8;
                    data.data8 = data.data7;
                    data.data7 = data.data6;
                    data.data6 = data.data5;
                    data.data5 = data.data4;
                    data.data4 = data.data3;
                    data.data3 = data.data2;
                    data.data2 = data.data1;
                    data.data1 = data.data0;
                    break;
                case 1:
                    data.data9 = data.data8;
                    data.data8 = data.data7;
                    data.data7 = data.data6;
                    data.data6 = data.data5;
                    data.data5 = data.data4;
                    data.data4 = data.data3;
                    data.data3 = data.data2;
                    data.data2 = data.data1;
                    break;
                case 2:
                    data.data9 = data.data8;
                    data.data8 = data.data7;
                    data.data7 = data.data6;
                    data.data6 = data.data5;
                    data.data5 = data.data4;
                    data.data4 = data.data3;
                    data.data3 = data.data2;
                    break;
                case 3:
                    data.data9 = data.data8;
                    data.data8 = data.data7;
                    data.data7 = data.data6;
                    data.data6 = data.data5;
                    data.data5 = data.data4;
                    data.data4 = data.data3;
                    break;
                case 4:
                    data.data9 = data.data8;
                    data.data8 = data.data7;
                    data.data7 = data.data6;
                    data.data6 = data.data5;
                    data.data5 = data.data4;
                    break;
                case 5:
                    data.data9 = data.data8;
                    data.data8 = data.data7;
                    data.data7 = data.data6;
                    data.data6 = data.data5;
                    break;
                case 6:
                    data.data9 = data.data8;
                    data.data8 = data.data7;
                    data.data7 = data.data6;
                    break;
                case 7:
                    data.data9 = data.data8;
                    data.data8 = data.data7;
                    break;
                case 8:
                    data.data9 = data.data8;
                    break;
                case 9:
                    break;
                default: throw new InvalidOperationException();
            }

            return true;
        }

        // this is quite hot, inline this despite it having weird control flow
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ref ulong GetBitfield(int index)
        {
            switch (index)
            {
                case 0: return ref bitfield.bitfield0;
                case 1: return ref bitfield.bitfield1;
                case 2: return ref bitfield.bitfield2;
                default: throw new InvalidOperationException();
            }
        }

        // this is quite hot, inline this despite it having weird control flow
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private byte GetBitsSetBeforeBitfield(int index)
        {
            switch (index)
            {
                case 0: return 0;
                case 1: return Bitfield0SetBits();
                case 2: return Bitfield01SetBits();
                default: throw new InvalidOperationException();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private byte Bitfield0SetBits()
        => Helpers.CountSetBits_Naive(bitfield.bitfield0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private byte Bitfield01SetBits()
        => (byte)(Helpers.CountSetBits_Naive(bitfield.bitfield0) + Helpers.CountSetBits_Naive(bitfield.bitfield1));
    }
}
