using UnityEngine;
using System.Collections;
using NUnit.Framework;

namespace Tests
{
    public class Noise_Test: MonoBehaviour
    {
        [Test]
        public void IsNull_Test()
        {
            Assert.IsNull(null);
        }
    }
}

