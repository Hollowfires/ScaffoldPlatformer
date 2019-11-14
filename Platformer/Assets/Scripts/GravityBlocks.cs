using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBlocks : MonoBehaviour
{
    void Start()
    {
        Physics2D.gravity = new Vector2(0, -9.8f);
    }

    void Update()
    {
    }
}
