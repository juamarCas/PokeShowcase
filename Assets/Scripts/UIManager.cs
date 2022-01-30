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
    
    [SerializeField]
    private Player _player;

    

    private void Start()
    {
        _fireCommand = new FireCommand();
    }

    public void Attack()
    {
        _fireCommand.Execute(ref _player);
    }

    public void Search()
    {
        Debug.Log("Search!");
    }
}
