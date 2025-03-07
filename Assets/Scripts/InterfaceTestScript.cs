using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceTestScript : MonoBehaviour
{
    public Sprite trapeziumSprite;
    public Sprite circleSprite;
    public Sprite nonagonSprite;

    public Button trapeziumButton;
    public Button circleButton;
    public Button nonagonButton;

    void Start()
    {
        // Assign Button Click Events, create shapes on click
        trapeziumButton.onClick.AddListener(() => CreateTrapezium());
        circleButton.onClick.AddListener(() => CreateCircle());
        nonagonButton.onClick.AddListener(() => CreateNonagon());
    }

    void CreateTrapezium()
    {
        Trapezium trapezium = new Trapezium(10, 8, 5, 7, 6);
        CreateShape("Trapezium", trapeziumSprite, new Vector2(-5, 0), trapezium);
    }

    void CreateCircle()
    {
        Circle circle = new Circle(5);
        CreateShape("Circle", circleSprite, new Vector2(0, 0), circle);
    }

    void CreateNonagon()
    {
        Nonagon nonagon = new Nonagon(4);
        CreateShape("Nonagon", nonagonSprite, new Vector2(5, 0), nonagon);
    }

    void CreateShape(string name, Sprite sprite, Vector2 position, IShape shapeData)
    {
        GameObject shape = new GameObject(name);
        shape.transform.position = position;

        SpriteRenderer renderer = shape.AddComponent<SpriteRenderer>();
        renderer.sprite = sprite;

        // Add Collider2D for click detection
        shape.AddComponent<BoxCollider2D>();

        // Attach click handler and assign shape data
        ShapeClickHandler clickHandler = shape.AddComponent<ShapeClickHandler>();
        clickHandler.SetShapeData(shapeData);
    }
}

/// <summary>
/// Interface for shape classes
/// </summary>

public interface IShape
{
    float CalculateArea();
    float CalculatePerimeter();
}

public class Trapezium : IShape
{
    // Trapezium properties
    private float base1, base2, side1, side2, height;

    public Trapezium(float b1, float b2, float s1, float s2, float h)
    {
        base1 = b1;
        base2 = b2;
        side1 = s1;
        side2 = s2;
        height = h;
    }

    /// <summary>
    /// Calculate the area of the trapezium
    /// </summary>
    /// <returns></returns>

    public float CalculateArea()
    {
        return 0.5f * (base1 + base2) * height;
    }

    /// <summary>
    /// Calculate the perimeter of the trapezium
    /// </summary>
    /// <returns></returns>
    public float CalculatePerimeter()
    {
        return base1 + base2 + side1 + side2;
    }
}

/// <summary>
/// Circle class implementing IShape interface
/// Calculates the area and perimeter of a circle
/// </summary>

public class Circle : IShape
{
    private float radius;

    public Circle(float r)
    {
        radius = r;
    }

    public float CalculateArea()
    {
        return Mathf.PI * radius * radius;
    }

    public float CalculatePerimeter()
    {
        return 2 * Mathf.PI * radius;
    }
}

/// <summary>
/// Nonagon class implementing IShape interface
/// Calculates the area and perimeter of a nonagon
/// </summary>
public class Nonagon : IShape
{
    private float side;

    public Nonagon(float s)
    {
        side = s;
    }

    public float CalculateArea()
    {
        return 2.25f * side * side / Mathf.Tan(Mathf.PI / 9);
    }

    public float CalculatePerimeter()
    {
        return 9 * side;
    }
}
