using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Xml.Linq;

namespace Tiled2Unity
{
    partial class ImportTiled2Unity
    {
        public void TsxImported(string tsxPath)
        {
            string tilesetName = tsxPath.Substring(tsxPath.LastIndexOf('/') + 1, tsxPath.Length - tsxPath.LastIndexOf(".tsx") + 1);
            string tilesetDirectory = tsxPath.Substring(0, tsxPath.LastIndexOf('/'));
            string prefabPath = tilesetDirectory + "/" + tilesetName + ".prefab";

            GameObject tilesetObject = new GameObject(tilesetName);
            tilesetObject.AddComponent<Tileset>();

            Tileset tileset = tilesetObject.GetComponent<Tileset>();
            tileset.Properties = new TilesetProperties();
            XDocument document = XDocument.Load(tsxPath);
            XElement tilesetXml = document.Element("tileset");

            foreach (XElement tileXml in tilesetXml.Descendants("tile"))
            {
                XElement propertiesXml = tileXml.Element("properties");
                if (propertiesXml != null)
                {
                    int id = int.Parse(tileXml.Attribute("id").Value);
                    List<TiledProperty> properties = new List<TiledProperty>();
                    tileset.Properties[id] = properties;
                    foreach (XElement propertyXml in propertiesXml.Descendants("property"))
                    {
                        TiledProperty property = new TiledProperty();
                        properties.Add(property);
                        property.Key = propertyXml.Attribute("name").Value;
                        property.Value = propertyXml.Attribute("value").Value;
                    }
                }
            }

            AssetDatabase.DeleteAsset(prefabPath);
            PrefabUtility.CreatePrefab(prefabPath, tilesetObject);
            GameObject.DestroyImmediate(tilesetObject);
        }
    }
}
