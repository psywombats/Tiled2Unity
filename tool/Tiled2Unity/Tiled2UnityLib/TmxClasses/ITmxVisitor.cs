using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tiled2Unity
{
    // The object that does the visiting implements this interface
    public interface ITmxVisitor
    {
        void VisitMap(TmxMap map);
        void VisitGroupLayer(TmxGroupLayer groupLayer);
        void VisitTileLayer(TmxLayer tileLayer);
        void VisitObjectLayer(TmxObjectGroup groupLayer);
        void VisitObject(TmxObject obj);
    }

    // An object that is visited implements this interface
    public interface ITmxVisit
    {
        void Visit(ITmxVisitor visitor);
    }
}
