using System.Collections;
using System.Linq;
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

    private FireCommand m_fireCommand;
    private PokeAPI m_api;
    private List<GameObject> m_charIndicator = new List<GameObject>();
    
    [SerializeField]
    private Player _player;

    [Header("UI Elements")]
    [SerializeField]
    private Text name_text;
    [SerializeField]
    private InputField search_field;
    [SerializeField]
    private GameObject m_textPrefab;
    [SerializeField]
    private GameObject m_content;

    [Header("3D Model")]
    [SerializeField]
    private List<GameObject> m_models = new List<GameObject>();
   
    

    private void Start()
    {
        m_fireCommand   = new FireCommand();
        m_api           = new PokeAPI();
        name_text.text = "";
    }

    public void Attack()
    {
        m_fireCommand.Execute(ref _player);
    }

    /// <summary>
    /// Search a pokemon via the API
    /// </summary>
    public async void Search()
    {
        /*clear UI*/
        if (m_charIndicator.Count > 0)
        {
            foreach(GameObject characteristic in m_charIndicator)
            {
                Destroy(characteristic);
            }

            m_charIndicator.Clear();
        }

        string extract_pokemon = search_field.text;
        var _pokemon           = await m_api.GetPokemon(extract_pokemon);

        if(_pokemon.types == null)
        {
            //TODO: Implement error handling
            return;
        }
        
        name_text.text = _pokemon.name;

        int _typeCount    = _pokemon.types.Length;
        int _abilityCount = _pokemon.abilities.Length;

        Dictionary<string, int> _charsMap = new Dictionary<string, int>();
        Dictionary<string, Generic> _generic = new Dictionary<string, Generic>();

        /*following the order of the list declared in the DB class*/
        _charsMap.Add(DB._instance._charList[DB._instance._typePos], _typeCount);
        _charsMap.Add(DB._instance._charList[DB._instance._abilityPos], _abilityCount);

        /*auxiliary variable for unique identifier of characteristic*/
        int _genericCounter = 1;

        foreach(Type _type in _pokemon.types)
        {
            _generic.Add($"{DB._instance._charList[DB._instance._charList.IndexOf(DB._instance._typeString)]}{_genericCounter}", _type.type);
            _genericCounter++;
        }

        _genericCounter = 1;
        foreach (Ability _ability in _pokemon.abilities)
        {
            _generic.Add($"{DB._instance._charList[DB._instance._charList.IndexOf(DB._instance._abilityString)]}{_genericCounter}", _ability.ability);
            _genericCounter++;
        }

        foreach(string characteristic in DB._instance._charList)
        {
            int counter = 1;
           for(int i = 0; i < _charsMap[characteristic]; i++)
            {
                /*create UI element*/
                GameObject charText = Instantiate(m_textPrefab, m_content.transform.position, transform.rotation) as GameObject;
                m_charIndicator.Add(charText);
                charText.transform.SetParent(m_content.transform, false);
                charText.GetComponent<Text>().text = $"{characteristic}{counter}: {_generic[$"{characteristic}{counter}"].name}";
                counter++;
            }
        }

        
        
    }
}
