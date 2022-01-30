using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Transform m_weaponTransform;
    [SerializeField]
    private GameObject m_bullet;

    [SerializeField]
    [Range(0, 100)]
    private int m_bulletForce = 10;

    private Transform _target;

    private void Awake()
    {
        _target = this.GetComponent<CameraController>()._target;
    }

    public void Attack()
    {
        if (m_bullet == null) return;

        GameObject bullet = Instantiate(m_bullet, m_weaponTransform.position, transform.rotation);
        Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();

        Vector3 dir = _target.position - transform.position;
        Vector3 dir_norm = Vector3.Normalize(dir);
        bulletRB.AddForce( dir * m_bulletForce, ForceMode.Impulse);
    }
}
