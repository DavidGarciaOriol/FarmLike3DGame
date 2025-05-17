using UnityEngine;

public class InteraccionJugador : MonoBehaviour
{
    private JugadorController jugadorController;

    // La parte del terreno que el jugador est� seleccionando actualmente
    Terreno terrenoSeleccionado = null;

    // Start is called before the first frame update
    void Start()
    {
        // Accede al componente Jugador Controller
        jugadorController = transform.parent.GetComponent<JugadorController>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1))
        {
            EnHitInteractuable(hit);
        }
    }

    // Cuando el raycast toca con algo interactuable
    void EnHitInteractuable(RaycastHit hit)
    {
        Collider otro = hit.collider;
        
        // Si el jugador est� interactuando con terreno
        if (otro.tag == "Terreno")
        {
            Terreno terreno = otro.GetComponent<Terreno>();
            SeleccionarTerreno(terreno);
            return;
        }

        // Si el jugador no interact�a con terreno
        if (terrenoSeleccionado != null)
        {
            terrenoSeleccionado.Seleccionar(false);
            terrenoSeleccionado = null;
        }
    }

    // Maneja el proceso de selecci�n
    void SeleccionarTerreno(Terreno terreno)
    {
        if (terrenoSeleccionado != null)
        {
            terrenoSeleccionado.Seleccionar(false);
        }

        // Cambia el terreno seleccionado al que estamos seleccionando actualmente
        terrenoSeleccionado = terreno;
        terreno.Seleccionar(true);
    }

    // Cuando el jugador presiona el bot�n de interacci�n
    public void Interaccion()
    {
        // Comprueba si el jugador est� seleccionando terreno
        if (terrenoSeleccionado != null)
        {
            terrenoSeleccionado.Interactuar();
            return;
        }

        Debug.Log("No est�s en ning�n terreno.");
    }
}
