using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAttack : MonoBehaviour
{
    [SerializeField] GameObject shootOrigin;
    [SerializeField] private int attackCooldown = 2;
    private float timeToAttack  = 0;

    private bool canAttack = false;
    [SerializeField] private BulletController bulletType;
    [SerializeField] private float detectionDistance = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canAttack){
            createRayCast();
        }
        else{
            timeToAttack += Time.deltaTime;
        }

        if(timeToAttack > attackCooldown){
            canAttack = true;
        }
    }

    private void createRayCast(){
        RaycastHit hit;
        if(Physics.Raycast(shootOrigin.transform.position, shootOrigin.transform.TransformDirection(Vector3.forward), out hit, detectionDistance)){
            if(hit.transform.CompareTag(CollisionTags.Player.ToString())){
                ShootPrefab();
                canAttack = false;
                timeToAttack = 0;
            }
        }
    }
    private void ShootPrefab(){
         Instantiate(bulletType, shootOrigin.transform.position, shootOrigin.transform.rotation, gameObject.transform);
    }
    

}
