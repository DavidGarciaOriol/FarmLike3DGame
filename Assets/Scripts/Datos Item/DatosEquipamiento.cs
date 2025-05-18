using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Objetos/Equipamiento")]
public class DatosEquipamiento : DatosItem
{
    public enum TipoHerramienta
    {
        Azada,
        Regadera,
        Hacha,
        Pico
    }

    [Header("Tipo de herramienta")]
    public TipoHerramienta tipoHerramienta;
}
