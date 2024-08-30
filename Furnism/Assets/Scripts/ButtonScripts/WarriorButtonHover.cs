using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WarriorButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject WarriorHoverInfoText;

    //Check if you are hovering over the Warrior text if you are the Warrior panel shows up
    public void OnPointerEnter(PointerEventData eventData)
    {
        WarriorHoverInfoText.SetActive(true);

    }


    //Checks if you have stopped hovering over the Warrior text and deactivates the Warrior panel
    public void OnPointerExit(PointerEventData eventData)
    {
        WarriorHoverInfoText.SetActive(false);
    }
}
