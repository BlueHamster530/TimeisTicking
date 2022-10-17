using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class SelectNode : MonoBehaviour
{
    public UnityEvent myEvent;
    public void SelectEvent()
    {
        myEvent.Invoke();
    }

}
