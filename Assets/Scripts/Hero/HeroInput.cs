using UnityEngine;

[RequireComponent(typeof(HeroMover))]
public class HeroInput : MonoBehaviour
{
    private HeroMover _heroMover;
    private Vector3 startPos = new Vector3();
    private Vector3 endPos = new Vector3();
    bool mouseIsClicked = false;

    private void Start() => _heroMover = GetComponent<HeroMover>();             

    private void Update() 
    {              
        if (Input.GetMouseButton(0) && mouseIsClicked == false)
        {            
            startPos = Input.mousePosition;            
            mouseIsClicked = true;
        }

        if (!Input.GetMouseButton(0) && mouseIsClicked == true)
        {
            endPos = Input.mousePosition;            
            mouseIsClicked = false;
            Move(startPos, endPos);            
        }  
    }

    private void Move(Vector3 startPos, Vector3 endPos)
    {
        if (Mathf.Abs(endPos.y - startPos.y) < 200f)
            return;

        if (endPos.y > startPos.y) _heroMover.MoveUp();
        else _heroMover.MoveDown();
    }
}
