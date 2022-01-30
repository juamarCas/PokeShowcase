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
   
    

    private void Start()
    {
        _fireCommand = new FireCommand();
        _api = new PokeAPI();
        name_text.text = "";
    }

    public void Attack()
    {
        _fireCommand.Execute(ref _player);
    }

    public async void Search()
    {
        var _pokemon = await _api.GetPokemon("umbreon");
        //Debug.Log(_pokemon.types[0].type.name);
        name_text.text = _pokemon.name;
    }
}
