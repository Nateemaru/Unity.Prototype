using _Scripts.SO;
using RayFire;
using UnityEngine;

namespace _Scripts.Game
{
    [RequireComponent(typeof(RayfireRigid))]
    public class RandomColorizer : MonoBehaviour
    {
        [SerializeField] private ColorMaterialsConfig _materialsConfig;
        private RayfireRigid _rayfireRigid;

        private void Start()
        {
            _rayfireRigid = GetComponent<RayfireRigid>();
            _rayfireRigid.materials.innerMaterial = 
                _materialsConfig.Materials[Random.Range(0, _materialsConfig.Materials.Length)];
        }
    }
}