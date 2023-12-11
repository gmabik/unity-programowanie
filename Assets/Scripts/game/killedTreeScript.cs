using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killedTreeScript : MonoBehaviour
{
    public float hp = 100f;
    public void GetDamaged(float damage)
    {
        hp -= damage;
        if (hp <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
