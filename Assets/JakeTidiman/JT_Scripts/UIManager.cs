using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Camera theCam;

    public GameObject[] theButtons;
    public int currentButton;

    public GameObject playButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGameButton()
    {
        theCam.GetComponent<Animator>().SetBool("StartGame", true);
    }

}
