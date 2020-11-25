using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidosInicio : MonoBehaviour
{
    private float speed;
    public AudioSource[] Sonidos;

    float SoundBegin = 2;
    bool Tr2 = true;
    bool Tr = true;
    bool Tr3 = true;
    bool Tr4 = true;
    bool Tr5 = true;
    bool Act = true;
    private void Update()
    {
        if (Tr)
        {
            if (SoundBegin > 0)
            {
                SoundBegin -= Time.deltaTime;
            }
            else
            {
                SoundBegin = 0;
                if(SoundBegin == 0 && Act == true)
                {
                    StartCoroutine(ChangeSpeed(0f, 0.7f, 15f, Sonidos[0]));
                    SoundBegin = -1;
                }
                Tr= false;
            }
        }

 
        if(Sonidos[0].volume == 0.7f && Tr2)
        {
            StartCoroutine(ChangeSpeed(0f, 1f, 5, Sonidos[1]));
            Tr2=false;
        }

        if (Sonidos[1].volume >= 0.5f && Tr3)
        {
            StartCoroutine(ChangeSpeed(0f, 1f, 5, Sonidos[2]));
            Tr3 = false;
        }

        if (Sonidos[2].volume >= 0.5f && Tr4)
        {
            StartCoroutine(ChangeSpeed(0f, 1f, 8, Sonidos[3]));
            Tr4 = false;
        }

        if (Sonidos[3].volume >= 0.5f && Tr5)
        {
            StartCoroutine(ChangeSpeed(0f, 0.7f, 8, Sonidos[4]));
            Tr5 = false;
        }
    }

    IEnumerator ChangeSpeed(float v_start, float v_end, float duration ,AudioSource _Sonidos)
    {
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            speed = Mathf.Lerp(v_start, v_end, elapsed / duration);
            elapsed += Time.deltaTime;
            _Sonidos.volume = speed;
            yield return null;
        }
        speed = v_end;
        _Sonidos.volume = speed;
    }

    public void BajarRadio()
    {
        StartCoroutine(ChangeSpeed(1, 0, 5, Sonidos[1]));
        if(Sonidos[1].volume <= 0.4) { Tr3 = false;  Tr2 = false; }
    }
}
