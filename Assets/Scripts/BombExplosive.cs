using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosive : MonoBehaviour
{
    public delegate void ExplosiveBomb();
    public static ExplosiveBomb BombActive;

    private void OnMouseDown()
    {
        BombActive?.Invoke();
        Destroy(gameObject);
    }

}
