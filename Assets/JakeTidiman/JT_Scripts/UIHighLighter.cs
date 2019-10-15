using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class UIHighLighter : MonoBehaviour, ISelectHandler, IPointerEnterHandler
{
    // When highlighted with mouse.
    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponent<Animator>().SetBool("IsHighlighted", true);
        Debug.Log("<color=red>Event:</color> Completed mouse highlight.");
    }

    public void OnPointerExit()
    {
        gameObject.GetComponent<Animator>().SetBool("IsHighlighted", false);
    }
    
    // When selected.
    public void OnSelect(BaseEventData eventData)
    {
        // Do something.
        Debug.Log("<color=red>Event:</color> Completed selection.");
    }
}
