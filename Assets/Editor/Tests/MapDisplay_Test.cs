using UnityEngine;
using System.Collections;
using System;
using NUnit.Framework;

namespace Tests
{
    public class MapDisplay_Test : MonoBehaviour
    {
        MapDisplay mapDisplay = FindObjectOfType<MapDisplay>();

        [Test]
        public void TextureRender_Not_Null_Test()
        {
            Assert.IsNotNull(mapDisplay.textureRender);
        }

        [Test]
        public void MeshFilter_Not_Null_Test()
        {
            Assert.IsNotNull(mapDisplay.meshFilter);
        }

        [Test]
        public void MeshRenderer_Not_Null_Test()
        {
            Assert.IsNotNull(mapDisplay.meshRenderer);
        }
    }
}