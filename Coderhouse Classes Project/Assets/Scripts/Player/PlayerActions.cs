using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] Animator playerAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shieldBlock();
    }

    private void shieldBlock(){
        if(Input.GetMouseButton(1))
        { 
            playerAnimator.SetBool("IsBlocking", true);
        }
        if(Input.GetMouseButtonUp(1))
        {
            playerAnimator.SetBool("IsBlocking", false);
        }
    }

}
