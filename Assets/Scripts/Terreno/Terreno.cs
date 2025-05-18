using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DatosEquipamiento;

public class Terreno : MonoBehaviour
{
    [Header("Materiales del terreno")]
    [SerializeField]
    private Material terrenoHierba, terrenoArado, terrenoRegado;

    // Rendereizador del terreno
    private Renderer renderizadorTerreno;

    [Header("Selector")]
    // Selector de interacción del personaje
    [SerializeField] private GameObject selector;

    // Estados del terreno
    private enum EstadoTerreno
    {
        Hierba,
        Arado,
        Regado
    }

    // Estado actual del terreno
    private EstadoTerreno estadoActualTerreno;

    // Start is called before the first frame update
    void Start()
    {
        // Componente de renderizado del terreno
        renderizadorTerreno = GetComponent<Renderer>();

        // Estado por defecto del terreno
        CambiarEstadoTerreno(EstadoTerreno.Hierba);

        // Deseleccionar el terreno por defecto
        Seleccionar(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Cambios de estado del terreno
    void CambiarEstadoTerreno(EstadoTerreno nuevoEstado)
    {
        EstadoTerreno estadoActual = estadoActualTerreno;
        estadoActualTerreno = nuevoEstado;

        // Llama al cambio de material acorde al nuevo estado
        CambiarMaterialTerreno(nuevoEstado);
    }

    // Cambia el material del terreno según el estado del mismo
    void CambiarMaterialTerreno(EstadoTerreno estadoTerreno)
    {
        Material nuevoMaterial = terrenoHierba;

        switch (estadoTerreno)
        {
            case EstadoTerreno.Hierba:
                // Cambia a material hierba
                nuevoMaterial = terrenoHierba;
                break;

            case EstadoTerreno.Arado:
                // Cambia a material terreno arado
                nuevoMaterial = terrenoArado;
                break;

            case EstadoTerreno.Regado:
                // Cambia a material terreno regado
                nuevoMaterial = terrenoRegado;
                break;
        }

        // Llama al renderizador para que muestre el nuevo material
        CambiarRenderizadoTerreno(nuevoMaterial);
    }

    // Se encarga de modificar el renderizador para mostrar el nuevo material
    void CambiarRenderizadoTerreno(Material nuevoMaterialRenderizado)
    {
        renderizadorTerreno.material = nuevoMaterialRenderizado;
    }

    // Cambia el estado del selector para mostrarse o no
    public void Seleccionar(bool condicion)
    {
        selector.SetActive(condicion);
    }

    // Cuando el jugador presiona el botón de interacción seleccioanndo el terreno
    public void Interactuar()
    {
        // Comprueba la herramienta que el jugador tiene equipada
        DatosItem slotHerramienta = ManagerInventario.Instance.HerramientaEquipada;

        // Comprobamos que el objeto sea de tipo herramienta
        DatosEquipamiento herramienta = slotHerramienta as DatosEquipamiento;
        if (herramienta != null)
        {
            DatosEquipamiento.TipoHerramienta tipoDeHerramienta = herramienta.tipoHerramienta;
            switch (tipoDeHerramienta)
            {
                case DatosEquipamiento.TipoHerramienta.Azada:
                    if (estadoActualTerreno == EstadoTerreno.Hierba)
                        CambiarEstadoTerreno(EstadoTerreno.Arado);
                    else
                        Debug.Log("Este terreno ya está arado.");
                    break;

                case DatosEquipamiento.TipoHerramienta.Regadera:
                    if (estadoActualTerreno == EstadoTerreno.Arado)
                        CambiarEstadoTerreno(EstadoTerreno.Regado);
                    else
                        Debug.Log("Debes arar el terreno para regarlo.");

                    break;
            }
        }
        else
        {
            Debug.Log("No tienes ninguna herramienta equipada.");
        }
    }
}