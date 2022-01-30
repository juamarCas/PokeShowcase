using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This class will store global values needed by any object*/
public class DB : MonoBehaviour
{

    #region singleton
    public static DB _instance;

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
    [SerializeField]
    private string m_pokemonTag = "Pokemon";
    [SerializeField]
    private List<string> m_charsList = new List<string>();

    private string m_typeString = "types";
    private string m_abilityString = "abilities";

    /*find these elements in the list*/
    private int m_typePos;
    private int m_abilityPos;

    private void Start()
    {
        m_typePos = m_charsList.IndexOf(m_typeString);
        m_abilityPos = m_charsList.IndexOf(m_abilityString);
    }

    public List<string> _charList
    {
        get { return m_charsList; }
        private set { }
    }

    public string _pokemonTag
    {
        get { return m_pokemonTag; }
        private set { }
    }

    public string _typeString
    {
        get { return m_typeString; }
        private set { }

    } 

    public string _abilityString
    {
        get { return m_abilityString; }
        private set { }
    }

    public int _typePos
    {
        get { return m_typePos; }
        private set { }
    }

    public int _abilityPos
    {
        get { return m_abilityPos; }
        private set { }
    }
}
