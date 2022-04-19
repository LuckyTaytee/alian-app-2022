﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Renderer))]
public class MaterialGradientModifier : MonoBehaviour
{
    Renderer _renderer;

    // public Color myColor;
    [SerializeField] Gradient gradient;

    float _gradientPosition = -1;
    public float gradientPosition
    {
        get { return _gradientPosition ; }
        set
        {
            if (_gradientPosition != value)
            {
                _gradientPosition = value;
                _renderer.material.color = gradient.Evaluate(gradientPosition);
            }
        }
    }

    // void SetGradientPosition (float position)
    // {
    //     if (position == gradientPosition)
    //         return;

    //     gradientPosition = position;
    //     _renderer.material.color = gradient.Evaluate(gradientPosition);        
    // }

    void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // gradientPosition = 0;
        // SetGradientPosition(0);
    }

    // Update is called once per frame
    // void Update()
    // {
    //     gradientPosition = Mathf.Sin (((Time.time)) * 0.5f) + 0.5f;
    //     // SetGradientPosition (Mathf.Sin (((Time.time)) * 0.5f) + 0.5f);
    // }
}
