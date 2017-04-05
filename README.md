# Toolless version

An in-progress modification of the original to skip the export from tiled step and do everything in the Unity import process.

Also has some modifications to support non-stupid tiled lookup -- instead of every single tile getting its own object, there's a terrain grid and lookup table.

# Tiled2Unity

Tiled2Unity is made up of two parts:
- The [utility](tool/Tiled2Unity) that exports TMX files into Unity.
- The [Unity scripts](unity/Tiled2Unity) that import the output of the Tiled2Unity Utility.

