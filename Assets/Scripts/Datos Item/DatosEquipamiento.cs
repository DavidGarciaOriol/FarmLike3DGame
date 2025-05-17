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

    [Header("Tipo de herramienta")]
    [SerializeField]
    private TipoHerramienta tipoHerramienta;
}
