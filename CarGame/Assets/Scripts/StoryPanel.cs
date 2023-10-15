using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryPanel : MonoBehaviour
{
    private Animator storyAnimation;

    public int currentStoryIndex = 0;
    public GameObject[] Stories;

    private void Awake()
    {
        storyAnimation = GetComponent<Animator>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            storyAnimation.SetTrigger("endStory");
        }
    }
    public void chooseStory()
    {
        for (int i = 0; i < Stories.Length; i++)
        {
            if (i == currentStoryIndex)
            {
                Stories[i].SetActive(true);
            }
            else
            {
                Stories[i].SetActive(false);
            }
        }
    }
    public void closeStory()
    {
        gameObject.SetActive(false);
    }
}
