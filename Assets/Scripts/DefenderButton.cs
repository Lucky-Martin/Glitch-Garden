using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    public Defender defenderPrefab;
    private DefenderSpawner _defenderSpawner;

    private void Start()
    {
        _defenderSpawner = FindObjectOfType<DefenderSpawner>();
    }

    private void OnMouseDown()
    {
        DefenderButton[] buttons = FindObjectsOfType<DefenderButton>();

        foreach (DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(114, 114, 114, 255);    
        }
        
        _defenderSpawner.SetDefenderPrefab(defenderPrefab);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
