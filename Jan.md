## JAN 2026 - Orblast selection, Hover system

Greetings, this is the first entry of my journey on documenting a project of mine - a comprehensive map view system with the purpose of displaying the geography, political situation, demographical + economical information, and trade nodes for a fantasy world.

For some context, I enjoy grand strategy games, economic simulation, and resourse management games. Some of my favourites are Victoria 3, Stellaris & IXION

So that's where my current project comes into play, a core part of my very own program where you can manage trade, and observe information.
<img width="996" height="531" alt="image" src="https://github.com/user-attachments/assets/00eac8c0-1f14-4891-86ea-5be30dcf1727" />
I quickly made a flat map, separating the map into clickable Orblasts as buttons, however, I was not entirely satisified with the result. So I tried something new. I looked at Google Earth, and how it displays the map on a 3D globe. I thought it was really interesting and cool, so I decided to create that system in Unity. However, with no guidance and available resources, I'd have to research on the components and create it from scratch.

After weeks of work, trials and errors, seeking help in community forums, I had managed a working system.
<img width="995" height="552" alt="image" src="https://github.com/user-attachments/assets/031ed750-6a74-40bc-b5e1-dac7421c3cf0" />
The Orblast is highlighted when the mouse is hovering over it and upon clicking it (as of writing this) the correct name is outputted into console. 

<img width="293" height="44" alt="Screenshot 2026-02-05 184325" src="https://github.com/user-attachments/assets/76597c97-8301-4925-a956-e24ce0861b9d" />

## How the system works

This system utilizes two texture of one map, a normal map that is displayed for the user to see and another version of the map where each Orblasts are uniquely color-coded.

<img width="445" height="179" alt="image" src="https://github.com/user-attachments/assets/ed931949-8d92-400f-8ceb-c8da02160223" />

<img width="975" height="509" alt="image" src="https://github.com/user-attachments/assets/9e8933e9-86f0-4ce5-94c1-8962e973e94d" />

I've selected the **R** from **R**GB of the color coded map to be assigned as the ID of the Orblast, while the rest of the color values (G & B) are set at random for easier distinction.

*Example: Orblast A color: **255**, 58, 200 (RGB) - Orblast A's ID is **255***

A material is applied to a 3D sphere mesh using a shader graph. In the graph, there is *_MainTex, _OrblastColorCode, HoverStrength & OrblastID*.

- **_MainTex**: Where the main map is set for the viewer to look at.

- **_OrblastColorCode**: The color-coded version of the map is attached to here. (The image should not be exported in sRGB and the same option, along with any compression should be disabled in Inspector)

- **HoverStrength**: Sets the glow intensity of the orblast when highlighted (1 = The highlighted color is completely white, 0 = The color is transparent)

- **OrblastID**: ID of the orblast inputted into the material.


How the shader graph works can be explained through this diagram below:

<img width="1720" height="349" alt="image" src="https://github.com/user-attachments/assets/e9ab1bf9-48bb-4287-aae2-2139bb6f9642" />

We should get something like this

<img width="1519" height="328" alt="image" src="https://github.com/user-attachments/assets/2bfe776f-ee9d-4bb6-a4bc-b3a18bb55a7f" />

# Now we have a working shader and Orblast detection system. To utilize it, we would need a script. ***[A more detailed explaination of the code, along with the sample itself can be found here](https://github.com/monosemwich/3D-Globe-Information-Viewer-System/blob/monosemwich-journal/OrblastSelectionFunctionSample.cs)***


***Selection System***

1. A C# script is attached to the camera, when the left mouse button is clicked, the system shoots a Ray towards the 3D globe.
2. The ray determines the mouse position on the globe using ScreenPointToRay.
3. Using the uv texture coordinate at the collision location, the X-position and Y-position is determined with the help of Math.Clamp.
4. Using the mouse position, the color of the pixel is picked up. Only the R value is extracted and turned into an ID.
5. The ID is compared with a database (The database consists of a list of Orblast and its attached information and ID). If a match is found, the name of the matched Orblast is printed into the Console Log.

***Hover System***

The system works the same as the selection system. The only difference is that instead of printing the name into console log, The ID goes to the material of the globe and changes the value *_OrblastID* of the material to the ID via SetFloat.
