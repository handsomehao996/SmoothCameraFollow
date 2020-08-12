using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain : MonoBehaviour
{
    public int linkNumber = 9;
    public GameObject linkPref;
    public GameObject weihgt;

    Rigidbody2D previousRb;

    private void Start()
    {
        previousRb = GetComponent<Rigidbody2D>();
        for (int i = 0; i < linkNumber; i++)
        {
            GameObject link = Instantiate(linkPref, transform);
            HingeJoint2D hinge = link.GetComponent<HingeJoint2D>();
            hinge.connectedBody = previousRb;

            previousRb = link.GetComponent<Rigidbody2D>();
        }
        if(weihgt != null)
        {
            weihgt.GetComponent<HingeJoint2D>().connectedBody = previousRb;
        }
    }
}
