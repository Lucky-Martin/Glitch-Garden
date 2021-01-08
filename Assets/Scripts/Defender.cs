using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    public int starsCost = 5;
    
    private ResourceSystem _resourceSystem;

    private void Start()
    {
        _resourceSystem = FindObjectOfType<ResourceSystem>();
    }

    public void GainStars(int stars)
    {
        _resourceSystem.AddStars(stars);
    }

    public void BuyDefender()
    {
        _resourceSystem.SpendStars(starsCost);   
    }
}
