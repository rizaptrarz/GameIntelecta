using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crowbar : MonoBehaviour
{
    private float damage = 25f;
    [SerializeField] private Rigidbody2D rb;
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GiantBox box = collision.gameObject.GetComponent<GiantBox>();
        if (box != null && rb.velocity.magnitude > 40f)
        {
            Debug.Log("Damaging box");
            box.TakeDamage(damage);
        }
    }
}
