<?php
$servername = "localhost";
$username = "id17469917_proyectogar";
$password = "pN&x|8E=qkOyM?}@";
$dbname = "id17469917_projectdegree";
//variables del usuario reciben mediante metodo post la informacion //enviada de la aplicacion
$editIdStudent=$_POST['editIdStudent'];
$editNamesStudent=$_POST['editNamesStudent'];
$editLastNameStudent=$_POST['editLastNameStudent'];
$editEmailStudent=$_POST['editEmailStudent'];
$editPasswordStudent=$_POST['editPasswordStudent'];
$editDegreeStudent=$_POST['editDegreeStudent'];


// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error); 
}
echo"conexion exitosa--";

//UPDATE grado set DocenteIdDocente =1 WHERE IdGrado =

$sql3="UPDATE estudiante set GradoIdGrado='$editDegreeStudent',NombresEstudiante='".$editNamesStudent."',ApellidosEstudiante='".$editLastNameStudent."',EmailEstudiante='".$editEmailStudent."',ContrasenaEstudiante='".$editPasswordStudent."' WHERE IdEstudiante ='$editIdStudent' ";


if ($conn->query($sql3) === TRUE) {
  echo "actualizacion docennte";
} else {
  echo "Error: " . $sql . "<br>" . $conn->error;

}
$conn->close();
?>