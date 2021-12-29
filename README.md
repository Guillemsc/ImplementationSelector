# Welcome to Implementation Selector

[![contributions welcome](https://img.shields.io/badge/contributions-welcome-brightgreen.svg?style=flat)](https://github.com/Juce-Assets/Juce-ImplementationSelector/issues)
[![Twitter Follow](https://img.shields.io/badge/twitter-%406uillem-blue.svg?style=flat&label=Follow)](https://twitter.com/6uillem)
[![Discord](https://img.shields.io/discord/768962092296044614.svg)](https://discord.gg/dbG7zKA)
[![Release](https://img.shields.io/github/release/Juce-Assets/Juce-ImplementationSelector.svg)](https://github.com/Juce-Assets/Juce-ImplementationSelector/releases/latest)

**Welcome to [Implementation Selector](https://github.com/Juce-Assets/Juce-ImplementationSelector):** a small Unity editor extension that allows you to automatically select interface implementations directly on the editor. This is very useful for rapdily create configuration files for your applications.

## Installing
### - Via Github
Download the full repositories, and then place them under the Assets folder of your Unity project.

And that's all, with that you should be ready to go!

### - Via UPM
Add the following line to your [manifest.json](https://docs.unity3d.com/Manual/upm-manifestPrj.html).
```
"dependencies": {
   "com.juce.utils": "git+https://github.com/Juce-Assets/Juce-ImplementationSelector#1.0.0",
},
```

## Basic Usage
### SelectImplementationAttribute
You can turn an interface to a selectable interface using the attribute SelectImplementationAttribute.
You also need to use the SerializeReference Unity attribute.
```csharp
[SelectImplementation(typeof(IFood))]
[SerializeField, SerializeReference] private IFood food = default;
```
<img title="" src="https://github.com/Juce-Assets/Juce-ImplementationSelector/blob/main/Misc/HowTo1.png" alt="Logo" data-align="inline">

<img title="" src="https://github.com/Juce-Assets/Juce-ImplementationSelector/blob/main/Misc/HowTo4.png" alt="Logo" data-align="inline">

<img title="" src="https://github.com/Juce-Assets/Juce-ImplementationSelector/blob/main/Misc/HowTo5.png" alt="Logo" data-align="inline">

&nbsp;  

The classes that inherit from the base interface need to be marked as serializable with the System.Serializable attribute
```csharp
[System.Serializable]
public class AppleFood : IFood
{
    [SerializeField] private string appleName = default;
}
```

&nbsp; 

### SelectImplementationDefaultType
You can use the interface SelectImplementationDefaultType, on one of the classes that inherits from the base interface, to mark it as the default one that's going to appear on the editor the first time the user sees it.
```csharp
[System.Serializable]
[SelectImplementationDefaultType]
public class AppleFood : IFood
{
    [SerializeField] private string appleName = default;
}
```

&nbsp; 

### SelectImplementationTooltip
You can use the interface SelectImplementationTooltip, on one of the classes that inherits from the base interface, to show a tooltip when the user hovers this specific type with the mouse
```csharp
[System.Serializable]
[SelectImplementationTooltip("Apple tooltip")]
public class AppleFood : IFood
{
    [SerializeField] private string appleName = default;
}
```
<img title="" src="https://github.com/Juce-Assets/Juce-ImplementationSelector/blob/main/Misc/HowTo2.png" alt="Logo" data-align="inline">

&nbsp; 

### SelectImplementationCustomDisplayName
You can use the interface SelectImplementationCustomDisplayName, on one of the classes that inherits from the base interface, to show a specific name on the selection dropdown.
```csharp
[System.Serializable]
[SelectImplementationCustomDisplayName("Custom Apple display")]
public class AppleFood : IFood
{
    [SerializeField] private string appleName = default;
}
```
<img title="" src="https://github.com/Juce-Assets/Juce-ImplementationSelector/blob/main/Misc/HowTo3.png" alt="Logo" data-align="inline">
