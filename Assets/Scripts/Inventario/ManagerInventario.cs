using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerInventario : MonoBehaviour
{
    private ManagerInventario instance;

    public ManagerInventario Instance { get => instance; private set => instance = value; }

    // Patrón singleton en el manager de inventario
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
