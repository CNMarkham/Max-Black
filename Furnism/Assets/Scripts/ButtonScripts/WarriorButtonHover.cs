using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WarriorButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject WarriorHoverInfoText;
    public void OnPointerEnter(PointerEventData eventData)
    {
        WarriorHoverInfoText.SetActive(true);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        WarriorHoverInfoText.SetActive(false);
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
