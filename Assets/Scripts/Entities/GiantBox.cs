using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantBox : MonoBehaviour
{
    private float health = 100f;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            DestroyBox();
        }
    }
    
    private void DestroyBox()
    {
        Destroy(gameObject);
    }
}
