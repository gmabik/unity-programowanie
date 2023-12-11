using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerinteract : MonoBehaviour
{
    [SerializeField] private float interactCD;
    [SerializeField] private bool isOnCD;
    private float timer;
    private void OnTriggerStay(Collider other)
    {
        if (!isOnCD && other.gameObject.tag == "Player" && Input.GetMouseButton(0))
        {
            float currentDamage = other.gameObject.GetComponent<player>().damage * Random.Range(0.5f, 1.5f);
            if (transform.parent.TryGetComponent<treescript>(out treescript script))
            {
                script.GetDamaged(currentDamage);
                other.gameObject.GetComponent<player>().GetExp(currentDamage);
            }
            else if (transform.parent.TryGetComponent<killedTreeScript>(out killedTreeScript script2))
            {
                script2.GetDamaged(currentDamage);
                other.gameObject.GetComponent<player>().GetExp(currentDamage);
            }
            isOnCD = true;
            timer = 0f;
        }
    }

    private void Update()
    {
        if (isOnCD)
        {
            timer += Time.deltaTime;
            if (timer > interactCD) isOnCD = false;
        }
    }
}
