using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceSystem : MonoBehaviour
{
    public TextMeshProUGUI displayText;
    private int _stars = 10;

    private void Start()
    {
        DisplayStars();
    }

    private void DisplayStars()
    {
        displayText.text = _stars.ToString();
    }

    public int GetStars()
    {
        return _stars;
    }
    
    public void AddStars(int stars)
    {
        _stars += stars;
        DisplayStars();
    }

    public void SpendStars(int stars)
    {
        _stars -= stars;
        DisplayStars();
    }
}
