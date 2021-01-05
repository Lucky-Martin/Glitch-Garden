using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    public bool canMove = false;
    
    private float currentSpeed = 0.3f;

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void ShootProjectile()
    {
        Debug.Log("Shoot now!");
    }
    
    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        }
    }
}
