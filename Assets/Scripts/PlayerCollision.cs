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
    [SerializeField]
    private AudioSource characterAudioSource;
    [SerializeField]
    private AudioClip shieldSound;
    [SerializeField]
    private AudioClip invincibleSound;
    [SerializeField]
    private AudioClip shieldBreak;
    [SerializeField]
    private AudioClip oldLadyOof;
    [SerializeField]
    private AudioClip adultOof;
    [SerializeField]
    private AudioClip kidOof;
    [SerializeField]
    private AudioClip obstacle;

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
                collisionAudio.PlayOneShot(shieldBreak);
                Shield = false;
            }
            else if (Invincible == false)
            {
                collisionAudio.PlayOneShot(kidOof);
                timer.SubtractTime();
            }
        }

        // Power Up Collisions
        if (collision.gameObject.tag == "PowerupShield")
        {
            collisionAudio.PlayOneShot(shieldSound);
            Debug.Log("Hit Shield Powerup");
            Shield = true;
        }
        if (collision.gameObject.tag == "PowerupInv")
        {
            collisionAudio.PlayOneShot(invincibleSound);
            Debug.Log("Hit Invincible Powerup");
            Invincible = true;
            StartCoroutine(ExecuteAfterTime(5));
        }
        if (collision.gameObject.tag == "PowerupShotgun")
        {
            collisionAudio.PlayOneShot(shieldSound);
            Debug.Log("Hit Shotgun Powerup");
            // TODO Shotgun Powerup
            collisionAudio.PlayOneShot(frenzyAudioClip, 1.0f);
        }
        if (collision.gameObject.tag == "PowerupFrenzy")
        {
            collisionAudio.PlayOneShot(shieldSound);
            Debug.Log("Hit Frenzy Powerup");
            shootingScript.StartCoroutine("FrenzyTimer");
            // TODO Frenzy Powerup
            collisionAudio.PlayOneShot(shotgunAudioClip, 1.0f);
        }
        if (collision.gameObject.tag == "PowerupTimeSlow")
        {
            collisionAudio.PlayOneShot(shieldSound);
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
