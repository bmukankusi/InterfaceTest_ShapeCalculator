using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceTestScript : MonoBehaviour
{
    public Sprite trapeziumSprite;
    public Sprite circleSprite;
    public Sprite nonagonSprite;

    void Start()
    {
        TestTrapezium();
        TestCircle();
        TestNonagon();
    }

    void TestTrapezium()
    {
        Trapezium trapezium = new Trapezium(10, 8, 5, 7, 6);
        Debug.Log("Trapezium Area: " + trapezium.CalculateArea());
        Debug.Log("Trapezium Perimeter: " + trapezium.CalculatePerimeter());

        CreateShape("Trapezium", trapeziumSprite, new Vector2(-5, 0));
    }

    void TestCircle()
    {
        Circle circle = new Circle(5);
        Debug.Log("Circle Area: " + circle.CalculateArea());
        Debug.Log("Circle Perimeter: " + circle.CalculatePerimeter());

        CreateShape("Circle", circleSprite, new Vector2(0, 0));
    }

    void TestNonagon()
    {
        Nonagon nonagon = new Nonagon(4);
        Debug.Log("Nonagon Area: " + nonagon.CalculateArea());
        Debug.Log("Nonagon Perimeter: " + nonagon.CalculatePerimeter());

        CreateShape("Nonagon", nonagonSprite, new Vector2(5, 0));
    }

    void CreateShape(string name, Sprite sprite, Vector2 position)
    {
        GameObject shape = new GameObject(name);
        shape.transform.position = position;

        SpriteRenderer renderer = shape.AddComponent<SpriteRenderer>();
        renderer.sprite = sprite;
    }
}

public interface IShape
{
    float CalculateArea();
    float CalculatePerimeter();
}

public class Trapezium : IShape
{
    private float base1, base2, side1, side2, height;

    public Trapezium(float b1, float b2, float s1, float s2, float h)
    {
        base1 = b1;
        base2 = b2;
        side1 = s1;
        side2 = s2;
        height = h;
    }

    public float CalculateArea()
    {
        return 0.5f * (base1 + base2) * height;
    }

    public float CalculatePerimeter()
    {
        return base1 + base2 + side1 + side2;
    }
}

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
