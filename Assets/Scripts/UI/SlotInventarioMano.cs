using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotInventarioMano : SlotInventario
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        ManagerInventario.Instance.ManoHaciaInventario(tipoDeInventario);
    }
}
