using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    private bool isResized = false;
    public bool IsResized { get { return isResized; } set { isResized = value; } }

    private bool canResize = true;
    public bool CanResize { get { return canResize; } set { canResize = value; } }
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(gameObject.name + " collide with " + collision.gameObject.name);
        
    }

}
