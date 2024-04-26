using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Contador : MonoBehaviour
{
    public string nombre;
    public int valor;
    public TextMeshProUGUI tmpGUI;
    public Color colorInfo = Color.white;
    public TextoZoomico notificacion;

    void Start()
    {
        valor = PlayerPrefs.GetInt(nombre, valor);
        tmpGUI.text = valor.ToString("00");
    }

    public void Sumar()
    {
        valor++;
        PlayerPrefs.SetInt(nombre, valor);
        tmpGUI.text = valor.ToString("00");
        Notificar("+1");
    }
    public void Restar()
    {
        valor--;
        PlayerPrefs.SetInt(nombre, valor);
        tmpGUI.text = valor.ToString("00");
        Notificar("-1");
    }
    public void Resetear()
    {
        valor=0;
        PlayerPrefs.SetInt(nombre, valor);
        tmpGUI.text = valor.ToString("00");
        Notificar("00");
    }

    void Notificar(string texto)
	{
		if (notificacion != null)
		{
            notificacion.colorActual = colorInfo;
            notificacion.Animar(texto);
		}
	}

}
