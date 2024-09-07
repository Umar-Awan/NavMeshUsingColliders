using Sirenix.OdinInspector;
using UnityEngine;

public class BoxColliderVisualizer : MonoBehaviour
{
    // Parent GameObject to hold all the generated boxes
    public GameObject boxParent;

    void Start()
    {
        
    }

    [Button("Generate Boxes")]
    public void GenerateBoxColliderObjects()
    {
        // Create a parent GameObject to hold all the generated box objects
        boxParent = new GameObject("BoxCollidersParent");

        // Find all BoxColliders in the scene, including inactive ones
        BoxCollider[] allBoxColliders = FindObjectsOfType<BoxCollider>(true);

        foreach (BoxCollider boxCollider in allBoxColliders)
        {
            GenerateBoxFromCollider(boxCollider);
        }
    }

    // This function generates a visual box object from a BoxCollider
    void GenerateBoxFromCollider(BoxCollider boxCollider)
    {
        // Create a new GameObject to represent the BoxCollider
        GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);

        // Set the new GameObject's transform to match the BoxCollider
        box.transform.position = boxCollider.transform.TransformPoint(boxCollider.center);
        box.transform.rotation = boxCollider.transform.rotation;
        box.transform.localScale = Vector3.Scale(boxCollider.size, boxCollider.transform.lossyScale);

        // Set the new box as a child of the parent object for easy deletion
        box.transform.parent = boxParent.transform;

        // Disable the BoxCollider on the new GameObject (since we just want the visual)
        Destroy(box.GetComponent<BoxCollider>());
    }
}
