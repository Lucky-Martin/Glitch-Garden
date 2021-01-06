using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 2f;
    public float spinSpeed = 10f;
    public int damage = 20;

    private bool isShot = false;

    public void Shoot()
    {
        isShot = true;
    }

    private void Update()
    {
        if (isShot)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Check if the entity script is present
        Entity entity = other.GetComponent<Entity>();
        if (entity && other.CompareTag("Attacker"))
        {
            //Deal damage if so
            entity.DealDamage(damage);
        }
        //Destroy the projectile
        Destroy(gameObject);
    }
}
