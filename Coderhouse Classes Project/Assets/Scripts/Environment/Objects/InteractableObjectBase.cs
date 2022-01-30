using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectBase : MonoBehaviour
{
    [SerializeField] Sprite image;
    [SerializeField] string interactText;
    public virtual void OnInteract(){

    }
}

