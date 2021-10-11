<?php
$servername = "localhost";
$username = "id17469917_proyectogar";
$password = "pN&x|8E=qkOyM?}@";
$dbname = "id17469917_projectdegree";
//variables del usuario


// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error); 
}


$sql = "SELECT IdGrado,NombreGrado FROM grado ";
$result = $conn->query($sql); 

if ($result->num_rows > 0) {
  // output data of each row

  while($row = $result->fetch_assoc()) {
  
   echo($row["IdGrado"]."|".$row["NombreGrado"]."|");
  

    
  }

  
} else {
  echo "-----------No se encuentran grados registrados";
}
echo"estono";
$conn->close();
?>