 $filename = "img_001.jpg" #image filename
 $latLongString = "28.2539139N, 16.8374311W" #coordinates in expected format

 #divide string to latitudue and longitudue strings
 $latitudue_str,$longitude_str =  $latLongString.replace(" ","").split(',')

 #separate number part (without letter)
 $longitude = $longitude_str.Substring(0,$longitude_str.Length-1)
 $latitudue = $latitudue_str.Substring(0,$latitudue_str.Length-1)

 #separate direction char
 $N_or_S = $latitudue_str.Substring($latitudue_str.Length-1)
 $E_or_W = $longitude_str.Substring($longitude_str.Length-1)

 #run exiftool to edit coordinates
 exiftool.exe -GPSLongitudeRef="$E_or_W" -GPSLongitude="$longitude" -GPSLatitudeRef="$N_or_S" -GPSLatitude="$latitudue"  "$filename" -overwrite_original 