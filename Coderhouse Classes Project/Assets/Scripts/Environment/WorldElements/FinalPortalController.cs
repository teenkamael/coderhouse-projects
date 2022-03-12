using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPortalController : MonoBehaviour
{
    [SerializeField] WorldEvent portalEvent;


    void Awake(){
    }
    // Start is called before the first frame update
    void Start()
    {
        CustomEventActions.ControllerEventToExecute = ExecuteEvent;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ExecuteEvent(WorldEvent currentEvent)
    {
        
        Debug.Log($"Id de evento: { currentEvent.Id }");
        if (portalEvent.CanActionateEvent(currentEvent))
            if (currentEvent.Id == portalEvent.Id)
            {
                gameObject.SetActive(true);
            }
        Debug.Log("Event executed successfully");
    }
}
