using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

    private Vector3 scaleModificator = new Vector3(0.5f, 0.5f, 0.5f);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider collider)
    {
        var player = collider.GetComponent<PlayerCollision>();
        if (player != null)
        {
            if (player.CanResize)
            {
                if (!player.IsResized)
                {
                    collider.transform.localScale += scaleModificator;
                    player.IsResized = true;
                }
                else
                {
                    collider.transform.localScale -= scaleModificator;
                    player.IsResized = false;
                }
                player.CanResize = false;
            }
            else
                player.CanResize = true;


        }
    }

}
