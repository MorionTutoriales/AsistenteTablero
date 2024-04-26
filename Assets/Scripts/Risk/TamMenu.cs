using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class TamMenu : MonoBehaviour
{
    RectTransform rt;
    public Vector2 tamaños;
    public bool visible;
    VerticalLayoutGroup grupo;

    void Start()
    {
        rt = GetComponent<RectTransform>();
        grupo = GetComponentInParent<VerticalLayoutGroup>();
    }

    public void CambiarVisible()
	{
        visible = !visible;
        Vector2 tams = rt.sizeDelta;

        if (visible)
		{
            tams.y = tamaños.y;
            rt.sizeDelta = tams;
		}
		else
        {
            tams.y = tamaños.x;
            rt.sizeDelta = tams;
        }
		if (grupo != null)
        {
            grupo.spacing = 0.1f;
            grupo.spacing = 0.2f;
        }
	}
}
