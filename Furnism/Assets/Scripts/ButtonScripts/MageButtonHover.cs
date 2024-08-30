using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MageButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject MageHoverInfoText;

    //Check if you are hovering over the Mage text if you are the Mage panel shows up
    public void OnPointerEnter(PointerEventData eventData)
    {
        MageHoverInfoText.SetActive(true);

    }

    //Checks if you have stopped hovering over the Mage text and deactivates the Mage panel
    public void OnPointerExit(PointerEventData eventData)
    {
        MageHoverInfoText.SetActive(false);
    }
}
