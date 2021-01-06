﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public int health = 100;
    public int damage = 15;

    private bool isBodyColliding = false;
    private float currentSpeed = 0.3f;
    private float prefferedSpeed;

    public void DealDamage(int damageToGive)
    {
        health -= damageToGive;
        if (health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Entity is dead!");
        }
    }
    
    public void SetMovementSpeed(float speed)
    {
        if (isBodyColliding)
        {
            return;
        }
        currentSpeed = speed;
        prefferedSpeed = currentSpeed;
    }

    public void ShootProjectile(GameObject projectile)
    {
        GameObject shotProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
        shotProjectile.GetComponent<Projectile>().Shoot();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (CompareTag("Attacker"))
        {
            if (currentSpeed > 0f)
            {
                transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
            }
        }
    }

    private IEnumerator HitDefender(Entity defender)
    {
        while (defender.health > 0)
        {
            yield return new WaitForSeconds(1);
            defender.DealDamage(damage);
        }

        isBodyColliding = false;
        SetMovementSpeed(prefferedSpeed);   
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Defender"))
        {
            SetMovementSpeed(0f);
            isBodyColliding = true; 
            StartCoroutine(HitDefender(other.GetComponent<Entity>()));
        }
    }
}