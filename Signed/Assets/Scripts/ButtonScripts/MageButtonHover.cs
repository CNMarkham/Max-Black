using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MageButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject MageHoverInfoText;
    public void OnPointerEnter(PointerEventData eventData)
    {
        MageHoverInfoText.SetActive(true);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        MageHoverInfoText.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

}
