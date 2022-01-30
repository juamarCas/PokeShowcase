using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform m_target;

    public Transform _target{
        get{
            return m_target;
        }
        
        private set
        { }
    }

    [SerializeField]
    private float m_vel = 100.0f;

    void Start()
    {
        transform.LookAt(m_target.position);
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(m_target.position, Vector3.up, -Input.GetAxis("Horizontal") * m_vel * Time.deltaTime);
        transform.Translate(Vector3.forward * Input.GetAxis("Mouse ScrollWheel"));
    }
}
