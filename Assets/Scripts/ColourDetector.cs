using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourDetector : MonoBehaviour
{
    public string colour;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(colour))
        {
            print("Match");
        }
        else
        {
            print("Didnt Match");
        }
    }
}
