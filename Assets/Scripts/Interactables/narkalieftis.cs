using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class narkalieftis : Interactable
{
    [SerializeField]
    private GameObject door;
    private bool doorOpen;

    public static int interactedCubesCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Interact()
    {
        interactedCubesCount++;
        CheckInteractedCubes();
    }


    void CheckInteractedCubes()
    {
        if (interactedCubesCount >= 5)
        {
            interactedCubesCount = 0;
            doorOpen = !doorOpen;
            door.GetComponent<Animator>().SetBool("IsOpen", doorOpen);
        }
    }
}
