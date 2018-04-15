using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shreadder : MonoBehaviour {

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<Pins>())
        {
            Destroy(other.transform.parent.gameObject);
        }
    }
}
