using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    bool isColliding = false;
    
    void Update ()
    {
        if (isColliding)	// If currently being focused
        {
         
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Interact();
            }
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
            isColliding = true;
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
            isColliding = true;
    }
    
    public virtual void Interact ()
    {
		
    }
}
