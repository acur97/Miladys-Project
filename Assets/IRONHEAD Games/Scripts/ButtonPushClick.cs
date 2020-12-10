﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
public class ButtonPushClick : MonoBehaviour
{
    public int Bases;
    public int Objetos;
    public SonidosInicio Manager;
    public float MinLocalY = 0.25f;
    public float MaxLocalY = 0.55f;
  
    public bool isBeingTouched = false;
    public bool isClicked = false;

    public Material greenMat;


    public float smooth = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        // Start with button up top / popped up
        transform.localPosition = new Vector3(transform.localPosition.x, MaxLocalY, transform.localPosition.z);

    }

  

    private void Update()
    {
        Vector3 buttonDownPosition = new Vector3(transform.localPosition.x, MinLocalY, transform.localPosition.z);
        Vector3 buttonUpPosition = new Vector3(transform.localPosition.x, MaxLocalY, transform.localPosition.z);
        if (!isClicked)
        {
            if (!isBeingTouched && (transform.localPosition.y > MaxLocalY  || transform.localPosition.y < MaxLocalY))
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, buttonUpPosition, Time.deltaTime * smooth);
            }

            if (transform.localPosition.y < MinLocalY)
            {
                isClicked = true;               
                transform.localPosition = buttonDownPosition;
                OnButtonDown();
            }
        }
      
    }


    void OnButtonDown()
    {
        GetComponent<MeshRenderer>().material = greenMat;
        GetComponent<Collider>().isTrigger = true;
        Manager.ActivarSonidos(Objetos);
        Manager.StartCoroutine(Manager.ChangeSpeed(0f, 1f, 10f, Manager.combos[Bases].sonido));
    }


    private void OnTriggerEnter(Collider other)
    {
        if (isClicked)
        {
   
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.gameObject.tag != "BackButton")
        {
            isBeingTouched = true;
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.tag != "BackButton")
        {
            isBeingTouched = false;

        }
    }



}
