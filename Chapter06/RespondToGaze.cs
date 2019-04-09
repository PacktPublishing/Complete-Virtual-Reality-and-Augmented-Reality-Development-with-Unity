using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespondToGaze : MonoBehaviour
{

    public bool highlight = true;
    public bool clicker = true;
    public string inputButton = "Fire1";
    public bool timedClick = true;
    public float delay = 2.0f;

    private Button button;
    private bool isSelected;
    private float timer;

    void Start()
    {
        button = GetComponent<Button>();
    }

    void Update()
    {
        isSelected = false;

        Transform camera = Camera.main.transform;
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) &&
            (hit.transform.parent != null) &&
            (hit.transform.parent.gameObject == gameObject))
        {
            isSelected = true;
        }


        if (isSelected)
        {
            if (highlight)
                button.Select();
            if (clicker && Input.GetButtonDown(inputButton))
                button.onClick.Invoke();
            if (timedClick)
            {
                timer += Time.deltaTime;
                if (timer >= delay)
                    button.onClick.Invoke();
            }
        }
        else
        {
            UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
            timer = 0f;
        }
    }
}
