using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LinUtils;

public class GameState : MonoBehaviour
{
    [SerializeField] 
    private string state = "normal";

    public GameObject bag;

    void Awake()
    {
        bag = utils.FindInActiveObjectByName("Bag");
        // bag.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        // bag = GameObject.Find("Bag");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (state != "pause")
            {
                pause_game();
            }
            else
            {
                resume_game();
            }
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            switch_backpack();
        }
    }

    void pause_game()
    {
        Time.timeScale = 0;
        state = "pause";
    }

    void resume_game()
    {
        Time.timeScale = 1;
        state = "normal";
    }

    void switch_backpack()
    {
        bag.SetActive(!bag.activeInHierarchy);
    }
}
