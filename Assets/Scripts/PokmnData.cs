using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokmnData: MonoBehaviour
{
    [SerializeField]
    private string m_name;

    public string _name
    {
        get { return m_name; }
        private set { }
    }
}
