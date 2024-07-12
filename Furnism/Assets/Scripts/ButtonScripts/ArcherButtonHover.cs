using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArcherButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject ArcherHoverInfoText;
    public void OnPointerEnter(PointerEventData eventData)
    {
        ArcherHoverInfoText.SetActive(true);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ArcherHoverInfoText.SetActive(false);
    }


}
