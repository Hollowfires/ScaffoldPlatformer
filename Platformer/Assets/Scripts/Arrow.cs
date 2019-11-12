using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // config params
    [SerializeField] CrossHair crossHair1;
    [SerializeField] PlayerMovement character;
    //[SerializeField] AudioClip[] arrowSounds;
    [SerializeField] float speed = 20;

    // state
    Vector2 CrossHairToArrowVector;
    bool inFlight = false;
    [SerializeField] public bool bombArrow = true;

    

    // Cached component references
    //AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(inFlight == false)
        {
            LockArrowToCharacter();
            LaunchOnMouseClick();
            SwitchBombArrow();
        }
        else
        {
            if (this.transform.position.x > crossHair1.maxX | this.transform.position.x < crossHair1.minX | this.transform.position.y > crossHair1.maxY | this.transform.position.y < crossHair1.minY)
                ResetArrowPos();
        }
        
    }

    private void SwitchBombArrow()
    {
        if (Input.GetKeyDown(KeyCode.Q) && bombArrow == false)
        {
            bombArrow = true;
            Debug.Log("bomb arrow on");
        }

        else if (Input.GetKeyDown(KeyCode.Q) && bombArrow == true)
        {
            bombArrow = false;
            Debug.Log("bomb arrow off");
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {

            float xComponentUnit = (crossHair1.transform.position.x - 6) / Mathf.Sqrt(Mathf.Pow(crossHair1.transform.position.x - 6, 2) + Mathf.Pow(crossHair1.transform.position.y, 2));
            float yComponentUnit = (crossHair1.transform.position.y) / Mathf.Sqrt(Mathf.Pow(crossHair1.transform.position.x - 6, 2) + Mathf.Pow(crossHair1.transform.position.y, 2));

            inFlight = true;
            Vector2 crossHairPos = new Vector2(xComponentUnit, yComponentUnit);
            GetComponent<Rigidbody2D>().velocity = crossHairPos*speed;
        }
    }

    private void LockArrowToCharacter()
    {
        Vector2 characterPos = new Vector2(character.transform.position.x, character.transform.position.y);
        transform.position = characterPos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (inFlight) {
            AudioClip clip = arrowSounds[Random.Range(0, arrowSounds.Length)];
            myAudioSource.PlayOneShot(clip);
        }*/

        ResetArrowPos();

    }

    private void ResetArrowPos()
    {
        
       
            LockArrowToCharacter();
            inFlight = false;
     
    }

    
}
