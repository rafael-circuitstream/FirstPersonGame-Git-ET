using TMPro;
using UnityEngine;

public class UIAimFeedback : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI interactionText;
    [SerializeField] private PlayerInteractorModule interactorModule;
    private void Start()
    {
        interactorModule.OnNewInteractionFound += DisplayInteractionText;
    }

    public void DisplayInteractionText(GameObject interaction)
    {
        if(interaction == null)
        {
            HideInteractionText();
        }
        else
        {
            interactionText.gameObject.SetActive(true);
            interactionText.text = "PRESS RMB TO INTERACT WITH " + interaction.name;
        }

    }

    public void HideInteractionText()
    {
        interactionText.gameObject.SetActive(false);
    }
}
