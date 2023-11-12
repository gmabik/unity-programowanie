using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerinteract : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player" && Input.GetMouseButton(0))
        {
            transform.parent.GetComponent<treescript>().GetDamaged(other.gameObject.GetComponent<player>().damage);
        }
    }
}
