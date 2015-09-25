using UnityEngine;
using System.Collections;

public class backToMainland : MonoBehaviour
{
    public Transform mainLandTrans;


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.transform.position = mainLandTrans.position;
        }
    }
}
