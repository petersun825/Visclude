
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    public string tagToCheck;
    public UnityEvent toTrigger;
    public GameObject pairmentObject;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagToCheck))
        {
            // Check the active state and set it to the opposite
            bool isActive = pairmentObject.activeSelf;
         
            Debug.Log("activeself: " + pairmentObject.activeSelf);
            pairmentObject.SetActive(!isActive);
            Debug.Log("activeself: " + pairmentObject.activeSelf);

            // Optionally, invoke the UnityEvent
            toTrigger.Invoke();
        }
    }

    private void SetBackgroundColor(string hexColor)
    {
        Color color;
        if (ColorUtility.TryParseHtmlString(hexColor, out color))
        {
            Camera.main.backgroundColor = color;
        }
        else
        {
            Debug.LogError("Invalid color string: " + hexColor);
        }
    }
}
