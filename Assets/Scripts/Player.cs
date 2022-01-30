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

    private Transform m_target;

    public Transform _target {
        get { return m_target; }
        private set { }
    }

    private void Awake()
    {
        m_target = this.GetComponent<CameraController>()._target;
    }

    /*
     Creates a bullet and push it to the targets direction
     */
    public void Attack()
    {
        if (m_bullet == null) return;

        GameObject bullet = Instantiate(m_bullet, m_weaponTransform.position, transform.rotation) as GameObject;
        Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();

        Vector3 dir = m_target.position - transform.position;
        Vector3 dir_norm = Vector3.Normalize(dir);
        bulletRB.AddForce( dir_norm * m_bulletForce, ForceMode.Impulse);
    }
}
