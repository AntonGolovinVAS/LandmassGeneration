using UnityEngine;
using System.Collections;
using NUnit.Framework;

namespace Tests
{
    public class MapGenerator_Test : MonoBehaviour
    {
        MapGenerator mapGenerator = FindObjectOfType<MapGenerator>();

        [Test]
        public void Regions_Is_Not_Zero_Test()
        {
            Assert.NotZero(mapGenerator.regions.Length);
        }
    }
}