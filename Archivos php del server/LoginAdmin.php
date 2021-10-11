<?php
$servername = "localhost";
$username = "id17469917_proyectogar";
$password = "pN&x|8E=qkOyM?}@";
$dbname = "id17469917_projectdegree";
//variables del usuario
$loginEmail=$_POST['loginEmail'];
//$loginEmail="celozano@jdc.edu.co";
$loginPassword=$_POST['loginPassword'];
//$loginPassword="carlos12";
// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error); 
}


$sql = "SELECT ContrasenaDocente,Rango FROM docente WHERE EmailDocente = '".$loginEmail."'";
$result = $conn->query($sql); 

if ($result->num_rows > 0) {
  // output data of each row
  while($row = $result->fetch_assoc()) {
    if ($row["ContrasenaDocente"] == $loginPassword) {
      
     
      if ($row["Rango"] =="0") {
       echo "false";
      
     }
       
    } else{
      echo "----El correo electronico y la contraseña no coinciden";
    }
  }
  
} else {
  echo "----usuario no exites";
}
$conn->close();
?>