using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] Transform PortalPoint;

    private void OnCollisionEnter(Collision collision)
    {
        // 0.23f
        // "Player"
        // >, <, <=, >=, !=, ==
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.position = PortalPoint.position;
        }
    }
}
