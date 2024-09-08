using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unidades : MonoBehaviour
{
	public DiccionarioUnidades[] diccionarioUnidades;
	public List<Unidad> unidades = new List<Unidad>();
	public GestorVisualUnidad gvu;

	[ContextMenu("Imprimir JSON")]
	public void Imprimir()
	{
		print(AJson());
	}

	private void Start()
	{
		gvu.Inicializar(diccionarioUnidades[0].unidades[2]);
	}

	public string AJson()
	{
		DiccionarioUnidades du = new DiccionarioUnidades();
		du.unidades = unidades;
		return JsonUtility.ToJson(du);
	}
}

[System.Serializable]
public class DiccionarioUnidades
{
	public string nombre;
	public List<Unidad> unidades = new List<Unidad>();
}
[System.Serializable]
public class Unidad
{
	public string nombre;
	public string foto;
	public int puntos;
	public string keywords;
	public Estadisticas estadisticas;
	public Heroes heroe;
	public string descripcion;
	public string equipo;
	public Opcion[] opciones;
	public string[] reglasEspeciales;
	public string[] habilidades;

}

[System.Serializable]
public class Estadisticas
{
	public int velocidad;
	public int combateC;
	public int combateD;
	public int fuerza;
	public int defensa;
	public int ataques;
	public int resistencia;
	public int valor;
}

[System.Serializable]
public class Heroes
{
	public int poder, voluntad, destino;
}

[System.Serializable]
public class Opcion
{
	public string nombre;
	public int costo;
	public bool equipado;
}