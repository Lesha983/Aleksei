using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosive : MonoBehaviour
{
    [SerializeField] private List<GameObject> _monsters;

    private void OnMouseDown()
    {
        _monsters.AddRange(GameObject.FindGameObjectsWithTag("Monster"));
        Explosive();
    }

    private void Explosive()
    {
        //_monsters.AddRange(GameObject.FindGameObjectsWithTag("Monster"));
        foreach (GameObject monster in _monsters)
        {
            monster.GetComponent<Enemy>().DiedMonster();
        }
        GetComponent<SphereCollider>().enabled = false;
        Destroy(gameObject);
    }
}
