using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TiempoDeJuego
{
    [SerializeField] private int anyo;
    public enum Estacion
    {
        Primavera,
        Verano,
        Otonyo,
        Invierno
    }

    public enum DiaDeLaSemana
    {
        Domingo,
        Lunes,
        Martes,
        Miercoles,
        Jueves,
        Viernes,
        Sabado
    }

    public Estacion estacionActual;

    [SerializeField] private int dia;
    [SerializeField] private int hora;
    [SerializeField] private int minuto;

    public int Anyo { get => anyo; set => anyo = value; }
    public int Dia { get => dia; set => dia = value; }
    public int Hora { get => hora; set => hora = value; }
    public int Minuto { get => minuto; set => minuto = value; }

    // Constructor general de la clase
    public TiempoDeJuego(int anyo, Estacion estacionActual, int dia, int hora, int minuto)
    {
        this.Anyo = anyo;
        this.estacionActual = estacionActual;
        this.Dia = dia;
        this.Hora = hora;
        this.Minuto = minuto;
    }

    // Constructor para crear una nueva instancia
    // de marca de tiempo a partir de una ya existente
    public TiempoDeJuego(TiempoDeJuego tiempo)
    {
        this.Anyo = tiempo.anyo;
        this.estacionActual = tiempo.estacionActual;
        this.Dia = tiempo.dia;
        this.Hora = tiempo.hora;
        this.Minuto = tiempo.minuto;
    }

    public void ActualizarReloj()
    {
        minuto++;

        // 60 minutos => 1 hora
        if (minuto >= 60)
        {
            minuto = 0;
            hora++;
        }

        // 24 horas => 1 d�a
        if (hora >= 24)
        {
            hora = 0;
            dia++;
        }

        // 28 d�as => cambio de estaci�n
        if (dia >= 28)
        {
            dia = 1;

            // Si es la �ltima estaci�n del a�o, suma un a�o y vuelve a la primera
            if (estacionActual == Estacion.Invierno)
            {
                estacionActual = Estacion.Primavera;
                anyo++;
            }
            else
            {
                estacionActual++;
            }
        }
    }

    public DiaDeLaSemana ObtenerDiaDeLaSemana()
    {
        // Convierte el tiempo total transcurrido a d�as
        int diasTranscurridos = AnyosADias(anyo) + EstacionADias(estacionActual) + dia;

        // Resto de d�as al dividir los d�as transcurridos entre 7 de la semana
        int indiceDia = diasTranscurridos % 7;

        // Transformas y devuelves el d�a exacto de la semana
        return (DiaDeLaSemana) indiceDia;
    }

    public static int HorasAMinuto(int horas)
    {
        return horas * 60;
    }

    public static int DiasAHora(int dias)
    {
        return dias * 24;
    }

    public static int EstacionADias(Estacion estacion)
    {
        return (int) estacion * 28;
    }

    public static int AnyosADias(int anyos)
    {
        return anyos * 4 * 28;
    }

    public static int CompararTiemposDeJuego(TiempoDeJuego tiempo1, TiempoDeJuego tiempo2)
    {
        int tiempo1Horas = DiasAHora(AnyosADias(tiempo1.anyo))
            + DiasAHora(EstacionADias(tiempo1.estacionActual))
            + DiasAHora(tiempo1.dia)
            + tiempo1.hora;

        int tiempo2Horas = DiasAHora(AnyosADias(tiempo2.anyo))
            + DiasAHora(EstacionADias(tiempo2.estacionActual))
            + DiasAHora(tiempo2.dia)
            + tiempo2.hora;

        int diferencia = tiempo2Horas - tiempo1Horas;

        return Mathf.Abs(diferencia);
    }
}
