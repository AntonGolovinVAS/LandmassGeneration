using UnityEditor;
using UnityEngine;

public class GenerateHeightMapEditorWindow : EditorWindow
{
    MapGenerator mapGenerator;
    float currentNoiseScale;
    int currentOctaves;
    float currentPersistance;
    int currentSeed;
    Vector2 currentOffSet;
    bool currentAutoUpdate;
    Texture2D currentHeightMap;
    float currentLacunarity;
    int LevelOfDetail;
    float currentMeshHeightMultiplier;
    AnimationCurve currentAnimationCurve;
    TerrainType[] currentRegions;

    DrawMode drawMode;
    private void Awake()
    {
        mapGenerator = FindObjectOfType<MapGenerator>();
        //mapGenerator.drawMode = MapGenerator.DrawMode.NoiseMap;
        currentNoiseScale = 0.0f;
        currentOctaves = 0;
        currentPersistance = 0.0f;
        currentSeed = 0;
        currentAutoUpdate = false;
        currentHeightMap = mapGenerator.texture2d;
        LevelOfDetail = 0;
        currentRegions = mapGenerator.regions;


    }

    private void OnGUI()
    {
        GUILayout.Space(10);
        drawMode = (DrawMode)EditorGUILayout.EnumPopup("Draw mod", drawMode);
        GUILayout.Space(10);
        LevelOfDetail = EditorGUILayout.IntSlider("Level of detail", LevelOfDetail, 0, 6);
        GUILayout.Space(10);
        currentNoiseScale = EditorGUILayout.FloatField("NoiseScale", currentNoiseScale);
        GUILayout.Space(10);
        currentOctaves = EditorGUILayout.IntField("Octaves", currentOctaves);
        GUILayout.Space(10);
        currentPersistance = EditorGUILayout.Slider("Persistance", currentPersistance, 0, 1);
        GUILayout.Space(10);
        currentLacunarity = EditorGUILayout.FloatField("Lacunarity", currentLacunarity);
        GUILayout.Space(10);
        currentSeed = EditorGUILayout.IntField("Seed", currentSeed);
        GUILayout.Space(10);
        currentOffSet = EditorGUILayout.Vector2Field("Off set: ", currentOffSet);
        GUILayout.Space(10);
        currentMeshHeightMultiplier = EditorGUILayout.FloatField("Mesh Height Multiplier", currentMeshHeightMultiplier);
        currentAutoUpdate = EditorGUILayout.Toggle("Auto Update", currentAutoUpdate);

        currentAnimationCurve = EditorGUILayout.CurveField("Curve", currentAnimationCurve);
        if (GUILayout.Button("Generate"))
        {
            mapGenerator.GenerateMap();
            mapGenerator.meshHeightCurve = currentAnimationCurve;
        }

        

        GUI.Label(new Rect (170,330, currentHeightMap.width + 500 , currentHeightMap.height + 500),currentHeightMap, "");

        GUILayout.Space(250);
        if (GUILayout.Button("Save Height Map"))
        {
            SaveTexture2D.SaveTextureAsPNG(currentHeightMap);
        }
        
    }
    
    private void OnInspectorUpdate()
    {
        mapGenerator.noiseScale = currentNoiseScale;
        mapGenerator.octaves = currentOctaves;
        mapGenerator.seed = currentSeed;
        mapGenerator.offSet = currentOffSet;
        mapGenerator.autoUpdate = currentAutoUpdate;
        mapGenerator.levelOfDetail = LevelOfDetail;
        mapGenerator.lacunarity = currentLacunarity;
        if (mapGenerator.autoUpdate)
        {
            mapGenerator.GenerateMap();
            mapGenerator.meshHeightCurve = currentAnimationCurve;
        }
        mapGenerator.persistance = currentPersistance;
        currentHeightMap = mapGenerator.texture2d;
        mapGenerator.drawMode = drawMode;
        mapGenerator.meshHeightMultiplier = currentMeshHeightMultiplier;
    }
}
