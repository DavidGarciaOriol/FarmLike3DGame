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
        Lunes,
        Martes,
        Miercoles,
        Jueves,
        Viernes,
        Sabado,
        Domingo
    }

    public Estacion estacionActual;

    [SerializeField] private int dia;
    [SerializeField] private int hora;
    [SerializeField] private int minuto;

    public int Anyo { get => anyo; set => anyo = value; }
    public int Dia { get => dia; set => dia = value; }
    public int Hora { get => hora; set => hora = value; }
    public int Minuto { get => minuto; set => minuto = value; }

    public TiempoDeJuego(int anyo, Estacion estacionActual, int dia, int hora, int minuto)
    {
        this.Anyo = anyo;
        this.estacionActual = estacionActual;
        this.Dia = dia;
        this.Hora = hora;
        this.Minuto = minuto;
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

        // 24 horas => 1 día
        if (hora >= 24)
        {
            hora = 0;
            dia++;
        }

        // 28 días => cambio de estación
        if (dia >= 28)
        {
            dia = 1;

            // Si es la última estación del año, suma un año y vuelve a la primera
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
        // Convierte el tiempo total transcurrido a días
        int diasTranscurridos = AnyosADias(anyo) + EstacionADias(estacionActual) + dia;

        // Resto de días al dividir los días transcurridos entre 7 de la semana
        int indiceDia = diasTranscurridos % 7;

        // Transformas y devuelves el día exacto de la semana
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
}
