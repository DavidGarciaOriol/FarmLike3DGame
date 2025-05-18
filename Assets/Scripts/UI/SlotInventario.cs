using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotInventario : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private DatosItem objetoAMostrar;

    [SerializeField] private Image imagenObjeto;
    
    public enum TipoInventario
    {
        Objeto,
        Herramienta
    }

    [SerializeField] // Determina de qu� secci�n del inventario forma parte este objeto u herramienta
    public TipoInventario tipoDeInventario;

    private int indiceSlot;

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

    public void AsignarIndiceSlot(int indice)
    {
        indiceSlot = indice;
    }

    // Muestra la informaci�n del objeto sobre el que est� el rat�n
    // en la caja de informaci�n del inventario
    public void OnPointerEnter(PointerEventData eventData)
    {
        UIManager.Instance.MostrarInformacionObjeto(objetoAMostrar);
    }

    // Oculta la informaci�n cuando el jugador aparta el rat�n del objeto
    public void OnPointerExit(PointerEventData eventData)
    {
        UIManager.Instance.MostrarInformacionObjeto(null);
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        ManagerInventario.Instance.InventarioHaciaMano(indiceSlot, tipoDeInventario);
    }
}
