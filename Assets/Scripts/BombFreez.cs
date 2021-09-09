using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombFreez : MonoBehaviour
{
    private void OnMouseDown()
    {
        GetComponent<SphereCollider>().enabled = false;
        MonsterSpawner.freez = false;
        Destroy(gameObject);
    }
}
