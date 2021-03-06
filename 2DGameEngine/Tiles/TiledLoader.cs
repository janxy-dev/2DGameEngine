﻿using _2DGameEngine.Entities;
using _2DGameEngine.Scenes;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace _2DGameEngine.Tiles
{
    public static class TiledLoader
    {
        public static Tileset LoadTileset(string path)
        {
            int tileWidth = 0;
            int tileHeight = 0;
            string source = "";
            using (StreamReader sr = new StreamReader(path))
            {
                XmlReader xr = XmlReader.Create(sr);
                while (xr.Read())
                {
                    if (xr.NodeType == XmlNodeType.Element)
                    {
                        switch (xr.Name)
                        {
                            case "tileset":
                                tileWidth = int.Parse(xr.GetAttribute(3));
                                tileHeight = int.Parse(xr.GetAttribute(4));
                                break;
                            case "image":
                                source = xr.GetAttribute(0);
                                source = source.Substring(source.LastIndexOf("Content/")+8).Split('.')[0];
                                break;
                        }
                    }
                }
            }
            return new Tileset(source, tileWidth, tileHeight);
        }
        public static List<Layer> LoadMap(string path)
        {
            int width, height, tileWidth, tileHeight;
            width = height = tileWidth = tileHeight = 0;
            List<Tileset> tilesets = new List<Tileset>();
            List<Layer> layers = new List<Layer>();
            int layerID = -1;
            using (StreamReader sr = new StreamReader(path))
            {
                XmlReader xr = XmlReader.Create(sr);
                while (xr.Read())
                {
                    if(xr.NodeType == XmlNodeType.Element)
                    {
                        switch (xr.Name)
                        {
                            case "map":
                                width = int.Parse(xr.GetAttribute(4));
                                height = int.Parse(xr.GetAttribute(5));
                                tileWidth = int.Parse(xr.GetAttribute(6));
                                tileHeight = int.Parse(xr.GetAttribute(7));
                                break;
                            case "tileset":
                                tilesets.Add(LoadTileset(xr.GetAttribute(1)));
                                break;
                            case "layer":
                                layers.Add(new TileLayer(width, height, tileWidth, tileHeight));
                                layerID++;
                                break;
                            case "objectgroup":
                                layers.Add(new Layer());
                                layerID++;
                                break;
                            case "object":
                                Entity entity = new Entity();
                                layers[layerID].AddEntity(entity);
                                int posx = (int)float.Parse(xr.GetAttribute(1));
                                int posy = (int)float.Parse(xr.GetAttribute(2));
                                int w = (int)float.Parse(xr.GetAttribute(3));
                                int h = (int)float.Parse(xr.GetAttribute(4));
                                entity.Transform.Position = new Point(posx, posy);
                                entity.Transform.Size = new Point(w, h);
                                entity.AddComponent(new BoxCollider());
                                break;
                            case "data":
                                string[] buffer = xr.ReadElementContentAsString().Replace("\n", "").Split(',');
                                for (int x = 0; x < width; x++)
                                {
                                    for (int y = 0; y < height; y++)
                                    {
                                        int index = int.Parse(buffer[x + y * width])-1;
                                        if(index < 0){
                                            ((TileLayer)layers[layerID]).AddTile(new Tile(new Point(x, y)));
                                            continue;
                                        }
                                        for(int i = 0; i<tilesets.Count; i++)
                                        {
                                            int a = 0;
                                            if (i > 0) a = tilesets[i - 1].TileCount;
                                            if (index-a < tilesets[i].TileCount)
                                            {
                                                ((TileLayer)layers[layerID]).AddTile(new Tile(new Point(x, y), tilesets[i], index-a));
                                                break;
                                            }
                                        }
                                    }
                                }
                                break;
                        }
                    }
                }
            }
            return layers;
        }
    }
}
