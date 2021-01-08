using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    private Defender _defenderPrefab;
    private ResourceSystem _resourceSystem;
    
    public void SetDefenderPrefab(Defender defender)
    {
        _defenderPrefab = defender;
        _resourceSystem = FindObjectOfType<ResourceSystem>();
    }
    
    private void OnMouseDown()
    {
        if (!_defenderPrefab)
        {
            return;
        }
        
        Vector2 mouseClickPos = Input.mousePosition;
        Vector2 clickPos = Camera.main.ScreenToWorldPoint(mouseClickPos);
        
        SpawnDefender(SnapToGrid(clickPos));
    }

    private Vector2 SnapToGrid(Vector2 worldPos)
    {
        Vector2 offset = _defenderPrefab.GetComponent<Entity>().offset;
        
        float gridX = Mathf.RoundToInt(worldPos.x) + offset.x;
        float gridY = Mathf.RoundToInt(worldPos.y) + offset.y;

        return new Vector2(gridX, gridY);
    }

    private void SpawnDefender(Vector2 position) 
    {
        //Check if we have enough stars
        if (_resourceSystem.GetStars() - _defenderPrefab.starsCost >= 0)
        {
            _resourceSystem.SpendStars(_defenderPrefab.starsCost);
            Defender defender = Instantiate(_defenderPrefab, position, Quaternion.identity);   
        }
    }
}
