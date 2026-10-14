using System;
using System.Collections.Generic;
using Selectica;

[Serializable]
public class Cell
{
    public CellIndex index;
    public List<string> entitiesIds;

    public Cell(CellIndex index)
    {
        this.index = index;
    }
}