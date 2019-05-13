using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SaveTexture2D
{
    static int count = 0;
    public static void SaveTextureAsPNG(Texture2D _texture)
    {
        
        byte[] bytes = _texture.EncodeToPNG();
        var dirPath = Application.dataPath + "/../SaveTexture2D/";
        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }
        File.WriteAllBytes(dirPath + "Image"+ count.ToString() + ".png", bytes);
        count++;
    }
}
