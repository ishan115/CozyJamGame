using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardsAndPowerups : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 moveUp = new Vector3(0, 0.25f);
        this.transform.Translate(moveUp);
    }
}
