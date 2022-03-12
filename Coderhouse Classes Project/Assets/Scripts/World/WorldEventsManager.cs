using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class WorldEventsManager : MonoBehaviour
{
    public static WorldEventsManager worldEventsManager;
    public bool dontDestroyOnLoad;

    public List<WorldEvent> worldEvents;
    private static List<WorldEvent> _worldEvents;
    private void Awake()
    {
        if (worldEventsManager == null)
        {
            _worldEvents = worldEvents;
            worldEventsManager = this;
            if (dontDestroyOnLoad)
            {
                DontDestroyOnLoad(gameObject);
            }
            else
                Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        CustomEventActions.TaskCompleted = CompleteTaskOnEvent;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void CompleteTaskOnEvent(Task taskToComplete){
        WorldEvent currentEvent = _worldEvents.Single(x => x.Id == taskToComplete.EventId);
        currentEvent.TasksToComplete.Single(x => x.Id == taskToComplete.Id).IsCompleted = true;

        CustomEventActions.ControllerEventToExecute(currentEvent);
    }
}
