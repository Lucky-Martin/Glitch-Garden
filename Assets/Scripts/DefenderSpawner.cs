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
        
        SpawnDefender(SnapToGrid(clickPos));
    }

    private Vector2 SnapToGrid(Vector2 worldPos)
    {
        Vector2 offset = defenderPrefab.GetComponent<Entity>().offset;
        
        float gridX = Mathf.RoundToInt(worldPos.x) + offset.x;
        float gridY = Mathf.RoundToInt(worldPos.y) + offset.y;

        return new Vector2(gridX, gridY);
    }

    private void SpawnDefender(Vector2 position) 
    {
        GameObject defender = Instantiate(defenderPrefab, position, Quaternion.identity);
    }
}
