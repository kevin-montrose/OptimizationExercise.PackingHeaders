using OptimizationExercise.PackingHeaders.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace OptimizationExercise.PackingHeaders.FieldsImpl
{
    public sealed class FieldHeaders_V2 : IHeadersStructure<FieldHeaders_V2, FieldHeaders_V2.Enumerator>
    {
        public struct Enumerator : IEnumerator<HeaderNames>
        {
            private readonly FieldHeaders_V2 outer;

            private byte nextValue;
            private byte numYielded;

            public HeaderNames Current { get; private set; }

            object IEnumerator.Current
            => Current;

            internal Enumerator(FieldHeaders_V2 outer)
            {
                this.outer = outer;
                nextValue = 0;
                numYielded = 0;
                Current = default;
            }

            public bool MoveNext()
            {
                if (numYielded == Constants.MaximumSetHeaders)
                {
                    return false;
                }

                ref string? dataStart = ref outer.data.aardvark;

                while (nextValue < Constants.HeaderNamesCount)
                {
                    var checkValue = nextValue;
                    nextValue++;

                    if (Unsafe.Add(ref dataStart, checkValue) != null)
                    {
                        Current = (HeaderNames)checkValue;
                        return true;
                    }
                }

                return false;
            }

            public void Reset()
            {
                throw new NotSupportedException();
            }


            public void Dispose() { }
        }

        private int numSet;

        private FieldData data;

        #region direct access by name
        public string? Aardvark { get => data.aardvark; set => SetChecked(ref data.aardvark, value); }
        public string? Albatross { get => data.albatross; set => SetChecked(ref data.albatross, value); }
        public string? Alligator { get => data.alligator; set => SetChecked(ref data.alligator, value); }
        public string? Anteater { get => data.anteater; set => SetChecked(ref data.anteater, value); }
        public string? Antelope { get => data.antelope; set => SetChecked(ref data.antelope, value); }
        public string? Bat { get => data.bat; set => SetChecked(ref data.bat, value); }
        public string? Beaver { get => data.beaver; set => SetChecked(ref data.beaver, value); }
        public string? Bee { get => data.bee; set => SetChecked(ref data.bee, value); }
        public string? Beetle { get => data.beetle; set => SetChecked(ref data.beetle, value); }
        public string? Binturong { get => data.binturong; set => SetChecked(ref data.binturong, value); }
        public string? Bird { get => data.bird; set => SetChecked(ref data.bird, value); }
        public string? Boar { get => data.boar; set => SetChecked(ref data.boar, value); }
        public string? Buffalo { get => data.buffalo; set => SetChecked(ref data.buffalo, value); }
        public string? Butterfly { get => data.butterfly; set => SetChecked(ref data.butterfly, value); }
        public string? Camel { get => data.camel; set => SetChecked(ref data.camel, value); }
        public string? Capybara { get => data.capybara; set => SetChecked(ref data.capybara, value); }
        public string? Caracal { get => data.caracal; set => SetChecked(ref data.caracal, value); }
        public string? Cat { get => data.cat; set => SetChecked(ref data.cat, value); }
        public string? Cattle { get => data.cattle; set => SetChecked(ref data.cattle, value); }
        public string? Chamois { get => data.chamois; set => SetChecked(ref data.chamois, value); }
        public string? Chicken { get => data.chicken; set => SetChecked(ref data.chicken, value); }
        public string? Chimpanzee { get => data.chimpanzee; set => SetChecked(ref data.chimpanzee, value); }
        public string? Chinchilla { get => data.chinchilla; set => SetChecked(ref data.chinchilla, value); }
        public string? Coati { get => data.coati; set => SetChecked(ref data.coati, value); }
        public string? Cockroach { get => data.cockroach; set => SetChecked(ref data.cockroach, value); }
        public string? Cormorant { get => data.cormorant; set => SetChecked(ref data.cormorant, value); }
        public string? Cow { get => data.cow; set => SetChecked(ref data.cow, value); }
        public string? Crab { get => data.crab; set => SetChecked(ref data.crab, value); }
        public string? Crocodile { get => data.crocodile; set => SetChecked(ref data.crocodile, value); }
        public string? Cuckoo { get => data.cuckoo; set => SetChecked(ref data.cuckoo, value); }
        public string? Curlew { get => data.curlew; set => SetChecked(ref data.curlew, value); }
        public string? Deer { get => data.deer; set => SetChecked(ref data.deer, value); }
        public string? Dhole { get => data.dhole; set => SetChecked(ref data.dhole, value); }
        public string? Dinosaur { get => data.dinosaur; set => SetChecked(ref data.dinosaur, value); }
        public string? Dog { get => data.dog; set => SetChecked(ref data.dog, value); }
        public string? Dogfish { get => data.dogfish; set => SetChecked(ref data.dogfish, value); }
        public string? Dolphin { get => data.dolphin; set => SetChecked(ref data.dolphin, value); }
        public string? Donkey { get => data.donkey; set => SetChecked(ref data.donkey, value); }
        public string? Dragonfly { get => data.dragonfly; set => SetChecked(ref data.dragonfly, value); }
        public string? Duck { get => data.duck; set => SetChecked(ref data.duck, value); }
        public string? Dugong { get => data.dugong; set => SetChecked(ref data.dugong, value); }
        public string? Eland { get => data.eland; set => SetChecked(ref data.eland, value); }
        public string? Elephant { get => data.elephant; set => SetChecked(ref data.elephant, value); }
        public string? Elk { get => data.elk; set => SetChecked(ref data.elk, value); }
        public string? Emu { get => data.emu; set => SetChecked(ref data.emu, value); }
        public string? Falcon { get => data.falcon; set => SetChecked(ref data.falcon, value); }
        public string? Ferret { get => data.ferret; set => SetChecked(ref data.ferret, value); }
        public string? Fish { get => data.fish; set => SetChecked(ref data.fish, value); }
        public string? Fossa { get => data.fossa; set => SetChecked(ref data.fossa, value); }
        public string? Fox { get => data.fox; set => SetChecked(ref data.fox, value); }
        public string? Frog { get => data.frog; set => SetChecked(ref data.frog, value); }
        public string? Gaur { get => data.gaur; set => SetChecked(ref data.gaur, value); }
        public string? Gazelle { get => data.gazelle; set => SetChecked(ref data.gazelle, value); }
        public string? Gecko { get => data.gecko; set => SetChecked(ref data.gecko, value); }
        public string? Genet { get => data.genet; set => SetChecked(ref data.genet, value); }
        public string? Gerbil { get => data.gerbil; set => SetChecked(ref data.gerbil, value); }
        public string? Gnat { get => data.gnat; set => SetChecked(ref data.gnat, value); }
        public string? Gnu { get => data.gnu; set => SetChecked(ref data.gnu, value); }
        public string? Goat { get => data.goat; set => SetChecked(ref data.goat, value); }
        public string? Goldfinch { get => data.goldfinch; set => SetChecked(ref data.goldfinch, value); }
        public string? Goosander { get => data.goosander; set => SetChecked(ref data.goosander, value); }
        public string? Gorilla { get => data.gorilla; set => SetChecked(ref data.gorilla, value); }
        public string? Goshawk { get => data.goshawk; set => SetChecked(ref data.goshawk, value); }
        public string? Grasshopper { get => data.grasshopper; set => SetChecked(ref data.grasshopper, value); }
        public string? Grouse { get => data.grouse; set => SetChecked(ref data.grouse, value); }
        public string? Guanaco { get => data.guanaco; set => SetChecked(ref data.guanaco, value); }
        public string? Gull { get => data.gull; set => SetChecked(ref data.gull, value); }
        public string? Hamster { get => data.hamster; set => SetChecked(ref data.hamster, value); }
        public string? Hare { get => data.hare; set => SetChecked(ref data.hare, value); }
        public string? Hawk { get => data.hawk; set => SetChecked(ref data.hawk, value); }
        public string? Hedgehog { get => data.hedgehog; set => SetChecked(ref data.hedgehog, value); }
        public string? Heron { get => data.heron; set => SetChecked(ref data.heron, value); }
        public string? Herring { get => data.herring; set => SetChecked(ref data.herring, value); }
        public string? Hoatzin { get => data.hoatzin; set => SetChecked(ref data.hoatzin, value); }
        public string? Hoopoe { get => data.hoopoe; set => SetChecked(ref data.hoopoe, value); }
        public string? Hornet { get => data.hornet; set => SetChecked(ref data.hornet, value); }
        public string? Horse { get => data.horse; set => SetChecked(ref data.horse, value); }
        public string? Hummingbird { get => data.hummingbird; set => SetChecked(ref data.hummingbird, value); }
        public string? Hyena { get => data.hyena; set => SetChecked(ref data.hyena, value); }
        public string? Ibis { get => data.ibis; set => SetChecked(ref data.ibis, value); }
        public string? Iguana { get => data.iguana; set => SetChecked(ref data.iguana, value); }
        public string? Jackal { get => data.jackal; set => SetChecked(ref data.jackal, value); }
        public string? Jaguar { get => data.jaguar; set => SetChecked(ref data.jaguar, value); }
        public string? Jay { get => data.jay; set => SetChecked(ref data.jay, value); }
        public string? Kingbird { get => data.kingbird; set => SetChecked(ref data.kingbird, value); }
        public string? Kingfisher { get => data.kingfisher; set => SetChecked(ref data.kingfisher, value); }
        public string? Kinkajou { get => data.kinkajou; set => SetChecked(ref data.kinkajou, value); }
        public string? Kodkod { get => data.kodkod; set => SetChecked(ref data.kodkod, value); }
        public string? Kookaburra { get => data.kookaburra; set => SetChecked(ref data.kookaburra, value); }
        public string? Kowari { get => data.kowari; set => SetChecked(ref data.kowari, value); }
        public string? Langur { get => data.langur; set => SetChecked(ref data.langur, value); }
        public string? Lapwing { get => data.lapwing; set => SetChecked(ref data.lapwing, value); }
        public string? Lark { get => data.lark; set => SetChecked(ref data.lark, value); }
        public string? Lechwe { get => data.lechwe; set => SetChecked(ref data.lechwe, value); }
        public string? Lemur { get => data.lemur; set => SetChecked(ref data.lemur, value); }
        public string? Lizard { get => data.lizard; set => SetChecked(ref data.lizard, value); }
        public string? Llama { get => data.llama; set => SetChecked(ref data.llama, value); }
        public string? Locust { get => data.locust; set => SetChecked(ref data.locust, value); }
        public string? Lyrebird { get => data.lyrebird; set => SetChecked(ref data.lyrebird, value); }
        public string? Macaque { get => data.macaque; set => SetChecked(ref data.macaque, value); }
        public string? Macaw { get => data.macaw; set => SetChecked(ref data.macaw, value); }
        public string? Mallard { get => data.mallard; set => SetChecked(ref data.mallard, value); }
        public string? Mammoth { get => data.mammoth; set => SetChecked(ref data.mammoth, value); }
        public string? Manatee { get => data.manatee; set => SetChecked(ref data.manatee, value); }
        public string? Mandrill { get => data.mandrill; set => SetChecked(ref data.mandrill, value); }
        public string? Marmoset { get => data.marmoset; set => SetChecked(ref data.marmoset, value); }
        public string? Marmot { get => data.marmot; set => SetChecked(ref data.marmot, value); }
        public string? Meerkat { get => data.meerkat; set => SetChecked(ref data.meerkat, value); }
        public string? Mink { get => data.mink; set => SetChecked(ref data.mink, value); }
        public string? Mongoose { get => data.mongoose; set => SetChecked(ref data.mongoose, value); }
        public string? Monkey { get => data.monkey; set => SetChecked(ref data.monkey, value); }
        public string? Moose { get => data.moose; set => SetChecked(ref data.moose, value); }
        public string? Mouse { get => data.mouse; set => SetChecked(ref data.mouse, value); }
        public string? Myna { get => data.myna; set => SetChecked(ref data.myna, value); }
        public string? Narwhal { get => data.narwhal; set => SetChecked(ref data.narwhal, value); }
        public string? Newt { get => data.newt; set => SetChecked(ref data.newt, value); }
        public string? Nightingale { get => data.nightingale; set => SetChecked(ref data.nightingale, value); }
        public string? Nilgai { get => data.nilgai; set => SetChecked(ref data.nilgai, value); }
        public string? Ocelot { get => data.ocelot; set => SetChecked(ref data.ocelot, value); }
        public string? Octopus { get => data.octopus; set => SetChecked(ref data.octopus, value); }
        public string? Okapi { get => data.okapi; set => SetChecked(ref data.okapi, value); }
        public string? Olingo { get => data.olingo; set => SetChecked(ref data.olingo, value); }
        public string? Opossum { get => data.opossum; set => SetChecked(ref data.opossum, value); }
        public string? Ostrich { get => data.ostrich; set => SetChecked(ref data.ostrich, value); }
        public string? Owl { get => data.owl; set => SetChecked(ref data.owl, value); }
        public string? Ox { get => data.ox; set => SetChecked(ref data.ox, value); }
        public string? Oyster { get => data.oyster; set => SetChecked(ref data.oyster, value); }
        public string? Panda { get => data.panda; set => SetChecked(ref data.panda, value); }
        public string? Panther { get => data.panther; set => SetChecked(ref data.panther, value); }
        public string? Peafowl { get => data.peafowl; set => SetChecked(ref data.peafowl, value); }
        public string? Pelican { get => data.pelican; set => SetChecked(ref data.pelican, value); }
        public string? Penguin { get => data.penguin; set => SetChecked(ref data.penguin, value); }
        public string? Pheasant { get => data.pheasant; set => SetChecked(ref data.pheasant, value); }
        public string? Pig { get => data.pig; set => SetChecked(ref data.pig, value); }
        public string? Pigeon { get => data.pigeon; set => SetChecked(ref data.pigeon, value); }
        public string? Pika { get => data.pika; set => SetChecked(ref data.pika, value); }
        public string? Pony { get => data.pony; set => SetChecked(ref data.pony, value); }
        public string? Porpoise { get => data.porpoise; set => SetChecked(ref data.porpoise, value); }
        public string? Pug { get => data.pug; set => SetChecked(ref data.pug, value); }
        public string? Quail { get => data.quail; set => SetChecked(ref data.quail, value); }
        public string? Quetzal { get => data.quetzal; set => SetChecked(ref data.quetzal, value); }
        public string? Rabbit { get => data.rabbit; set => SetChecked(ref data.rabbit, value); }
        public string? Raccoon { get => data.raccoon; set => SetChecked(ref data.raccoon, value); }
        public string? Ram { get => data.ram; set => SetChecked(ref data.ram, value); }
        public string? Rat { get => data.rat; set => SetChecked(ref data.rat, value); }
        public string? Reindeer { get => data.reindeer; set => SetChecked(ref data.reindeer, value); }
        public string? Rhea { get => data.rhea; set => SetChecked(ref data.rhea, value); }
        public string? Rhinoceros { get => data.rhinoceros; set => SetChecked(ref data.rhinoceros, value); }
        public string? Rook { get => data.rook; set => SetChecked(ref data.rook, value); }
        public string? Salamander { get => data.salamander; set => SetChecked(ref data.salamander, value); }
        public string? Sandpiper { get => data.sandpiper; set => SetChecked(ref data.sandpiper, value); }
        public string? Sardine { get => data.sardine; set => SetChecked(ref data.sardine, value); }
        public string? Sassaby { get => data.sassaby; set => SetChecked(ref data.sassaby, value); }
        public string? Seahorse { get => data.seahorse; set => SetChecked(ref data.seahorse, value); }
        public string? Seal { get => data.seal; set => SetChecked(ref data.seal, value); }
        public string? Serval { get => data.serval; set => SetChecked(ref data.serval, value); }
        public string? Sheep { get => data.sheep; set => SetChecked(ref data.sheep, value); }
        public string? Shrike { get => data.shrike; set => SetChecked(ref data.shrike, value); }
        public string? Siamang { get => data.siamang; set => SetChecked(ref data.siamang, value); }
        public string? Skink { get => data.skink; set => SetChecked(ref data.skink, value); }
        public string? Skipper { get => data.skipper; set => SetChecked(ref data.skipper, value); }
        public string? Skunk { get => data.skunk; set => SetChecked(ref data.skunk, value); }
        public string? Sloth { get => data.sloth; set => SetChecked(ref data.sloth, value); }
        public string? Snake { get => data.snake; set => SetChecked(ref data.snake, value); }
        public string? Spider { get => data.spider; set => SetChecked(ref data.spider, value); }
        public string? Spoonbill { get => data.spoonbill; set => SetChecked(ref data.spoonbill, value); }
        public string? Squid { get => data.squid; set => SetChecked(ref data.squid, value); }
        public string? Squirrel { get => data.squirrel; set => SetChecked(ref data.squirrel, value); }
        public string? Starfish { get => data.starfish; set => SetChecked(ref data.starfish, value); }
        public string? Tamarin { get => data.tamarin; set => SetChecked(ref data.tamarin, value); }
        public string? Tapir { get => data.tapir; set => SetChecked(ref data.tapir, value); }
        public string? Tarsier { get => data.tarsier; set => SetChecked(ref data.tarsier, value); }
        public string? Termite { get => data.termite; set => SetChecked(ref data.termite, value); }
        public string? Tiger { get => data.tiger; set => SetChecked(ref data.tiger, value); }
        public string? Toad { get => data.toad; set => SetChecked(ref data.toad, value); }
        public string? Toucan { get => data.toucan; set => SetChecked(ref data.toucan, value); }
        public string? Turaco { get => data.turaco; set => SetChecked(ref data.turaco, value); }
        public string? Turtle { get => data.turtle; set => SetChecked(ref data.turtle, value); }
        public string? Viper { get => data.viper; set => SetChecked(ref data.viper, value); }
        public string? Vulture { get => data.vulture; set => SetChecked(ref data.vulture, value); }
        public string? Wallaby { get => data.wallaby; set => SetChecked(ref data.wallaby, value); }
        public string? Wasp { get => data.wasp; set => SetChecked(ref data.wasp, value); }
        public string? Wildebeest { get => data.wildebeest; set => SetChecked(ref data.wildebeest, value); }
        public string? Wobbegong { get => data.wobbegong; set => SetChecked(ref data.wobbegong, value); }
        public string? Wolf { get => data.wolf; set => SetChecked(ref data.wolf, value); }
        public string? Wolverine { get => data.wolverine; set => SetChecked(ref data.wolverine, value); }
        public string? Wombat { get => data.wombat; set => SetChecked(ref data.wombat, value); }
        public string? Woodpecker { get => data.woodpecker; set => SetChecked(ref data.woodpecker, value); }
        public string? Worm { get => data.worm; set => SetChecked(ref data.worm, value); }
        public string? Wren { get => data.wren; set => SetChecked(ref data.wren, value); }
        public string? Yak { get => data.yak; set => SetChecked(ref data.yak, value); }
        public string? Zebra { get => data.zebra; set => SetChecked(ref data.zebra, value); }
        #endregion

        private FieldHeaders_V2()
        {
        }

        public Enumerator GetEnumerator()
        => new Enumerator(this);

        public bool TryGetValue(HeaderNames name, [NotNullWhen(returnValue: true)] out string? value)
        {
            value = Unsafe.Add(ref data.aardvark, (int)name);
            return value != null;
        }

        public void Set(HeaderNames name, string value)
        {
            if (numSet == Constants.MaximumSetHeaders)
            {
                // too many set
                throw new InvalidOperationException();
            }

            ref string? field = ref Unsafe.Add(ref data.aardvark, (int)name);
            if(field != null)
            {
                // can't set twice
                throw new ArgumentException();
            }

            field = value;

            numSet++;
        }

        public static FieldHeaders_V2 CreateEmpty()
        => new FieldHeaders_V2();

        public static FieldHeaders_V2 CreateFromDictionary(Dictionary<HeaderNames, string> dict)
        {
            if (dict.Count > Constants.MaximumSetHeaders)
            {
                throw new ArgumentException(nameof(dict));
            }

            var ret = new FieldHeaders_V2();
            foreach (var kv in dict)
            {
                ref string? field = ref Unsafe.Add(ref ret.data.aardvark, (int)kv.Key);
                field = kv.Value;
            }

            return ret;
        }

        // setting should be as close to just updating the field as possible, so inline the hell out of this
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SetChecked(ref string? oldValue, string? value)
        {
            if (oldValue != null)
            {
                // can't set twice
                throw new InvalidOperationException();
            }

            if (numSet == Constants.MaximumSetHeaders)
            {
                // too many set
                throw new InvalidOperationException();
            }

            value = value ?? throw new ArgumentNullException(nameof(value));

            oldValue = value;
            numSet++;
        }
    }
}
