# NavMeshUsingColliders
In Unity, baking a NavMesh typically relies on the presence of Mesh Renderers. However, some developers need to generate NavMesh based on colliders (including trigger colliders), especially in cases where objects do not have meshes or you want to base the navigation area on the actual physical boundaries (like colliders) rather than the visual meshes.

This script provides a solution to visualize Box Colliders in your scene by generating new box-shaped GameObjects that match the size, position, and orientation of the colliders. These new objects can then be used as a reference for baking NavMesh, ensuring that the NavMesh is generated based on the colliders rather than the Mesh Renderer.

The solution works even if the colliders are set as triggers, are inactive, or if a single object has multiple colliders attached. This script can help developers visualize and make use of colliders in the navigation system, ensuring precise NavMesh baking.

# How It Works:
Parent Object Creation: The script creates a parent GameObject called BoxCollidersParent, which will hold all the visualized box objects generated from the scene's BoxColliders.
Find All Box Colliders: It uses FindObjectsOfType<BoxCollider>(true) to locate all box colliders in the scene, even if the objects they are attached to are inactive or set as triggers.
Generate Cube Objects: For each BoxCollider found, the script:
Creates a new Cube primitive.
Sets the cube’s position and rotation to match the BoxCollider’s center and the associated transform’s rotation.
Adjusts the cube's scale to match the BoxCollider’s size, taking into account the object's overall scale in the scene.
Groups all generated cubes under the BoxCollidersParent GameObject.
Disables the BoxCollider component on the new cube object, making it a visual representation only.
Works with Triggers and Inactive Objects: Since the script looks for both active and inactive colliders, it visualizes every collider in the scene, ensuring that any physical boundaries—whether trigger colliders or regular colliders—are captured in the visualization.
# Usage:
Attach the script to any GameObject in your scene (preferably an empty GameObject for organization).
When the scene starts or the script runs, it will automatically generate box-shaped GameObjects corresponding to each BoxCollider in the scene.
The newly created cubes will act as visual representations of the colliders, giving you a clear idea of the physical boundaries in the scene that can be used for NavMesh generation.
All visualized cubes are parented under a single GameObject called BoxCollidersParent, which can be easily deleted later if no longer needed.
This solution is ideal for developers who are looking to bake NavMesh based on collider boundaries instead of mesh renderers, ensuring a more accurate navigation area, especially for complex environments where visual and physical boundaries differ.
