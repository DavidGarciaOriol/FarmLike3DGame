using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Objetos/Objetos")]
public class DatosItem : ScriptableObject
{
    [Header("Datos del objeto")]
    [SerializeField][TextArea] // Descripción del objeto
    private string descripcion;

    [SerializeField] // Icono que se muestra en la UI
    private Sprite imagen;

    [SerializeField] // Modelado del objeto que se verá en el juego
    private GameObject modelado;

    DatosEquipamiento equipamiento;
}
