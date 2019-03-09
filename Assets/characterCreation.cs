using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterCreation : MonoBehaviour {

    private List<GameObject> models;
    private int selectionIndex = 1;
    void Start () {
        models = new List<GameObject>();
        foreach (Transform t in transform)
        {
            models.Add(t.gameObject);
            t.gameObject.SetActive(false);
        }
        models[selectionIndex].SetActive(true);
	}
	
    public void Select (int index)
    {
        if(index == selectionIndex)
        {
            return;
        }
        if(index < 0 || index >= models.Count)
        {
            return;
           
        }
        models[selectionIndex].SetActive(false);
        selectionIndex = index;
        models[selectionIndex].SetActive(true);
    }
	// Update is called once per frame
	void Update () {
       /* if (Input.GetKeyDown(KeyCode.PageUp))
            Select(1);
        else if (Input.GetKeyDown(KeyCode.PageDown))
            Select(0); */



	}
}
