using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Objetos/Equipamiento")]
public class DatosEquipamiento : DatosItem
{
    enum TipoHerramienta
    {
        Azada,
        Regadera,
        Hacha,
        Pico
    }

    [SerializeField]
    private TipoHerramienta tipoHerramienta;
}
