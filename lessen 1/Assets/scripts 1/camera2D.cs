using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera2D : MonoBehaviour
{
    public Transform _gameObject;
    [Header("Camera position restrictions")]
    public float minY;
    public float maxY;
    public float minX;
    public float maxX;
    void UpdateCameraPosition()
    {
                
                transform.position = new Vector3(
                // Положение игрового объекта, за которым мы двигаемся
                Mathf.Clamp(_gameObject.position.x, minX, maxX),
                Mathf.Clamp(_gameObject.position.y, minY, maxY),
                // Положение камеры z должно оставать неизменным 
                transform.position.z // (если камеры куда-то проваливается, заменить на, например, -10)
              );
        
     
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void Update()
    {
        UpdateCameraPosition();
    }
}
