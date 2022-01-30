using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision == null) return;

        if (collision.collider == null) return;

        if(collision.gameObject.tag == DB._instance._pokemonTag)
        {
            Renderer _renderer = collision.gameObject.GetComponent<Renderer>();

            float r = Random.Range(0.0f, 1.0f);
            float g = Random.Range(0.0f, 1.0f);
            float b = Random.Range(0.0f, 1.0f);
            Color r_color = new Color(r, g, b, 1.0f);
            _renderer.material.SetColor("_Color", r_color);
        }
    }
}
