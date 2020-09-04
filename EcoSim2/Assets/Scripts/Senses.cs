using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Senses : MonoBehaviour
{
    [SerializeField] float senseRadius = 1f;

    RaycastHit[] EntitiesInSenseArea()
    {
        return Physics.SphereCastAll(this.transform.position, senseRadius, Vector3.up, 0);
    }

    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, senseRadius);
    }

}
