using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    private Renderer _renderer;
    public bool IsSafeZone { get; private set; }

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        IsSafeZone = true;
        SetColor();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();

        if (player != null)
        {
            IsSafeZone = false;
            SetColor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();

        if (player != null)
        {
            IsSafeZone = true;
            SetColor();
        }
    }

    private void SetColor()
    {
        if (IsSafeZone)
            _renderer.material.color = new Color(0, 1, 0, 0.4f);
        else
            _renderer.material.color = new Color(1, 0, 0, 0.5f);
    }
}
