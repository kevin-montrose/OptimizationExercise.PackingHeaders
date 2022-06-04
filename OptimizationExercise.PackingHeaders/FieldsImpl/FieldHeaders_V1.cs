using OptimizationExercise.PackingHeaders.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace OptimizationExercise.PackingHeaders.FieldsImpl
{
    public sealed class FieldHeaders_V1 : IHeadersStructure<FieldHeaders_V1, FieldHeaders_V1.Enumerator>
    {
        public struct Enumerator : IEnumerator<HeaderNames>
        {
            private readonly FieldHeaders_V1 outer;

            private byte nextValue;
            private byte numYielded;

            public HeaderNames Current { get; private set; }

            object IEnumerator.Current
            => Current;

            internal Enumerator(FieldHeaders_V1 outer)
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

                while (nextValue < Constants.HeaderNamesCount)
                {
                    var header = (HeaderNames)nextValue;
                    nextValue++;
                    if (outer.TryGetValue(header, out _))
                    {
                        Current = header;
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

        #region header value fields
        private string? aardvark;
        private string? albatross;
        private string? alligator;
        private string? anteater;
        private string? antelope;
        private string? bat;
        private string? beaver;
        private string? bee;
        private string? beetle;
        private string? binturong;
        private string? bird;
        private string? boar;
        private string? buffalo;
        private string? butterfly;
        private string? camel;
        private string? capybara;
        private string? caracal;
        private string? cat;
        private string? cattle;
        private string? chamois;
        private string? chicken;
        private string? chimpanzee;
        private string? chinchilla;
        private string? coati;
        private string? cockroach;
        private string? cormorant;
        private string? cow;
        private string? crab;
        private string? crocodile;
        private string? cuckoo;
        private string? curlew;
        private string? deer;
        private string? dhole;
        private string? dinosaur;
        private string? dog;
        private string? dogfish;
        private string? dolphin;
        private string? donkey;
        private string? dragonfly;
        private string? duck;
        private string? dugong;
        private string? eland;
        private string? elephant;
        private string? elk;
        private string? emu;
        private string? falcon;
        private string? ferret;
        private string? fish;
        private string? fossa;
        private string? fox;
        private string? frog;
        private string? gaur;
        private string? gazelle;
        private string? gecko;
        private string? genet;
        private string? gerbil;
        private string? gnat;
        private string? gnu;
        private string? goat;
        private string? goldfinch;
        private string? goosander;
        private string? gorilla;
        private string? goshawk;
        private string? grasshopper;
        private string? grouse;
        private string? guanaco;
        private string? gull;
        private string? hamster;
        private string? hare;
        private string? hawk;
        private string? hedgehog;
        private string? heron;
        private string? herring;
        private string? hoatzin;
        private string? hoopoe;
        private string? hornet;
        private string? horse;
        private string? hummingbird;
        private string? hyena;
        private string? ibis;
        private string? iguana;
        private string? jackal;
        private string? jaguar;
        private string? jay;
        private string? kingbird;
        private string? kingfisher;
        private string? kinkajou;
        private string? kodkod;
        private string? kookaburra;
        private string? kowari;
        private string? langur;
        private string? lapwing;
        private string? lark;
        private string? lechwe;
        private string? lemur;
        private string? lizard;
        private string? llama;
        private string? locust;
        private string? lyrebird;
        private string? macaque;
        private string? macaw;
        private string? mallard;
        private string? mammoth;
        private string? manatee;
        private string? mandrill;
        private string? marmoset;
        private string? marmot;
        private string? meerkat;
        private string? mink;
        private string? mongoose;
        private string? monkey;
        private string? moose;
        private string? mouse;
        private string? myna;
        private string? narwhal;
        private string? newt;
        private string? nightingale;
        private string? nilgai;
        private string? ocelot;
        private string? octopus;
        private string? okapi;
        private string? olingo;
        private string? opossum;
        private string? ostrich;
        private string? owl;
        private string? ox;
        private string? oyster;
        private string? panda;
        private string? panther;
        private string? peafowl;
        private string? pelican;
        private string? penguin;
        private string? pheasant;
        private string? pig;
        private string? pigeon;
        private string? pika;
        private string? pony;
        private string? porpoise;
        private string? pug;
        private string? quail;
        private string? quetzal;
        private string? rabbit;
        private string? raccoon;
        private string? ram;
        private string? rat;
        private string? reindeer;
        private string? rhea;
        private string? rhinoceros;
        private string? rook;
        private string? salamander;
        private string? sandpiper;
        private string? sardine;
        private string? sassaby;
        private string? seahorse;
        private string? seal;
        private string? serval;
        private string? sheep;
        private string? shrike;
        private string? siamang;
        private string? skink;
        private string? skipper;
        private string? skunk;
        private string? sloth;
        private string? snake;
        private string? spider;
        private string? spoonbill;
        private string? squid;
        private string? squirrel;
        private string? starfish;
        private string? tamarin;
        private string? tapir;
        private string? tarsier;
        private string? termite;
        private string? tiger;
        private string? toad;
        private string? toucan;
        private string? turaco;
        private string? turtle;
        private string? viper;
        private string? vulture;
        private string? wallaby;
        private string? wasp;
        private string? wildebeest;
        private string? wobbegong;
        private string? wolf;
        private string? wolverine;
        private string? wombat;
        private string? woodpecker;
        private string? worm;
        private string? wren;
        private string? yak;
        private string? zebra;
        #endregion

        #region direct access by name
        public string? Aardvark { get => aardvark; set => SetChecked(ref aardvark, value); }
        public string? Albatross { get => albatross; set => SetChecked(ref albatross, value); }
        public string? Alligator { get => alligator; set => SetChecked(ref alligator, value); }
        public string? Anteater { get => anteater; set => SetChecked(ref anteater, value); }
        public string? Antelope { get => antelope; set => SetChecked(ref antelope, value); }
        public string? Bat { get => bat; set => SetChecked(ref bat, value); }
        public string? Beaver { get => beaver; set => SetChecked(ref beaver, value); }
        public string? Bee { get => bee; set => SetChecked(ref bee, value); }
        public string? Beetle { get => beetle; set => SetChecked(ref beetle, value); }
        public string? Binturong { get => binturong; set => SetChecked(ref binturong, value); }
        public string? Bird { get => bird; set => SetChecked(ref bird, value); }
        public string? Boar { get => boar; set => SetChecked(ref boar, value); }
        public string? Buffalo { get => buffalo; set => SetChecked(ref buffalo, value); }
        public string? Butterfly { get => butterfly; set => SetChecked(ref butterfly, value); }
        public string? Camel { get => camel; set => SetChecked(ref camel, value); }
        public string? Capybara { get => capybara; set => SetChecked(ref capybara, value); }
        public string? Caracal { get => caracal; set => SetChecked(ref caracal, value); }
        public string? Cat { get => cat; set => SetChecked(ref cat, value); }
        public string? Cattle { get => cattle; set => SetChecked(ref cattle, value); }
        public string? Chamois { get => chamois; set => SetChecked(ref chamois, value); }
        public string? Chicken { get => chicken; set => SetChecked(ref chicken, value); }
        public string? Chimpanzee { get => chimpanzee; set => SetChecked(ref chimpanzee, value); }
        public string? Chinchilla { get => chinchilla; set => SetChecked(ref chinchilla, value); }
        public string? Coati { get => coati; set => SetChecked(ref coati, value); }
        public string? Cockroach { get => cockroach; set => SetChecked(ref cockroach, value); }
        public string? Cormorant { get => cormorant; set => SetChecked(ref cormorant, value); }
        public string? Cow { get => cow; set => SetChecked(ref cow, value); }
        public string? Crab { get => crab; set => SetChecked(ref crab, value); }
        public string? Crocodile { get => crocodile; set => SetChecked(ref crocodile, value); }
        public string? Cuckoo { get => cuckoo; set => SetChecked(ref cuckoo, value); }
        public string? Curlew { get => curlew; set => SetChecked(ref curlew, value); }
        public string? Deer { get => deer; set => SetChecked(ref deer, value); }
        public string? Dhole { get => dhole; set => SetChecked(ref dhole, value); }
        public string? Dinosaur { get => dinosaur; set => SetChecked(ref dinosaur, value); }
        public string? Dog { get => dog; set => SetChecked(ref dog, value); }
        public string? Dogfish { get => dogfish; set => SetChecked(ref dogfish, value); }
        public string? Dolphin { get => dolphin; set => SetChecked(ref dolphin, value); }
        public string? Donkey { get => donkey; set => SetChecked(ref donkey, value); }
        public string? Dragonfly { get => dragonfly; set => SetChecked(ref dragonfly, value); }
        public string? Duck { get => duck; set => SetChecked(ref duck, value); }
        public string? Dugong { get => dugong; set => SetChecked(ref dugong, value); }
        public string? Eland { get => eland; set => SetChecked(ref eland, value); }
        public string? Elephant { get => elephant; set => SetChecked(ref elephant, value); }
        public string? Elk { get => elk; set => SetChecked(ref elk, value); }
        public string? Emu { get => emu; set => SetChecked(ref emu, value); }
        public string? Falcon { get => falcon; set => SetChecked(ref falcon, value); }
        public string? Ferret { get => ferret; set => SetChecked(ref ferret, value); }
        public string? Fish { get => fish; set => SetChecked(ref fish, value); }
        public string? Fossa { get => fossa; set => SetChecked(ref fossa, value); }
        public string? Fox { get => fox; set => SetChecked(ref fox, value); }
        public string? Frog { get => frog; set => SetChecked(ref frog, value); }
        public string? Gaur { get => gaur; set => SetChecked(ref gaur, value); }
        public string? Gazelle { get => gazelle; set => SetChecked(ref gazelle, value); }
        public string? Gecko { get => gecko; set => SetChecked(ref gecko, value); }
        public string? Genet { get => genet; set => SetChecked(ref genet, value); }
        public string? Gerbil { get => gerbil; set => SetChecked(ref gerbil, value); }
        public string? Gnat { get => gnat; set => SetChecked(ref gnat, value); }
        public string? Gnu { get => gnu; set => SetChecked(ref gnu, value); }
        public string? Goat { get => goat; set => SetChecked(ref goat, value); }
        public string? Goldfinch { get => goldfinch; set => SetChecked(ref goldfinch, value); }
        public string? Goosander { get => goosander; set => SetChecked(ref goosander, value); }
        public string? Gorilla { get => gorilla; set => SetChecked(ref gorilla, value); }
        public string? Goshawk { get => goshawk; set => SetChecked(ref goshawk, value); }
        public string? Grasshopper { get => grasshopper; set => SetChecked(ref grasshopper, value); }
        public string? Grouse { get => grouse; set => SetChecked(ref grouse, value); }
        public string? Guanaco { get => guanaco; set => SetChecked(ref guanaco, value); }
        public string? Gull { get => gull; set => SetChecked(ref gull, value); }
        public string? Hamster { get => hamster; set => SetChecked(ref hamster, value); }
        public string? Hare { get => hare; set => SetChecked(ref hare, value); }
        public string? Hawk { get => hawk; set => SetChecked(ref hawk, value); }
        public string? Hedgehog { get => hedgehog; set => SetChecked(ref hedgehog, value); }
        public string? Heron { get => heron; set => SetChecked(ref heron, value); }
        public string? Herring { get => herring; set => SetChecked(ref herring, value); }
        public string? Hoatzin { get => hoatzin; set => SetChecked(ref hoatzin, value); }
        public string? Hoopoe { get => hoopoe; set => SetChecked(ref hoopoe, value); }
        public string? Hornet { get => hornet; set => SetChecked(ref hornet, value); }
        public string? Horse { get => horse; set => SetChecked(ref horse, value); }
        public string? Hummingbird { get => hummingbird; set => SetChecked(ref hummingbird, value); }
        public string? Hyena { get => hyena; set => SetChecked(ref hyena, value); }
        public string? Ibis { get => ibis; set => SetChecked(ref ibis, value); }
        public string? Iguana { get => iguana; set => SetChecked(ref iguana, value); }
        public string? Jackal { get => jackal; set => SetChecked(ref jackal, value); }
        public string? Jaguar { get => jaguar; set => SetChecked(ref jaguar, value); }
        public string? Jay { get => jay; set => SetChecked(ref jay, value); }
        public string? Kingbird { get => kingbird; set => SetChecked(ref kingbird, value); }
        public string? Kingfisher { get => kingfisher; set => SetChecked(ref kingfisher, value); }
        public string? Kinkajou { get => kinkajou; set => SetChecked(ref kinkajou, value); }
        public string? Kodkod { get => kodkod; set => SetChecked(ref kodkod, value); }
        public string? Kookaburra { get => kookaburra; set => SetChecked(ref kookaburra, value); }
        public string? Kowari { get => kowari; set => SetChecked(ref kowari, value); }
        public string? Langur { get => langur; set => SetChecked(ref langur, value); }
        public string? Lapwing { get => lapwing; set => SetChecked(ref lapwing, value); }
        public string? Lark { get => lark; set => SetChecked(ref lark, value); }
        public string? Lechwe { get => lechwe; set => SetChecked(ref lechwe, value); }
        public string? Lemur { get => lemur; set => SetChecked(ref lemur, value); }
        public string? Lizard { get => lizard; set => SetChecked(ref lizard, value); }
        public string? Llama { get => llama; set => SetChecked(ref llama, value); }
        public string? Locust { get => locust; set => SetChecked(ref locust, value); }
        public string? Lyrebird { get => lyrebird; set => SetChecked(ref lyrebird, value); }
        public string? Macaque { get => macaque; set => SetChecked(ref macaque, value); }
        public string? Macaw { get => macaw; set => SetChecked(ref macaw, value); }
        public string? Mallard { get => mallard; set => SetChecked(ref mallard, value); }
        public string? Mammoth { get => mammoth; set => SetChecked(ref mammoth, value); }
        public string? Manatee { get => manatee; set => SetChecked(ref manatee, value); }
        public string? Mandrill { get => mandrill; set => SetChecked(ref mandrill, value); }
        public string? Marmoset { get => marmoset; set => SetChecked(ref marmoset, value); }
        public string? Marmot { get => marmot; set => SetChecked(ref marmot, value); }
        public string? Meerkat { get => meerkat; set => SetChecked(ref meerkat, value); }
        public string? Mink { get => mink; set => SetChecked(ref mink, value); }
        public string? Mongoose { get => mongoose; set => SetChecked(ref mongoose, value); }
        public string? Monkey { get => monkey; set => SetChecked(ref monkey, value); }
        public string? Moose { get => moose; set => SetChecked(ref moose, value); }
        public string? Mouse { get => mouse; set => SetChecked(ref mouse, value); }
        public string? Myna { get => myna; set => SetChecked(ref myna, value); }
        public string? Narwhal { get => narwhal; set => SetChecked(ref narwhal, value); }
        public string? Newt { get => newt; set => SetChecked(ref newt, value); }
        public string? Nightingale { get => nightingale; set => SetChecked(ref nightingale, value); }
        public string? Nilgai { get => nilgai; set => SetChecked(ref nilgai, value); }
        public string? Ocelot { get => ocelot; set => SetChecked(ref ocelot, value); }
        public string? Octopus { get => octopus; set => SetChecked(ref octopus, value); }
        public string? Okapi { get => okapi; set => SetChecked(ref okapi, value); }
        public string? Olingo { get => olingo; set => SetChecked(ref olingo, value); }
        public string? Opossum { get => opossum; set => SetChecked(ref opossum, value); }
        public string? Ostrich { get => ostrich; set => SetChecked(ref ostrich, value); }
        public string? Owl { get => owl; set => SetChecked(ref owl, value); }
        public string? Ox { get => ox; set => SetChecked(ref ox, value); }
        public string? Oyster { get => oyster; set => SetChecked(ref oyster, value); }
        public string? Panda { get => panda; set => SetChecked(ref panda, value); }
        public string? Panther { get => panther; set => SetChecked(ref panther, value); }
        public string? Peafowl { get => peafowl; set => SetChecked(ref peafowl, value); }
        public string? Pelican { get => pelican; set => SetChecked(ref pelican, value); }
        public string? Penguin { get => penguin; set => SetChecked(ref penguin, value); }
        public string? Pheasant { get => pheasant; set => SetChecked(ref pheasant, value); }
        public string? Pig { get => pig; set => SetChecked(ref pig, value); }
        public string? Pigeon { get => pigeon; set => SetChecked(ref pigeon, value); }
        public string? Pika { get => pika; set => SetChecked(ref pika, value); }
        public string? Pony { get => pony; set => SetChecked(ref pony, value); }
        public string? Porpoise { get => porpoise; set => SetChecked(ref porpoise, value); }
        public string? Pug { get => pug; set => SetChecked(ref pug, value); }
        public string? Quail { get => quail; set => SetChecked(ref quail, value); }
        public string? Quetzal { get => quetzal; set => SetChecked(ref quetzal, value); }
        public string? Rabbit { get => rabbit; set => SetChecked(ref rabbit, value); }
        public string? Raccoon { get => raccoon; set => SetChecked(ref raccoon, value); }
        public string? Ram { get => ram; set => SetChecked(ref ram, value); }
        public string? Rat { get => rat; set => SetChecked(ref rat, value); }
        public string? Reindeer { get => reindeer; set => SetChecked(ref reindeer, value); }
        public string? Rhea { get => rhea; set => SetChecked(ref rhea, value); }
        public string? Rhinoceros { get => rhinoceros; set => SetChecked(ref rhinoceros, value); }
        public string? Rook { get => rook; set => SetChecked(ref rook, value); }
        public string? Salamander { get => salamander; set => SetChecked(ref salamander, value); }
        public string? Sandpiper { get => sandpiper; set => SetChecked(ref sandpiper, value); }
        public string? Sardine { get => sardine; set => SetChecked(ref sardine, value); }
        public string? Sassaby { get => sassaby; set => SetChecked(ref sassaby, value); }
        public string? Seahorse { get => seahorse; set => SetChecked(ref seahorse, value); }
        public string? Seal { get => seal; set => SetChecked(ref seal, value); }
        public string? Serval { get => serval; set => SetChecked(ref serval, value); }
        public string? Sheep { get => sheep; set => SetChecked(ref sheep, value); }
        public string? Shrike { get => shrike; set => SetChecked(ref shrike, value); }
        public string? Siamang { get => siamang; set => SetChecked(ref siamang, value); }
        public string? Skink { get => skink; set => SetChecked(ref skink, value); }
        public string? Skipper { get => skipper; set => SetChecked(ref skipper, value); }
        public string? Skunk { get => skunk; set => SetChecked(ref skunk, value); }
        public string? Sloth { get => sloth; set => SetChecked(ref sloth, value); }
        public string? Snake { get => snake; set => SetChecked(ref snake, value); }
        public string? Spider { get => spider; set => SetChecked(ref spider, value); }
        public string? Spoonbill { get => spoonbill; set => SetChecked(ref spoonbill, value); }
        public string? Squid { get => squid; set => SetChecked(ref squid, value); }
        public string? Squirrel { get => squirrel; set => SetChecked(ref squirrel, value); }
        public string? Starfish { get => starfish; set => SetChecked(ref starfish, value); }
        public string? Tamarin { get => tamarin; set => SetChecked(ref tamarin, value); }
        public string? Tapir { get => tapir; set => SetChecked(ref tapir, value); }
        public string? Tarsier { get => tarsier; set => SetChecked(ref tarsier, value); }
        public string? Termite { get => termite; set => SetChecked(ref termite, value); }
        public string? Tiger { get => tiger; set => SetChecked(ref tiger, value); }
        public string? Toad { get => toad; set => SetChecked(ref toad, value); }
        public string? Toucan { get => toucan; set => SetChecked(ref toucan, value); }
        public string? Turaco { get => turaco; set => SetChecked(ref turaco, value); }
        public string? Turtle { get => turtle; set => SetChecked(ref turtle, value); }
        public string? Viper { get => viper; set => SetChecked(ref viper, value); }
        public string? Vulture { get => vulture; set => SetChecked(ref vulture, value); }
        public string? Wallaby { get => wallaby; set => SetChecked(ref wallaby, value); }
        public string? Wasp { get => wasp; set => SetChecked(ref wasp, value); }
        public string? Wildebeest { get => wildebeest; set => SetChecked(ref wildebeest, value); }
        public string? Wobbegong { get => wobbegong; set => SetChecked(ref wobbegong, value); }
        public string? Wolf { get => wolf; set => SetChecked(ref wolf, value); }
        public string? Wolverine { get => wolverine; set => SetChecked(ref wolverine, value); }
        public string? Wombat { get => wombat; set => SetChecked(ref wombat, value); }
        public string? Woodpecker { get => woodpecker; set => SetChecked(ref woodpecker, value); }
        public string? Worm { get => worm; set => SetChecked(ref worm, value); }
        public string? Wren { get => wren; set => SetChecked(ref wren, value); }
        public string? Yak { get => yak; set => SetChecked(ref yak, value); }
        public string? Zebra { get => zebra; set => SetChecked(ref zebra, value); }
        #endregion

        private FieldHeaders_V1()
        {
        }

        public Enumerator GetEnumerator()
        => new Enumerator(this);

        public bool TryGetValue(HeaderNames name, [NotNullWhen(returnValue: true)] out string? value)
        {
            switch (name)
            {
                case HeaderNames.Aardvark: value = aardvark; break;
                case HeaderNames.Albatross: value = albatross; break;
                case HeaderNames.Alligator: value = alligator; break;
                case HeaderNames.Anteater: value = anteater; break;
                case HeaderNames.Antelope: value = antelope; break;
                case HeaderNames.Bat: value = bat; break;
                case HeaderNames.Beaver: value = beaver; break;
                case HeaderNames.Bee: value = bee; break;
                case HeaderNames.Beetle: value = beetle; break;
                case HeaderNames.Binturong: value = binturong; break;
                case HeaderNames.Bird: value = bird; break;
                case HeaderNames.Boar: value = boar; break;
                case HeaderNames.Buffalo: value = buffalo; break;
                case HeaderNames.Butterfly: value = butterfly; break;
                case HeaderNames.Camel: value = camel; break;
                case HeaderNames.Capybara: value = capybara; break;
                case HeaderNames.Caracal: value = caracal; break;
                case HeaderNames.Cat: value = cat; break;
                case HeaderNames.Cattle: value = cattle; break;
                case HeaderNames.Chamois: value = chamois; break;
                case HeaderNames.Chicken: value = chicken; break;
                case HeaderNames.Chimpanzee: value = chimpanzee; break;
                case HeaderNames.Chinchilla: value = chinchilla; break;
                case HeaderNames.Coati: value = coati; break;
                case HeaderNames.Cockroach: value = cockroach; break;
                case HeaderNames.Cormorant: value = cormorant; break;
                case HeaderNames.Cow: value = cow; break;
                case HeaderNames.Crab: value = crab; break;
                case HeaderNames.Crocodile: value = crocodile; break;
                case HeaderNames.Cuckoo: value = cuckoo; break;
                case HeaderNames.Curlew: value = curlew; break;
                case HeaderNames.Deer: value = deer; break;
                case HeaderNames.Dhole: value = dhole; break;
                case HeaderNames.Dinosaur: value = dinosaur; break;
                case HeaderNames.Dog: value = dog; break;
                case HeaderNames.Dogfish: value = dogfish; break;
                case HeaderNames.Dolphin: value = dolphin; break;
                case HeaderNames.Donkey: value = donkey; break;
                case HeaderNames.Dragonfly: value = dragonfly; break;
                case HeaderNames.Duck: value = duck; break;
                case HeaderNames.Dugong: value = dugong; break;
                case HeaderNames.Eland: value = eland; break;
                case HeaderNames.Elephant: value = elephant; break;
                case HeaderNames.Elk: value = elk; break;
                case HeaderNames.Emu: value = emu; break;
                case HeaderNames.Falcon: value = falcon; break;
                case HeaderNames.Ferret: value = ferret; break;
                case HeaderNames.Fish: value = fish; break;
                case HeaderNames.Fossa: value = fossa; break;
                case HeaderNames.Fox: value = fox; break;
                case HeaderNames.Frog: value = frog; break;
                case HeaderNames.Gaur: value = gaur; break;
                case HeaderNames.Gazelle: value = gazelle; break;
                case HeaderNames.Gecko: value = gecko; break;
                case HeaderNames.Genet: value = genet; break;
                case HeaderNames.Gerbil: value = gerbil; break;
                case HeaderNames.Gnat: value = gnat; break;
                case HeaderNames.Gnu: value = gnu; break;
                case HeaderNames.Goat: value = goat; break;
                case HeaderNames.Goldfinch: value = goldfinch; break;
                case HeaderNames.Goosander: value = goosander; break;
                case HeaderNames.Gorilla: value = gorilla; break;
                case HeaderNames.Goshawk: value = goshawk; break;
                case HeaderNames.Grasshopper: value = grasshopper; break;
                case HeaderNames.Grouse: value = grouse; break;
                case HeaderNames.Guanaco: value = guanaco; break;
                case HeaderNames.Gull: value = gull; break;
                case HeaderNames.Hamster: value = hamster; break;
                case HeaderNames.Hare: value = hare; break;
                case HeaderNames.Hawk: value = hawk; break;
                case HeaderNames.Hedgehog: value = hedgehog; break;
                case HeaderNames.Heron: value = heron; break;
                case HeaderNames.Herring: value = herring; break;
                case HeaderNames.Hoatzin: value = hoatzin; break;
                case HeaderNames.Hoopoe: value = hoopoe; break;
                case HeaderNames.Hornet: value = hornet; break;
                case HeaderNames.Horse: value = horse; break;
                case HeaderNames.Hummingbird: value = hummingbird; break;
                case HeaderNames.Hyena: value = hyena; break;
                case HeaderNames.Ibis: value = ibis; break;
                case HeaderNames.Iguana: value = iguana; break;
                case HeaderNames.Jackal: value = jackal; break;
                case HeaderNames.Jaguar: value = jaguar; break;
                case HeaderNames.Jay: value = jay; break;
                case HeaderNames.Kingbird: value = kingbird; break;
                case HeaderNames.Kingfisher: value = kingfisher; break;
                case HeaderNames.Kinkajou: value = kinkajou; break;
                case HeaderNames.Kodkod: value = kodkod; break;
                case HeaderNames.Kookaburra: value = kookaburra; break;
                case HeaderNames.Kowari: value = kowari; break;
                case HeaderNames.Langur: value = langur; break;
                case HeaderNames.Lapwing: value = lapwing; break;
                case HeaderNames.Lark: value = lark; break;
                case HeaderNames.Lechwe: value = lechwe; break;
                case HeaderNames.Lemur: value = lemur; break;
                case HeaderNames.Lizard: value = lizard; break;
                case HeaderNames.Llama: value = llama; break;
                case HeaderNames.Locust: value = locust; break;
                case HeaderNames.Lyrebird: value = lyrebird; break;
                case HeaderNames.Macaque: value = macaque; break;
                case HeaderNames.Macaw: value = macaw; break;
                case HeaderNames.Mallard: value = mallard; break;
                case HeaderNames.Mammoth: value = mammoth; break;
                case HeaderNames.Manatee: value = manatee; break;
                case HeaderNames.Mandrill: value = mandrill; break;
                case HeaderNames.Marmoset: value = marmoset; break;
                case HeaderNames.Marmot: value = marmot; break;
                case HeaderNames.Meerkat: value = meerkat; break;
                case HeaderNames.Mink: value = mink; break;
                case HeaderNames.Mongoose: value = mongoose; break;
                case HeaderNames.Monkey: value = monkey; break;
                case HeaderNames.Moose: value = moose; break;
                case HeaderNames.Mouse: value = mouse; break;
                case HeaderNames.Myna: value = myna; break;
                case HeaderNames.Narwhal: value = narwhal; break;
                case HeaderNames.Newt: value = newt; break;
                case HeaderNames.Nightingale: value = nightingale; break;
                case HeaderNames.Nilgai: value = nilgai; break;
                case HeaderNames.Ocelot: value = ocelot; break;
                case HeaderNames.Octopus: value = octopus; break;
                case HeaderNames.Okapi: value = okapi; break;
                case HeaderNames.Olingo: value = olingo; break;
                case HeaderNames.Opossum: value = opossum; break;
                case HeaderNames.Ostrich: value = ostrich; break;
                case HeaderNames.Owl: value = owl; break;
                case HeaderNames.Ox: value = ox; break;
                case HeaderNames.Oyster: value = oyster; break;
                case HeaderNames.Panda: value = panda; break;
                case HeaderNames.Panther: value = panther; break;
                case HeaderNames.Peafowl: value = peafowl; break;
                case HeaderNames.Pelican: value = pelican; break;
                case HeaderNames.Penguin: value = penguin; break;
                case HeaderNames.Pheasant: value = pheasant; break;
                case HeaderNames.Pig: value = pig; break;
                case HeaderNames.Pigeon: value = pigeon; break;
                case HeaderNames.Pika: value = pika; break;
                case HeaderNames.Pony: value = pony; break;
                case HeaderNames.Porpoise: value = porpoise; break;
                case HeaderNames.Pug: value = pug; break;
                case HeaderNames.Quail: value = quail; break;
                case HeaderNames.Quetzal: value = quetzal; break;
                case HeaderNames.Rabbit: value = rabbit; break;
                case HeaderNames.Raccoon: value = raccoon; break;
                case HeaderNames.Ram: value = ram; break;
                case HeaderNames.Rat: value = rat; break;
                case HeaderNames.Reindeer: value = reindeer; break;
                case HeaderNames.Rhea: value = rhea; break;
                case HeaderNames.Rhinoceros: value = rhinoceros; break;
                case HeaderNames.Rook: value = rook; break;
                case HeaderNames.Salamander: value = salamander; break;
                case HeaderNames.Sandpiper: value = sandpiper; break;
                case HeaderNames.Sardine: value = sardine; break;
                case HeaderNames.Sassaby: value = sassaby; break;
                case HeaderNames.Seahorse: value = seahorse; break;
                case HeaderNames.Seal: value = seal; break;
                case HeaderNames.Serval: value = serval; break;
                case HeaderNames.Sheep: value = sheep; break;
                case HeaderNames.Shrike: value = shrike; break;
                case HeaderNames.Siamang: value = siamang; break;
                case HeaderNames.Skink: value = skink; break;
                case HeaderNames.Skipper: value = skipper; break;
                case HeaderNames.Skunk: value = skunk; break;
                case HeaderNames.Sloth: value = sloth; break;
                case HeaderNames.Snake: value = snake; break;
                case HeaderNames.Spider: value = spider; break;
                case HeaderNames.Spoonbill: value = spoonbill; break;
                case HeaderNames.Squid: value = squid; break;
                case HeaderNames.Squirrel: value = squirrel; break;
                case HeaderNames.Starfish: value = starfish; break;
                case HeaderNames.Tamarin: value = tamarin; break;
                case HeaderNames.Tapir: value = tapir; break;
                case HeaderNames.Tarsier: value = tarsier; break;
                case HeaderNames.Termite: value = termite; break;
                case HeaderNames.Tiger: value = tiger; break;
                case HeaderNames.Toad: value = toad; break;
                case HeaderNames.Toucan: value = toucan; break;
                case HeaderNames.Turaco: value = turaco; break;
                case HeaderNames.Turtle: value = turtle; break;
                case HeaderNames.Viper: value = viper; break;
                case HeaderNames.Vulture: value = vulture; break;
                case HeaderNames.Wallaby: value = wallaby; break;
                case HeaderNames.Wasp: value = wasp; break;
                case HeaderNames.Wildebeest: value = wildebeest; break;
                case HeaderNames.Wobbegong: value = wobbegong; break;
                case HeaderNames.Wolf: value = wolf; break;
                case HeaderNames.Wolverine: value = wolverine; break;
                case HeaderNames.Wombat: value = wombat; break;
                case HeaderNames.Woodpecker: value = woodpecker; break;
                case HeaderNames.Worm: value = worm; break;
                case HeaderNames.Wren: value = wren; break;
                case HeaderNames.Yak: value = yak; break;
                case HeaderNames.Zebra: value = zebra; break;
                default: throw new ArgumentException(nameof(name));
            }

            return value != null;
        }

        public void Set(HeaderNames name, string value)
        {
            if (numSet == Constants.MaximumSetHeaders)
            {
                // too many set
                throw new InvalidOperationException();
            }

            switch (name)
            {
                case HeaderNames.Aardvark: GetNull(ref aardvark) = value; break;
                case HeaderNames.Albatross: GetNull(ref albatross) = value; break;
                case HeaderNames.Alligator: GetNull(ref alligator) = value; break;
                case HeaderNames.Anteater: GetNull(ref anteater) = value; break;
                case HeaderNames.Antelope: GetNull(ref antelope) = value; break;
                case HeaderNames.Bat: GetNull(ref bat) = value; break;
                case HeaderNames.Beaver: GetNull(ref beaver) = value; break;
                case HeaderNames.Bee: GetNull(ref bee) = value; break;
                case HeaderNames.Beetle: GetNull(ref beetle) = value; break;
                case HeaderNames.Binturong: GetNull(ref binturong) = value; break;
                case HeaderNames.Bird: GetNull(ref bird) = value; break;
                case HeaderNames.Boar: GetNull(ref boar) = value; break;
                case HeaderNames.Buffalo: GetNull(ref buffalo) = value; break;
                case HeaderNames.Butterfly: GetNull(ref butterfly) = value; break;
                case HeaderNames.Camel: GetNull(ref camel) = value; break;
                case HeaderNames.Capybara: GetNull(ref capybara) = value; break;
                case HeaderNames.Caracal: GetNull(ref caracal) = value; break;
                case HeaderNames.Cat: GetNull(ref cat) = value; break;
                case HeaderNames.Cattle: GetNull(ref cattle) = value; break;
                case HeaderNames.Chamois: GetNull(ref chamois) = value; break;
                case HeaderNames.Chicken: GetNull(ref chicken) = value; break;
                case HeaderNames.Chimpanzee: GetNull(ref chimpanzee) = value; break;
                case HeaderNames.Chinchilla: GetNull(ref chinchilla) = value; break;
                case HeaderNames.Coati: GetNull(ref coati) = value; break;
                case HeaderNames.Cockroach: GetNull(ref cockroach) = value; break;
                case HeaderNames.Cormorant: GetNull(ref cormorant) = value; break;
                case HeaderNames.Cow: GetNull(ref cow) = value; break;
                case HeaderNames.Crab: GetNull(ref crab) = value; break;
                case HeaderNames.Crocodile: GetNull(ref crocodile) = value; break;
                case HeaderNames.Cuckoo: GetNull(ref cuckoo) = value; break;
                case HeaderNames.Curlew: GetNull(ref curlew) = value; break;
                case HeaderNames.Deer: GetNull(ref deer) = value; break;
                case HeaderNames.Dhole: GetNull(ref dhole) = value; break;
                case HeaderNames.Dinosaur: GetNull(ref dinosaur) = value; break;
                case HeaderNames.Dog: GetNull(ref dog) = value; break;
                case HeaderNames.Dogfish: GetNull(ref dogfish) = value; break;
                case HeaderNames.Dolphin: GetNull(ref dolphin) = value; break;
                case HeaderNames.Donkey: GetNull(ref donkey) = value; break;
                case HeaderNames.Dragonfly: GetNull(ref dragonfly) = value; break;
                case HeaderNames.Duck: GetNull(ref duck) = value; break;
                case HeaderNames.Dugong: GetNull(ref dugong) = value; break;
                case HeaderNames.Eland: GetNull(ref eland) = value; break;
                case HeaderNames.Elephant: GetNull(ref elephant) = value; break;
                case HeaderNames.Elk: GetNull(ref elk) = value; break;
                case HeaderNames.Emu: GetNull(ref emu) = value; break;
                case HeaderNames.Falcon: GetNull(ref falcon) = value; break;
                case HeaderNames.Ferret: GetNull(ref ferret) = value; break;
                case HeaderNames.Fish: GetNull(ref fish) = value; break;
                case HeaderNames.Fossa: GetNull(ref fossa) = value; break;
                case HeaderNames.Fox: GetNull(ref fox) = value; break;
                case HeaderNames.Frog: GetNull(ref frog) = value; break;
                case HeaderNames.Gaur: GetNull(ref gaur) = value; break;
                case HeaderNames.Gazelle: GetNull(ref gazelle) = value; break;
                case HeaderNames.Gecko: GetNull(ref gecko) = value; break;
                case HeaderNames.Genet: GetNull(ref genet) = value; break;
                case HeaderNames.Gerbil: GetNull(ref gerbil) = value; break;
                case HeaderNames.Gnat: GetNull(ref gnat) = value; break;
                case HeaderNames.Gnu: GetNull(ref gnu) = value; break;
                case HeaderNames.Goat: GetNull(ref goat) = value; break;
                case HeaderNames.Goldfinch: GetNull(ref goldfinch) = value; break;
                case HeaderNames.Goosander: GetNull(ref goosander) = value; break;
                case HeaderNames.Gorilla: GetNull(ref gorilla) = value; break;
                case HeaderNames.Goshawk: GetNull(ref goshawk) = value; break;
                case HeaderNames.Grasshopper: GetNull(ref grasshopper) = value; break;
                case HeaderNames.Grouse: GetNull(ref grouse) = value; break;
                case HeaderNames.Guanaco: GetNull(ref guanaco) = value; break;
                case HeaderNames.Gull: GetNull(ref gull) = value; break;
                case HeaderNames.Hamster: GetNull(ref hamster) = value; break;
                case HeaderNames.Hare: GetNull(ref hare) = value; break;
                case HeaderNames.Hawk: GetNull(ref hawk) = value; break;
                case HeaderNames.Hedgehog: GetNull(ref hedgehog) = value; break;
                case HeaderNames.Heron: GetNull(ref heron) = value; break;
                case HeaderNames.Herring: GetNull(ref herring) = value; break;
                case HeaderNames.Hoatzin: GetNull(ref hoatzin) = value; break;
                case HeaderNames.Hoopoe: GetNull(ref hoopoe) = value; break;
                case HeaderNames.Hornet: GetNull(ref hornet) = value; break;
                case HeaderNames.Horse: GetNull(ref horse) = value; break;
                case HeaderNames.Hummingbird: GetNull(ref hummingbird) = value; break;
                case HeaderNames.Hyena: GetNull(ref hyena) = value; break;
                case HeaderNames.Ibis: GetNull(ref ibis) = value; break;
                case HeaderNames.Iguana: GetNull(ref iguana) = value; break;
                case HeaderNames.Jackal: GetNull(ref jackal) = value; break;
                case HeaderNames.Jaguar: GetNull(ref jaguar) = value; break;
                case HeaderNames.Jay: GetNull(ref jay) = value; break;
                case HeaderNames.Kingbird: GetNull(ref kingbird) = value; break;
                case HeaderNames.Kingfisher: GetNull(ref kingfisher) = value; break;
                case HeaderNames.Kinkajou: GetNull(ref kinkajou) = value; break;
                case HeaderNames.Kodkod: GetNull(ref kodkod) = value; break;
                case HeaderNames.Kookaburra: GetNull(ref kookaburra) = value; break;
                case HeaderNames.Kowari: GetNull(ref kowari) = value; break;
                case HeaderNames.Langur: GetNull(ref langur) = value; break;
                case HeaderNames.Lapwing: GetNull(ref lapwing) = value; break;
                case HeaderNames.Lark: GetNull(ref lark) = value; break;
                case HeaderNames.Lechwe: GetNull(ref lechwe) = value; break;
                case HeaderNames.Lemur: GetNull(ref lemur) = value; break;
                case HeaderNames.Lizard: GetNull(ref lizard) = value; break;
                case HeaderNames.Llama: GetNull(ref llama) = value; break;
                case HeaderNames.Locust: GetNull(ref locust) = value; break;
                case HeaderNames.Lyrebird: GetNull(ref lyrebird) = value; break;
                case HeaderNames.Macaque: GetNull(ref macaque) = value; break;
                case HeaderNames.Macaw: GetNull(ref macaw) = value; break;
                case HeaderNames.Mallard: GetNull(ref mallard) = value; break;
                case HeaderNames.Mammoth: GetNull(ref mammoth) = value; break;
                case HeaderNames.Manatee: GetNull(ref manatee) = value; break;
                case HeaderNames.Mandrill: GetNull(ref mandrill) = value; break;
                case HeaderNames.Marmoset: GetNull(ref marmoset) = value; break;
                case HeaderNames.Marmot: GetNull(ref marmot) = value; break;
                case HeaderNames.Meerkat: GetNull(ref meerkat) = value; break;
                case HeaderNames.Mink: GetNull(ref mink) = value; break;
                case HeaderNames.Mongoose: GetNull(ref mongoose) = value; break;
                case HeaderNames.Monkey: GetNull(ref monkey) = value; break;
                case HeaderNames.Moose: GetNull(ref moose) = value; break;
                case HeaderNames.Mouse: GetNull(ref mouse) = value; break;
                case HeaderNames.Myna: GetNull(ref myna) = value; break;
                case HeaderNames.Narwhal: GetNull(ref narwhal) = value; break;
                case HeaderNames.Newt: GetNull(ref newt) = value; break;
                case HeaderNames.Nightingale: GetNull(ref nightingale) = value; break;
                case HeaderNames.Nilgai: GetNull(ref nilgai) = value; break;
                case HeaderNames.Ocelot: GetNull(ref ocelot) = value; break;
                case HeaderNames.Octopus: GetNull(ref octopus) = value; break;
                case HeaderNames.Okapi: GetNull(ref okapi) = value; break;
                case HeaderNames.Olingo: GetNull(ref olingo) = value; break;
                case HeaderNames.Opossum: GetNull(ref opossum) = value; break;
                case HeaderNames.Ostrich: GetNull(ref ostrich) = value; break;
                case HeaderNames.Owl: GetNull(ref owl) = value; break;
                case HeaderNames.Ox: GetNull(ref ox) = value; break;
                case HeaderNames.Oyster: GetNull(ref oyster) = value; break;
                case HeaderNames.Panda: GetNull(ref panda) = value; break;
                case HeaderNames.Panther: GetNull(ref panther) = value; break;
                case HeaderNames.Peafowl: GetNull(ref peafowl) = value; break;
                case HeaderNames.Pelican: GetNull(ref pelican) = value; break;
                case HeaderNames.Penguin: GetNull(ref penguin) = value; break;
                case HeaderNames.Pheasant: GetNull(ref pheasant) = value; break;
                case HeaderNames.Pig: GetNull(ref pig) = value; break;
                case HeaderNames.Pigeon: GetNull(ref pigeon) = value; break;
                case HeaderNames.Pika: GetNull(ref pika) = value; break;
                case HeaderNames.Pony: GetNull(ref pony) = value; break;
                case HeaderNames.Porpoise: GetNull(ref porpoise) = value; break;
                case HeaderNames.Pug: GetNull(ref pug) = value; break;
                case HeaderNames.Quail: GetNull(ref quail) = value; break;
                case HeaderNames.Quetzal: GetNull(ref quetzal) = value; break;
                case HeaderNames.Rabbit: GetNull(ref rabbit) = value; break;
                case HeaderNames.Raccoon: GetNull(ref raccoon) = value; break;
                case HeaderNames.Ram: GetNull(ref ram) = value; break;
                case HeaderNames.Rat: GetNull(ref rat) = value; break;
                case HeaderNames.Reindeer: GetNull(ref reindeer) = value; break;
                case HeaderNames.Rhea: GetNull(ref rhea) = value; break;
                case HeaderNames.Rhinoceros: GetNull(ref rhinoceros) = value; break;
                case HeaderNames.Rook: GetNull(ref rook) = value; break;
                case HeaderNames.Salamander: GetNull(ref salamander) = value; break;
                case HeaderNames.Sandpiper: GetNull(ref sandpiper) = value; break;
                case HeaderNames.Sardine: GetNull(ref sardine) = value; break;
                case HeaderNames.Sassaby: GetNull(ref sassaby) = value; break;
                case HeaderNames.Seahorse: GetNull(ref seahorse) = value; break;
                case HeaderNames.Seal: GetNull(ref seal) = value; break;
                case HeaderNames.Serval: GetNull(ref serval) = value; break;
                case HeaderNames.Sheep: GetNull(ref sheep) = value; break;
                case HeaderNames.Shrike: GetNull(ref shrike) = value; break;
                case HeaderNames.Siamang: GetNull(ref siamang) = value; break;
                case HeaderNames.Skink: GetNull(ref skink) = value; break;
                case HeaderNames.Skipper: GetNull(ref skipper) = value; break;
                case HeaderNames.Skunk: GetNull(ref skunk) = value; break;
                case HeaderNames.Sloth: GetNull(ref sloth) = value; break;
                case HeaderNames.Snake: GetNull(ref snake) = value; break;
                case HeaderNames.Spider: GetNull(ref spider) = value; break;
                case HeaderNames.Spoonbill: GetNull(ref spoonbill) = value; break;
                case HeaderNames.Squid: GetNull(ref squid) = value; break;
                case HeaderNames.Squirrel: GetNull(ref squirrel) = value; break;
                case HeaderNames.Starfish: GetNull(ref starfish) = value; break;
                case HeaderNames.Tamarin: GetNull(ref tamarin) = value; break;
                case HeaderNames.Tapir: GetNull(ref tapir) = value; break;
                case HeaderNames.Tarsier: GetNull(ref tarsier) = value; break;
                case HeaderNames.Termite: GetNull(ref termite) = value; break;
                case HeaderNames.Tiger: GetNull(ref tiger) = value; break;
                case HeaderNames.Toad: GetNull(ref toad) = value; break;
                case HeaderNames.Toucan: GetNull(ref toucan) = value; break;
                case HeaderNames.Turaco: GetNull(ref turaco) = value; break;
                case HeaderNames.Turtle: GetNull(ref turtle) = value; break;
                case HeaderNames.Viper: GetNull(ref viper) = value; break;
                case HeaderNames.Vulture: GetNull(ref vulture) = value; break;
                case HeaderNames.Wallaby: GetNull(ref wallaby) = value; break;
                case HeaderNames.Wasp: GetNull(ref wasp) = value; break;
                case HeaderNames.Wildebeest: GetNull(ref wildebeest) = value; break;
                case HeaderNames.Wobbegong: GetNull(ref wobbegong) = value; break;
                case HeaderNames.Wolf: GetNull(ref wolf) = value; break;
                case HeaderNames.Wolverine: GetNull(ref wolverine) = value; break;
                case HeaderNames.Wombat: GetNull(ref wombat) = value; break;
                case HeaderNames.Woodpecker: GetNull(ref woodpecker) = value; break;
                case HeaderNames.Worm: GetNull(ref worm) = value; break;
                case HeaderNames.Wren: GetNull(ref wren) = value; break;
                case HeaderNames.Yak: GetNull(ref yak) = value; break;
                case HeaderNames.Zebra: GetNull(ref zebra) = value; break;
                default: throw new ArgumentException(nameof(name));
            }

            numSet++;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            ref string? GetNull(ref string? toCheck)
            {
                if (toCheck != null)
                {
                    // can't set twice
                    throw new ArgumentException();
                }

                return ref toCheck;
            }
        }

        public static FieldHeaders_V1 CreateEmpty()
        => new FieldHeaders_V1();

        public static FieldHeaders_V1 CreateFromDictionary(Dictionary<HeaderNames, string> dict)
        {
            if (dict.Count > Constants.MaximumSetHeaders)
            {
                throw new ArgumentException(nameof(dict));
            }

            var ret = new FieldHeaders_V1();
            foreach (var kv in dict)
            {
                ret.SetUnsafe(kv.Key, kv.Value);
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

        // pretty hot when creating types, so inline aggressively
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SetUnsafe(HeaderNames name, string value)
        {
            switch (name)
            {
                case HeaderNames.Aardvark: aardvark = value; break;
                case HeaderNames.Albatross: albatross = value; break;
                case HeaderNames.Alligator: alligator = value; break;
                case HeaderNames.Anteater: anteater = value; break;
                case HeaderNames.Antelope: antelope = value; break;
                case HeaderNames.Bat: bat = value; break;
                case HeaderNames.Beaver: beaver = value; break;
                case HeaderNames.Bee: bee = value; break;
                case HeaderNames.Beetle: beetle = value; break;
                case HeaderNames.Binturong: binturong = value; break;
                case HeaderNames.Bird: bird = value; break;
                case HeaderNames.Boar: boar = value; break;
                case HeaderNames.Buffalo: buffalo = value; break;
                case HeaderNames.Butterfly: butterfly = value; break;
                case HeaderNames.Camel: camel = value; break;
                case HeaderNames.Capybara: capybara = value; break;
                case HeaderNames.Caracal: caracal = value; break;
                case HeaderNames.Cat: cat = value; break;
                case HeaderNames.Cattle: cattle = value; break;
                case HeaderNames.Chamois: chamois = value; break;
                case HeaderNames.Chicken: chicken = value; break;
                case HeaderNames.Chimpanzee: chimpanzee = value; break;
                case HeaderNames.Chinchilla: chinchilla = value; break;
                case HeaderNames.Coati: coati = value; break;
                case HeaderNames.Cockroach: cockroach = value; break;
                case HeaderNames.Cormorant: cormorant = value; break;
                case HeaderNames.Cow: cow = value; break;
                case HeaderNames.Crab: crab = value; break;
                case HeaderNames.Crocodile: crocodile = value; break;
                case HeaderNames.Cuckoo: cuckoo = value; break;
                case HeaderNames.Curlew: curlew = value; break;
                case HeaderNames.Deer: deer = value; break;
                case HeaderNames.Dhole: dhole = value; break;
                case HeaderNames.Dinosaur: dinosaur = value; break;
                case HeaderNames.Dog: dog = value; break;
                case HeaderNames.Dogfish: dogfish = value; break;
                case HeaderNames.Dolphin: dolphin = value; break;
                case HeaderNames.Donkey: donkey = value; break;
                case HeaderNames.Dragonfly: dragonfly = value; break;
                case HeaderNames.Duck: duck = value; break;
                case HeaderNames.Dugong: dugong = value; break;
                case HeaderNames.Eland: eland = value; break;
                case HeaderNames.Elephant: elephant = value; break;
                case HeaderNames.Elk: elk = value; break;
                case HeaderNames.Emu: emu = value; break;
                case HeaderNames.Falcon: falcon = value; break;
                case HeaderNames.Ferret: ferret = value; break;
                case HeaderNames.Fish: fish = value; break;
                case HeaderNames.Fossa: fossa = value; break;
                case HeaderNames.Fox: fox = value; break;
                case HeaderNames.Frog: frog = value; break;
                case HeaderNames.Gaur: gaur = value; break;
                case HeaderNames.Gazelle: gazelle = value; break;
                case HeaderNames.Gecko: gecko = value; break;
                case HeaderNames.Genet: genet = value; break;
                case HeaderNames.Gerbil: gerbil = value; break;
                case HeaderNames.Gnat: gnat = value; break;
                case HeaderNames.Gnu: gnu = value; break;
                case HeaderNames.Goat: goat = value; break;
                case HeaderNames.Goldfinch: goldfinch = value; break;
                case HeaderNames.Goosander: goosander = value; break;
                case HeaderNames.Gorilla: gorilla = value; break;
                case HeaderNames.Goshawk: goshawk = value; break;
                case HeaderNames.Grasshopper: grasshopper = value; break;
                case HeaderNames.Grouse: grouse = value; break;
                case HeaderNames.Guanaco: guanaco = value; break;
                case HeaderNames.Gull: gull = value; break;
                case HeaderNames.Hamster: hamster = value; break;
                case HeaderNames.Hare: hare = value; break;
                case HeaderNames.Hawk: hawk = value; break;
                case HeaderNames.Hedgehog: hedgehog = value; break;
                case HeaderNames.Heron: heron = value; break;
                case HeaderNames.Herring: herring = value; break;
                case HeaderNames.Hoatzin: hoatzin = value; break;
                case HeaderNames.Hoopoe: hoopoe = value; break;
                case HeaderNames.Hornet: hornet = value; break;
                case HeaderNames.Horse: horse = value; break;
                case HeaderNames.Hummingbird: hummingbird = value; break;
                case HeaderNames.Hyena: hyena = value; break;
                case HeaderNames.Ibis: ibis = value; break;
                case HeaderNames.Iguana: iguana = value; break;
                case HeaderNames.Jackal: jackal = value; break;
                case HeaderNames.Jaguar: jaguar = value; break;
                case HeaderNames.Jay: jay = value; break;
                case HeaderNames.Kingbird: kingbird = value; break;
                case HeaderNames.Kingfisher: kingfisher = value; break;
                case HeaderNames.Kinkajou: kinkajou = value; break;
                case HeaderNames.Kodkod: kodkod = value; break;
                case HeaderNames.Kookaburra: kookaburra = value; break;
                case HeaderNames.Kowari: kowari = value; break;
                case HeaderNames.Langur: langur = value; break;
                case HeaderNames.Lapwing: lapwing = value; break;
                case HeaderNames.Lark: lark = value; break;
                case HeaderNames.Lechwe: lechwe = value; break;
                case HeaderNames.Lemur: lemur = value; break;
                case HeaderNames.Lizard: lizard = value; break;
                case HeaderNames.Llama: llama = value; break;
                case HeaderNames.Locust: locust = value; break;
                case HeaderNames.Lyrebird: lyrebird = value; break;
                case HeaderNames.Macaque: macaque = value; break;
                case HeaderNames.Macaw: macaw = value; break;
                case HeaderNames.Mallard: mallard = value; break;
                case HeaderNames.Mammoth: mammoth = value; break;
                case HeaderNames.Manatee: manatee = value; break;
                case HeaderNames.Mandrill: mandrill = value; break;
                case HeaderNames.Marmoset: marmoset = value; break;
                case HeaderNames.Marmot: marmot = value; break;
                case HeaderNames.Meerkat: meerkat = value; break;
                case HeaderNames.Mink: mink = value; break;
                case HeaderNames.Mongoose: mongoose = value; break;
                case HeaderNames.Monkey: monkey = value; break;
                case HeaderNames.Moose: moose = value; break;
                case HeaderNames.Mouse: mouse = value; break;
                case HeaderNames.Myna: myna = value; break;
                case HeaderNames.Narwhal: narwhal = value; break;
                case HeaderNames.Newt: newt = value; break;
                case HeaderNames.Nightingale: nightingale = value; break;
                case HeaderNames.Nilgai: nilgai = value; break;
                case HeaderNames.Ocelot: ocelot = value; break;
                case HeaderNames.Octopus: octopus = value; break;
                case HeaderNames.Okapi: okapi = value; break;
                case HeaderNames.Olingo: olingo = value; break;
                case HeaderNames.Opossum: opossum = value; break;
                case HeaderNames.Ostrich: ostrich = value; break;
                case HeaderNames.Owl: owl = value; break;
                case HeaderNames.Ox: ox = value; break;
                case HeaderNames.Oyster: oyster = value; break;
                case HeaderNames.Panda: panda = value; break;
                case HeaderNames.Panther: panther = value; break;
                case HeaderNames.Peafowl: peafowl = value; break;
                case HeaderNames.Pelican: pelican = value; break;
                case HeaderNames.Penguin: penguin = value; break;
                case HeaderNames.Pheasant: pheasant = value; break;
                case HeaderNames.Pig: pig = value; break;
                case HeaderNames.Pigeon: pigeon = value; break;
                case HeaderNames.Pika: pika = value; break;
                case HeaderNames.Pony: pony = value; break;
                case HeaderNames.Porpoise: porpoise = value; break;
                case HeaderNames.Pug: pug = value; break;
                case HeaderNames.Quail: quail = value; break;
                case HeaderNames.Quetzal: quetzal = value; break;
                case HeaderNames.Rabbit: rabbit = value; break;
                case HeaderNames.Raccoon: raccoon = value; break;
                case HeaderNames.Ram: ram = value; break;
                case HeaderNames.Rat: rat = value; break;
                case HeaderNames.Reindeer: reindeer = value; break;
                case HeaderNames.Rhea: rhea = value; break;
                case HeaderNames.Rhinoceros: rhinoceros = value; break;
                case HeaderNames.Rook: rook = value; break;
                case HeaderNames.Salamander: salamander = value; break;
                case HeaderNames.Sandpiper: sandpiper = value; break;
                case HeaderNames.Sardine: sardine = value; break;
                case HeaderNames.Sassaby: sassaby = value; break;
                case HeaderNames.Seahorse: seahorse = value; break;
                case HeaderNames.Seal: seal = value; break;
                case HeaderNames.Serval: serval = value; break;
                case HeaderNames.Sheep: sheep = value; break;
                case HeaderNames.Shrike: shrike = value; break;
                case HeaderNames.Siamang: siamang = value; break;
                case HeaderNames.Skink: skink = value; break;
                case HeaderNames.Skipper: skipper = value; break;
                case HeaderNames.Skunk: skunk = value; break;
                case HeaderNames.Sloth: sloth = value; break;
                case HeaderNames.Snake: snake = value; break;
                case HeaderNames.Spider: spider = value; break;
                case HeaderNames.Spoonbill: spoonbill = value; break;
                case HeaderNames.Squid: squid = value; break;
                case HeaderNames.Squirrel: squirrel = value; break;
                case HeaderNames.Starfish: starfish = value; break;
                case HeaderNames.Tamarin: tamarin = value; break;
                case HeaderNames.Tapir: tapir = value; break;
                case HeaderNames.Tarsier: tarsier = value; break;
                case HeaderNames.Termite: termite = value; break;
                case HeaderNames.Tiger: tiger = value; break;
                case HeaderNames.Toad: toad = value; break;
                case HeaderNames.Toucan: toucan = value; break;
                case HeaderNames.Turaco: turaco = value; break;
                case HeaderNames.Turtle: turtle = value; break;
                case HeaderNames.Viper: viper = value; break;
                case HeaderNames.Vulture: vulture = value; break;
                case HeaderNames.Wallaby: wallaby = value; break;
                case HeaderNames.Wasp: wasp = value; break;
                case HeaderNames.Wildebeest: wildebeest = value; break;
                case HeaderNames.Wobbegong: wobbegong = value; break;
                case HeaderNames.Wolf: wolf = value; break;
                case HeaderNames.Wolverine: wolverine = value; break;
                case HeaderNames.Wombat: wombat = value; break;
                case HeaderNames.Woodpecker: woodpecker = value; break;
                case HeaderNames.Worm: worm = value; break;
                case HeaderNames.Wren: wren = value; break;
                case HeaderNames.Yak: yak = value; break;
                case HeaderNames.Zebra: zebra = value; break;
                default: throw new ArgumentException(nameof(name));
            }

            numSet++;
        }
    }
}
