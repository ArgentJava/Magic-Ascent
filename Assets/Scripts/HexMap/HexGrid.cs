using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Resources;

public class HexGrid : MonoBehaviour
{
    // -- Fields, Variables, and Events --------------------------------------------------------------------- //

    //TODO: Add properties for grid size, hex size, and hex prefab
    [field: SerializeField] public HexOrientation Orientation { get; private set; }
    [field: SerializeField] public int Width { get; private set; }
    [field: SerializeField] public int Height { get; private set; }
    [field: SerializeField] public float HexSize { get; private set; }

    [field: SerializeField] public int BatchSize { get; private set; }

    [SerializeField] private List<HexCell> cells = new List<HexCell>();
    private MapGenerator mapGenerator;

    private Task<List<HexCell>> hexGenerationTask;
    //TODO: Methods to get, change, add, and remove hexes
    private Vector3 gridOrigin;

    //Events linked to map loading info
    //The map info has been generated:
    public event System.Action OnMapInfoGenerated;
    //One of the batches has been successfully instantiated:
    public event System.Action<float> OnCellBatchGenerated;
    //All cell instantiation has been completed:
    public event System.Action OnCellInstancesGenerated;

    // -- End of Fields, Variables, and Events -------------------------------------------------------------- //
    //
    // -- Auto functions: Awake, Start, Update, ETC ----------------------------------------------------------------- //

    private void Awake()
    {
        gridOrigin = transform.position;
        mapGenerator = FindAnyObjectByType<MapGenerator>();
    }

    private void OnEnable()
    {
        if (mapGenerator != null)
        {
            mapGenerator.OnTerrainMapGenerated += SetHexCellTerrainTypes;
        }
    }

    private void OnDisable()
    {
        if (mapGenerator != null)
        {
            mapGenerator.OnTerrainMapGenerated -= SetHexCellTerrainTypes;
        }
        if (hexGenerationTask != null && hexGenerationTask.Status == TaskStatus.Running)
        {
            hexGenerationTask.Dispose();
        }
    }

    // -- End of Auto functions: Awake, Start, Update, ETC ---------------------------------------------------------- //
    //
    // -- Functions ------------------------------------------------------------------------------------------------- //

    private void SetHexCellTerrainTypes(TerrainType[,] terrainMap)
    {
        Debug.Log("Setting Hex Cell Terrain Types");
        ClearHexCells();
        hexGenerationTask = Task.Run(() => GenerateHexCellData(terrainMap));
        hexGenerationTask.ContinueWith(task =>
        {
            Debug.Log("Hex Cell Data Generated");
            cells = task.Result;
            MainThreadDispatcher.Instance.Enqueue(() => StartCoroutine(InstantiateCells(cells)));
        });
    }

    private void ClearHexCells()
    {
        for (int i = 0; i < cells.Count; i++)
        {
            cells[i].ClearTerrain();
        }
        cells.Clear();
    }

    public List<HexCell> GenerateHexCellData(TerrainType[,] terrainMap)
    {
        System.Random rng = new System.Random();
        List<HexCell> hexCells = new List<HexCell>();

        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                int flippedX = Width - x - 1;
                int flippedY = Height - y - 1;

                //Vector3 centrePosition = HexMetrics.Center(HexSize, x, -y, Orientation) + gridOrigin;
                HexCell cell = new HexCell();
                cell.SetCoordinates(new Vector2(x, y), Orientation);
                cell.Grid = this;
                cell.HexSize = HexSize;
                cell.SetTerrainType(terrainMap[flippedX, flippedY]);
                hexCells.Add(cell);
            }
        }
        return hexCells;
    }

    // -- End of Functions ------------------------------------------------------------------------------------------ //
    //
    // -- Enumerators ------------------------------------------------------------------------------------------------//

    private IEnumerator InstantiateCells(List<HexCell> hexCells)
    {
        int batchCount = 0;
        int totalBatches = Mathf.CeilToInt(cells.Count / BatchSize);
        for (int i = 0; i < cells.Count; i++)
        {
            cells[i].CreateTerrain();
            if (i % BatchSize == 0)
            {
                batchCount++;
                OnCellBatchGenerated?.Invoke((float)batchCount / totalBatches);
                yield return null;
            }
        }
        OnCellInstancesGenerated?.Invoke();
    }

    // -- End of Enumerators -----------------------------------------------------------------------------------------//

    private void OnDrawGizmos()
    {
        for(int z = 0; z < Height; z++)
        {
            for (int x = 0; x < Width; x++)
            {
                Vector3 centerPosition = HexMetrics.Center(HexSize, x, z, Orientation) + transform.position;
                for (int s = 0; s < HexMetrics.Corners(HexSize, Orientation).Length; s++)
                {
                    Gizmos.DrawLine(
                        centerPosition + HexMetrics.Corners(HexSize, Orientation)[s % 6],
                        centerPosition + HexMetrics.Corners(HexSize, Orientation)[(s + 1) % 6]
                        );
                }

            }
        }
    }

}

public enum HexOrientation
{
    FlatTop,
    PointyTop
}