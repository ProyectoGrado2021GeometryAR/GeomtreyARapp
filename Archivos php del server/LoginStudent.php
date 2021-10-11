<?php
$servername = "localhost";
$username = "id17469917_proyectogar";
$password = "pN&x|8E=qkOyM?}@";
$dbname = "id17469917_projectdegree";
//variables del usuario
$loginEmail=$_POST['loginEmail'];
$loginPassword=$_POST['loginPassword'];

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error); 
}


$sql = "SELECT ContrasenaEstudiante,GradoIdGrado,IdEstudiante FROM estudiante WHERE EmailEstudiante = '".$loginEmail."'";
$result = $conn->query($sql); 

if ($result->num_rows > 0) {
  // output data of each row
  while($row = $result->fetch_assoc()) {
    if ($row["ContrasenaEstudiante"] == $loginPassword) {
      
    if ($row["GradoIdGrado"] =="4") {
       //echo "4";
       echo($row["GradoIdGrado"]."|".$row["IdEstudiante"]."|");
     }else {
      // echo "5";
      echo($row["GradoIdGrado"]."|".$row["IdEstudiante"]."|");
     }
      echo("stop");
    } else{
      
    }
  }
  
} else {
  echo "-----------usuario no exites";
}
$conn->close();
?>