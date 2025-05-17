using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotInventario : MonoBehaviour
{
    [SerializeField] private DatosItem objetoAMostrar;

    [SerializeField] private Image imagenObjeto;

    public void Mostrar(DatosItem objetoAMostrar)
    {
        if (objetoAMostrar != null)
        {
            imagenObjeto.sprite = objetoAMostrar.Imagen;
            this.objetoAMostrar = objetoAMostrar;
            imagenObjeto.gameObject.SetActive(true);

            return;
        }

        imagenObjeto.gameObject.SetActive(false);
    }
}
