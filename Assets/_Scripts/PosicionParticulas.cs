using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosicionParticulas : MonoBehaviour
{
    private Transform ps;
    public float multiplicador;

    private float velocidad;

    private void Awake()
    {
        ps = transform;
    }

    void Update()
    {
        velocidad = AudioSpectrum.amplitudeBuffer * multiplicador;

        ps.localPosition = new Vector3(0, 0, velocidad);
    }
}