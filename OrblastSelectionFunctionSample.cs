//Orblast Selection Function -- Composed by Monosem
//Explaination of how this code section is utilized can be found in "JAN 2026 - Orblast selection, Hover system"
//This code is fragmented, in other words, it will not work on its own like this.

void OrblastSelectionController()
    {
        if (!Input.GetMouseButtonDown(0)) //Checks for Left Mouse Button clicks
        {
            return;
        } 
        else 
        {
            Ray globeToRay = cameraObject.ScreenPointToRay(Input.mousePosition); //Creates a ray pointing from the camera to the mousePos
            if (globeMesh.Raycast(globeToRay, out RaycastHit hit, 100f)) //Checks if this ray is hitting the globe, "100f" is the limit, otherwise the ray would just strech infinitely long
            {
                Vector2 uv = hit.textureCoord;
                int xPos = Mathf.Clamp((int)(uv.x * orblastColorCode.width), 0, orblastColorCode.width - 1); //Determines the X-Position. "uv.x" are UV coordinates ranging from 0-1 and orblastColorCode.width converts the uv into a valid pixel position on the X-axis of the image. Math.Clamp acts as a safety net, setting the minimum and maximum so we don't get a nasty error when the UV position accidentally goes out of bounds. 
                int yPos = Mathf.Clamp((int)(uv.y * orblastColorCode.height), 0, orblastColorCode.height - 1); //Same thing but with Y-Position and image height.
                Color32 resColorID = orblastColorCode.GetPixel(xPos, yPos); //Using the X & Y positon, a pixel is selected and its color extracted. Color32 is used because it stores byte integars with the range of 0-255.
                byte orblastID = resColorID.r; //Selects only the R value, everythign else (G, B & A) is ignored.

                OrblastInformationHandler orblast = database.ExtractID(orblastID); //It searches in the database of Orblasts and tries to find an orblast in the database that has a corresponding ID that matches to the R value
                if (orblast != null)
                {
                    Debug.Log("Selected: " + orblast.OrblastName); //If a match is found, the corresponing information(name - as of writing this) is printed into console log.
                }
            }
        }
    }

void OrblastHoverController()
    {
        Ray globeToRay = cameraObject.ScreenPointToRay(Input.mousePosition); //This version does not check for a mouse button click.
        if (!globeMesh.Raycast(globeToRay, out RaycastHit hit, 100f))//Checks if the ray hits the 3D globe
        {
            globeMat.SetFloat("_OrblastID", 0);//If the ray does not hit the globe, the OrblastID in the material will be set to 0.
            return;
        }
        Vector2 uv = hit.textureCoord;
        int xPos = Mathf.Clamp((int)(uv.x * orblastColorCode.width), 0, orblastColorCode.width - 1);
        int yPos = Mathf.Clamp((int)(uv.y * orblastColorCode.height), 0, orblastColorCode.height - 1);
        Color32 hoverCheck = orblastColorCode.GetPixel(xPos, yPos);
        byte orblastID = hoverCheck.r;

        if (orblastID == 0)//Checks if the R value is 0.
        {
            globeMat.SetFloat("_OrblastID", 0);//If it is 0, the OrblastID in the material will be set to 0.
            return;
        }
        OrblastInformationHandler orblast = database.ExtractID(orblastID);//Searches for a matching orblase
        if (orblast != null)
        {
            globeMat.SetFloat("_OrblastID", orblastID);//If a match is found, the OrblastID in the material will be set to the same value as the ID and the material will do the rest of the work.
        }
        else
        {
            globeMat.SetFloat("_OrblastID", 0);//If no match is found, the OrblastID in the material will be set to 0.
        }
    }
