using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Actions;

public class UIManager : MonoBehaviour
{
    #region Singleton
    public static UIManager _instance;

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

    private FireCommand _fireCommand;
    private PokeAPI _api;
    
    [SerializeField]
    private Player _player;

    [Header("UI Elements")]
    [SerializeField]
    private Text name_text;
    [SerializeField]
    private InputField search_field;
   
    

    private void Start()
    {
        _fireCommand   = new FireCommand();
        _api           = new PokeAPI();
        name_text.text = "";
    }

    public void Attack()
    {
        _fireCommand.Execute(ref _player);
    }

    public async void Search()
    {
        string extract_pokemon = search_field.text;
        var _pokemon           = await _api.GetPokemon(extract_pokemon);
        //Debug.Log(_pokemon.types[0].type.name);
        name_text.text = _pokemon.name;

        int _typeCount    = _pokemon.types.Length;
        int _abilityCount = _pokemon.abilities.Length;

        Dictionary<string, int> _charsMap = new Dictionary<string, int>();

        /*following the order of the list declared in the DB class*/
        _charsMap.Add(DB._instance._charList[0], _typeCount);
        _charsMap.Add(DB._instance._charList[1], _abilityCount);

        foreach(string characteristic in DB._instance._charList)
        {
           for(int i = 0; i < _charsMap[characteristic]; i++)
            {
                //TODO: instantiate UI Elements
            }
        }

        
    }
}
