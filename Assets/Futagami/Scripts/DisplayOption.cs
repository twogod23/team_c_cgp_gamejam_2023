using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayOption : MonoBehaviour
{
    [SerializeField] private GameObject optionPanel;
    [SerializeField] private List<GameObject> hideObjects;
    // Start is called before the first frame update
    void Start()
    {
        optionPanel.SetActive(false);
        foreach (var obj in hideObjects)
        {
            obj.SetActive(true);
        }
    }

    public void DisplayOptionPanel()
    {
        optionPanel.SetActive(true);
        if (hideObjects != null)
        {
            foreach (var obj in hideObjects)
            {
                obj.SetActive(false);
            }
        }
    }

    public void CloseOptionPanel()
    {
        optionPanel.SetActive(false);
        if (hideObjects != null)
        {
            foreach (var obj in hideObjects)
            {
                obj.SetActive(true);
            }
        }
    }
}
