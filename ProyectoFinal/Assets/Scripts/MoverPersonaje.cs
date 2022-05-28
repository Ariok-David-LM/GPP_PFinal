using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPersonaje : MonoBehaviour
{
    private Rigidbody rb;
    public float incrementoVelocidad = 1;
    public float fuerzaSalto = 1;
    private bool puedeSaltar = true;
    public Animator ani;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");
        bool saltar = Input.GetButton("Jump");
        Vector3 movimiento = new Vector3(movimientoH, 0, movimientoV);
        if (movimiento !=  Vector3.zero)
        {
            ani.SetBool("Caminar", true);
        } else
        {
            ani.SetBool("Caminar", false);
        }
        Vector3 salto = new Vector3(0, fuerzaSalto, 0);
        rb.transform.Translate(movimiento * incrementoVelocidad);
        if (saltar && puedeSaltar)
        {
            rb.AddForce(salto, ForceMode.Impulse);
            puedeSaltar = false;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        puedeSaltar = true;
    }
}
