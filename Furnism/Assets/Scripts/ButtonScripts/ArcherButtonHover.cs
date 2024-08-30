using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArcherButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject ArcherHoverInfoText;
    
    //Check if you are hovering over the Archer text if you are the Archer panel shows up
    public void OnPointerEnter(PointerEventData eventData)
    {
        ArcherHoverInfoText.SetActive(true);

    }

    //Checks if you have stopped hovering over the Archer text and deactivates the Archer panel
    public void OnPointerExit(PointerEventData eventData)
    {
        ArcherHoverInfoText.SetActive(false);
    }
}
