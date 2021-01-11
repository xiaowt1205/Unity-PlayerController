using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject _player;

    [SerializeField] GameObject _directionRot;

    void Start()
    {
        
    }

    void Update()
    {
        _directionRot.transform.localEulerAngles = new Vector3(gameObject.transform.eulerAngles.x * -1f,0,0);
        gameObject.transform.LookAt(_player.transform);
    }
}
