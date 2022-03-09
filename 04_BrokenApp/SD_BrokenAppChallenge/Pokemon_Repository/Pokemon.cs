namespace Pokemon_Repository
{
            public enum PokemonType
        {
            Normal = 100,
            Grass,
            Fire,
            Water,
            Electric,
            Ice,
            Bug,
            Ground,
            Rock,
            Fighting,
            Psychic,
            Ghost,
            Dark,
            Fairy,
            Dragon,
            None
        }
    public class Pokemon
    {

        public string? PokemonSpeciesName { get; set; }
        public string? PokemonNickName { get; set; }
        public int Level { get; set; }
        public PokemonType PokemonType { get; set; }
        public PokemonType SecondaryType {get; set;}
        public string MoveOne { get; set; }
        public string MoveTwo { get; set; }
        public string MoveThree { get; set; }
        public string MoveFour { get; set; }

    public Pokemon(string speciesName, string nickName, int level, PokemonType pokemonType, PokemonType secondaryType, string moveOne, string moveTwo, string moveThree, string moveFour)
    {
        //TeamPosition = teamPosition;
        PokemonSpeciesName = speciesName;
        PokemonNickName = nickName;
        Level = level;
        PokemonType = pokemonType;
        SecondaryType = secondaryType;
        MoveOne = moveOne;
        MoveTwo = moveTwo;
        MoveThree = moveTwo;
        MoveFour = moveFour;
    }
    }
}
