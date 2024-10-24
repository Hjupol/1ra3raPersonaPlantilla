using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_player1st : MonoBehaviour
{
    [SerializeField]private float velocidad;
    [SerializeField]private float velocidadRotacion;
    [SerializeField]private CharacterController controller;
    [SerializeField]private Transform transformPersonaje;
    [SerializeField]private Camera camaraPersonaje;

    private Vector3 movimiento;
    private float rotacionX;

    private void MovimientoPersonaje()
    {
        float ejeX = Input.GetAxis("Horizontal");
        float ejeZ = Input.GetAxis("Vertical");

        movimiento = transform.right * ejeX + transform.forward * ejeZ;
        controller.SimpleMove(movimiento * velocidad);
    }

    private void MovimientoCamara()
    {
        float mouseY = Input.GetAxis("Mouse Y") * velocidadRotacion;
        float mouseX = Input.GetAxis("Mouse X") * velocidadRotacion;

        rotacionX -= mouseY;
        //Primera persona:
        //rotacionX = Mathf.Clamp(rotacionX, -90f, 90f);
        rotacionX = Mathf.Clamp(rotacionX, -10f, 20);

        camaraPersonaje.transform.localRotation = Quaternion.Euler(rotacionX, 0, 0);
        transformPersonaje.Rotate(Vector3.up * mouseX);

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimientoPersonaje();
        MovimientoCamara();
    }
}
