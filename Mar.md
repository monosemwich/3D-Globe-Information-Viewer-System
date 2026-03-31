## MAR 2026 - Mapmodes Prototype & Tooltip System

Greetings, this is the second entry of my journey on documenting a project of mine - a comprehensive map view system with the purpose of displaying the geography, political situation, demographical + economical information, and trade nodes for a fantasy world.

For some context, I enjoy grand strategy games, economic simulation, and resourse management games. Some of my favourites are Victoria 3, Stellaris & IXION.
So that's where my current project comes into play, a core part of my very own program where you can manage trade, and observe information.

Unfortunately, due to other personal matters I had to deal with such as exams and burnout, I was not able to get much work done, especially in February where my semesters were held. Hopefully this holiday in April can get me some room to continue my project further.

### FIrstly, let's talk about **Mapmodes**

Map Modes are features found in map-based programs or video games such as Europa Universalis 4, and Google Maps. They show the map in a different view, if we take a look at Google Maps at the bottom left corner, you'd see something like this:
<img width="406" height="103" alt="image" src="https://github.com/user-attachments/assets/bdca0e69-ffaf-43b5-8656-0f0483dfc9f8" />

They allow the user to swich over to different varients of the map, which show specific information to the user. Why is it done that way? Because it's user-friendly; application designers know that their application has many information but not everyone needs that information at the same time. Putting everything into one map will overwhelm the user along with cluttering and overshadowing map features that users actually want to see. Not only that, it's resource intensive; showing everything all at once use up hardware resources, and if the users don't even need 90% of it, it would be a waste of processing power,

### Now how do we make it?

On paper implementing such feature should be relatively simple; and that would be correct, at least for the visual part.

```globeMat.SetTexture("_MainTex", mapmodeEntries[mapmodeIndex].MapTexture);```

With just one line of code assigned under a function and said function is responding to a button, you get a system that changes the globe's texture to the desired texture you assigned.

However making it functional is harder by 100 folds; while making map modes I want to impliment a tooltip system to show unique information unique to each map mode:
- Orblast Names (Default/Orblast Map Mode)
- States Name (States Map Mode)
- Terrain depth region names based on topography, and lake names (Terrain Map Mode)

Thanks to online resources and guides by Code Monkey and Game Dev Guides, I was able to learn the basics behind tooltips and created a modified system that works with the current logic I use for Orblast hover systems to extract the information and sends it to the tooltip systems and give a result.

<img width="370" height="302" alt="image" src="https://github.com/user-attachments/assets/59a57ff2-d78c-474a-bf49-6b28aa939d33" />

Another thing I want to implement is to still be able to select and hover indicate the Orblasts while still in different map modes (which on its own shows information via tooltips).

As of writing this, I have made 3 map modes: The default map mode(or orblasts map mode), states map mode, and terrain map mode.

<img width="756" height="433" alt="image" src="https://github.com/user-attachments/assets/06772fad-389c-4b0a-ae9e-e051dcecd513" />

In my main script, I have created what's called Mapmode Entry which tracks on what mapmodes are available to use along with having its own respective button, map texture, and color-coded texture

Using the same logic I made we can let the raycast pick up the assigned color-coded map texture for the ID (oblast map mode picks up ID from R value ; states map mode picks up ID from G value ; terrain map mode picks up ID from B value).
Afterwards, the information handler logic compares the picked up value and compares it the database and picks the matching one and its name and sends it to the tooltip system.

<img width="442" height="833" alt="image" src="https://github.com/user-attachments/assets/d742a4bd-ed93-4f9c-8771-159d613cd73f" />

Now that we got our logic in place, we just have to create a function that switches between mapmodes:
- We use an enum class to differientiate between mapmodes because it's easy to swap and it allows us to use if statements to let the code know which logic system to use especially in the part where the raycast catches either the R, G, or B values to be used as ID.
- Another is the visual asthetics part which changes the globe's material texture.
- Lastly, the technical aspects part which changes the color-coded map texture

[Code sample of the function can be found here!](https://github.com/monosemwich/3D-Globe-Information-Viewer-System/blob/monosemwich-journal/MapmodeSwitchFunctionSample.cs)

## In the end our result is presented like this:

<img width="668" height="288" alt="image" src="https://github.com/user-attachments/assets/f30c2a3b-f4f9-4508-a53c-239a5d59a15b" />

In the states mapmode, the tooltip picks up the name of the state which contains two Orblasts: Navi, and Isletm; however, the orblast is still interactable and gets highlighted.

<img width="417" height="344" alt="image" src="https://github.com/user-attachments/assets/00fbc0e3-f87b-46a8-8208-b6fd7bcea9d0" />

Same goes here, in the terrain mapmode, the tooltip picks up geographical details while still making Orblasts interactable.

