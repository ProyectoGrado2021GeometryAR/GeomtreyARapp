<?php
$servername = "localhost";
$username = "id17469917_proyectogar";
$password = "pN&x|8E=qkOyM?}@";
$dbname = "id17469917_projectdegree";
//variables del usuario reciben mediante metodo post la informacion //enviada de la aplicacion
$createIdStudent=$_POST['createIdStudent'];
$createNamesStudent=$_POST['createNamesStudent'];
$createLastNamesStudent=$_POST['createLastNamesStudent'];
$createEmailStudent=$_POST['createEmailStudent'];
$createPasswordStudent=$_POST['createPasswordStudent'];
$createStatus=$_POST['createStatus'];
$createDegree=$_POST['createDegree'];


// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error); 
}


$sql0 = "SELECT EmailEstudiante, IdEstudiante FROM estudiante WHERE EmailEstudiante = '".$createEmailStudent."'";
$result0 = $conn->query($sql0); 

$sql1 = "SELECT EmailEstudiante, IdEstudiante FROM estudiante WHERE  IdEstudiante ='$createIdStudent'";
$result1 = $conn->query($sql1); 

if ($result0->num_rows > 0) {
  //tell user that that name is already taken
  echo"error";
} else if ($result1->num_rows > 0) {
  //tell user that that name is already taken
  echo"error";
  
  
 

} else {


$sql2 = "SELECT IdGrado,NombreGrado FROM grado WHERE NombreGrado ='".$createDegree."'";
$result2 = $conn->query($sql2); 

if ($result2->num_rows > 0) {
  // output data of each row

  while($row = $result2->fetch_assoc()) {
  
  

   $sql3 = "INSERT INTO estudiante (IdEstudiante,GradoIdGrado,NombresEstudiante, ApellidosEstudiante,EmailEstudiante, ContrasenaEstudiante,EstadoEstudiante) VALUES ('$createIdStudent','".$row["IdGrado"]."','".$createNamesStudent."', '".$createLastNamesStudent."', '".$createEmailStudent."', '".$createPasswordStudent."','".$createStatus."')";


if ($conn->query($sql3) === TRUE) {
  echo "createStudent";
} else {
  echo ("errorDB");
}

      
  }
}




}
$conn->close();
?>