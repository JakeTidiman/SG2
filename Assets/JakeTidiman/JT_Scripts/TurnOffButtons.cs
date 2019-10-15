using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffButtons : MonoBehaviour
{
    private UIManager theMan;

    // Start is called before the first frame update
    void Start()
    {
        theMan = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideButton()
    {
        foreach (var item in theMan.theButtons)
        {
            item.GetComponent<Animator>().SetBool("Hide", true);
        }

        theMan.playButton.GetComponent<Animator>().SetBool("Start", true);
    }
}
