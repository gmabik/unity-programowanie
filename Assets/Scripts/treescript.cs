using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treescript : MonoBehaviour
{
    float hp = 100f;
    public GameObject deadTree;
    public void GetDamaged(float damage)
    {
        hp -= damage;
        if (hp <= 0f)
        {
            GameObject newDeadTree = Instantiate(deadTree, deadTree.transform.position + transform.position, Quaternion.identity);
            newDeadTree.transform.GetChild(0).GetComponent<Rigidbody>().AddForce(Vector3.forward * 100);
            newDeadTree.transform.GetChild(0).parent = null;
            Destroy(gameObject);
        }
    }
}
