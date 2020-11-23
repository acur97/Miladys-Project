using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlVolumen : MonoBehaviour
{
    public GameObject Interactuable;
    private float speed;

    private void Update()
    {

        AudioSource A = Interactuable.GetComponentInChildren<AudioSource>();
        A.volume = speed;
    }

    IEnumerator ChangeSpeed(float v_start, float v_end, float duration)
    {
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            speed = Mathf.Lerp(v_start, v_end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        speed = v_end;
    }

    public void Empezar()
    {
        StartCoroutine(ChangeSpeed(1, 0, 5f));
    }

}
