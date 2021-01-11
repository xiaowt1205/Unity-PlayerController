using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    [SerializeField] float _rotationPower;
    [SerializeField] GameObject _followTransform;
    [SerializeField] Vector3 nextPosition;
    [SerializeField] Quaternion nextRotation;
    [SerializeField] float rotationLerp = 0.5f;
    [SerializeField] float speed;
    [SerializeField] float _lookX;
    [SerializeField] float _lookY;
    [SerializeField] float horizontal;
    [SerializeField] float vertical;

    public GameObject[] camera;

    void Start()
    {
        camera[0].gameObject.SetActive(true);
        camera[1].gameObject.SetActive(false);
    }

    void Update()
    {
        _lookX = Input.GetAxis("Mouse X");
        _lookY = Input.GetAxis("Mouse Y");
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        _followTransform.transform.rotation *= Quaternion.AngleAxis(_lookX * _rotationPower, Vector3.up);
        _followTransform.transform.rotation *= Quaternion.AngleAxis(_lookY * _rotationPower, Vector3.left * -1f);

        var angles = _followTransform.transform.localEulerAngles;
        angles.z = 0;

        var angle = _followTransform.transform.localEulerAngles.x;

        if (angle > 180 && angle < 340)
        {
            angles.x = 340;
        }
        else if (angle < 180 && angle > 40)
        {
            angles.x = 40;
        }

        _followTransform.transform.localEulerAngles = angles;


        nextRotation = Quaternion.Lerp(_followTransform.transform.rotation, nextRotation, Time.deltaTime * rotationLerp);

        float moveSpeed = speed / 100f;
        Vector3 position = (transform.forward * vertical * moveSpeed) + (transform.right * horizontal * moveSpeed);
        nextPosition = transform.position + position;
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, Time.deltaTime * speed);

        transform.rotation = Quaternion.Euler(0, _followTransform.transform.rotation.eulerAngles.y, 0);
        _followTransform.transform.localEulerAngles = new Vector3(angles.x, 0, 0);


        if (Input.GetMouseButton(1))
        {
            camera[0].gameObject.SetActive(false);
            camera[1].gameObject.SetActive(true);
        }
        else
        {
            camera[0].gameObject.SetActive(true);
            camera[1].gameObject.SetActive(false);
        }

    }
}
