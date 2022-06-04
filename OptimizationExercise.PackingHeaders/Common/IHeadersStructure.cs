using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace OptimizationExercise.PackingHeaders.Common
{
    public interface IHeadersStructure<TSelf, TEnumerator>
        where TSelf: IHeadersStructure<TSelf, TEnumerator>
        where TEnumerator : struct, IEnumerator<HeaderNames>
    {
        #region direct access by "name" (ie property)
        string? Aardvark { get; set; }
        string? Albatross { get; set; }
        string? Alligator { get; set; }
        string? Anteater { get; set; }
        string? Antelope { get; set; }
        string? Bat { get; set; }
        string? Beaver { get; set; }
        string? Bee { get; set; }
        string? Beetle { get; set; }
        string? Binturong { get; set; }
        string? Bird { get; set; }
        string? Boar { get; set; }
        string? Buffalo { get; set; }
        string? Butterfly { get; set; }
        string? Camel { get; set; }
        string? Capybara { get; set; }
        string? Caracal { get; set; }
        string? Cat { get; set; }
        string? Cattle { get; set; }
        string? Chamois { get; set; }
        string? Chicken { get; set; }
        string? Chimpanzee { get; set; }
        string? Chinchilla { get; set; }
        string? Coati { get; set; }
        string? Cockroach { get; set; }
        string? Cormorant { get; set; }
        string? Cow { get; set; }
        string? Crab { get; set; }
        string? Crocodile { get; set; }
        string? Cuckoo { get; set; }
        string? Curlew { get; set; }
        string? Deer { get; set; }
        string? Dhole { get; set; }
        string? Dinosaur { get; set; }
        string? Dog { get; set; }
        string? Dogfish { get; set; }
        string? Dolphin { get; set; }
        string? Donkey { get; set; }
        string? Dragonfly { get; set; }
        string? Duck { get; set; }
        string? Dugong { get; set; }
        string? Eland { get; set; }
        string? Elephant { get; set; }
        string? Elk { get; set; }
        string? Emu { get; set; }
        string? Falcon { get; set; }
        string? Ferret { get; set; }
        string? Fish { get; set; }
        string? Fossa { get; set; }
        string? Fox { get; set; }
        string? Frog { get; set; }
        string? Gaur { get; set; }
        string? Gazelle { get; set; }
        string? Gecko { get; set; }
        string? Genet { get; set; }
        string? Gerbil { get; set; }
        string? Gnat { get; set; }
        string? Gnu { get; set; }
        string? Goat { get; set; }
        string? Goldfinch { get; set; }
        string? Goosander { get; set; }
        string? Gorilla { get; set; }
        string? Goshawk { get; set; }
        string? Grasshopper { get; set; }
        string? Grouse { get; set; }
        string? Guanaco { get; set; }
        string? Gull { get; set; }
        string? Hamster { get; set; }
        string? Hare { get; set; }
        string? Hawk { get; set; }
        string? Hedgehog { get; set; }
        string? Heron { get; set; }
        string? Herring { get; set; }
        string? Hoatzin { get; set; }
        string? Hoopoe { get; set; }
        string? Hornet { get; set; }
        string? Horse { get; set; }
        string? Hummingbird { get; set; }
        string? Hyena { get; set; }
        string? Ibis { get; set; }
        string? Iguana { get; set; }
        string? Jackal { get; set; }
        string? Jaguar { get; set; }
        string? Jay { get; set; }
        string? Kingbird { get; set; }
        string? Kingfisher { get; set; }
        string? Kinkajou { get; set; }
        string? Kodkod { get; set; }
        string? Kookaburra { get; set; }
        string? Kowari { get; set; }
        string? Langur { get; set; }
        string? Lapwing { get; set; }
        string? Lark { get; set; }
        string? Lechwe { get; set; }
        string? Lemur { get; set; }
        string? Lizard { get; set; }
        string? Llama { get; set; }
        string? Locust { get; set; }
        string? Lyrebird { get; set; }
        string? Macaque { get; set; }
        string? Macaw { get; set; }
        string? Mallard { get; set; }
        string? Mammoth { get; set; }
        string? Manatee { get; set; }
        string? Mandrill { get; set; }
        string? Marmoset { get; set; }
        string? Marmot { get; set; }
        string? Meerkat { get; set; }
        string? Mink { get; set; }
        string? Mongoose { get; set; }
        string? Monkey { get; set; }
        string? Moose { get; set; }
        string? Mouse { get; set; }
        string? Myna { get; set; }
        string? Narwhal { get; set; }
        string? Newt { get; set; }
        string? Nightingale { get; set; }
        string? Nilgai { get; set; }
        string? Ocelot { get; set; }
        string? Octopus { get; set; }
        string? Okapi { get; set; }
        string? Olingo { get; set; }
        string? Opossum { get; set; }
        string? Ostrich { get; set; }
        string? Owl { get; set; }
        string? Ox { get; set; }
        string? Oyster { get; set; }
        string? Panda { get; set; }
        string? Panther { get; set; }
        string? Peafowl { get; set; }
        string? Pelican { get; set; }
        string? Penguin { get; set; }
        string? Pheasant { get; set; }
        string? Pig { get; set; }
        string? Pigeon { get; set; }
        string? Pika { get; set; }
        string? Pony { get; set; }
        string? Porpoise { get; set; }
        string? Pug { get; set; }
        string? Quail { get; set; }
        string? Quetzal { get; set; }
        string? Rabbit { get; set; }
        string? Raccoon { get; set; }
        string? Ram { get; set; }
        string? Rat { get; set; }
        string? Reindeer { get; set; }
        string? Rhea { get; set; }
        string? Rhinoceros { get; set; }
        string? Rook { get; set; }
        string? Salamander { get; set; }
        string? Sandpiper { get; set; }
        string? Sardine { get; set; }
        string? Sassaby { get; set; }
        string? Seahorse { get; set; }
        string? Seal { get; set; }
        string? Serval { get; set; }
        string? Sheep { get; set; }
        string? Shrike { get; set; }
        string? Siamang { get; set; }
        string? Skink { get; set; }
        string? Skipper { get; set; }
        string? Skunk { get; set; }
        string? Sloth { get; set; }
        string? Snake { get; set; }
        string? Spider { get; set; }
        string? Spoonbill { get; set; }
        string? Squid { get; set; }
        string? Squirrel { get; set; }
        string? Starfish { get; set; }
        string? Tamarin { get; set; }
        string? Tapir { get; set; }
        string? Tarsier { get; set; }
        string? Termite { get; set; }
        string? Tiger { get; set; }
        string? Toad { get; set; }
        string? Toucan { get; set; }
        string? Turaco { get; set; }
        string? Turtle { get; set; }
        string? Viper { get; set; }
        string? Vulture { get; set; }
        string? Wallaby { get; set; }
        string? Wasp { get; set; }
        string? Wildebeest { get; set; }
        string? Wobbegong { get; set; }
        string? Wolf { get; set; }
        string? Wolverine { get; set; }
        string? Wombat { get; set; }
        string? Woodpecker { get; set; }
        string? Worm { get; set; }
        string? Wren { get; set; }
        string? Yak { get; set; }
        string? Zebra { get; set; }
        #endregion

        /// <summary>
        /// Set a header to a given value.
        /// 
        /// Note that a header can only be set once.
        /// </summary>
        void Set(HeaderNames header, string value);

        /// <summary>
        /// Try to lookup a header based on the given <see cref="HeaderNames"/>.
        /// </summary>
        bool TryGetValue(HeaderNames header, [NotNullWhen(returnValue:true)]out string? value);

        /// <summary>
        /// Enumerate the headers that are set.
        /// </summary>
        TEnumerator GetEnumerator();

        /// <summary>
        /// Create an empty headers struct.
        /// </summary>
        abstract static TSelf CreateEmpty();

        /// <summary>
        /// Create an headers struct from a dictionary
        /// </summary>
        abstract static TSelf CreateFromDictionary(Dictionary<HeaderNames, string> headers);
    }
}
