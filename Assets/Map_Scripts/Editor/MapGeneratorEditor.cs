using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;
using System.IO;

[CustomEditor(typeof(MapGenerator))]
public class MapGeneratorEditor : Editor
{
    private MapGenerator mapGen;

    // Foldout states
    private bool showBasicSettings = true;
    private bool showNoiseSettings = true;
    private bool showBiomeSettings = true;
    private bool showPreview = true;
    private bool showStatistics = false;
    private bool showPresets = false;

    // Preview settings
    private int previewOctave = -1; // -1 means show all octaves
    private Texture2D previewTexture;
    private Texture2D noisePreviewTexture;
    private bool showNoisePreview = true;
    private bool showColorPreview = true;

    // Comparison
    private int comparisonSeed = 0;
    private Texture2D comparisonTexture;

    // Statistics
    private Dictionary<TerrainType, int> terrainCounts;
    private Dictionary<TerrainType, float> terrainPercentages;

    // Serialized properties
    private SerializedProperty widthProp;
    private SerializedProperty heightProp;
    private SerializedProperty noiseScaleProp;
    private SerializedProperty octavesProp;
    private SerializedProperty persistanceProp;
    private SerializedProperty lacunarityProp;
    private SerializedProperty seedProp;
    private SerializedProperty offsetProp;
    private SerializedProperty autoUpdateProp;
    private SerializedProperty useHexGridProp;
    private SerializedProperty generateMapOnStartProp;
    private SerializedProperty useThreadedGenerationProp;
    private SerializedProperty biomesProp;
}