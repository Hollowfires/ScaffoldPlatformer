using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    public GameObject mainObject;




    private void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.gameObject.tag == "bomb")
         {
             DestroyBlock();
         }
    }
    
    private void DestroyBlock()
    {
        //AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        
        
            Destroy(gameObject);
            TriggerSparklesVFX();
        
        
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }

}
