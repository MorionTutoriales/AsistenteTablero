using UnityEngine;
using UnityEngine.UI;

public class ToggleZonas : MonoBehaviour
{
    public Image tog;
    public int puntos;

    public int GetPuntos()
	{
		if (tog.enabled)
		{
			return puntos;
		}
		return 0;
	}
}
