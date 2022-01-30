using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Pokemon object to deserialize a JSON
/// </summary>
[Serializable]
public class Pokemon
{
    public Ability[] abilities;
    public int base_experience;
    public Generic[] forms;
    public Game_indices[] game_indices;
    public int height;
    public Held_items[] held_items;
    public int id;
    public bool is_default;
    public string location_area_encounters;

    public string name;
    public int order;

    public Generic species;
    public Sprites sprites;
    public Stats[] stats;
    public Type[] types;

    int weight;

}


[Serializable]
public class Ability
{
    public bool is_hidden;
    public int slot;
    public Generic ability;
    
}

public class Game_indices
{
    public int game_index;
    public Generic version;

}

public class Held_items
{
    public Generic item;
    public Version_detail[] version_details;
}

public class Moves
{

}

public class Sprites
{
    public string back_default;
    public string back_female;
    public string back_shiny;
    public string back_shiny_female;
    public string front_default;
    public string front_female;
    public string front_shiny;
    public string front_shiny_female;
}

[Serializable]
public class Type
{
    public int slot { get; set; }
    public Generic type;
}

public class Stats
{
    public int base_stat;
    public int effort;
    Generic stat;
}

/*Generic class indicate objects with just name and url*/
[Serializable]
public class Generic
{
    public string name;
    public string url;
}

public class Version_detail
{
    int rarity;
    Generic version;
}

