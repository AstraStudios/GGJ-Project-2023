using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowOnClick : MonoBehaviour
{
    // the script to generate plants
    PlantLSystem tree;
    BoxCollider2D boxCollider;

    private void ResizeColider()
    {
        // calculate the size of the tree
        Vector2 size;
        size.x = tree.maxX - tree.minX;
        size.y = tree.maxY - tree.minY;

        boxCollider.size = size;

        // get the offset
        Vector2 offset;
        offset.x = tree.minX + (size.x / 2);
        offset.y = tree.minY + (size.y / 2);

        boxCollider.offset = offset;
    }

    private void Start()
    {
        tree = gameObject.GetComponent<PlantLSystem>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();

        ResizeColider();
    }

    // make the tree bigger
    private void OnMouseDown()
    {
        tree.Generate(tree.currentRecusrionLevel + 1);

        ResizeColider();
    }
}
