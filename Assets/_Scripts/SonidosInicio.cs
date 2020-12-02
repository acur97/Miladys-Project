using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidosInicio : MonoBehaviour
{
    private float speed;
    [System.Serializable]
    public class ComboSonidos
    {
        public AudioSource sonido;
        public ParticleSystem particulas;
    }
    public GameObject[] Interactuables;
    public ComboSonidos[] combos;
    public GameObject Tutorial;
    //public AudioSource[] Sonidos;

    float SoundBegin = 2;
    float Megatimer = 10;
    bool Tr2 = true;
    bool Tr = true;
    bool Tr3 = true;
    bool Tr4 = true;
    bool Tr5 = true;
    bool Act = true;
    bool Tr6 = true;
    bool flag;

    /*private void Awake()
    {
        for (int i = 0; i < combos.Length; i++)
        {
            if (combos[i].particulas != null)
            {
                combos[i].particulas.SetActive(false);
            }
        }
    }*/

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
                    StartCoroutine(ChangeSpeed(0f, 1f, 15f, combos[0].sonido));
                    SoundBegin = -1;
                }
                Tr= false;
            }
        }


        if (combos[0].sonido.volume >= 0.7f && Tr2)
        {
            if (combos[1].particulas != null)
            {
                combos[1].particulas.Play();
            }
            StartCoroutine(ChangeSpeed(0f, 1f, 5, combos[1].sonido));
            Tr2=false;
        }

        if (combos[1].sonido.volume >= 0.5f && Tr3)
        {
            if (combos[2].particulas != null)
            {
                combos[2].particulas.Play();
            }
            StartCoroutine(ChangeSpeed(0f, 1f, 5, combos[2].sonido));
            Tr3 = false;
        }

        if (combos[2].sonido.volume >= 0.5f && Tr4)
        {
            if (combos[3].particulas != null)
            {
                combos[3].particulas.Play();
            }
            StartCoroutine(ChangeSpeed(0f, 1f, 8, combos[3].sonido));
            Tr4 = false;
        }

        if (combos[3].sonido.volume >= 0.5f && Tr5)
        {
            if (combos[4].particulas != null)
            {
                combos[4].particulas.Play();
            }
            StartCoroutine(ChangeSpeed(0f, 0.7f, 8, combos[4].sonido));
            Tr5 = false;
        }


        if (combos[4].sonido.volume >= 0.5 && Tr6)
        {
            for (int i = 0; i <=4 ; i++)
            {
                Interactuables[i].SetActive(true);
            }
            Tr6 = false;
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
        StartCoroutine(ChangeSpeed(1, 0, 5, combos[1].sonido));
        if(combos[1].sonido.volume <= 0.4) { Tr3 = false;  Tr2 = false; }
    }

    public void BajarGeneral()
    {
        combos[0].sonido.volume -= 0.2f;
    }

    public void ActivarMegafono()
    {   
        if (flag)
        {
            if (Megatimer > 0)
            {
                Megatimer -= Time.deltaTime;
            }
            else
            {
                Megatimer = 0;
                if(Megatimer==0) Interactuables[5].SetActive(true);
            }
            flag = false;
        }
    }
}
