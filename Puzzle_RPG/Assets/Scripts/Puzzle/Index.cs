﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Index
{
    public int x;
    public int y;
    
    public Index(int mx, int my)
    {
        x = mx;
        y = my;
    }

    public Index(Vector2 vector)
    {
        x = (int)vector.x;
        y = (int)vector.y;
    }

    public void add(Index i)
    {
        x += i.x;
        y += i.y;
    }

    public bool Equal(Index idx)
    {
        return (x == idx.x && y == idx.y);
    }

    public static Index Add(Index a, Index b)
    {
        return new Index(a.x + b.x, a.y + b.y);
    }

    public static Index Mult(Index a, int i)
    {
        return new Index(a.x * i, a.y * i);
    }

    public static Index right { get { return new Index(1, 0); } }
    public static Index left { get { return new Index(-1, 0); } }
    public static Index up { get { return new Index(0, -1); } }
    public static Index down { get { return new Index(0, 1); } }
}
