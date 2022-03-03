using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowGlassPortal : MonoBehaviour
{
    [SerializeField] Transform[] possiblePositions;

    void Update(){

    }
    private void OnCollisionStay(Collision collision) {

        if(collision.gameObject.CompareTag("PlayerGO"))
        {
            Debug.Log("Entro");
            int random =  Random.Range(0, possiblePositions.Length);
            transform.position = possiblePositions[random].position;
        }
    }

}
