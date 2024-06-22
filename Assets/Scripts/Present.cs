using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Present : MonoBehaviour
{
    private Color _color;
    
    public void Initialize()
    {
        _color = transform.GetChild(0).GetComponent<Renderer>().materials[1].color;
    }

    public Color ReturnColor()
    {
        return _color;
    }
}
