using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMaterials : MonoBehaviour
{
    public List<Material> MaterialsPlayer;
    public List<Material> MaterialsEnemy;

    public static ColorMaterials Initialization;

    private void Awake()
    {
        Initialization = this;
    }

}
