# Copilot Instructions for RimWorld Predator Hunt Alert Mod

Welcome to the development documentation for the Predator Hunt Alert mod for RimWorld. This file provides guidelines and instructions to help enhance your productivity with GitHub Copilot in this C# project.

## Mod Overview and Purpose

The "Predator Hunt Alert" mod is designed to provide players with timely and crucial alerts when predators in the game world are hunting. This enhancement aims to improve player awareness and decision-making, providing an additional layer of strategy and immersion in the gameplay.

## Key Features and Systems

- **Critical Alerts:** Notifications for when predators become a threat to the colony, allowing players to take preventative actions.
- **Manhunter Alerts:** Specific alerts when predators enter a manhunter state, showing the urgency in handling these threats.
- **Predator Specific Alerts:** Detailed alerts for when specific predators begin hunting.
- **Customization Options:** Settings that players can adjust to control the types of alerts they receive.

## Coding Patterns and Conventions

- **Class Structure:** All classes are organized within their respective files named after the class.
- **Access Modifiers:** Follow standard access modifier conventions (e.g., `public` for widely used classes and `internal` for classes used within the assembly).
- **Naming Conventions:** Use PascalCase for class and method names. Use camelCase for method parameters and local variables.
  
Example:

csharp
public class Alert_Manhunter : Alert_Critical
{
    // Implementation details...
}


## XML Integration

RimWorld heavily relies on XML for defining game data and mod configuration. Although no XML files are directly referenced in your summary, ensure any adjustments to XML are in line with:

- Properly formatted XML syntax.
- Correctly linked data through XML tag structures that relate to the C# code, especially when registering alerts and settings.

## Harmony Patching

Harmony is used in this mod to enhance or alter base game functionality seamlessly. For adding or updating Harmony patches, consider:

- **Adding Prefix and Postfix Methods:** Add prefix, postfix, or transpile patches to alter game behavior.
- **Robustness:** Ensure patched methods are well-tested, both in the context of mod alone and with likely mod sets.
- **Efficiency:** Avoid unnecessary computations in patches to minimize performance impacts.

Example patch setup:

csharp
[HarmonyPatch(typeof(SomeRimWorldClass), "SomeMethod")]
static class SomeRimWorldClass_SomeMethod_Patch
{
    static void Prefix()
    {
        // Code to execute before SomeMethod
    }
}


## Suggestions for Copilot

- **Code Completion:** Use Copilot to suggest patterns for similar alert systems by examining existing structure in classes like `Alert_Manhunter`.
- **Refactor Suggestions:** Allow Copilot to assist in refactoring methods to enhance readability or performance.
- **Integration Patterns:** Use suggestions for integrating new C# classes with XML data structures.
- **Debugging Aids:** Leverage Copilot for generating test cases or logs that help in identifying issues with alert logic.

By following these guidelines and using GitHub Copilot effectively, you can enhance the Predator Hunt Alert mod, ensuring it remains responsive and useful for RimWorld players. Enjoy your coding!
