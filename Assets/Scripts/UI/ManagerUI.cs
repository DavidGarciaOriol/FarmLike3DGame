using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManagerUI : MonoBehaviour, IObservadorDeTiempo
{
    public static ManagerUI Instance { get; private set; }

    [Header("HUD - Información")]
    [SerializeField] private Image slotHerramientaEquipada;

    [SerializeField] private TextMeshProUGUI tiempoTexto;
    [SerializeField] private TextMeshProUGUI fechaTexto;

    [Header("Sistema de Inventario")]
    [SerializeField] private GameObject panelInventario;
    [SerializeField] private SlotInventario[] slotsHerramientas;
    [SerializeField] private SlotInventario[] slotsObjetos;

    [Header("Objetos Equipados")]
    [SerializeField] private SlotInventarioMano slotHerramientaEnMano;
    [SerializeField] private SlotInventarioMano slotObjetoEnMano;

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
        AsignarIndicesSlots();

        // Agrega el UI Manager
        ManagerTiempo.Instance.RegistrarObservador(this);
    }

    public void AsignarIndicesSlots()
    {
        for (int i = 0; i < slotsHerramientas.Length; i++) 
        {
            slotsHerramientas[i].AsignarIndiceSlot(i);
            slotsObjetos[i].AsignarIndiceSlot(i);
        }
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

        // Renderiza los slots de objetos equipados
        slotHerramientaEnMano.Mostrar(ManagerInventario.Instance.HerramientaEquipada);
        slotObjetoEnMano.Mostrar(ManagerInventario.Instance.ObjetoEquipado);

        // Cogemos la herramienta equipada
        DatosItem herramientaEquipada = ManagerInventario.Instance.HerramientaEquipada;

        if (herramientaEquipada != null)
        {
            slotHerramientaEquipada.sprite = herramientaEquipada.Imagen;

            slotHerramientaEquipada.gameObject.SetActive(true);

            return;
        }

        slotHerramientaEquipada.gameObject.SetActive(false);
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

    // Maneja el HUD según el tiempo
    public void ActualizacionDeReloj(TiempoDeJuego tiempoDeJuego)
    {
        // Maneja la hora

        int horas = tiempoDeJuego.Hora;
        int minutos = tiempoDeJuego.Minuto;

        tiempoTexto.text = horas.ToString("00") + ":" + minutos.ToString("00");

        // Maneja la fecha
        int dia = tiempoDeJuego.Dia;
        string estacion = tiempoDeJuego.estacionActual.ToString();
        string diaDeLaSemana = tiempoDeJuego.ObtenerDiaDeLaSemana().ToString();

        fechaTexto.text = estacion + " " + dia + " (" + diaDeLaSemana.Substring(0,3) + ")";
    }
}
