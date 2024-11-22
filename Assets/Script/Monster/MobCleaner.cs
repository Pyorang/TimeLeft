using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobCleaner : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.GetComponent<Monster>() != null)
        {
            Destroy(collider.gameObject);
        }
    }
}
