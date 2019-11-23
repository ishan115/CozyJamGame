using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleCollision : MonoBehaviour
{
    [SerializeField]
    Timer timer;
    [SerializeField]
    private Sprite deadKid;

    SpriteRenderer kidSpriteRenderer;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Executes if people are hit by snowballs
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Hit person");
            timer.AddTime();
            this.gameObject.GetComponent<SpriteRenderer>().sprite = deadKid;
        }
        if(collision.gameObject.tag == "Player")
        {
            timer.SubtractTime();
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = deadKid;
        }
    }
}
