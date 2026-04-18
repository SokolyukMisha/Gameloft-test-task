using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteAlways]
public class TileGridGenerator : MonoBehaviour
{
    [Header("Grid")]
    [SerializeField] private GameObject tilePrefab;
    [Min(1)] [SerializeField] private int gridWidth = 10;
    [Min(1)] [SerializeField] private int gridHeight = 10;

    [Header("Placement")]
    [SerializeField] private bool centerGridAroundGenerator = true;

    private const float TileSpacing = 2f;

#if UNITY_EDITOR
    public void GenerateGridInEditor()
    {
        if (Application.isPlaying)
        {
            Debug.LogWarning("TileGridGenerator: generation is editor-only. Stop Play Mode first.", this);
            return;
        }

        if (tilePrefab == null)
        {
            Debug.LogWarning("TileGridGenerator: assign Tile Prefab first.", this);
            return;
        }

        ClearGridInEditor();

        Vector3 origin = transform.position;
        if (centerGridAroundGenerator)
        {
            float halfW = (gridWidth - 1) * TileSpacing * 0.5f;
            float halfH = (gridHeight - 1) * TileSpacing * 0.5f;
            origin -= new Vector3(halfW, 0f, halfH);
        }

        Undo.RegisterFullObjectHierarchyUndo(gameObject, "Generate Tile Grid");

        for (int z = 0; z < gridHeight; z++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                Vector3 spawnPos = origin + new Vector3(x * TileSpacing, 0f, z * TileSpacing);

                GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(tilePrefab, transform);
                if (instance == null)
                {
                    instance = Instantiate(tilePrefab, transform);
                }

                Undo.RegisterCreatedObjectUndo(instance, "Generate Tile");
                instance.name = $"Tile_{x}_{z}";
                instance.transform.position = spawnPos;
                instance.transform.rotation = transform.rotation;
            }
        }

        EditorUtility.SetDirty(gameObject);
        Debug.Log($"TileGridGenerator: generated {gridWidth * gridHeight} tiles.", this);
    }

    public void ClearGridInEditor()
    {
        if (Application.isPlaying)
            return;

        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            GameObject child = transform.GetChild(i).gameObject;
            Undo.DestroyObjectImmediate(child);
        }

        EditorUtility.SetDirty(gameObject);
    }
#endif
}
