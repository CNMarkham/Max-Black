using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject PanelInfo;

    //If you cursors on it turn on that classes attack information for the player to see
    public void OnPointerEnter(PointerEventData eventData)
    {
        PanelInfo.SetActive(true);
    }


    //Checks if you have stopped hovering over the Warrior text and deactivates the Warrior panel
    public void OnPointerExit(PointerEventData eventData)
    {
        PanelInfo.SetActive(false);
    }
}
