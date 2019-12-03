using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // config params
    [SerializeField] CrossHair crossHair1;
    [SerializeField] Character character;
    //[SerializeField] AudioClip[] arrowSounds;
    [SerializeField] float speed = 20;

    // state
    Vector2 CrossHairToArrowVector;
    bool inFlight = false;
    

    // Cached component references
    //AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (inFlight == false)
        {
            LockArrowToCharacter();
            LaunchOnMouseClick();
            SwitchBombArrow();
        }
        else
        {
            if (this.transform.position.x > crossHair1.getXMax() | this.transform.position.x < crossHair1.getXMin() | this.transform.position.y > crossHair1.getYMax() | this.transform.position.y < crossHair1.getYMin())
                ResetArrowPos();
        }

    }

    private void SwitchBombArrow()
    {
        if (Input.GetKeyDown(KeyCode.Q) && tag == "Untagged")
        {
            tag = "bomb";
            Debug.Log("bomb arrow on");
        }

        else if (Input.GetKeyDown(KeyCode.Q) && tag == "bomb")
        {
            tag = "Untagged";
            Debug.Log("bomb arrow off");
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {


            gameObject.GetComponent<Renderer>().enabled = true;
            Vector2 crossHairPos = new Vector2(crossHair1.transform.position.x, crossHair1.transform.position.y);
            Vector2 characterPos = new Vector2(character.transform.position.x, character.transform.position.y);

            Vector2 arrowVec = crossHairPos - characterPos;
            arrowVec.Normalize();
            inFlight = true;
            GetComponent<Rigidbody2D>().velocity = arrowVec * speed;

            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            Vector2 direction = new Vector2(mousePosition.x - character.transform.position.x,
                                            mousePosition.y - character.transform.position.y);

            transform.up = direction;
            transform.Rotate(new Vector3(0f, 0f, 90f));
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
        gameObject.GetComponent<Renderer>().enabled = false;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ResetArrowPos();
        gameObject.GetComponent<Renderer>().enabled = false;
    }

    private void ResetArrowPos()
    {


        LockArrowToCharacter();
        inFlight = false;
        GetComponent<Rigidbody2D>().angularVelocity = 0;

    }

   

}
