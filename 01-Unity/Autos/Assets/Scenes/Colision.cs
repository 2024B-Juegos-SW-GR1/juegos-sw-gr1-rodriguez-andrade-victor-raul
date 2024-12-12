using System;
using UnityEngine;

public class Colision : MonoBehaviour
{
    private bool hasPackage;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    [SerializeField] private float destroyDelay = 0.5f;
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Golpeee");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entrando a Trigger");
        
        if (other.tag == "Paquete" && hasPackage != true)
        {
            Debug.Log("Paquete recogido");
            hasPackage = true;
            Destroy(other.gameObject, destroyDelay);
        }

        if (other.tag == "Cliente" && hasPackage == true)
        {
            Debug.Log("Paquete entregado");
            hasPackage = false;
            _spriteRenderer.color = Color.red;
        }
    }
}
