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
    
    public string _pokemonTag
    {
        get { return m_pokemonTag; }
        private set { }
    }

}
