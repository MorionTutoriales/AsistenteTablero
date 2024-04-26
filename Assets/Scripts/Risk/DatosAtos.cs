using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DatosAtos : MonoBehaviour
{
    public int unidadesAReclamar = 0;
    public TextMeshProUGUI tmpUnidades;

    public int puntos = 0;
    public TextMeshProUGUI tmpPuntos;

    public Contador contadorTerritorios;
    public Contador contadorFortalezas;
    public Contador contadorMisiones;
    public Contador contadorCartasTerrirorio;

    public ToggleZonas[] zonas;
    IEnumerator Start()
    {
		while (true)
		{
            yield return new WaitForSeconds (1);
            ActualizarUnidades();
            ActualizarPuntos();
		}
    }

    // Update is called once per frame
    void ActualizarUnidades()
    {
        int cuentaTerrenos = Mathf.RoundToInt((contadorTerritorios.valor - contadorTerritorios.valor % 3) / 3);
        cuentaTerrenos += (contadorTerritorios.valor % 3) > 0 ? 1 : 0;
        int score = Mathf.Max(3, cuentaTerrenos);
		for (int i = 0; i < zonas.Length; i++)
		{
            score += zonas[i].GetPuntos();
		}
        tmpUnidades.text = score.ToString("00");
    }
    void ActualizarPuntos()
    {
        int score = 0;
        for (int i = 0; i < zonas.Length; i++)
        {
            score += zonas[i].GetPuntos();
        }
        score += contadorTerritorios.valor;
        score += 2 * contadorFortalezas.valor;
        score += contadorMisiones.valor;
        score += contadorCartasTerrirorio.valor;
        tmpPuntos.text = score.ToString("00");
    }
}
