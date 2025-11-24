using UnityEngine;

public class Cell
{
    #region Properties
    public int Index { get; private set; }
    public Vector3 WorldPosition { get; private set; }
    public float Size { get; private set; }
    public bool IsSelected { get; private set; }
    public bool HasBuilding { get; private set; }
    #endregion

    #region  Constract
    public Cell(int index, Vector3 position, float size)
    {
        Index = index;
        WorldPosition = position;
        Size = size;
    }
    #endregion

    #region  PublicMethods
    public void Select()
    {
        IsSelected = true;
    }
    public void Deselect()
    {
        IsSelected = false;
    }
    
    public void Builded()
    {
        HasBuilding = true;
    }

    public void UnBuilded()
    {
        HasBuilding = false;
    }

    public void DebugDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(WorldPosition, new Vector3(Size * 0.95f, Size * 0.01f, Size * 0.95f));

        if (IsSelected == true)
        {
            Vector3 BorderPosition = WorldPosition;
            BorderPosition.y += 0.1f;
            Gizmos.color = Color.white;
            Gizmos.DrawWireCube(WorldPosition, new Vector3(Size * 1, Size * 0.03f, Size * 1f));
        }

    }

    #endregion
}
