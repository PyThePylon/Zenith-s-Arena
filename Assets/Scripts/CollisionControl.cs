using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionControl : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        print("Landed on floor");
    }

    private void OnCollisionStay(Collision collision)
    {
       // print("Walking on floor");
    }

    private void OnCollisionExit(Collision collision)
    {
        print("Leaving floor");
    }

}
