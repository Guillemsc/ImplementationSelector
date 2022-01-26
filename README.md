# Welcome to Implementation Selector

[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://opensource.org/licenses/MIT)
[![contributions welcome](https://img.shields.io/badge/contributions-welcome-brightgreen.svg?style=flat)](https://github.com/Juce-Assets/Juce-ImplementationSelector/issues)
[![Twitter Follow](https://img.shields.io/badge/twitter-%406uillem-blue.svg?style=flat&label=Follow)](https://twitter.com/6uillem)
[![Discord](https://img.shields.io/discord/768962092296044614.svg)](https://discord.gg/dbG7zKA)
[![Release](https://img.shields.io/github/release/Juce-Assets/Juce-ImplementationSelector.svg)](https://github.com/Juce-Assets/Juce-ImplementationSelector/releases/latest)

**Welcome to [Implementation Selector](https://github.com/Juce-Assets/Juce-ImplementationSelector):** a small Unity editor extension that allows you to automatically select an interface/base class's implementations directly on the editor. This is very useful for rapdily create configuration files for your applications.

<img title="" src="https://github.com/Juce-Assets/Juce-ImplementationSelector/blob/main/Misc/HowTo4.png" alt="Logo" data-align="inline">

# Contents

- [Installing](https://github.com/Juce-Assets/Juce-ImplementationSelector#installing)
- [Basic Usage](https://github.com/Juce-Assets/Juce-ImplementationSelector#basic-usage)
- [Want to contribute?](https://github.com/Juce-Assets/Juce-ImplementationSelector#want-to-contribute)
- [Contributors](https://github.com/Juce-Assets/Juce-ImplementationSelector#contributors)

## Installing
### - Via Github
Download the full repositories, and then place it under the Assets folder of your Unity project.

And that's all, with that you should be ready to go!

### - Via UPM
Add the following line to your [manifest.json](https://docs.unity3d.com/Manual/upm-manifestPrj.html).
```
"dependencies": {
   "com.juce.implementationselector": "git+https://github.com/Juce-Assets/Juce-ImplementationSelector",
},
```

## Basic Usage
### - SelectImplementationAttribute
You can turn an interface/base class to a selectable one using the attribute SelectImplementationAttribute.
You also need to use the SerializeReference Unity attribute.
```csharp
[SelectImplementation(typeof(IFood))]
[SerializeField, SerializeReference] private IFood food = default;
```

<img title="" src="https://github.com/Juce-Assets/Juce-ImplementationSelector/blob/main/Misc/HowTo1.png" alt="Logo" data-align="inline">

<img title="" src="https://github.com/Juce-Assets/Juce-ImplementationSelector/blob/main/Misc/HowTo4.png" alt="Logo" data-align="inline">

<img title="" src="https://github.com/Juce-Assets/Juce-ImplementationSelector/blob/main/Misc/HowTo5.png" alt="Logo" data-align="inline">

&nbsp; 

It works with lists too!
```csharp
[SelectImplementation(typeof(IFood))]
[SerializeField, SerializeReference] private List<IFood> food = default;
```
<img title="" src="https://github.com/Juce-Assets/Juce-ImplementationSelector/blob/main/Misc/HowTo6.png" alt="Logo" data-align="inline">

&nbsp;  
SelectImplementation has two default values that can be changed: 
- DisplayLabel: determines if the variable name is shown on the inspector. It's enabled by default.
- ForceExpanded: determines if the properties of the class can be collapsed with a dropdown, or ar shown all the time. It's disabled by default.
```csharp
[SelectImplementation(typeof(IFood), displayLabel: true, forceExpanded: false)]
[SerializeField, SerializeReference] private IFood food = default;
```

&nbsp;  

The classes that inherit from the base one need to be marked as serializable with the System.Serializable attribute.
They also need to have the default constructor, or a public parameterless one.
```csharp
[System.Serializable]
public class AppleFood : IFood
{
    [SerializeField] private string appleName = default;
}
```

&nbsp; 

### - SelectImplementationTrimDisplayName
You can use the attribute SelectImplementationTrimDisplayName, on the base interface/class, to define a string that will always be trimmed from the name displayed of the classes that implement this interface.

For example, if you have a base interface named IFood, and classes that inherit from it, like AppleFood, GrapesFood, PizzaFood, by using the SelectImplementationTrimDisplayName("Food"), the class names will be desplayed as Apple, Grapes, Pizza.
```csharp
[SelectImplementationTrimDisplayName("Food")]
public interface IFood
{
   
}
```

&nbsp; 

### - SelectImplementationDefaultType
You can use the attribute SelectImplementationDefaultType, on one of the classes that inherits from the base interface/class, to mark it as the default one that's going to appear on the editor the first time the user sees it.
```csharp
[System.Serializable]
[SelectImplementationDefaultType]
public class AppleFood : IFood
{
    [SerializeField] private string appleName = default;
}
```

&nbsp; 

### - SelectImplementationTooltip
You can use the attribute SelectImplementationTooltip, on one of the classes that inherits from the base interface/class, to show a tooltip when the user hovers this specific type with the mouse
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

### - SelectImplementationCustomDisplayName
You can use the attribute SelectImplementationCustomDisplayName, on one of the classes that inherits from the base interface/class, to show a specific name on the selection dropdown.
```csharp
[System.Serializable]
[SelectImplementationCustomDisplayName("Custom Apple display")]
public class AppleFood : IFood
{
    [SerializeField] private string appleName = default;
}
```
<img title="" src="https://github.com/Juce-Assets/Juce-ImplementationSelector/blob/main/Misc/HowTo3.png" alt="Logo" data-align="inline">

&nbsp; 

We are always aiming to improve this tool. You can always leave suggestions on the [Issues](https://github.com/Juce-Assets/Juce-ImplementationSelector/issues).

## Want to contribute?

**Please follow these steps to get your work merged in.**

0. Clone the repo and make a new branch: `$ git checkout https://github.com/Juce-Assets/Juce-ImplementationSelector/tree/main -b [name_of_new_branch]`.

1. Add a feature, fix a bug, or refactor some code :)

2. Update `README.md` contributors, if necessary.

3. Open a Pull Request with a comprehensive description of changes.

### 

## Contributors

- Guillem SC - [@Guillemsc](https://github.com/Guillemsc)
- Balázs K - [@BallerJColt](https://github.com/BallerJColt)
