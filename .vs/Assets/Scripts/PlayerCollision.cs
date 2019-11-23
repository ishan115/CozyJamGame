using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    private Timer timer;
    [SerializeField]
    private Spawning spawningObject;
    [SerializeField]
    private Shooting shootingScript;


    //sound instantiation
    private AudioSource collisionAudio;
    public AudioClip frenzyAudioClip;
    public AudioClip shotgunAudioClip;

    bool Shield = false;
    bool Invincible = false;

    private void Start()
    {
        collisionAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Hazard")
        {
            Debug.Log("Hit Hazard");
            if (Shield == true)
            {
                Shield = false;
            }
            else if (Invincible == false)
            {
                timer.SubtractTime();
            }
        }

        // Power Up Collisions
        if (collision.gameObject.tag == "PowerupShield")
        {
            Debug.Log("Hit Shield Powerup");
            Shield = true;
        }
        if (collision.gameObject.tag == "PowerupInv")
        {
            Debug.Log("Hit Invincible Powerup");
            Invincible = true;
            StartCoroutine(ExecuteAfterTime(5));
        }
        if (collision.gameObject.tag == "PowerupShotgun")
        {
            Debug.Log("Hit Shotgun Powerup");
            // TODO Shotgun Powerup
            collisionAudio.PlayOneShot(frenzyAudioClip, 1.0f);
        }
        if (collision.gameObject.tag == "PowerupFrenzy")
        {
            Debug.Log("Hit Frenzy Powerup");
            shootingScript.StartCoroutine("FrenzyTimer");
            // TODO Frenzy Powerup
            collisionAudio.PlayOneShot(shotgunAudioClip, 1.0f);
        }
        if (collision.gameObject.tag == "PowerupTimeSlow")
        {
            Debug.Log("Hit TimeSlow Powerup");
            // TODO Time Slow Powerup
            timer.SlowTimer();
            spawningObject.StartSlowTimer();
        }

        IEnumerator ExecuteAfterTime(float time)
        {
            yield return new WaitForSeconds(time);
            Invincible = false;
        }
    }
}
