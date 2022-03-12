using System;
using UnityEngine;

public class Task : MonoBehaviour
{
    public int Id { get; private set; }

    public string EventId { get; private set; }
    public string Name;

    public string Description;

    public bool IsCompleted;

    public bool IsOptional;

    void Start(){
        if(Id == 0 || EventId == String.Empty){
            Debug.Log("Debe iniciar los valores Id y EventId con SetTaskIds para que esta tarea funcione");
        }
    }   

    public void SetTaskIds(int id, string eventId)
    {
        Id = id;
        EventId = eventId;
    }
}
