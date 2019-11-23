using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteStuff : MonoBehaviour
{
    [SerializeField]
    private Spawning spawningObject;

    private void OnTriggerEnter2D(Collider2D other)
    {
        spawningObject.RemoveInstantiatedObjectFromList(other.gameObject);
        Destroy(other.gameObject);
    }
}
