using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speedMovement = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         Move();
    }

    public void Move(){
        transform.position += speedMovement * Time.deltaTime * Vector3.forward;
    }
}
