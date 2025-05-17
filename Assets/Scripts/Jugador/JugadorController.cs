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

    private void Awake()
    {
        // Obtener componentes de movimiento
        animator = GetComponent<Animator>();
        controladorPersonaje = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Moverse();
        Correr();
    }

    // Se encarga del movimiento del jugador
    void Moverse()
    {
        // Obtener inputs para movimiento horizontal y vertical
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Dirección
        Vector3 direccion = new Vector3(horizontal, 0f, vertical).normalized;

        // Velocidad de movimiento
        Vector3 velocidad = velocidadMovimento * Time.deltaTime * direccion;

        // Comprobar si hay movimiento
        if (direccion.magnitude >= 0.1f)
        {
            // Cambia estado a Caminar
            CambiarEstadoJugador(EstadoJugador.Caminando);

            // Mirar en la dirección adecuada
            transform.rotation = Quaternion.LookRotation(direccion);

            // Movimiento
            controladorPersonaje.Move(velocidad);
        }
        else
        {
            // Cambiar el estado a Idle
            CambiarEstadoJugador(EstadoJugador.Idle);
        }

        // Enlaza la velocidad del jugador con el parámetro
        // del animador para determinar la animación
        animator.SetFloat("Velocidad", velocidad.magnitude);
    }

    // Maneja la función de correr del jugador
    void Correr()
    {
        // Si la tecla de correr está pulsada
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
    private void CambiarEstadoJugador(EstadoJugador nuevoEstado)
    {
        EstadoJugador estadoAntiguo = estadoActualJugador;
        estadoActualJugador = nuevoEstado;
    }
}
