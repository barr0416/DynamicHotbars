using UnityEngine;

public class Hotbar : MonoBehaviour 
{
    /// <summary>
    /// Awake this instance.
    /// </summary>
    private void Awake()
    {
        //Go through each child of the parent and get the hotbar buttons
        foreach(var button in GetComponentsInChildren<HotbarButton>())
        {
            //Add a listener to each event
            button.OnButtonClicked += ButtonOnButtonClicked;
        }
    }

    /// <summary>
    /// Buttons the on button clicked.
    /// </summary>
    /// <param name="buttonNumber">Button number.</param>
    private void ButtonOnButtonClicked(int buttonNumber)
    {
        Debug.Log("Button " + buttonNumber + " was clicked.");

        //Input data here that you want to do
    }
}
