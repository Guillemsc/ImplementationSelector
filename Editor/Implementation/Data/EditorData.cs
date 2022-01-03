using System;
using System.Collections.Generic;
using UnityEngine;

namespace Juce.ImplementationSelector.Data
{
    public class EditorData 
    {
        public Type[] Types { get; set; }
        public Dictionary<string, int> TypeIndexMap { get; } = new Dictionary<string, int>();
        public GUIContent[] NamesGuiContent { get; set; }
    }
}