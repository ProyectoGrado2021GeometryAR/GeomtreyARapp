<?php
$servername = "localhost";
$username = "id17469917_proyectogar";
$password = "pN&x|8E=qkOyM?}@";
$dbname = "id17469917_projectdegree";
//variables del usuario
$searchTeacherById=$_POST['searchTeacherById'];

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error); 
}


$sql ="SELECT IdDocente,NombresDocente,ApellidosDocente,EmailDocente from docente WHERE rango=1 and IdDocente='".$searchTeacherById."'"; 
$result = $conn->query($sql); 
if ($result->num_rows > 0) {
  // output data of each row

  while($row = $result->fetch_assoc()) {
  
   
   echo($row["IdDocente"]."|".$row["NombresDocente"]."|".$row["ApellidosDocente"]."|".$row["EmailDocente"]."|");
  

    
  }
echo("stop");
  
} else {
  echo "stop";
}

$conn->close();
?>