using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*/

/// <summary>
///
/// </summary>

public class ViewPoint : Singleton<ViewPoint>
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;


    private void Awake()
    {
        Camera cam = Camera.main;
        Vector2 bottomLeft = cam.ViewportToWorldPoint(new Vector3(0f, 0f));
        Vector2 topRight = cam.ViewportToWorldPoint(new Vector3(1f, 1f));



        minX = bottomLeft.x;
        maxX = topRight.x;
        minY = bottomLeft.y;
        maxY = topRight.y;
    }

    public Vector3 PlayerMoveablePosition(Vector3 playerPosition, float paddingX, float paddingY)
    {
        Vector3 position = Vector3.zero;

        position.x = Mathf.Clamp(playerPosition.x, minX + paddingX, maxX - paddingX);
        position.y = Mathf.Clamp(playerPosition.y, minY + paddingY, maxY - paddingY);

        return position;
    }

    public Vector2 PlayerMoveablePosition(float x, float y)
    {
        Vector3 position = Vector3.zero;
        if (x > maxX) position.x = maxX;
        if (x < minX) position.x = minX;
        if (y > maxX) position.y = maxY;
        if (y < minX) position.y = minY;
        return position;
    }
}
