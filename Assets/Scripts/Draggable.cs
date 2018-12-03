using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour {

    Vector3 mousePosition;

    [SerializeField]
    MouseActions mouseActions;

    public bool isAttached;
    SpriteSwitcher sswitcher;
   
    void Awake ()
    {
        // Not the best solution, upgrade if possible
        mouseActions = FindObjectOfType<MouseActions>();
        mousePosition = Vector3.zero;
        sswitcher = gameObject.GetComponent<SpriteSwitcher>();
    }


    void LateUpdate ()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
    }

    /*
    private void OnMouseUpAsButton()
    {
        mouseActions.Drop(gameObject);
        sswitcher.ChangeSprite("falling");
    }

    private void OnMouseDown()
    {
        if (mouseActions.AttachedObject == gameObject)
        {
            sswitcher.ChangeSprite("holded");
        }
    }
    */

    private void OnMouseDown()
    {
        isAttached = true;
    }


    private void OnMouseDrag()
    {
        if (isAttached)
        {
            transform.position = mousePosition;
            mouseActions.Attach(gameObject);
        }
        // vymazat    transform.position = mousePosition;
        // vymazat    mouseActions.Attach(gameObject);
    }
}
