using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    private Color _color;

    public void Initialize()
    {
        _color = transform.GetChild(0).GetComponent<Renderer>().materials[0].color;
    }

    public Color ReturnColor()
    {
        return _color;
    }
    
}
