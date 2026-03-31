//Mapmode Switch Function -- Composed by Monosem
//Explaination of how this code section is utilized can be found in "MAR 2026 - Mapmode Prototype & Tooltip System"
//This code is fragmented, in other words, it will not work on its own like this.

public void mapmodeSwitch(int mapmodeIndex)
{
    globeMat.SetTexture("_MainTex", mapmodeEntries[mapmodeIndex].MapTexture);
    SelectedMode = (MapMode)mapmodeIndex;
    orblastMapMode = mapmodeEntries[mapmodeIndex].MapColorID;
}
