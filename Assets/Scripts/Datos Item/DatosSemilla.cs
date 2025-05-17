using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Objetos/Semilla")]
public class DatosSemilla : DatosItem
{
    [Header("Informaci�n de la semilla")]
    [SerializeField] // Tiempo necesario para que la semilla madure en una hortaliza
    private int diasParaCrecer;

    [SerializeField] // Hortaliza que proporcionar� la semilla tras madurar
    private DatosItem hortalizaQueProporciona;
}
