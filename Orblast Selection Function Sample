//Orblast Selection Function -- Composed by Monosem
//Explaination of how this code section works can be found in "JAN 2026 - Orblast selection, Hover system, & Basic Mapmode changes"
//This code is not meant to be used; it is fragmented, in other words, it will not work on its own like this.

void OrblastSelectionController()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        } 
        else 
        {
            Ray globeToRay = cameraObject.ScreenPointToRay(Input.mousePosition);
            if (globeMesh.Raycast(globeToRay, out RaycastHit hit, 100f))
            {
                Vector2 uv = hit.textureCoord;
                int xPos = Mathf.Clamp((int)(uv.x * orblastColorCode.width), 0, orblastColorCode.width - 1);
                int yPos = Mathf.Clamp((int)(uv.y * orblastColorCode.height), 0, orblastColorCode.height - 1);
                Color32 resColorID = orblastColorCode.GetPixel(xPos, yPos);
                byte orblastID = resColorID.r;

                OrblastInformationHandler orblast = database.ExtractID(orblastID);
                if (orblast != null)
                {
                    Debug.Log("Selected: " + orblast.OrblastName);
                }
            }
        }
    }
