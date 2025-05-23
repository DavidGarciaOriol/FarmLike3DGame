using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorController : MonoBehaviour
{

    // Componentes de movimiento
    private CharacterController controladorPersonaje;
    private Animator animator;

    private float velocidadMovimento = 1f;

    [Header("Movimiento del Jugador")]
    [SerializeField] float velocidadCaminar = 3f;
    [SerializeField] float velocidadCorrer = 5f;

    [Header("Interacciones")]
    InteraccionJugador interaccionJugador;

    private enum EstadoJugador
    {
        Idle,
        Caminando,
        Corriendo,
        Arando,
        Regando,
        Plantando,
        Cosechando,
    }

    private EstadoJugador estadoActualJugador = EstadoJugador.Idle;

    // Start is called before the first frame update
    void Start()
    {
        // Obtener componente de animaci�n
        animator = GetComponent<Animator>();

        // Obtener componente de control de personaje
        controladorPersonaje = GetComponent<CharacterController>();

        // Obtener componente de interacci�n
        interaccionJugador = GetComponentInChildren<InteraccionJugador>();
    }

    // Update is called once per frame
    void Update()
    {
        Moverse();
        Correr();
        Interactuar();
    }

    // Se encarga del movimiento del jugador
    void Moverse()
    {
        // Obtener inputs para movimiento horizontal y vertical
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Direcci�n
        Vector3 direccion = new Vector3(horizontal, 0f, vertical).normalized;

        // Velocidad de movimiento
        Vector3 velocidad = velocidadMovimento * Time.deltaTime * direccion;

        // Comprobar si hay movimiento
        if (direccion.magnitude >= 0.1f)
        {
            // Cambia estado a Caminar
            CambiarEstadoJugador(EstadoJugador.Caminando);

            // Mirar en la direcci�n adecuada
            transform.rotation = Quaternion.LookRotation(direccion);

            // Movimiento
            controladorPersonaje.Move(velocidad);
        }
        else
        {
            // Cambiar el estado a Idle
            CambiarEstadoJugador(EstadoJugador.Idle);
        }

        // Enlaza la velocidad del jugador con el par�metro
        // del animador para determinar la animaci�n
        animator.SetFloat("Velocidad", velocidad.magnitude);
    }

    // Maneja la funci�n de correr del jugador
    void Correr()
    {
        // Si la tecla de correr est� pulsada
        if (Input.GetButton("Correr"))
        {
            animator.SetBool("Corriendo", true);
            CambiarEstadoJugador(EstadoJugador.Corriendo);
            velocidadMovimento = velocidadCorrer;
        }
        else
        {
            animator.SetBool("Corriendo", false);
            CambiarEstadoJugador(EstadoJugador.Caminando);
            velocidadMovimento = velocidadCaminar;
        }
    }

    // Modifica el estado del jugador
    void CambiarEstadoJugador(EstadoJugador nuevoEstado)
    {
        EstadoJugador estadoAntiguo = estadoActualJugador;
        estadoActualJugador = nuevoEstado;
    }

    void Interactuar()
    {
        if (Input.GetButtonDown("Click"))
        {
            // Interactuar
            interaccionJugador.Interaccion();
        }

        //TODO: Interacci�n items
    }
}
