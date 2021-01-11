using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Locate : MonoBehaviour
{

    [SerializeField] float _speed;
    [SerializeField] Transform _direction;


    void Start()
    {
        
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal,0f,vertical);
        transform.Translate(movement * Time.deltaTime * _speed , _direction);
    }
}
