using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
   
    

    private void Start()
    {
        _fireCommand = new FireCommand();
        _api = new PokeAPI();
    }

    public void Attack()
    {
        _fireCommand.Execute(ref _player);
    }

    public async void Search()
    {
        var _pokemon = await _api.GetPokemon("umbreon");
        Debug.Log(_pokemon.name);
    }
}
