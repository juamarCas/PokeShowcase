using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutScreen : MonoBehaviour
{
    void OnBecomeInvisible()
    {
        Debug.Log("Out of camera!");
        Destroy(this);
    }
}
