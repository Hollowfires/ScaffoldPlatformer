﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_Crosshair : MonoBehaviour
{
    // configuration parameters
    [SerializeField] public float minX = 1f;
    [SerializeField] public float maxX = 15f;
    [SerializeField] public float minY = 1f;
    [SerializeField] public float maxY = 12f;
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float screenHeightInUnits = 12f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float mousePosInUnitsY = Input.mousePosition.y / Screen.height * screenHeightInUnits;
        float mousePosInUnitsX = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 CrossHairPos = new Vector2(transform.position.x, transform.position.y);
        CrossHairPos.x = Mathf.Clamp(mousePosInUnitsX, minX, maxX);
        CrossHairPos.y = Mathf.Clamp(mousePosInUnitsY, minY, maxY);
        transform.position = CrossHairPos;
    }

    //center of a square image...
    //Area = (s)ide ^ 2
    //Vector2 crosshairCenter = new Vector2(transform.position.x, transform.position.y);
    //crosshairCenter = Vector2(numOfPixels.x(img)/2, numOfPixels.y(img)/2)
}
