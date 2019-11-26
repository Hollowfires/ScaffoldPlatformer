using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair : MonoBehaviour
{
    // configuration parameters
    //[SerializeField] public float minX = 1f;
    //[SerializeField] public float maxX = 15f;
    //[SerializeField] public float minY = 1f;
    //[SerializeField] public float maxY = 12f;
    //[SerializeField] float screenWidthInUnits = 16f;
    //[SerializeField] float screenHeightInUnits = 12f;

    Vector2 CrossHairPos;

    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] public float minY = 1f;
    [SerializeField] public float maxY = 11f;
    [SerializeField] float screenHeightInUnits = 12f;

    float xMin;
    float xMax;
    float yMin;
    float yMax;

    public float getXMin()
    {
        return xMin;
    }

    public float getXMax()
    {
        return xMax;
    }

    public float getYMin()
    {
        return yMin;
    }

    public float getYMax()
    {
        return yMax;
    }

    float padding = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
        float mousePosInUnitsY = Input.mousePosition.y ;
        float mousePosInUnitsX = Input.mousePosition.x ;
        Vector2 CrossHairPos = new Vector2(transform.position.x, transform.position.y);
        CrossHairPos.x = Mathf.Clamp(mousePosInUnitsX, xMin, xMax);
        CrossHairPos.y = Mathf.Clamp(mousePosInUnitsY, yMin, yMax);
        transform.position = CrossHairPos; */
        SetUpMoveBoundaries();
        Move();
    }

    private void Move()
    {

        float mousePosInUnitsY = Input.mousePosition.y / Camera.main.scaledPixelHeight * screenHeightInUnits;
        float mousePosInUnitsX = Input.mousePosition.x / Camera.main.scaledPixelWidth * screenWidthInUnits;
        CrossHairPos = new Vector2(transform.position.x, transform.position.y);
        CrossHairPos.x = Mathf.Clamp(mousePosInUnitsX + Camera.main.transform.position.x - 9, xMin, xMax);
        CrossHairPos.y = Mathf.Clamp(mousePosInUnitsY + Camera.main.transform.position.y - 6, yMin, yMax);
        Debug.Log("Cross hair position in x axis " + CrossHairPos.x);
        Debug.Log("Cross hair position in y axis " + CrossHairPos.y);
        transform.position = CrossHairPos;
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }
}
