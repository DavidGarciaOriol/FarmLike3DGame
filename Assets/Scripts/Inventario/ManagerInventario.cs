using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerInventario : MonoBehaviour
{
    public static ManagerInventario Instance;

    [Header("Inventario de herramientas")]
    [SerializeField] // Slots de Herramientas del inventario
    private DatosItem[] listaHerramientas = new DatosItem[8];

    [SerializeField] // Herramienta equipada en la mano
    private DatosItem herramientaEquipada = null;

    [Header("Inventario de objetos")]
    [SerializeField] // Slots de Objetos del inventario
    private DatosItem[] listaObjetos = new DatosItem[8];

    [SerializeField] // Objeto equipado en la mano
    private DatosItem objetoEquipado = null;

    /** Equipar Objetos */

    // Maneja el paso de inventario a la mano
    public void InventarioHaciaMano(int indiceSlot, SlotInventario.TipoInventario tipoDeInventario)
    {
        if (tipoDeInventario == SlotInventario.TipoInventario.Objeto)
        {
            // Almacenar los datos de los slots del inventario
            DatosItem objetoParaEquipar = listaObjetos[indiceSlot];

            // Mover el contenido del slot de inventario hacia la mano
            listaObjetos[indiceSlot] = objetoEquipado;

            // Mover el contenido del slot de la mano hacia el inventario
            objetoEquipado = objetoParaEquipar;
        }
        else
        {
            // Almacenar los datos de los slots del inventario
            DatosItem herramientaParaEquipar = listaHerramientas[indiceSlot];

            // Mover el contenido del slot de inventario hacia la mano
            listaHerramientas[indiceSlot] = herramientaEquipada;

            // Mover el contenido del slot de la mano hacia el inventario
            herramientaEquipada = herramientaParaEquipar;
        }

        // Actualizamos los cambios en la interfaz
        UIManager.Instance.RenderizarInventario();
    }

    // Maneja el paso de la mano al inventario correspondiente
    public void ManoHaciaInventario(SlotInventario.TipoInventario tipoDeInventario)
    {

    }

    // Patrón singleton en el manager de inventario
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

    public DatosItem[] ListaHerramientas { get => listaHerramientas; set => listaHerramientas = value; }
    public DatosItem HerramientaEquipada { get => herramientaEquipada; set => herramientaEquipada = value; }
    public DatosItem[] ListaObjetos { get => listaObjetos; set => listaObjetos = value; }
    public DatosItem ObjetoEquipado { get => objetoEquipado; set => objetoEquipado = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
