using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // config params
    [SerializeField] CrossHair crossHair1;
    [SerializeField] Character character;
    [SerializeField] AudioClip[] arrowSounds;
    [SerializeField] float speed = 20;

    // state
    Vector2 CrossHairToArrowVector;
    bool inFlight = false;

    // Cached component references
    AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(inFlight == false)
        {
            LockArrowToCrossHair();
            LaunchOnMouseClick();
        }
        else
        {
            ResetArrowPos();
        }
        
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {

            float xComponentUnit = (crossHair1.transform.position.x - 6) / Mathf.Sqrt(Mathf.Pow(crossHair1.transform.position.x - 6, 2) + Mathf.Pow(crossHair1.transform.position.y, 2)); // Vector math
            float yComponentUnit = (crossHair1.transform.position.y) / Mathf.Sqrt(Mathf.Pow(crossHair1.transform.position.x - 6, 2) + Mathf.Pow(crossHair1.transform.position.y, 2));

            inFlight = true;
            Vector2 crossHairPos = new Vector2(xComponentUnit, yComponentUnit);
            GetComponent<Rigidbody2D>().velocity = crossHairPos*speed;
        }
    }

    private void LockArrowToCrossHair()     // locks current crosshair position for the arrow. allows the arrow to fly straight without follow the crosshair mid-flight.
    {
        Vector2 characterPos = new Vector2(character.transform.position.x, character.transform.position.y);
        transform.position = characterPos;
    }

    private void OnCollisionEnter2D(Collision2D collision)      //play arrow sound once it is fired.
    {
        if (inFlight) {
            AudioClip clip = arrowSounds[Random.Range(0, arrowSounds.Length)];
            myAudioSource.PlayOneShot(clip);
        }
            
    }

    private void ResetArrowPos()        //returns arrow to its origin
    {
        if(this.transform.position.x > crossHair1.maxX | this.transform.position.x < crossHair1.minX | this.transform.position.y > crossHair1.maxY | this.transform.position.y < crossHair1.minY)
        {
            LockArrowToCrossHair();
            inFlight = false;
        }
    }

    
}
