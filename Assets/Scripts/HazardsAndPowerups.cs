using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardsAndPowerups : MonoBehaviour
{
    [SerializeField]
    private float translateUpAmount = 0.125f;

    private float slowDownLength = 5f;
    private bool isSlowed = false;
    

    void FixedUpdate()
    {
        if(isSlowed==true)
        {
            Vector3 moveUp = new Vector3(0, translateUpAmount/2);
            this.transform.Translate(moveUp);
        }
        else
        {
            Vector3 moveUp = new Vector3(0, translateUpAmount);
            this.transform.Translate(moveUp);
        }
    }

    public void SlowDown()
    {
        isSlowed = true;
        StartCoroutine("SlowTimer");
    }

    private IEnumerator SlowTimer()
    {
        yield return new WaitForSeconds(slowDownLength);
        isSlowed = false;
    }
}