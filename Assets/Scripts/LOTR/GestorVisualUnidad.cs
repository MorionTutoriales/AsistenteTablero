using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GestorVisualUnidad : MonoBehaviour
{
	public Unidad unidad;
	public RawImage imPerfil;
	public Text txtNombre;
	public Text txtKeywords;
	public Text ve,c,f,a,d,r,v;
	public GameObject padreEstadiHeroe;
	public Text po, vo, de;
	public Text txtDescripcion;
	public Text txtEquipo;
	public GestorVisualOpcion gestorOpcion;
	public Text txtReglasEspeciales;
	public Text txtHabilidades;


	public GameObject[] elementosVisibilizables;

	List<GestorVisualOpcion> gestores = new List<GestorVisualOpcion>();

	public void Inicializar(Unidad u)
	{
		unidad = u;
		Graficar();
	}

	public void Graficar()
	{
		txtKeywords.text = unidad.keywords;
		ve.text = unidad.estadisticas.velocidad.ToString();
		c.text = unidad.estadisticas.combateC.ToString() + "/" + unidad.estadisticas.combateD.ToString() + "+";
		f.text = unidad.estadisticas.fuerza.ToString();
		a.text = unidad.estadisticas.ataques.ToString();
		d.text = unidad.estadisticas.defensa.ToString();
		r.text = unidad.estadisticas.resistencia.ToString();
		v.text = unidad.estadisticas.valor.ToString();
		if (unidad.heroe.poder + unidad.heroe.voluntad + unidad.heroe.destino <= 0)
			padreEstadiHeroe.SetActive(false);
		po.text = unidad.heroe.poder.ToString();
		vo.text = unidad.heroe.voluntad.ToString();
		de.text = unidad.heroe.destino.ToString();


		txtDescripcion.text = unidad.descripcion;
		txtEquipo.text = unidad.equipo;

		for (int i = 0; i < unidad.opciones.Length; i++)
		{
			GestorVisualOpcion gop = Instantiate(gestorOpcion.gameObject, gestorOpcion.transform.parent).GetComponent<GestorVisualOpcion>();
			gop.Inicializar(unidad.opciones[i]);
			gestores.Add(gop);
		}

		gestorOpcion.gameObject.SetActive(false);

		for (int i = 0; i < unidad.reglasEspeciales.Length; i++)
		{
			Text gap = Instantiate(txtReglasEspeciales.gameObject, txtReglasEspeciales.transform.parent).GetComponent<Text>();
			gap.text = (unidad.reglasEspeciales[i]);
		}
		txtReglasEspeciales.gameObject.SetActive(false);

		for (int i = 0; i < unidad.habilidades.Length; i++)
		{
			Text gap = Instantiate(txtHabilidades.gameObject, txtHabilidades.transform.parent).GetComponent<Text>();
			gap.text = (unidad.habilidades[i]);
		}
		txtHabilidades.gameObject.SetActive(false);

		PonerNombre();

		StartCoroutine(DownloadImage(unidad.foto));
	}

	public void PonerNombre()
	{
		txtNombre.text = unidad.nombre + " (" + CalcularCosto() + ")";
	}

	public int CalcularCosto()
	{
		int co = unidad.puntos;
		for (int i = 0; i < unidad.opciones.Length; i++)
		{
			if (unidad.opciones[i].equipado)
			{
				co += unidad.opciones[i].costo;
			}
		}
		return (co);
	}


	public void CambiarEquipos()
	{
		for (int i = 0; i < unidad.opciones.Length; i++)
		{
			unidad.opciones[i].equipado = gestores[i].tgEquipado.isOn;
		}
		PonerNombre();
	}
	public void VisibleInvisible()
	{
		for (int i = 0; i < elementosVisibilizables.Length; i++)
		{
			elementosVisibilizables[i].SetActive(!elementosVisibilizables[i].activeSelf);
		}
	}

	IEnumerator DownloadImage(string MediaUrl)
	{
		UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
		yield return request.SendWebRequest();
		if (request.isNetworkError || request.isHttpError)
			Debug.Log(request.error);
		else
			imPerfil.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
	}
}
