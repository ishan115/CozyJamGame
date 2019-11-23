using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardsAndPowerups : MonoBehaviour
{
    [SerializeField]
    private float translateUpAmount = 0.125f;

    private float slowDownLength = 5f;


    void FixedUpdate()
    {
        Vector3 moveUp = new Vector3(0, translateUpAmount);
        this.transform.Translate(moveUp);
    }

    public void SlowDown()
    {
        translateUpAmount = translateUpAmount / 2;
        StartCoroutine("SlowTimer");
    }

    private IEnumerator SlowTimer()
    {
        yield return new WaitForSeconds(slowDownLength);
        translateUpAmount = translateUpAmount * 2;
    }
}