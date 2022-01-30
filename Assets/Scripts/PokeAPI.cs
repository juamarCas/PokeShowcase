using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;


public class PokeAPI : MonoBehaviour
{
    #region Singleton
    public static PokeAPI _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    #endregion

    /*route configuration*/
    private const string protocol = "https";
    private const string host     = "pokeapi.co";
    private const string path     = "api";
    private const string version  = "v2";

    private const string pokemon_path = "pokemon";

    private const string api = protocol + "://" + host + "/" + path + "/" + version + "/";

    /// <summary>
    /// Returns pokemon information
    /// </summary>
    /// <param name="_pokemon">pokemon name</param>
    /// <returns>A pokemon object with all the information</returns>
    public async Task<Pokemon> GetPokemon(string _pokemon)
    {
        string low_pokemon = _pokemon.ToLower();

        string url = api + "/" + pokemon_path + "/" + low_pokemon;
        using var www = UnityWebRequest.Get(url);
        www.SetRequestHeader("Content-Type", "application/json");

        var operation = www.SendWebRequest();
        while (!operation.isDone)
            await Task.Yield();

        if(www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError($"error: {www.error}");
        }
       

        var json = www.downloadHandler.text;
        Pokemon pkmn = new Pokemon();

        try
        {
            pkmn = JsonUtility.FromJson<Pokemon>(json);
        }
        catch(Exception ex)
        {
            Debug.Log(ex);
        }

        
        return await Task.FromResult(pkmn);
    }
}
