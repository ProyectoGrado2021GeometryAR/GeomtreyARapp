<?php
$servername = "localhost";
$username = "id17469917_proyectogar";
$password = "pN&x|8E=qkOyM?}@";
$dbname = "id17469917_projectdegree";
//variables del usuario reciben mediante metodo post la informacion //enviada de la aplicacion
$createIdTeacher=$_POST['createIdTeacher'];
$updateDegreeTeacher=$_POST['updateDegreeTeacher'];

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error); 
}
echo"conexion exitosa--";

//UPDATE grado set DocenteIdDocente =1 WHERE IdGrado =
$sql3 = "UPDATE grado set DocenteIdDocente ='$createIdTeacher' WHERE IdGrado ='$updateDegreeTeacher'";

if ($conn->query($sql3) === TRUE) {
  echo "actualizacion grados";
} else {
  echo "Error: " . $sql . "<br>" . $conn->error;

}
$conn->close();
?>