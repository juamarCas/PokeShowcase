using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Actions;

public class UIManager : MonoBehaviour
{
    private FireCommand _fireCommand;
    
    [SerializeField]
    private Player _player;

    private void Awake()
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
