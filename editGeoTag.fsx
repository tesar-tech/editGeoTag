open System.Diagnostics

let changeGeotag (photoName:string, longLatString:string) =
        let longLatString_seq = longLatString.Replace(" ","").Split(',')
        let latitudue= Seq.head longLatString_seq
        let longitude = Seq.last longLatString_seq
        let argumentsString = " -GPSLongitudeRef=" + (Seq.last longitude).ToString() + " -GPSLongitude=\""+ longitude.Substring(0,longitude.Length-1) + "\" -GPSLatitudeRef=" + (Seq.last latitudue).ToString() + " -GPSLatitude=\"" + latitudue.Substring(0,latitudue.Length-1) + "\" " + photoName + " -overwrite_original" 
        //e. g.  -GPSLongitudeRef=W -GPSLongitude="16.8374311" -GPSLatitudeRef=N -GPSLatitude="28.2539139" IMG_123.jpg -overwrite_original
        let _processStartInfo =  
             ProcessStartInfo(
                FileName =  @"exiftool.exe",
                Arguments = argumentsString, 
                WorkingDirectory = __SOURCE_DIRECTORY__ ) // same folder as script folder
        let p = new Process(StartInfo = _processStartInfo)
        p.Start()
        


//IMG_123 is photo name without extension (.jpg)
//second parameter is string with longitude
changeGeotag ("img_001.jpg" , "28.2539139N, 16.8374311W")




