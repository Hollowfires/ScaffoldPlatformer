using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair : MonoBehaviour
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
        float mousePosInUnitsY = Input.mousePosition.y / Screen.height * screenHeightInUnits; //replaced "Screen.width" in this line with "Screen.height"
        float mousePosInUnitsX = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 CrossHairPos = new Vector2 (transform.position.x, transform.position.y);
        CrossHairPos.x = Mathf.Clamp(mousePosInUnitsX, minX, maxX);
        CrossHairPos.y = Mathf.Clamp(mousePosInUnitsY, minY, maxY);
        transform.position = CrossHairPos;
    }
}
