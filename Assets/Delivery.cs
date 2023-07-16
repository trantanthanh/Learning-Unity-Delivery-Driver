using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{

    private bool hasPackage = false;
    [SerializeField] float destroyDelay = 0.5f;
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Ouch !!!");
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackage)
        {
            hasPackage = true;
            Debug.Log("collect package");
            Destroy(other.gameObject, destroyDelay);
        }

        if (other.tag == "Customer" && hasPackage)
        {
            hasPackage = false;
            Debug.Log("Package delivered");
        }
    }
}
