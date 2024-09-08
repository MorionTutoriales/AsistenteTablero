using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestorVisualOpcion : MonoBehaviour
{
	public Text txtOpcion, txtCosto;
	public Toggle tgEquipado;
	public Opcion opcion;

	public void Inicializar(Opcion o)
	{
		opcion = o;
		txtOpcion.text = opcion.nombre;
		txtCosto.text = opcion.costo.ToString();
	}
}
