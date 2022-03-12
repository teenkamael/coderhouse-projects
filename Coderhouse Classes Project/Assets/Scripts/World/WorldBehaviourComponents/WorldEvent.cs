using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class WorldEvent : MonoBehaviour
{
    public string Id;
    public List<Task> TasksToComplete;

    public WorldEvent EventCorrelated;

    public string Name;
    public string Description;


      void Start()
    {
    }
    public bool CanActionateEvent(WorldEvent eventToActive)
    {
        
        if (Id == eventToActive.Id)
        {
            return (eventToActive.TasksToComplete.Where(x => x.IsCompleted == true
                 && x.IsOptional == false).Count() == eventToActive.TasksToComplete.Count());
        }

        return false;
    }
}

