using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    public GameObject defenderPrefab;
    private void OnMouseDown()
    {
        Vector2 mouseClickPos = Input.mousePosition;
        Vector2 clickPos = Camera.main.ScreenToWorldPoint(mouseClickPos);
        
        SpawnDefender(clickPos);
    }

    private void SpawnDefender(Vector2 position) 
    {
        GameObject defender = Instantiate(defenderPrefab, position, Quaternion.identity);
    }
}
