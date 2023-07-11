using _Scripts.SO;
using RayFire;
using UnityEngine;

namespace _Scripts.Game.Colorizers
{
    public class RandomColorizer : MonoBehaviour
    {
        [SerializeField] private ColorMaterialsConfig _materialsConfig;
        private MeshRenderer _mesh;

        private void Start()
        {
            _mesh = GetComponent<MeshRenderer>();
            _mesh.material = _materialsConfig.Materials[Random.Range(0, _materialsConfig.Materials.Length)];
        }
    }
}