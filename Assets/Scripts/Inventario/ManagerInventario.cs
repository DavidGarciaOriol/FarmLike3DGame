using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerInventario : MonoBehaviour
{
    public static ManagerInventario Instance;

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

    [Header("Inventario de herramientas")]
    [SerializeField] // Slots de Herramientas del inventario
    private DatosItem[] listaHerramientas = new DatosItem[8];

    [SerializeField] // Herramienta equipada en la mano
    private DatosItem herramientaEuipada = null;

    [Header("Inventario de objetos")]
    [SerializeField] // Slots de Objetos del inventario
    private DatosItem[] listaObjetos = new DatosItem[8];

    [SerializeField] // Objeto equipado en la mano
    private DatosItem objetoEquipado = null;

    public DatosItem[] ListaHerramientas { get => listaHerramientas; set => listaHerramientas = value; }
    public DatosItem HerramientaEuipada { get => herramientaEuipada; set => herramientaEuipada = value; }
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
