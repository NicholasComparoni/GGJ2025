using System;
using Unity.AI.Navigation;
using UnityEngine;

[RequireComponent(typeof(NavMeshSurface))]
public class NavmeshComponent : MonoBehaviour
{
    private NavMeshSurface _surface;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _surface = GetComponent<NavMeshSurface>();
    }

    private void Start()
    {
        _surface.BuildNavMesh();
    }
}
