using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectCollision : MonoBehaviour
{
    public static int collideNumber = 0;
    private mainContraol mainControl;

    void Awake()
    {
        mainControl = GameObject.FindObjectOfType<mainContraol>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "needle")
        {
            ++collideNumber;
            Debug.Log(col.gameObject.transform.localScale.x);
            Destroy(col.gameObject);
        }
        //update the score
        mainControl.collisionNumber = collideNumber;
    }
}
