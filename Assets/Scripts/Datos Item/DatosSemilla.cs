using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Objetos/Semilla")]
public class DatosSemilla : DatosItem
{
    // Tiempo necesario para que la semilla madure en una hortaliza
    private int diasParaCrecer;

    // Hortaliza que proporcionará la semilla tras madurar
    private DatosItem hortalizaQueProporciona;
}
