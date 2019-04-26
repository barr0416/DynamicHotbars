using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HotbarButton : MonoBehaviour 
{
    //Event for button click
    public event Action<int> OnButtonClicked;

    //Values for the keycode, text, and key number
    private KeyCode newKeyCode;
    [SerializeField] private TMP_Text tmpText;
    private int keyNumber;

    /// <summary>
    /// Called on saves and compiles
    /// </summary>
    private void OnValidate()
    {
        //Set the key number to the correct one in the set by comparing to the siblings in the current parent
        keyNumber = transform.GetSiblingIndex() + 1;
        newKeyCode = KeyCode.Alpha0 + keyNumber;

        //Check for the component required for the text
        if(tmpText == null)
        {
            tmpText = GetComponentInChildren<TMP_Text>();
        }

        //Set the text to the correc value
        tmpText.SetText(keyNumber.ToString());

        //Change the name to represent what the button is now
        gameObject.name = "Hotbar Button " + keyNumber;
    }

    /// <summary>
    /// Awake this instance.
    /// </summary>
    private void Awake()
    {
        //Add the listener for button click
        GetComponent<Button>().onClick.AddListener(HandleClick);
    }

    /// <summary>
    /// Update this instance.
    /// </summary>
    private void Update()
    {
        //Check for key input and handle the click
        if(Input.GetKeyDown(newKeyCode))
        {
            this.HandleClick();
        }
    }

    /// <summary>
    /// Handles the click.
    /// </summary>
    private void HandleClick()
    {
        //Check for a null reference before attempting to invoke the event
        if (OnButtonClicked != null)
        {
            OnButtonClicked.Invoke(keyNumber);
        }
    }
}
