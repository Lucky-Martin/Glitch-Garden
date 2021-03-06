﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public int health = 100;
    public int damage = 15;
    public Vector2 offset;
    public GameObject deathVFX;
    
    private bool _isBodyColliding = false;
    private float _currentSpeed = 0.3f;
    private float _prefferedSpeed;

    public void DealDamage(int damageToGive)
    {
        health -= damageToGive;
        if (health <= 0)
        {
            GameObject vfx = Instantiate(deathVFX, transform.position, transform.rotation);
            Destroy(vfx, 2f);
            
            Destroy(gameObject);
        }
    }
    
    public void SetMovementSpeed(float speed)
    {
        if (_isBodyColliding)
        {
            return;
        }
        _currentSpeed = speed;
        _prefferedSpeed = _currentSpeed;
    }

    public void ShootProjectile(GameObject projectile)
    {
        GameObject shotProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
        shotProjectile.GetComponent<Projectile>().Shoot();
        Debug.Log(shotProjectile);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (CompareTag("Attacker"))
        {
            if (_currentSpeed > 0f)
            {
                transform.Translate(Vector2.left * _currentSpeed * Time.deltaTime);
            }
        }
    }

    private IEnumerator HitDefender(Entity defender)
    {
        while (defender.health > 0)
        {
            yield return new WaitForSeconds(1);
            if (gameObject)
            {
                defender.DealDamage(damage);
            }
        }

        _isBodyColliding = false;
        SetMovementSpeed(_prefferedSpeed);   
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Check if this instance "Attacker" collides with "Defender"
        if (other.CompareTag("Defender") && CompareTag("Attacker"))
        {
            Debug.Log("Entity hit");
            SetMovementSpeed(0f);
            _isBodyColliding = true; 
            StartCoroutine(HitDefender(other.GetComponent<Entity>()));
        }
    }
}
