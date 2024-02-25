using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatDirectionController : MonoBehaviour
{
    [SerializeField]
    float distance = 5.0F;


    Vector2 _position;

    private void Update()
    {
        transform.position = 
            Vector2.MoveTowards(transform.position, _position, distance * Time.deltaTime);
    }

    public void SetTarget(Transform target)
    {
        _position = target.position ;
    }
        
}
