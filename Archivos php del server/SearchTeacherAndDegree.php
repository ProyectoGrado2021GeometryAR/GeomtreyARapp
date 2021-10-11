<?php
$servername = "localhost";
$username = "id17469917_proyectogar";
$password = "pN&x|8E=qkOyM?}@";
$dbname = "id17469917_projectdegree";
//variables del usuario
$numbDocument=$_POST['numbDocument'];



// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error); 
}





$sql = "SELECT IdDocente,NombresDocente,ApellidosDocente,EmailDocente,IdGrado FROM docente,grado WHERE IdDocente=DocenteIdDocente and IdDocente='".$numbDocument."'and Rango=1";

$result = $conn->query($sql); 

if ($result->num_rows > 0) {
  // output data of each row
  while($row = $result->fetch_assoc()) {
     
  
      
    echo($row["IdDocente"]."|".$row["NombresDocente"]."|".$row["ApellidosDocente"]."|".$row["EmailDocente"]."|".$row["IdGrado"]."|");

      

    }
  echo("stop");
  
} else {
  
//UPDATE DocenteId 
$sql3 = "update docente set Active=0 where IdDocente='$numbDocument'";

if ($conn->query($sql3) === TRUE) {
  echo "Inactive";//docente inactivo
} else {
  echo "Error: " . $sql . "<br>" . $conn->error;

}
  
  
}
$conn->close();
?>