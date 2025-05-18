using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("Sistema de Inventario")]
    [SerializeField] private GameObject panelInventario;
    [SerializeField] private SlotInventario[] slotsHerramientas;
    [SerializeField] private SlotInventario[] slotsObjetos;

    [Header("Información sobre Objetos")]
    [SerializeField] private TextMeshProUGUI textoNombreObjeto;
    [SerializeField] private TextMeshProUGUI textoDescripcionObjeto;


    // Patrón singleton en el manager de UI
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        RenderizarInventario();
    }

    // Renderiza la pantalla de inventario para que refleje el del usuario
    public void RenderizarInventario()
    {
        // Cogemos los slots de herramientas del manager de inventario
        DatosItem[] slotsHerramientasInventario = ManagerInventario.Instance.ListaHerramientas;

        // Cogemos los slots de herramientas del manager de inventario
        DatosItem[] slotsObjetosInventario = ManagerInventario.Instance.ListaObjetos;

        // Renderiza el panel de herramientas
        RenderizarPanelInventario(slotsHerramientasInventario, slotsHerramientas);

        // Renderiza el panel de objetos
        RenderizarPanelInventario(slotsObjetosInventario, slotsObjetos);
    }

    // Renderiza un panel del inventario
    void RenderizarPanelInventario(DatosItem[] slots, SlotInventario[] uiSlots)
    {
        for (int i = 0; i < uiSlots.Length; i++)
        {
            uiSlots[i].Mostrar(slots[i]);
        }
    }

    // Muestra o desactiva el panel del inventario general
    public void CambiarPanelInventario()
    {
        // Si está activo, lo desactiva y viceversa
        panelInventario.SetActive(!panelInventario.activeSelf);
        RenderizarInventario();
    }

    public void MostrarInformacionObjeto(DatosItem datos)
    {
        if (datos == null)
        {
            textoNombreObjeto.text = "";
            textoDescripcionObjeto.text = "";
            return;
        }

        textoNombreObjeto.text = datos.name;
        textoDescripcionObjeto.text = datos.Descripcion;
    }
}
