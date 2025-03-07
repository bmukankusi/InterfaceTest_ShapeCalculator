using UnityEngine;

public class ShapeClickHandler : MonoBehaviour
{

    // Interface reference to store shape data
    private IShape shapeData;

    public void SetShapeData(IShape shape)
    {
        shapeData = shape;
    }

    // OnMouseDown is called when the user has pressed the mouse button while over the GUIElement or Collider
    private void OnMouseDown()
    {
        if (shapeData != null)
        {
            Debug.Log(gameObject.name + " Clicked!");
            Debug.Log("Area: " + shapeData.CalculateArea());
            Debug.Log("Perimeter: " + shapeData.CalculatePerimeter());
        }
    }
}
