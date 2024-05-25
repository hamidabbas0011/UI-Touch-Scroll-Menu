using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public GameObject[] menuPanels;
    public Scrollbar scrollbar;
    public float transitionSpeed = 10f;

    private int targetIndex = -1;
    private bool isTransitioning = false;
    private float[] positions;
    //private float scrollPos = 0;

    void Start()
    {
        // Initialize positions array based on the number of menu panels
        positions = new float[menuPanels.Length];
        float distance = 1f / (menuPanels.Length - 1f);
        for (int i = 0; i < positions.Length; i++)
        {
            positions[i] = distance * i;
        }
    }

    void Update()
    {
        // Smoothly transition to the target position if transitioning
        if (isTransitioning)
        {
            scrollbar.value = Mathf.Lerp(scrollbar.value, positions[targetIndex], Time.deltaTime * transitionSpeed);
            if (Mathf.Abs(scrollbar.value - positions[targetIndex]) < 0.001f)
            {
                scrollbar.value = positions[targetIndex];
                isTransitioning = false;
            }
        }
    }

    public void SwitchMenu(Button clickedButton)
    {
        int index = clickedButton.transform.GetSiblingIndex();
        if (index >= 0 && index < menuPanels.Length)
        {
            targetIndex = index;
            isTransitioning = true;
            
        }
    }
}
