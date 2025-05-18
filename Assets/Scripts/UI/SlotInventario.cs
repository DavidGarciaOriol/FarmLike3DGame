using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotInventario : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private DatosItem objetoAMostrar;

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

    // Muestra la información del objeto sobre el que está el ratón
    // en la caja de información del inventario
    public void OnPointerEnter(PointerEventData eventData)
    {
        UIManager.Instance.MostrarInformacionObjeto(objetoAMostrar);
    }

    // Oculta la información cuando el jugador aparta el ratón del objeto
    public void OnPointerExit(PointerEventData eventData)
    {
        UIManager.Instance.MostrarInformacionObjeto(null);
    }
}
