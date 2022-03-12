using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TurretEvents : MonoBehaviour
{
    [SerializeField] ProjectileType projectileNeededToReceive;

    private Task turretActivation;
    // Start is called before the first frame update
    void Awake()
    {
        GenerateTurretActivation();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {

        var colliderGameObject = collider.gameObject;
        var parentGameObject = colliderGameObject.transform.parent.gameObject;
        if (colliderGameObject.transform.parent.gameObject.CompareTag(CollisionTags.Player.ToString()))
        {
            BulletController controller = colliderGameObject.GetComponent<BulletController>();
            if (controller != null)
            {
                if (controller.GetProjectileType() == projectileNeededToReceive)
                {
                    turretActivation.IsCompleted = true;
                    Debug.Log($"Task {turretActivation.Name} completed");
                    CustomEventActions.TaskCompleted(turretActivation);
                }
            }
            Destroy(colliderGameObject);
        }
    }

    private void GenerateTurretActivation()
    {
        turretActivation = gameObject.GetComponent<Task>();
        var currentEvent = gameObject.transform.parent.GetComponent<WorldEvent>();
        
        turretActivation.SetTaskIds(Convert.ToInt32(projectileNeededToReceive), currentEvent.Id);
    }


}
